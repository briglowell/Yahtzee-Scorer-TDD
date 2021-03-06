using System;
using Xunit;
using YahtzeeScorer;

namespace YahtzeeTests
{
    public class Tests
    {
        [Fact]
        public void Score_By_Number_Returns_10_Given_Two_Fives()
        {
            Scorer scorer = new Scorer();
            int[] dice = new int[] { 5, 5, 4, 3, 2 };
            int expectedScore = 10;
            int actualScore = scorer.ScoreByNumber(dice, 5);
            Assert.Equal(expectedScore, actualScore);
        }

        [Fact]
        public void Score_By_Number_Returns_5_Given_One_Five()
        {
            Scorer scorer = new Scorer();
            int[] dice = new int[] { 5, 4, 4, 3, 2 };
            int expectedScore = 5;
            int actualScore = scorer.ScoreByNumber(dice, 5);
            Assert.Equal(expectedScore, actualScore);
        }

        [Theory]
        [InlineData(new int[] { 6,6,6,6,6}, 6, 30)]
        [InlineData(new int[] { 6,5,6,4,3}, 6, 12)]
        [InlineData(new int[] { 4,4,4,3,1}, 4, 12)]
        [InlineData(new int[] { 4,4,4,3,1}, 3, 3)]
        [InlineData(new int[] { 4,4,4,3,1}, 1, 1)]
        [InlineData(new int[] { 4,4,4,3,1}, 2, 0)]
        public void Score_By_Number(int[] dice, int chosenNumber, int expectedScore)
        {
            Scorer scorer = new Scorer();
            int actualScore = scorer.ScoreByNumber(dice, chosenNumber);
            Assert.Equal(expectedScore, actualScore);
        }

        [Theory]
        [InlineData(new int[] { 6, 6, 6, 6, 6 }, 30)]
        [InlineData(new int[] { 6, 5, 6, 4, 3 }, 24)]
        [InlineData(new int[] { 4, 4, 4, 3, 1 }, 16)]
        [InlineData(new int[] { 4, 4, 4, 4, 1 }, 17)]
        [InlineData(new int[] { 4, 1, 2, 3, 1 }, 11)]
        [InlineData(new int[] { 1, 1, 1, 3, 1 }, 7)]
        public void Score_By_Sum_Of_All_Dice(int[] dice, int expectedScore)
        {
            Scorer scorer = new Scorer();
            int actualScore = scorer.ScoreBySumOfAllDice(dice);
            Assert.Equal(expectedScore, actualScore);
        }

        [Theory]
        [InlineData(new int[] { 4, 4, 3, 2, 1 }, 8)]
        [InlineData(new int[] { 4, 4, 5, 5, 2 } , 10)]
        public void Score_Highest_Pair(int[] dice, int expectedScore)
        {
            Scorer scorer = new Scorer();
            int actualScore = scorer.ScoreByHighestPair(dice);
            Assert.Equal(expectedScore, actualScore);
        }

        [Theory]
        [InlineData(new int[] { 4, 4, 3, 2, 1 }, 0)]
        [InlineData(new int[] { 4, 4, 5, 5, 2 }, 18)]
        [InlineData(new int[] { 1, 1, 3, 3, 2 }, 8)]
        [InlineData(new int[] { 5, 5, 5, 5, 2 }, 0)]
        [InlineData(new int[] { 5, 4, 3, 2, 1 }, 0)]

        public void Score_Two_Pair(int[] dice, int expectedScore)
        {
            Scorer scorer = new Scorer();
            int actualScore = scorer.ScoreTwoPair(dice);
            Assert.Equal(expectedScore, actualScore);
        }

        [Theory]
        [InlineData(new int[] { 4, 4, 3, 2, 1 }, 0)]
        [InlineData(new int[] { 5, 4, 3, 2, 1 }, 0)]
        [InlineData(new int[] { 4, 4, 4, 5, 2 }, 12)]
        [InlineData(new int[] { 4, 4, 4, 4, 2 }, 12)]
        public void Score_Three_Of_A_Kind(int[] dice, int expectedScore)
        {
            Scorer scorer = new Scorer();
            int actualScore = scorer.ScoreThreeOfAKind(dice);
            Assert.Equal(expectedScore, actualScore);
        }

        [Theory]
        [InlineData(new int[] { 4, 4, 3, 2, 1 }, 0)]
        [InlineData(new int[] { 4, 4, 4, 5, 2 }, 0)]
        [InlineData(new int[] { 4, 4, 4, 4, 2 }, 16)]
        [InlineData(new int[] { 2, 2, 2, 2, 2 }, 8)]

        public void Score_Four_Of_A_Kind(int[] dice, int expectedScore)
        {
            Scorer scorer = new Scorer();
            int actualScore = scorer.ScoreFourOfAKind(dice);
            Assert.Equal(expectedScore, actualScore);
        }

        [Theory]
        [InlineData(new int[] { 4, 4, 3, 2, 1 }, 15)]
        [InlineData(new int[] { 4, 4, 4, 5, 2 }, 0)]
        [InlineData(new int[] { 6, 3, 1, 4, 5 }, 15)]
        [InlineData(new int[] { 2, 3, 4, 5, 2 }, 15)]

        public void Score_A_Small_Straight(int[] dice, int expectedScore)
        {
            Scorer scorer = new Scorer();
            int actualScore = scorer.ScoreSmallStraight(dice);
            Assert.Equal(expectedScore, actualScore);
        }

        [Theory]
        [InlineData(new int[] { 4, 4, 4, 5, 2 }, 0)]
        [InlineData(new int[] { 6, 3, 2, 4, 5 }, 20)]
        [InlineData(new int[] { 2, 3, 4, 5, 1 }, 20)]

        public void Score_A_Large_Straight(int[] dice, int expectedScore)
        {
            Scorer scorer = new Scorer();
            int actualScore = scorer.ScoreLargeStraight(dice);
            Assert.Equal(expectedScore, actualScore);
        }


        [Theory]
        [InlineData(new int[] { 4, 4, 4, 5, 2 }, 0)]
        [InlineData(new int[] { 4, 4, 4, 5, 5 }, 22)]
        [InlineData(new int[] { 6, 6, 6, 1, 1 }, 20)]
        [InlineData(new int[] { 4, 4, 4, 4, 4 }, 0)]

        public void Score_Full_House(int[] dice, int expectedScore)
        {
            Scorer scorer = new Scorer();
            int actualScore = scorer.ScoreFullHouse(dice);
            Assert.Equal(expectedScore, actualScore);
        }

        [Theory]
        [InlineData(new int[] { 4, 4, 3, 2, 1 }, 0)]
        [InlineData(new int[] { 4, 4, 4, 5, 2 }, 0)]
        [InlineData(new int[] { 4, 4, 4, 4, 2 }, 0)]
        [InlineData(new int[] { 2, 2, 2, 2, 2 }, 50)]
        [InlineData(new int[] { 1, 1, 1, 1, 1 }, 50)]

        public void Score_Yahtzee(int[] dice, int expectedScore)
        {
            Scorer scorer = new Scorer();
            int actualScore = scorer.ScoreYahtzee(dice);
            Assert.Equal(expectedScore, actualScore);
        }
    }
}
