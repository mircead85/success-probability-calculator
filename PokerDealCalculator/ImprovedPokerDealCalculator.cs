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
    public class ImprovedPokerDealCalculator
    {

        protected int NoNonDeadCardsInDeck { get; set; }

        public int NoCardsInDeck;
        public int MaxNoOuts { get; protected set; }
        public int MaxNoTimes { get; protected set; }
        public int NoCardsToCome { get; protected set; }
        public int NoOuts { get; protected set; }
        public int NoTimes { get; protected set; }

        protected bool bComputed;

        protected ImprovedPokerDealCalculator()
        {
        }

        public ImprovedPokerDealCalculator(int noOfCardsInDeck, int noDeadCards, int noOuts, int noCardsToCome, int noTimes)
        {

            NoCardsInDeck = noOfCardsInDeck;
            NoNonDeadCardsInDeck = NoCardsInDeck - noDeadCards;
            NoCardsToCome = noCardsToCome;
            MaxNoTimes = NoNonDeadCardsInDeck / NoCardsToCome;
            NoOuts = noOuts;
            NoTimes = noTimes;

            EV = new double?[NoOuts + 1, NoTimes + 1];
            bComputed = false;
            
        }
        
        protected void Compute()
        {
            f_calc(0, 0);
        }


        protected double?[,] EV;

        /// <summary>
        /// Returns the expected value of having whichOut+1 number of outs dealing NoTimes, having already hit hitsSoFar with the outs 0..whichOut-1.
        /// </summary>
        /// <param name="whichOut"></param>
        /// <param name="hitsSoFar"></param>
        /// <returns></returns>
        protected virtual double f_calc(int whichOut, int hitsSoFar)
        {
            if (whichOut == NoOuts)
                return hitsSoFar;

            if(hitsSoFar == NoTimes)
                return hitsSoFar;

            var curCell = EV[whichOut, hitsSoFar]; 

            if (curCell.HasValue)
                return curCell.Value;

            double alpha = (double)(NoTimes - hitsSoFar)*NoCardsToCome / (NoNonDeadCardsInDeck - whichOut);
            //I choose the value of out whichOut. alpha = hits, 1-alpha = misses.

            EV[whichOut, hitsSoFar] = alpha * f_calc(whichOut + 1, hitsSoFar + 1) + (1 - alpha) * f_calc(whichOut + 1, hitsSoFar);
            
            return EV[whichOut, hitsSoFar].Value;
        }

        public double ExpectedValue
        {
            get
            {
                if (!bComputed)
                    Compute();

                return EV[0, 0].Value / NoTimes;
            }
        }
    }
}
