using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Diagnostics;
using DataStructures;

namespace ResourceBasedSuccessGames
{
    [Serializable]
    public class SimpleGameTrivialSolver
    {
        SimpleGame theGame;

        /// <summary>
        /// [bankroll, stage]
        /// </summary>
        public double[,] probability;
        /// <summary>
        /// Decisions are 1-based. Decisions for the first action.
        /// </summary>
        public int[] decision;

        public double MaxError = 1.0;

        protected double[] get_probability(int curIteration)
        {
            return spaceTimeStruct.Get(curIteration).Item2;
        }
        
        public double GetProbability(int bankRoll, int curStage)
        {
            int maxBankroll = getEscapeBankroll(theGame.MaxStages - curStage);

            if (bankRoll > maxBankroll)
                bankRoll = maxBankroll;

            if (bankRoll < 0 || bankRoll > maxBankroll)
                throw new ArgumentException("Invalid bankroll.");
            if (curStage < 0 || curStage > theGame.MaxStages)
                throw new ArgumentException("Invalid stage of play.");

            return get_probability(theGame.MaxStages - curStage)[bankRoll];
        }

        public ISimpleGamble GetBestDecision(int bankRoll, int curStage)
        {
            int maxBankroll = getEscapeBankroll(theGame.MaxStages - curStage);

            if (bankRoll > maxBankroll)
                bankRoll = maxBankroll;

            if (bankRoll < 0 || bankRoll > maxBankroll)
                throw new ArgumentException("Invalid bankroll.");
            if (curStage < 0 || curStage > theGame.MaxStages)
                throw new ArgumentException("Invalid stage of play.");

            int bestDecisionIdx = 0;
            double bestProb = 0;
            GetBestChoice(theGame.MaxStages - curStage, curStage, bankRoll, get_probability(theGame.MaxStages - curStage),  
                out bestDecisionIdx, out bestProb);

            if (bestDecisionIdx > 0)
                return theGame.Gambles[bestDecisionIdx - 1];
            else
                return null;
        }

        public double Value
        {
            get
            {
                return get_probability(theGame.MaxStages)[theGame.StartingBankroll];
            }
        }
        
        protected ISpaceTimeTradeoffStructure<Tuple<int,double[]>> spaceTimeStruct;

        public SimpleGameTrivialSolver(SimpleGame game)
        {
            theGame = game;

            spaceTimeStruct = new SpaceTimeTradeoffStructure<Tuple<int, double[]>>((int)Math.Sqrt(theGame.MaxStages), theGame.MaxStages);

            probability = null;// new double[maxBankroll + 1, game.MaxStages + 1];
            decision = null;// new int[maxBankroll + 1];
        }

        public long TimeToSolveInMilliseconds;

        public void Solve()
        {
            Stopwatch sw1 = new Stopwatch();
            sw1.Start();
            //InitializeGoal();
            SolveGoal();
            sw1.Stop();
            TimeToSolveInMilliseconds = sw1.ElapsedMilliseconds;
        }

        protected double[] InitializeGoal()
        {
            int maxBankroll = getEscapeBankroll(0);
            double[] probability = new double[maxBankroll + 1];

            switch (theGame.Objective)
            {
                case SimpleGame.Objectives.Reachability:
                    probability[theGame.ObjectiveBankroll] = 1.0;
                    break;
                case SimpleGame.Objectives.Safety:
                    for (int curBankroll = theGame.ObjectiveBankroll + 1; curBankroll <= maxBankroll; curBankroll++)
                        probability[curBankroll] = 1.0;
                    break;
                default:
                    throw new NotSupportedException("Unsupported game objective.");
            }
            return probability;
        }

        protected void LegacyInitializeGoal()
        {
            switch (theGame.Objective)
            {
                case SimpleGame.Objectives.Reachability:
                    probability[theGame.ObjectiveBankroll, 0] = 1.0;
                    break;
                case SimpleGame.Objectives.Safety:
                    for (int curBankroll = theGame.ObjectiveBankroll + 1; curBankroll < theGame.EscapeBankroll; curBankroll++)
                        probability[curBankroll, 0] = 1.0;
                    break;
                default:
                    throw new NotSupportedException("Unsupported game objective.");
            }
        }


        protected int getEscapeBankroll(int curIteration)
        {
            if (theGame.DynamicEscapeBankroll == null)
                return theGame.EscapeBankroll;
            else
                return theGame.DynamicEscapeBankroll(theGame.MaxStages - curIteration);
        }

        public int onePercent;
        public event EventHandler<int> OnProgressMade;

        protected Tuple<int, double[]> Solve(Tuple<int, double[]> lastIterationTuple)
        {
            int lastIteration = lastIterationTuple.Item1;
            var lastIterationProb = lastIterationTuple.Item2;
            int curIteration = lastIteration + 1;

            int maxBankroll = getEscapeBankroll(curIteration);
            int oldmaxBankroll = getEscapeBankroll(curIteration - 1);
            double[] probability = new double[maxBankroll+1];
            int gameStage = theGame.MaxStages - curIteration;
            
            int curBankroll;
            double maxChange = 0.0;
            for (curBankroll = 1; curBankroll <= maxBankroll; curBankroll++)
            {
                int bestChoice;
                double bestProb;
                                
                GetBestChoice(curIteration, gameStage, curBankroll, lastIterationProb, out bestChoice, out bestProb);

                probability[curBankroll] = bestProb;
                if (probability[curBankroll] - (curBankroll < oldmaxBankroll ? lastIterationProb[curBankroll] : 1.0) > maxChange)
                    maxChange = probability[curBankroll] - (curBankroll < oldmaxBankroll ? lastIterationProb[curBankroll] : 1.0);
            }
            MaxError = maxChange;

            Tuple<int, double[]> result = new Tuple<int, double[]>(curIteration, probability);

            if (OnProgressMade != null)
                if ((curIteration % onePercent) == 0)
                {
                    OnProgressMade(this, curIteration / onePercent);
                }

            return result;
        }

        protected double SolveGoal()
        {
            theGame.Gambles.Sort(new Comparison<ISimpleGamble>((left, right) => left.EntryFee < right.EntryFee ? -1 : 1));
            onePercent = (theGame.MaxStages + 50) / 100;
            spaceTimeStruct.nextValue = new Func<Tuple<int, double[]>, Tuple<int, double[]>>(Solve);
            spaceTimeStruct.Compute(new Tuple<int,double[]>(0, InitializeGoal()));
            return Value; //Make sure the last row is in cache.
        }

        protected void LegacySolveGoal()
        {
            theGame.Gambles.Sort(new Comparison<ISimpleGamble>( (left, right) => left.EntryFee < right.EntryFee ? -1:1));

            onePercent = (theGame.MaxStages + 50) / 100;

            int curIteration; //Starting from the LAST one: = maximum number of gambles left.
            for (curIteration = 1; curIteration <= theGame.MaxStages; curIteration++)
            {
                int gameStage = theGame.MaxStages - curIteration;
                int curBankroll;
                double maxChange = 0.0;
                for (curBankroll = 1; curBankroll < theGame.EscapeBankroll; curBankroll++)
                {
                    int bestChoice;
                    double bestProb;
                    GetBestChoice(curIteration, gameStage, curBankroll, out bestChoice, out bestProb);

                    probability[curBankroll, curIteration] = bestProb;
                    if (probability[curBankroll, curIteration] - probability[curBankroll, curIteration - 1] > maxChange)
                        maxChange = probability[curBankroll, curIteration] - probability[curBankroll, curIteration - 1];

                    decision[curBankroll] = bestChoice;
                }
                MaxError = maxChange;

                if(OnProgressMade != null)
                    if ((curIteration % onePercent) == 0)
                    {
                        OnProgressMade(this, curIteration / onePercent);
                    }
            }
        }

        private void GetBestChoice(int curIteration, int gameStage, int curBankroll, out int bestChoice, out double bestProb)
        {
            GetBestChoice(curIteration, gameStage, curBankroll, get_probability(curIteration - 1), out bestChoice, out bestProb);
        }

        private void GetBestChoice(int curIteration, int gameStage, int curBankroll, double[] lastIterProb, out int bestChoice, out double bestProb)
        {
            bestChoice = -1;
            bestProb = 0.0;

            ISimpleGamble forcedGamble = null;
            if (theGame.ForcedGamble != null)
            {
                forcedGamble = theGame.ForcedGamble(gameStage, curBankroll);
            }

            for (int curChoice = 0; curChoice < theGame.Gambles.Count; curChoice++)
            {
                if (forcedGamble != null)
                    if (forcedGamble != theGame.Gambles[curChoice])
                        continue;

                int bankrollAfterCost = curBankroll - theGame.Gambles[curChoice].EntryFee;
                if (bankrollAfterCost < 0)
                    break;

                double choiceProb = 0;
                foreach (var outcome in theGame.Gambles[curChoice].Outcomes)
                    choiceProb += outcome.Item2 *
                        ((bankrollAfterCost + outcome.Item1) >= getEscapeBankroll(curIteration-1) ? 1.0 : lastIterProb[bankrollAfterCost + outcome.Item1]);

                if (choiceProb > bestProb)
                {
                    bestChoice = curChoice + 1;
                    bestProb = choiceProb;
                }

                if (forcedGamble != null)
                    break;
            }
        }
    }
}
