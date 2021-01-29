using System;
using System.Collections.Generic;
using System.Linq;

namespace YahtzeeScorer
{
    public class Scorer
    {

        public int ScoreByNumber(int[] dice, int chosenNum)
        {
            int dieSum = 0;
            foreach (int die in dice)
            {
                if (die == chosenNum) 
                    dieSum += die;
            }
            return dieSum;
        }

        public int ScoreBySumOfAllDice(int[] dice)
        {
            return dice.Sum();
        }

        public int ScoreByHighestPair(int[] dice)
        {
            int highPair = 0;
            var dict = new Dictionary<int, int>();
            foreach (int die in dice)
            {
                if (dict.ContainsKey(die)) 
                    dict[die]++;
                else 
                    dict.Add(die, 1);
                if (dict[die] == 2 && die*2 > highPair) 
                    highPair = die*2;
            }
            return highPair;
        }

        public int ScoreTwoPair(int[] dice)
        {
            int pairScore = 0;
            int firstPair = 0;
            int secondPair = 0;
            var dict = new Dictionary<int, int>();
            foreach (int die in dice)
            {
                if (dict.ContainsKey(die)) 
                    dict[die]++;
                else 
                    dict.Add(die, 1);
                if (dict[die] == 2 && firstPair > 0) 
                    secondPair = 2 * die;
                else if (dict[die] == 2) 
                    firstPair = 2 * die;
                if (firstPair > 0 && secondPair > 0) 
                    pairScore = firstPair + secondPair;
            }
            return pairScore;
        }

        public int ScoreThreeOfAKind(int[] dice)
        {
            int highTriple = 0;
            var dict = new Dictionary<int, int>();
            foreach (int die in dice)
            {
                if (dict.ContainsKey(die)) 
                    dict[die]++;
                else 
                    dict.Add(die, 1);
                if (dict[die] == 3 && die * 3 > highTriple) 
                    highTriple = die * 3;
            }
            return highTriple;
        }

        public int ScoreFourOfAKind(int[] dice)
        {
            int highQuadruple = 0;
            var dict = new Dictionary<int, int>();
            foreach (int die in dice)
            {
                if (dict.ContainsKey(die)) 
                    dict[die]++;
                else 
                    dict.Add(die, 1);
                if (dict[die] == 4 && die * 4 > highQuadruple) 
                    highQuadruple = die * 4;
            }
            return highQuadruple;
        }

        public int ScoreSmallStraight(int[] dice)
        {
            int[] distinctDice = dice.Distinct().ToArray();
            Array.Sort(distinctDice);
            if (distinctDice.Length < 4) 
                return 0;

            int consecutiveNumbers = 0;
            for (int i = 0; i < distinctDice.Length; i++)
            {
                if(i + 1  <= distinctDice.Length-1)
                {
                    if (distinctDice[i + 1] == distinctDice[i] + 1)
                    {
                        consecutiveNumbers++;
                        if (consecutiveNumbers == 3)
                            return 15;
                    }
                    else consecutiveNumbers = 0;
                }
                
            }
            return 0;
        }

        public int ScoreLargeStraight(int[] dice)
        {
            int[] distinctDice = dice.Distinct().ToArray();
            Array.Sort(distinctDice);
            if (distinctDice.Length < 5)
                return 0;

            int consecutiveNumbers = 0;
            for (int i = 0; i < distinctDice.Length; i++)
            {
                if (i + 1 <= distinctDice.Length - 1)
                {
                    if (distinctDice[i + 1] == distinctDice[i] + 1)
                    {
                        consecutiveNumbers++;
                        if (consecutiveNumbers == 4)
                            return 20;
                    }
                    else consecutiveNumbers = 0;
                }

            }
            return 0;
        }

        public int ScoreFullHouse(int[] dice)
        {
            return 0;
        }

        public int ScoreYahtzee(int[] dice)
        {
            return 0;
        }


        //public int ScoreByNumber(int[] dice, int chosenNumber)
        //{
        //    //return dice.Length == 5 ? dice.Sum(n => n == chosenNumber ? n : 0) : 0;
        //    return dice.Length == 5 ? (from die in dice where die == chosenNumber select die).Sum() : 0;
        //}

        //public int ScoreByHighestPair(int[] dice)
        //{
        //    return dice.OrderByDescending(n => n).GroupBy(num => num).Where(grp => grp.Count() > 1).Select(y => y.Key).First() * 2;
        //}

        //public int ScoreTwoPair(int[] dice)
        //{
        //    return dice.GroupBy(n => n).Where(grp => grp.Count() > 1).Select(i => i.Key).Take(2).Sum() * 2;
        //}

        //public int ScoreThreeOfAKind(int[] dice)
        //{
        //    return dice.OrderBy(n => n).GroupBy(n => n).Where(grp => grp.Count() > 2).Select(y => y.Key).Last() * 3;
        //}

        //public int ScoreFourOfAKind(int[] dice)
        //{
        //    return dice.OrderBy(n => n).GroupBy(n => n).Where(grp => grp.Count() > 2).Select(y => y.Key).Last() * 4;
        //}

        //public int ScoreSmallStraight(int[] dice)
        //{
        //    var groups = dice.Distinct().OrderBy(n => n);
        //    var lastval = groups.First();
        //    return dice.Count() == 5 ? groups.Count() > 3 && !groups.Any(val => { var valid = val - lastval > 1 ? true : false; lastval = val; return valid; }) ? dice.Sum() : 0 : 0;
        //}

        //public int ScoreLargeStraight(int[] dice)
        //{
        //    return dice.Count() == 5 ? !dice.Select((i, j) => i - j).Distinct().Skip(1).Any() ? dice.Sum() : 0 : 0;
        //}

        //public int ScoreFullHouse(int[] dice)
        //{
        //    var groups = dice.GroupBy(n => n);
        //    return groups.Any(g1 => g1.Count() >= 3 && groups.Any(g2 => g2.Count() >= 2 && g2.Key != g1.Key)) ? dice.Sum() : 0;
        //}

        //public int ScoreYahtzee(int[] dice)
        //{
        //    return dice.Count() == 5 ? dice.GroupBy(n => n).Count() < 2 ? 50 : 0 : 0;
        //}

    }
}
