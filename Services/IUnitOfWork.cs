using FastfoodCenter.Entities.Models;

namespace FastfoodCenter.Services
{
    public interface IUnitOfWork
    {
         IRepository<Food> Foods { get; }
         IRepository<Restaurant> Restaurants { get; }
         IRepository<RestaurantFoods> RestaurantFoods { get; }
         IRepository<User> Users { get; }

         void Save();
    }
}