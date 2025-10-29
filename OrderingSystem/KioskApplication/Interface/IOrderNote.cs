namespace OrderingSystem.KioskApplication.Interface
{
    internal interface IOrderNote
    {
        void displayOrderNotice();

        string getNote { get; set; }
    }
}
