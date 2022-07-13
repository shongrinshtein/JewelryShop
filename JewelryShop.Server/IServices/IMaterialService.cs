using JewelryShop.Data.Models;

namespace JewelryShop.Server.IServices
{
    public interface IMaterialService : IService<Material>
    {
        Task ProduceWithMaterial(Material material);
    }
}
