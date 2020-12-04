using System.Collections.Generic;

namespace SimpleStore.DataModel.Model
{
    public class Location
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public int Stock { get; set; }

        public ICollection<Order> Orders { get; set; }

    }
}