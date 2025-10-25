using System.Data;
using OrderingSystem.Repository.Reports;

namespace OrderingSystem.Services
{
    public class InventoryServices
    {
        private IInventoryReportsRepository inventoryReportsRepository;
        public InventoryServices(IInventoryReportsRepository inventoryReportsRepository)
        {
            this.inventoryReportsRepository = inventoryReportsRepository;

        }
        public DataView getTrackingIngredients()
        {
            return inventoryReportsRepository.getIngredientTrackerView();
        }
        public DataView getIngredientExpiry()
        {
            return inventoryReportsRepository.getIngredientExpiry();
        }
        public DataView getInventorySummaryReports()
        {
            return inventoryReportsRepository.getInventoryReports();
        }
        public DataView getIngredientsUsage()
        {
            return inventoryReportsRepository.getIngredientsUsage();
        }

        public DataView getMenuPopularity()
        {
            return inventoryReportsRepository.getMenuPopularity();
        }
        public DataView getMenuPerformance()
        {
            return inventoryReportsRepository.getMenuPerformance();
        }
    }
}
