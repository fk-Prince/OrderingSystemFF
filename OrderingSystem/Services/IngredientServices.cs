using OrderingSystem.Repository.Ingredients;

namespace OrderingSystem.Services
{
    public class IngredientServices
    {

        IIngredientRepository ingredientRepository;

        public IngredientServices()
        {
            ingredientRepository = new IngredientRepository();
        }
    }
}
