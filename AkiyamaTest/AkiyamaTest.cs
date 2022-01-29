using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace BadSample.Akiyama
{
    [TestClass]
    public class AkiyamaTest
    {
        bool DoTest(decimal amount, MemberRank memberRank, int years, decimal discountedAmount)
        {
            var ans = DiscountManager.ApplyDiscount(amount, memberRank, years);

            return ans == discountedAmount;
        }

        [TestMethod]
        public void T0NotRegistered()
        {
            Assert.IsTrue(DoTest(0m, MemberRank.NonMember, 0, 0m));
        }

        [TestMethod]
        public void T123NotRegistered()
        {
            Assert.IsTrue(DoTest(123m, MemberRank.NonMember, 0, 123m));
        }

        [TestMethod]
        public void T123SimpleCustomer0()
        {
            Assert.IsTrue(DoTest(123m, MemberRank.Silver, 0, 123m * 0.9m));
        }

        [TestMethod]
        public void T123SimpleCustomer1()
        {
            Assert.IsTrue(DoTest(123m, MemberRank.Silver, 1, 123m * 0.9m * 0.99m));
        }

        [TestMethod]
        public void T123SimpleCustomer3()
        {
            Assert.IsTrue(DoTest(123m, MemberRank.Silver, 3, 123m * 0.9m * 0.97m));
        }

        [TestMethod]
        public void T123SimpleCustomer5()
        {
            Assert.IsTrue(DoTest(123m, MemberRank.Silver, 5, 123m * 0.9m * 0.95m));
        }

        [TestMethod]
        public void T123SimpleCustomer6()
        {
            Assert.IsTrue(DoTest(123m, MemberRank.Silver, 6, 123m * 0.9m * 0.95m));
        }

        [TestMethod]
        public void T123ValuableCustomer3()
        {
            Assert.IsTrue(DoTest(123m, MemberRank.Gold, 3, 123m * 0.7m * 0.97m));
        }

        [TestMethod]
        public void T123MostValuableCustomer3()
        {
            Assert.IsTrue(DoTest(123m, MemberRank.Platinum, 3, 123m * 0.5m * 0.97m));
        }
    }
}
