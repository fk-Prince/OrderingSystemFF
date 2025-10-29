namespace OrderingSystem.Model
{
    public class OrderItemModel
    {

        public int OrderItemId { get; protected set; }
        public string Note { get; protected set; }
        public string MenuName { get; protected set; }
        public int PurchaseQty { get; protected set; }
        public string SizeName { get; protected set; }
        public double Price { get; protected set; }
        public string FlavorName { get; protected set; }
        public bool NoteApproved { get; set; }

        public double getTotal()
        {
            return Price * PurchaseQty;
        }
        public static OrderItemBuilder Builder() => new OrderItemBuilder();
        public interface IOrderItemBuilder
        {
            OrderItemBuilder WithOrderItemId(int id);
            OrderItemBuilder WithNote(string note);
            OrderItemBuilder WithMenuName(string name);
            OrderItemBuilder WithPurchaseQty(int qty);
            OrderItemBuilder WithSizeName(string size);
            OrderItemBuilder WithPrice(double price);
            OrderItemBuilder WithFlavorName(string flavor);
            OrderItemBuilder WithNoteApproved(bool approved);

            OrderItemModel Build();
        }

        public class OrderItemBuilder : IOrderItemBuilder
        {
            public OrderItemModel oim;
            public OrderItemBuilder()
            {
                oim = new OrderItemModel();
            }

            public OrderItemModel Build()
            {
                return oim;
            }

            public OrderItemBuilder WithFlavorName(string flavor)
            {
                oim.FlavorName = flavor;
                return this;
            }

            public OrderItemBuilder WithMenuName(string name)
            {
                oim.MenuName = name;
                return this;
            }

            public OrderItemBuilder WithNote(string note)
            {
                oim.Note = note;
                return this;
            }

            public OrderItemBuilder WithNoteApproved(bool approved)
            {
                oim.NoteApproved = approved;
                return this;
            }

            public OrderItemBuilder WithOrderItemId(int id)
            {
                oim.OrderItemId = id;
                return this;
            }

            public OrderItemBuilder WithPrice(double price)
            {
                oim.Price = price;
                return this;
            }

            public OrderItemBuilder WithPurchaseQty(int qty)
            {
                oim.PurchaseQty = qty;
                return this;
            }

            public OrderItemBuilder WithSizeName(string size)
            {
                oim.SizeName = size;
                return this;
            }
        }
    }
}

