using PromotionEngine.DataEntities;
using System.Collections.Generic;
using System.Linq;

namespace PromotionEngine.BLComponent
{
    public class PricingCalculator
    {
        private static PricingCalculator instance = null;
        private static readonly object padlock = new object();

        private PricingCalculator()
        {

        }

        /// <summary>
        /// Singleton Implementation of the class
        /// </summary>
        public static PricingCalculator Instance
        {
            get
            {
                lock (padlock)
                {
                    if (instance == null)
                    {
                        instance = new PricingCalculator();
                    }
                    return instance;
                }
            }
        }

        /// <summary>
        /// Returns Total Price after calculation
        /// </summary>
        /// <param name="products"></param>
        /// <returns></returns>
        public int GetTotalPrice(List<Product> products)
        {
            int counterofA = 0;
            int priceofA = 50;
            int counterofB = 0;
            int priceofB = 30;
            int CounterofC = 0;
            int priceofC = 20;
            int CounterofD = 0;
            int priceofD = 15;
            foreach (Product pr in products)
            {
                if (pr.Id == "A" || pr.Id == "a")
                    counterofA = counterofA + 1;
                else if (pr.Id == "B" || pr.Id == "b")
                    counterofB = counterofB + 1;
                else if (pr.Id == "C" || pr.Id == "c")
                    CounterofC = CounterofC + 1;
                else if (pr.Id == "D" || pr.Id == "d")
                    CounterofD = CounterofD + 1;
            }
            int totalPriceofA = (counterofA / 3) * 130 + (counterofA % 3 * priceofA);
            int totalPriceofB = (counterofB / 2) * 45 + (counterofB % 2 * priceofB);
            int totalPriceofC = (CounterofC * priceofC);
            int totalPriceofD = (CounterofD * priceofD);
            return totalPriceofA + totalPriceofB + totalPriceofC + totalPriceofD;

        }
    }
}
