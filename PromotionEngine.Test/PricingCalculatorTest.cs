using Microsoft.VisualStudio.TestTools.UnitTesting;
using PromotionEngine.BLComponent;
using PromotionEngine.DataEntities;
using System.Collections.Generic;

namespace PromotionEngine.Test
{
    [TestClass]
    public class PricingCalculatorTest
    {
        #region DataSetUp

        #endregion

        /* Scenario A
              1 * A 50
              1 * B 30
              1 * C 20
             Total 100
           */
        [TestMethod]
        public void ScenarioA()
        {
            int expectedPrice = 100;
            List<Product> products = new List<Product>();
            products.Add(GetProduct("A"));
            products.Add(GetProduct("B"));
            products.Add(GetProduct("C"));
            int resultPrice = PricingCalculator.Instance.GetTotalPrice(products);
            Assert.IsTrue(resultPrice > 0);
            Assert.AreEqual(expectedPrice, resultPrice);
        }

        /* Scenario B
               5 * A       130 + 2 * 50
               5 * B       45 + 45 + 30
               1 * C       20
               Total   370
           */
        [TestMethod]
        public void ScenarioB()
        {
            int expectedPrice = 370;
            List<Product> products = new List<Product>();

            for (int i = 0; i < 5; i++)
            {
                products.Add(GetProduct("A"));
            }
            for (int i = 0; i < 5; i++)
            {
                products.Add(GetProduct("B"));
            }

            products.Add(GetProduct("C"));

            int resultPrice = PricingCalculator.Instance.GetTotalPrice(products);
            Assert.IsTrue(resultPrice > 0);
            Assert.AreEqual(expectedPrice, resultPrice);
        }

        /* Scenario C
           3 * A 130
           5 * B 45 + 45 + 1 * 30
           1 * C - 20
           1 * D 15
           Total	285 */
        [TestMethod]
        public void ScenarioC()
        {
            int expectedPrice = 285;
            List<Product> products = new List<Product>();

            for (int i = 0; i < 3; i++)
            {
                products.Add(GetProduct("A"));
            }
            for (int i = 0; i < 5; i++)
            {
                products.Add(GetProduct("B"));
            }

            products.Add(GetProduct("C"));
            products.Add(GetProduct("D"));

            int resultPrice = PricingCalculator.Instance.GetTotalPrice(products);
            Assert.IsTrue(resultPrice > 0);
            Assert.AreEqual(expectedPrice, resultPrice);
        }


        Product GetProduct(string productName)
        {
            return new Product(productName);
        }
    }
}
