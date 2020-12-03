using System;

namespace NumNum
{
    public class MenuItem
    {
        public string Name { get; set; }
        public decimal Price { get; set; }

        public override bool Equals(object obj)
        {
            return obj is MenuItem item &&
                   Name == item.Name &&
                   Price == item.Price;
        }

        public override int GetHashCode()
        {
            return HashCode.Combine(Name, Price);
        }
    }
}