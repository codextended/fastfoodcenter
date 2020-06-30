using System;
using System.Collections.Generic;

namespace FastfoodCenter.Entities.Models
{
    public partial class RestaurantFoods
    {
        public int Id { get; set; }
        public int RestaurantId { get; set; }
        public int FoodId { get; set; }

        public virtual Food Food { get; set; }
        public virtual Restaurant Restaurant { get; set; }
    }
}
