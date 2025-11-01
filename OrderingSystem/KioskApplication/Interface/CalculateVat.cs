namespace OrderingSystem.KioskApplication.Interface
{
    public class CalculateVat
    {

        // vat in ph
        public static double VAT = 0.12;
        /// <summary>
        /// 
        /// </summary>
        /// <param name="totalPrice">is a price including the discount</param>
        /// <returns>total amount of with vat</returns>
        public static double VatCalulator(double totalPrice)
        {
            return totalPrice + (totalPrice * VAT);
        }
    }

}
