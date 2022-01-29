using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace BadSample.V2
{
    [TestClass]
    public class V2Test
    {
        bool DoTest(decimal amount, int type, int years, decimal discountedAmount)
        {
            var class1 = new DiscountManager();

            var ans = class1.Calculate(amount, type, years);

            return ans == discountedAmount;
        }

        [TestMethod]
        public void T0_NotRegistered()
        {
            Assert.IsTrue(DoTest(0m, 1, 0, 0m));
        }

        [TestMethod]
        public void T123_NotRegistered()
        {
            Assert.IsTrue(DoTest(123m, 1, 0, 123m));
        }

        [TestMethod]
        public void T123_SimpleCustomer_0()
        {
            Assert.IsTrue(DoTest(123m, 2, 0, 123m * 0.9m));
        }

        [TestMethod]
        public void T123_SimpleCustomer_1()
        {
            Assert.IsTrue(DoTest(123m, 2, 1, 123m * 0.9m * 0.99m));
        }

        [TestMethod]
        public void T123_SimpleCustomer_3()
        {
            Assert.IsTrue(DoTest(123m, 2, 3, 123m * 0.9m * 0.97m));
        }

        [TestMethod]
        public void T123_SimpleCustomer_5()
        {
            Assert.IsTrue(DoTest(123m, 2, 5, 123m * 0.9m * 0.95m));
        }

        [TestMethod]
        public void T123_SimpleCustomer_6()
        {
            Assert.IsTrue(DoTest(123m, 2, 6, 123m * 0.9m * 0.95m));
        }

        [TestMethod]
        public void T123_ValuableCustomer_3()
        {
            Assert.IsTrue(DoTest(123m, 3, 3, 123m * 0.7m * 0.97m));
        }

        [TestMethod]
        public void T123_MostValuableCustomer_3()
        {
            Assert.IsTrue(DoTest(123m, 4, 3, 123m * 0.5m * 0.97m));
        }
    }
}
