using FastfoodCenter.Data;
using FastfoodCenter.Entities.Models;

namespace FastfoodCenter.Services
{
    public class UnitOfWork : IUnitOfWork
    {
        private FastfoodCenterContext _context;
        private BaseRepository<User> _user;
        private BaseRepository<Food>  _food;
        private BaseRepository<Restaurant> _restaurant;
        private BaseRepository<RestaurantFoods> _restaurantFoods;

        public UnitOfWork(FastfoodCenterContext dbcontext)
        {
            _context = dbcontext;
        }

        public IRepository<User> Users 
        {
            get
            {
                return _user ?? (_user = new BaseRepository<User>(_context));
            }
        }

        public IRepository<Food> Foods 
        {
            get
            {
                return _food ?? (_food = new BaseRepository<Food>(_context));
            }
        }

        public IRepository<Restaurant> Restaurants
        {
            get
            {
                return _restaurant ?? (_restaurant = new BaseRepository<Restaurant>(_context));
            }
        }

        public IRepository<RestaurantFoods> RestaurantFoods 
        {
            get
            {
                return _restaurantFoods ?? (_restaurantFoods = new BaseRepository<RestaurantFoods>(_context));
            }
        }

        public void Save()
        {
            _context.SaveChanges();
        }
    }
}