using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PokerDealCalculator
{

    /// <summary>
    /// Computes the EV of a hand with NoOuts outs with NoCardsToCome individual (or if drawing to absoulte win community) cards yet to come, if you deal it NoTimes times in the same NoCardsInDeck-card deck.
    /// </summary>
    public class BasicPokerDealCalculator
    {
        protected int NoNonDeadCardsInDeck { get; set; }

        public int NoCardsInDeck;
        public int MaxNoOuts { get; protected set; }
        public int MaxNoTimes { get; protected set; }
        public int NoCardsToCome { get; protected set; }
        public int NoOuts { get; protected set; }
        public int NoTimes { get; protected set; }


        protected double[,] EV;

        protected BasicPokerDealCalculator()
        {
        }

        public BasicPokerDealCalculator(int noOfCardsInDeck, int noDeadCards, int noOuts, int noCardsToCome, int noTimes)
        {
            NoCardsInDeck = noOfCardsInDeck;
            NoNonDeadCardsInDeck = NoCardsInDeck - noDeadCards;
            NoCardsToCome = noCardsToCome;
            MaxNoTimes = NoNonDeadCardsInDeck / NoCardsToCome;
            NoOuts = noOuts;
            NoTimes = noTimes;
            EV = new double[MaxNoTimes + 1, NoNonDeadCardsInDeck + 1];
            bComputed = false;
        }

        protected bool bComputed;

        private double[] logSum;
        protected void InitializeAlpha()
        {
            logSum = new double[NoNonDeadCardsInDeck + 1];
            logSum[0] = 0.0;

            for (int n = 1; n <= NoNonDeadCardsInDeck; n++)
            {
                logSum[n] = Math.Log(n) + logSum[n - 1];
            }
        }

        /// <summary>
        /// Returns the probability of hitting precisely noHitOuts outs from noOuts total outs in a single deal from a noCardsInDeck deck.
        /// </summary>
        /// <param name="noCardsLeft"></param>
        /// <param name="noOuts"></param>
        /// <param name="noHitOuts"></param>
        /// <returns></returns>
        protected double alpha(int noCardsLeft, int noOuts, int noHitOuts)
        {
            //=Comb(noCardsToCome,noHitOuts)*Comb(noCardsInDeck-noCardsToCome,noOuts-noHitOuts) / Comb(noCardsInDeck, noOuts).

            if (noHitOuts > NoCardsToCome)
                return 0.0;

            if (noHitOuts > noOuts)
                return 0.0;

            if (noOuts - noHitOuts > noCardsLeft - NoCardsToCome)
                return 0.0;

            double logResult = 0;

            logResult += logSum[NoCardsToCome] - logSum[noHitOuts] - logSum[NoCardsToCome - noHitOuts];
            logResult += logSum[noCardsLeft - NoCardsToCome] - logSum[noOuts - noHitOuts] - logSum[(noCardsLeft - NoCardsToCome) - (noOuts - noHitOuts)];
            logResult -= logSum[noCardsLeft] - logSum[noOuts] - logSum[noCardsLeft - noOuts];

            double result = Math.Exp(logResult);
            return result;
        }

        protected virtual void Compute()
        {
            InitializeAlpha();

            int noTimesLeft, noOutsRemaining;

            for (noTimesLeft = 1; noTimesLeft <= NoTimes; noTimesLeft++)
            {
                int noCardsLeft = NoNonDeadCardsInDeck - NoCardsToCome * (NoTimes - noTimesLeft);

                for (noOutsRemaining = 0; noOutsRemaining <= NoOuts; noOutsRemaining++)
                {
                    double EVcomputed = 0.0;

                    EVcomputed += alpha(noCardsLeft, noOutsRemaining, 0) * EV[noTimesLeft - 1, noOutsRemaining];

                    int noHitOuts;
                    for (noHitOuts = 1; noHitOuts <= Math.Min(NoCardsToCome, noOutsRemaining); noHitOuts++)
                    {
                        EVcomputed += alpha(noCardsLeft, noOutsRemaining, noHitOuts) * (1 + EV[noTimesLeft - 1, noOutsRemaining - noHitOuts]);
                    }

                    EV[noTimesLeft, noOutsRemaining] = EVcomputed;
                }
            }

            bComputed = true;
        }

        public double ExpectedValue
        {
            get
            {
                if (!bComputed)
                    Compute();

                return EV[NoTimes, NoOuts] / NoTimes;
            }
        }
    }
}
