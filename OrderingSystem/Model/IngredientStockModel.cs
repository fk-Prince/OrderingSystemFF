namespace OrderingSystem.Model
{
    public class IngredientStockModel : IngredientModel
    {
        public int IngredientStockId { get; set; }
        public string ActionReaset { get; set; }

        public interface IIngredientStockModel
        {
            IngredientStockBuilder SetIngredientName(string ingredientName);
            IngredientStockBuilder SetIngredientStockId(int id);
            IngredientStockBuilder SetIngredient_id(int ingredient_id);
            IngredientStockBuilder SetIngredientQuantity(int ingredientQuantity);
            IngredientStockBuilder SetIngredientUnit(string ingredientUnit);
            IngredientStockBuilder SetActionReason(string ingredientUnit);

            IngredientStockModel Build();
        }

        public static new IngredientStockBuilder Builder() => new IngredientStockBuilder();


        public class IngredientStockBuilder : IIngredientStockModel
        {
            private IngredientStockModel ingredientStock = new IngredientStockModel();
            public IngredientStockBuilder SetIngredientName(string ingredientName)
            {
                ingredientStock.ingredientName = ingredientName;
                return this;
            }
            public IngredientStockBuilder SetIngredient_id(int ingredient_id)
            {
                ingredientStock.ingredientId = ingredient_id;
                return this;
            }
            public IngredientStockModel Build()
            {
                return ingredientStock;
            }

            public IngredientStockBuilder SetIngredientUnit(string ingredientUnit)
            {
                ingredientStock.ingredientUnit = ingredientUnit;
                return this;
            }

            public IngredientStockBuilder SetIngredientQuantity(int ingredientQuantity)
            {
                ingredientStock.ingredientQuantity = ingredientQuantity;
                return this;
            }

            public IngredientStockBuilder SetIngredientStockId(int id)
            {
                ingredientStock.IngredientStockId = id;
                return this;
            }

            public IngredientStockBuilder SetActionReason(string ingredientUnit)
            {
                ingredientStock.ActionReaset = ingredientUnit;
                return this;
            }
        }
    }
}
