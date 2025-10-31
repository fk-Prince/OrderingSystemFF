namespace OrderingSystem.Model
{
    public class IngredientModel
    {
        protected int ingredientId;
        protected int ingredientQuantity;
        protected string ingredientName;
        protected string ingredientUnit;

        public string IngredientName { get => ingredientName; }
        public string IngredientUnit { get => ingredientUnit; }
        public int Ingredient_id { get => ingredientId; }
        public int IngredientQuantity { get => ingredientQuantity; }

        public interface IIngredientModel
        {
            IngredientBuilder SetIngredientName(string ingredientName);
            IngredientBuilder SetIngredient_id(int ingredient_id);
            IngredientBuilder SetIngredientQuantity(int ingredientQuantity);
            IngredientBuilder SetIngredientUnit(string ingredientUnit);
            IngredientModel Build();
        }

        public static IngredientBuilder Builder() => new IngredientBuilder();


        public class IngredientBuilder : IIngredientModel
        {
            private IngredientModel ingredientModel = new IngredientModel();
            public IngredientBuilder SetIngredientName(string ingredientName)
            {
                ingredientModel.ingredientName = ingredientName;
                return this;
            }
            public IngredientBuilder SetIngredient_id(int ingredient_id)
            {
                ingredientModel.ingredientId = ingredient_id;
                return this;
            }
            public IngredientModel Build()
            {
                return ingredientModel;
            }

            public IngredientBuilder SetIngredientUnit(string ingredientUnit)
            {
                ingredientModel.ingredientUnit = ingredientUnit;
                return this;
            }

            public IngredientBuilder SetIngredientQuantity(int ingredientQuantity)
            {
                ingredientModel.ingredientQuantity = ingredientQuantity;
                return this;
            }

        }

    }
}
