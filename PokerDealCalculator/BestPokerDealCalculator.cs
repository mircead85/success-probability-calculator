using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PokerDealCalculator
{
    public class BestPokerDealCalculator
    {
        public int NoCardsInDeck { get; protected set; }

        public BestPokerDealCalculator(int deckSize)
        {
            NoCardsInDeck = deckSize;
        }

        protected bool bInitialized = false;

        private double[] logSum;
        protected void InitializeAlpha()
        {
            logSum = new double[NoCardsInDeck + 1];
            logSum[0] = 0.0;

            for (int n = 1; n <= NoCardsInDeck; n++)
            {
                logSum[n] = Math.Log(n) + logSum[n - 1];
            }

            bInitialized = true;
        }

        public double ExpectedValue(int noDeadCards, int noOuts, int noTimes, int noCardsToCome)
        {
            //EV(n,k,x) = alpha * (1+EV(n-1,k-1,x-1)) + (1-alpha)*EV(n-1,k,x-1).
            //By induction, EV(n,k,x) = EV(n,1,x).

            if(!bInitialized)
                InitializeAlpha();
            
            int noCardsLeft = NoCardsInDeck - noDeadCards;

            double logMissed = 0.0;
            logMissed += logSum[noCardsLeft - noCardsToCome] + logSum[noCardsLeft - noOuts];
            logMissed -= logSum[noCardsLeft - noCardsToCome - noOuts] + logSum[noCardsLeft];

            double missedProb = Math.Exp(logMissed);
            return 1 - missedProb;
        }
    }
}
