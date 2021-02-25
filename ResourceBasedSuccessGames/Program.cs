using DataStructures;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ResourceBasedSuccessGames
{
    class Program
    {
        protected IOHelper ioHelper;

        SimpleGamble noPlay = new SimpleGamble(0);
        SimpleGamble play10usd = new SimpleGamble(10*10);
        SimpleGamble play20usd = new SimpleGamble(20*10);
        SimpleGamble play30usd = new SimpleGamble(30*10);
        SimpleGamble play50usd = new SimpleGamble(50*10);
        SimpleGamble play75usd = new SimpleGamble(75*10);
        SimpleGamble play100usd = new SimpleGamble(100*10);

        SimpleGamble monthyExpenses = new SimpleGamble(550*10);
        int expensesPaidEveryNoGames = 100;

        double roi = 0.099;
        double rake = 0.05;

        double getProbability(double roiV)
        {
            double result = (1+roiV) / (2.0 * (1 - rake));
            return result;
        }
        
        ISimpleGamble MonthlyExpenses(int gameStage, int bankRoll)
        {
            if (((gameStage+1) % expensesPaidEveryNoGames) == 0)
                return monthyExpenses;

            return null;
        }

        public void Solve()
        {
            ioHelper.AutoFlush = true;
            
            monthyExpenses.AddOutcome(0, 1);
            noPlay.AddOutcome(0, 1);

            var rakedGambles = new SimpleGamble[] { play10usd, play20usd, play30usd, play50usd, play75usd };
            foreach (var gamble in rakedGambles)
            {
                gamble.AddOutcome((int)(2 * gamble.EntryFee * (1 - rake)), getProbability(roi));
                gamble.AddOutcome(0, 1-getProbability(roi));
            }

            var numGames = 10*10*12;
            var myGame = new SimpleGame(numGames, 2000 * 10, 0 * 2000 * 10, SimpleGame.Objectives.Safety);
            myGame.ForcedGamble = new Func<int, int, ISimpleGamble>(MonthlyExpenses);
            myGame.Gambles.Add(monthyExpenses);
            myGame.Gambles.Add(noPlay);
            myGame.Gambles.AddRange(rakedGambles);
            myGame.EscapeBankroll = monthyExpenses.EntryFee * numGames / expensesPaidEveryNoGames;

            #region Test game

            var choice1Sg = new SimpleGamble(1);
            choice1Sg.AddOutcome(2, 0.99);
            choice1Sg.AddOutcome(1, 0.01);

            var choice2Sg = new SimpleGamble(10);
            choice2Sg.AddOutcome(100, 0.2);
            choice2Sg.AddOutcome(0, 0.8);

            var testGame = new SimpleGame(90, 10, 100, SimpleGame.Objectives.Reachability);
            testGame.Gambles.AddRange(new SimpleGamble[] { choice1Sg, choice2Sg });
            //Game value = ~90.00%
            #endregion

            var solver = new SimpleGameTrivialSolver(myGame);
            solver.Solve();

            ioHelper.WriteLine("Probability of reaching objective in " + myGame.MaxStages.ToString() + " stages: "+ solver.Value.ToString());
            //ioHelper.WriteLine("MaxError w/r to infinite number of games: " + solver.MaxError.ToString()); 
            ioHelper.WriteLine("Time to solve: " + solver.TimeToSolveInMilliseconds.ToString() + " ms.");

            string wait = ioHelper.ReadNextToken();
        }

        public Program(string inputFile, string outputFile)
        {
            ioHelper = new IOHelper(inputFile, outputFile, Encoding.Default);
            Solve();
            ioHelper.Dispose();
        }

        static void Main(string[] args)
        {
            Program myProgram = new Program(null, null);
        }
    }

}
