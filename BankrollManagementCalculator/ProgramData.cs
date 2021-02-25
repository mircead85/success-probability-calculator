using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using ResourceBasedSuccessGames;
using ResourceBasedSuccessGames.SpecificGambles;

namespace BankrollManagementCalculator
{
    public enum Periods
    {
        Game = 0,
        Day = 1,
        Week = 2,
        Month = 3,
        Year = 4
    }

    [Serializable]
    public class ProgramData
    {
        public ProgramData()
        {
            availableGambles = new List<DisplayableGamble>();
        }

        protected SimpleGame theGame = null;

        protected SimpleGameTrivialSolver solver = null;

        public double GamesPerDay
        {
            get
            {
                double coeff = 0;
                coeff = 1.0 / DaysPerPeriod(playablePeriod);
                return coeff * noGamesPlayable;
            }
        }

        public double DaysPerPeriod(Periods period)
        {
            switch (period)
            {
                case Periods.Day:
                    return 1;
                case Periods.Month:
                    return 30.52;
                case Periods.Week:
                    return 7;
                case Periods.Year:
                    return 365.25;
                case Periods.Game:
                    return 1;
            }
            return 0;
        }

        int expensesEveryNoGames;
        int noExpenses;
        int noGamesToPlay;

        protected static int roundDoubleAmount(double amount)
        {
            return ((int)(10 * amount));
        }

        protected ExpensesGamble expensesGamble;

        protected SimpleGamble getForcedExpensesGamble(int gameStage, int bankRoll)
        {
            if (gameStage > 0 && gameStage % expensesEveryNoGames == 0)
                return expensesGamble;

            return null;
        }

        protected int escapeBankroll(int gameStage)
        {
            int noexptopay = noExpenses - (gameStage - 1) / (expensesEveryNoGames + 1);
            return roundDoubleAmount(targetBankroll) + noexptopay * expensesGamble.EntryFee;
        }

        public void RebuildGame()
        {
            noGamesToPlay = (int)(simulationPeriod * DaysPerPeriod(simulationPeriodKind) * GamesPerDay + 0.5);
            expensesEveryNoGames = 0;
            noExpenses = 0;
            expensesGamble = null;
            if (bHasExpenses)
            {
                expensesEveryNoGames = (int)(paymentDueEveryPeriods * DaysPerPeriod(paymentPeriod) * GamesPerDay);
                noExpenses = noGamesToPlay / expensesEveryNoGames;
                noGamesToPlay += noExpenses;
                expensesGamble = new ExpensesGamble((int)(amountDue * 10));
            }
            
            theGame = new SimpleGame(noGamesToPlay, roundDoubleAmount(startingBankroll), roundDoubleAmount(targetBankroll), simulationObjective);
            if(bHasNoPlayGamble)
                theGame.Gambles.Add(new NoPlayGamble());

            theGame.Gambles.AddRange(availableGambles);
            if (bHasExpenses)
            {
                theGame.ForcedGamble = new Func<int, int, ISimpleGamble>(getForcedExpensesGamble);
                theGame.Gambles.Add(expensesGamble);
                theGame.DynamicEscapeBankroll = new Func<int, int>(escapeBankroll);
            }
            
            theGame.EscapeBankroll = roundDoubleAmount(targetBankroll+1);

            if (bHasExpenses)
                theGame.EscapeBankroll += noExpenses * expensesGamble.EntryFee;

            solver = null;
            GC.Collect();
            solver = new SimpleGameTrivialSolver(theGame);
        }

        public SimpleGameTrivialSolver Solver
        {
            get
            {
                if (solver == null)
                    RebuildGame();

                return solver;
            }
            set
            {
                solver = null;
            }
        }

        public List<DisplayableGamble> availableGambles;
        public bool bHasNoPlayGamble = true;

        public bool bHasExpenses = true;
        public double amountDue = 500;
        public int paymentDueEveryPeriods = 1;
        public Periods paymentPeriod = Periods.Month;

        public int noGamesPlayable = 150;
        public Periods playablePeriod = Periods.Month;

        public double targetBankroll = 1;
        public int simulationPeriod = 12;
        public Periods simulationPeriodKind = Periods.Month;
        public SimpleGame.Objectives simulationObjective = SimpleGame.Objectives.Reachability;

        public double startingBankroll = 100;
        public int periodsElapsed = 0;
        public Periods elapsedKind = Periods.Week;

        public double succesProbability = -1;
        public double failureProbability = -1;
        public string nextGambleText = "-----------";

        public void Recompute()
        {
            solver = null;
            RebuildGame();
            solver.Solve();
        }

        public bool FillResult()
        {
            if (solver == null)
                return false;

            int elapsedGames = (int)(periodsElapsed*DaysPerPeriod(elapsedKind)*GamesPerDay+0.5);
            if (elapsedKind == Periods.Game)
                elapsedGames = periodsElapsed;
            if(expensesEveryNoGames > 0)
                elapsedGames += elapsedGames / expensesEveryNoGames;

            succesProbability = solver.GetProbability(roundDoubleAmount(startingBankroll), elapsedGames);
            failureProbability = 1 - succesProbability;

            nextGambleText = "Already lost.";
            var decision = solver.GetBestDecision(roundDoubleAmount(startingBankroll), elapsedGames);
            if (decision != null)
                nextGambleText = decision.ToString();

            return true;
        }
    }

}
