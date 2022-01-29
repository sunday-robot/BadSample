using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace BadSample.Step8 {
    [TestClass]
    public class V2Test {
        bool DoTest(decimal amount, AccountStatus accountStatus, int years, decimal discountedAmount) {
            var class1 = new DiscountManager();

            var ans = class1.ApplyDiscount(amount, accountStatus, years);

            return ans == discountedAmount;
        }

        [TestMethod]
        public void T0_NotRegistered() {
            Assert.IsTrue(DoTest(0m, AccountStatus.NotRegistered, 0, 0m));
        }

        [TestMethod]
        public void T123_NotRegistered() {
            Assert.IsTrue(DoTest(123m, AccountStatus.NotRegistered, 0, 123m));
        }

        [TestMethod]
        public void T123_SimpleCustomer_0() {
            Assert.IsTrue(DoTest(123m, AccountStatus.SimpleCustomer, 0, 123m * 0.9m));
        }

        [TestMethod]
        public void T123_SimpleCustomer_1() {
            Assert.IsTrue(DoTest(123m, AccountStatus.SimpleCustomer, 1, 123m * 0.9m * 0.99m));
        }

        [TestMethod]
        public void T123_SimpleCustomer_3() {
            Assert.IsTrue(DoTest(123m, AccountStatus.SimpleCustomer, 3, 123m * 0.9m * 0.97m));
        }

        [TestMethod]
        public void T123_SimpleCustomer_5() {
            Assert.IsTrue(DoTest(123m, AccountStatus.SimpleCustomer, 5, 123m * 0.9m * 0.95m));
        }

        [TestMethod]
        public void T123_SimpleCustomer_6() {
            Assert.IsTrue(DoTest(123m, AccountStatus.SimpleCustomer, 6, 123m * 0.9m * 0.95m));
        }

        [TestMethod]
        public void T123_ValuableCustomer_3() {
            Assert.IsTrue(DoTest(123m, AccountStatus.ValuableCustomer, 3, 123m * 0.7m * 0.97m));
        }

        [TestMethod]
        public void T123_MostValuableCustomer_3() {
            Assert.IsTrue(DoTest(123m, AccountStatus.MostValuableCustomer, 3, 123m * 0.5m * 0.97m));
        }
    }
}
