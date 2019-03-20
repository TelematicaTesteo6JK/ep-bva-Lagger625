using System;

namespace SoftwareTesting {

    /// <summary>
    /// Calculates price to pay taking into account wholesale discounts.
    /// Business rules are as follows:
    ///     1. For 7 or less products, there is no discount.
    ///     2. For 8 - 15 products, there is 10% discount.
    ///     3. For 16 - 20 products, there is 15% discount.
    ///     4. For 21 - 30 products, there is 22% discount.
    ///     5. For 31 - 100 products, there is 40% discount.
    ///     6. For 101 or more products, there is 70% discount.
    /// </summary>
    class Discounts {
        public static decimal GetPrice(int quantity, decimal pricePerUnit) {
            if (quantity <= 0)
                throw new ArgumentException("Quantity must be 1 or more.");
            if (quantity <= 7)
                return quantity * pricePerUnit;
            if (quantity <= 15)
                return quantity * pricePerUnit * .9m;
            if (quantity <= 20)
                return quantity * pricePerUnit * .85m;
            if (quantity <= 30)
                return quantity * pricePerUnit * .78m;
            if (quantity <= 100)
                return quantity * pricePerUnit * .6m;
            return quantity * pricePerUnit * .3m;
        }
    }
}
