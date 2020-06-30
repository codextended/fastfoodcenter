using System;
using System.Collections.Generic;

namespace FastfoodCenter.Entities.Models
{
    public partial class Food
    {
        public Food()
        {
            RestaurantFoods = new HashSet<RestaurantFoods>();
        }

        public int Id { get; set; }
        public string Name { get; set; }
        public string ImageUrl { get; set; }

        public virtual ICollection<RestaurantFoods> RestaurantFoods { get; set; }
    }
}
