
using System.Drawing;
using marquisdanWAP.Pathfinder;
using NUnit.Framework;
using NUnit.Framework.Interfaces;

namespace marquisdanWAP.Test.Pathfinder
{
    public class PointBuyCalculatorTest
    {
        public class ConstructorTests
        {
            [Test]
            public void DefaultConstructorSetsDefaultStats()
            {
                var result = new PointBuyCalculator();

                Assert.That(result.Points, Is.EqualTo(PointBuyCalculator.DefaultPoints));
                foreach (var stat in result.Stat)
                {
                    Assert.That(stat, Is.EqualTo(PointBuyCalculator.DefaultStat));
                }
            }

            [Test]
            public void ParameterizedConstructorSetsCustomVals()
            {
                var startingPoints = 44;
                var startingStat = 7;

                var result = new PointBuyCalculator(startingPoints, startingStat);

                Assert.That(result.Points, Is.EqualTo(startingPoints));
                foreach (var stat in result.Stat)
                {
                    Assert.That(stat, Is.EqualTo(startingStat));
                }
            }
        }

        public class PointManipTests
        {
            [Test]
            public void CanResetPointsToCustomValue()
            {
                var customPoints = 44;
                var customStat = 7;

                var sut = new PointBuyCalculator();
                sut.ResetPoints(customPoints, customStat);

                Assert.That(sut.Points, Is.EqualTo(customPoints));
                foreach (var stat in sut.Stat)
                {
                    Assert.That(stat, Is.EqualTo(customStat));
                }
            }

            [Test]
            public void CanResetPointsToDefault()
            {
                var customPoints = 44;
                var customStat = 7;

                var sut = new PointBuyCalculator(customPoints, customStat);
                sut.ResetPointsToDefault();

                Assert.That(sut.Points, Is.EqualTo(PointBuyCalculator.DefaultPoints));
                foreach (var stat in sut.Stat)
                {
                    Assert.That(stat, Is.EqualTo(PointBuyCalculator.DefaultStat));
                }
            }

            [Test]
            public void IncrementingMultipleTimesIncreasesCost()
            {
                var startingPoints = 20;
                var startingStat = 10;

                var expectedFinalStatValue = 18;
                var expectedRemainingPoints = 3;

                var sut = new PointBuyCalculator(startingPoints, startingStat);

                for (int i = 0; i < 8; i++)
                {
                    sut.IncrementStat(0);
                }

                Assert.That(sut.Stat[0], Is.EqualTo(expectedFinalStatValue));
                Assert.That(sut.Points, Is.EqualTo(expectedRemainingPoints));
            }

            [Test]
            public void CannotIncreaseStatOverMaxEvenIfYouClick100TimesLikeAnInsanePerson()
            {
                var startingPoints = 20;
                var startingStat = 10;

                var expectedFinalStatValue = 18;
                var expectedRemainingPoints = 3;

                var sut = new PointBuyCalculator(startingPoints, startingStat);

                for (int i = 0; i < 100; i++)
                {
                    sut.IncrementStat(0);
                }

                Assert.That(sut.Stat[0], Is.EqualTo(expectedFinalStatValue));
                Assert.That(sut.Points, Is.EqualTo(expectedRemainingPoints));
            }

            [Test]
            public void DecrementingMultipleTimesGivesMorePointsBack()
            {
                var startingPoints = 20;
                var startingStat = 10;

                var expectedFinalStatValue = 7;
                var expectedRemainingPoints = 24;

                var sut = new PointBuyCalculator(startingPoints, startingStat);

                for (int i = 0; i < 3; i++)
                {
                    sut.DecrementStat(0);
                }

                Assert.That(sut.Stat[0], Is.EqualTo(expectedFinalStatValue));
                Assert.That(sut.Points, Is.EqualTo(expectedRemainingPoints));
            }

            [Test]
            public void CannotDecreaseStatUnderMinEvenIfYouClick100TimesLikeAnInsanePerson()
            {
                var startingPoints = 20;
                var startingStat = 10;

                var expectedFinalStatValue = 7;
                var expectedRemainingPoints = 24;

                var sut = new PointBuyCalculator(startingPoints, startingStat);

                for (int i = 0; i < 100; i++)
                {
                    sut.DecrementStat(0);
                }

                Assert.That(sut.Stat[0], Is.EqualTo(expectedFinalStatValue));
                Assert.That(sut.Points, Is.EqualTo(expectedRemainingPoints));
            }
        }

        public class GetModTests
        {
            private int racialBonus;
            private PointBuyCalculator sut;

            [SetUp]
            public void SetUp()
            {
                racialBonus = 2;
                sut = new PointBuyCalculator(20, 17);

                sut.IncrementStat(0);
            }

            [Test]
            public void GetsTotalWithRacialBonus()
            {
                var result = sut.FindTotalStat(0, racialBonus);

                Assert.That(result, Is.EqualTo(20));
            }

            [Test]
            public void EvenStatsIncreaseByOneWithRacialBonus()
            {

                var result1 = sut.FindTotalMod(0, 0);
                var result2 = sut.FindTotalMod(0, racialBonus);

                Assert.That(result1, Is.EqualTo(4));
                Assert.That(result2, Is.EqualTo(5));
            }

            [Test]
            public void OddStatsIncreaseByOneWithRacialBonus()
            {
                //have to test this separately from even numbers because of the risk of bad math
                var result1 = sut.FindTotalMod(1, 0);
                var result2 = sut.FindTotalMod(1, racialBonus);

                Assert.That(result1, Is.EqualTo(3));
                Assert.That(result2, Is.EqualTo(4));
            }
        }
    }
}