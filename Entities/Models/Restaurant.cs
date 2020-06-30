using System;
using System.Collections.Generic;

namespace FastfoodCenter.Entities.Models
{
    public partial class Restaurant
    {
        public Restaurant()
        {
            RestaurantFoods = new HashSet<RestaurantFoods>();
        }

        public int Id { get; set; }
        public string Name { get; set; }
        public string Address { get; set; }
        public string ImageUrl { get; set; }
        public int Ratings { get; set; }
        public float RateStars { get; set; }

        public virtual ICollection<RestaurantFoods> RestaurantFoods { get; set; }
    }
}
