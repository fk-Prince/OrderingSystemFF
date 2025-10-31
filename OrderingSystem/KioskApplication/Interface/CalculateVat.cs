namespace OrderingSystem.KioskApplication.Interface
{
    public class CalculateVat
    {
        public static double VAT = 0.12;
        public static double VatCalulator(double totalPrice)
        {
            return totalPrice + (totalPrice * VAT);
        }
    }

}
