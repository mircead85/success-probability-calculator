using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataStructures;

namespace PokerDealCalculator
{

    class Program
    {
        protected IOHelper ioHelper;

        int noCards, noDeadCards, noOuts, noTimes, noCardsToCome;

        public void Solve()
        {
            var BasicCalculator = new BasicPokerDealCalculator(noCards, noDeadCards, noOuts, noCardsToCome, noTimes);
            var ImprovedCalculator = new ImprovedPokerDealCalculator(noCards, noDeadCards, noOuts, noCardsToCome, noTimes);
            var BestCalculator = new BestPokerDealCalculator(noCards);
            
            var resultBasic = 100 * BasicCalculator.ExpectedValue;
            var resultImproved = 100 * ImprovedCalculator.ExpectedValue;
            var resultBest = 100 * BestCalculator.ExpectedValue(noDeadCards, noOuts, noTimes, noCardsToCome);
            ioHelper.WriteLine("Expected Value: ");
            ioHelper.WriteLine("Basic calculator = " + resultBasic.ToString());
            ioHelper.WriteLine("Improved calculator = " + resultImproved.ToString());
            ioHelper.WriteLine("Best calculator = " + resultBest.ToString());
            int r = ioHelper.ReadNextInt();
        }

        private void ReadData()
        {
            ioHelper.AutoFlush = true;

            ioHelper.WriteLine("Number of cards in deck: ");
            noCards = ioHelper.ReadNextInt();
            ioHelper.WriteLine("Number of dead cards: ");
            noDeadCards = ioHelper.ReadNextInt();
            ioHelper.WriteLine("Number of outs: ");
            noOuts = ioHelper.ReadNextInt();
            ioHelper.WriteLine("Number of cards to come: ");
            noCardsToCome = ioHelper.ReadNextInt();
            ioHelper.WriteLine("Number of times: ");
            noTimes = ioHelper.ReadNextInt();
        }

        public Program(string inputFile, string outputFile)
        {
            ioHelper = new IOHelper(inputFile, outputFile, Encoding.Default);
            using(ioHelper)
            {
                if (inputFile == null && outputFile == null)
                    ReadData();

                Solve();
            }
        }

        static void Main(string[] args)
        {
            Program myProgram = new Program(null, null);
        }
    }
}
