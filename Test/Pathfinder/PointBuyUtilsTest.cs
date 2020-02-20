using marquisdanWAP.Pathfinder;
using NUnit.Framework;

namespace marquisdanWAP.Test.Pathfinder
{
    public class PointBuyUtilsTest
    {
        public class FindCostTests
        {
            [Test]
            public void TestAllPossibleValues()
            {
                Assert.That(PointBuyUtils.FindMarginalCost(7), Is.EqualTo(-2), "7");
                Assert.That(PointBuyUtils.FindMarginalCost(8), Is.EqualTo(-1), "8");
                Assert.That(PointBuyUtils.FindMarginalCost(9), Is.EqualTo(-1), "9");
                Assert.That(PointBuyUtils.FindMarginalCost(10), Is.EqualTo(0), "10");
                Assert.That(PointBuyUtils.FindMarginalCost(11), Is.EqualTo(1), "11");
                Assert.That(PointBuyUtils.FindMarginalCost(12), Is.EqualTo(1), "12");
                Assert.That(PointBuyUtils.FindMarginalCost(13), Is.EqualTo(1), "13");
                Assert.That(PointBuyUtils.FindMarginalCost(14), Is.EqualTo(2), "14");
                Assert.That(PointBuyUtils.FindMarginalCost(15), Is.EqualTo(2), "15");
                Assert.That(PointBuyUtils.FindMarginalCost(16), Is.EqualTo(3), "16");
                Assert.That(PointBuyUtils.FindMarginalCost(17), Is.EqualTo(3), "17");
                Assert.That(PointBuyUtils.FindMarginalCost(18), Is.EqualTo(4), "18");
            }

            [Test]
            public void FindAllPossibleIncreases()
            {
                Assert.That(PointBuyUtils.FindCost(7, true), Is.EqualTo(2), "7 to 8");
                Assert.That(PointBuyUtils.FindCost(8, true), Is.EqualTo(1), "8 to 9");
                Assert.That(PointBuyUtils.FindCost(9, true), Is.EqualTo(1), "9 to 10");
                Assert.That(PointBuyUtils.FindCost(10, true), Is.EqualTo(1), "10 to 11");
                Assert.That(PointBuyUtils.FindCost(11, true), Is.EqualTo(1), "11 to 12");
                Assert.That(PointBuyUtils.FindCost(12, true), Is.EqualTo(1), "12 to 13");
                Assert.That(PointBuyUtils.FindCost(13, true), Is.EqualTo(2), "13 to 14");
                Assert.That(PointBuyUtils.FindCost(14, true), Is.EqualTo(2), "14 to 15");
                Assert.That(PointBuyUtils.FindCost(15, true), Is.EqualTo(3), "15 to 16");
                Assert.That(PointBuyUtils.FindCost(16, true), Is.EqualTo(3), "16 to 17");
                Assert.That(PointBuyUtils.FindCost(17, true), Is.EqualTo(4), "17 to 18");
            }

            [Test]
            public void FindAllPossibleDecreases()
            {
                Assert.That(PointBuyUtils.FindCost(8, false), Is.EqualTo(2), "8 to 7");
                Assert.That(PointBuyUtils.FindCost(9, false), Is.EqualTo(1), "9 to 8");
                Assert.That(PointBuyUtils.FindCost(10, false), Is.EqualTo(1), "10 to 9");
                Assert.That(PointBuyUtils.FindCost(11, false), Is.EqualTo(1), "11 to 10");
                Assert.That(PointBuyUtils.FindCost(12, false), Is.EqualTo(1), "12 to 11");
                Assert.That(PointBuyUtils.FindCost(13, false), Is.EqualTo(1), "13 to 12");
                Assert.That(PointBuyUtils.FindCost(14, false), Is.EqualTo(2), "14 to 13");
                Assert.That(PointBuyUtils.FindCost(15, false), Is.EqualTo(2), "15 to 14");
                Assert.That(PointBuyUtils.FindCost(16, false), Is.EqualTo(3), "16 to 15");
                Assert.That(PointBuyUtils.FindCost(17, false), Is.EqualTo(3), "17 to 16");
                Assert.That(PointBuyUtils.FindCost(18, false), Is.EqualTo(4), "18 to 17");
            }
        }

        public class FindModTests
        {
            [Test]
            public void FindModsForAllPossibleValues()
            {
                Assert.That(PointBuyUtils.FindMod(5), Is.EqualTo(-3), "5");
                Assert.That(PointBuyUtils.FindMod(6), Is.EqualTo(-2), "6");
                Assert.That(PointBuyUtils.FindMod(7), Is.EqualTo(-2), "7");
                Assert.That(PointBuyUtils.FindMod(8), Is.EqualTo(-1), "8");
                Assert.That(PointBuyUtils.FindMod(9), Is.EqualTo(-1), "9");
                Assert.That(PointBuyUtils.FindMod(10), Is.EqualTo(0), "10");
                Assert.That(PointBuyUtils.FindMod(11), Is.EqualTo(0), "11");
                Assert.That(PointBuyUtils.FindMod(12), Is.EqualTo(1), "12");
                Assert.That(PointBuyUtils.FindMod(13), Is.EqualTo(1), "13");
                Assert.That(PointBuyUtils.FindMod(14), Is.EqualTo(2), "14");
                Assert.That(PointBuyUtils.FindMod(15), Is.EqualTo(2), "15");
                Assert.That(PointBuyUtils.FindMod(16), Is.EqualTo(3), "16");
                Assert.That(PointBuyUtils.FindMod(17), Is.EqualTo(3), "17");
                Assert.That(PointBuyUtils.FindMod(18), Is.EqualTo(4), "18");
                Assert.That(PointBuyUtils.FindMod(19), Is.EqualTo(4), "19");
                Assert.That(PointBuyUtils.FindMod(20), Is.EqualTo(5), "20");
            }
        }
    }
}