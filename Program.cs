using System;
using System.Collections.Generic;
using System.Linq;

namespace NumNum
{
    class Program
    {
        static void Main(string[] args)
        {
            var menuItems = new List<MenuItem>()
            {
                // Hamburgers
                new MenuItem { Name = "Pretzel Bacon Pub Cheeseburger", Price = 5.59m },
                new MenuItem { Name = "Pretzel Bacon Pub Double", Price = 6.59m },
                new MenuItem { Name = "Pretzel Bacon Pub Triple", Price = 7.59m },

                new MenuItem { Name = "Jr. Bacon Cheeseburger", Price = 1.99m },
                new MenuItem { Name = "Jr. Cheeseburger Deluxe", Price = 1.89m },
                new MenuItem { Name = "Jr. Cheeseburger", Price = 1.79m },
                new MenuItem { Name = "Double Stack", Price = 2.49m },
                new MenuItem { Name = "Jr. Hamburger", Price = 1.39m },

                // Fries & Sides
                new MenuItem { Name = "Jr. Natural-Cut Fries", Price = 1.29m },
                new MenuItem { Name = "Small Natural-Cut Fries", Price = 1.89m },
                new MenuItem { Name = "Medium Natural-Cut Fries", Price = 2.29m },
                new MenuItem { Name = "Large Natural-Cut Fries", Price = 2.69m },

                // Frosty
                new MenuItem { Name = "Jr. Classic Chocolate Frosty", Price = 1.19m },
                new MenuItem { Name = "Small Classic Chocolate Frosty", Price = 1.69m },
                new MenuItem { Name = "Medium Classic Chocolate Frosty", Price = 1.99m },
                new MenuItem { Name = "Large Classic Chocolate Frosty", Price = 2.39m },

                // Chicken Sandwiches & Nuggets
                new MenuItem { Name = "Family Size Nuggets", Price = 9.99m },
            };


            // var menuItems = new List<MenuItem>()
            // {
            //     // Sandwiches & Meals
            //     new MenuItem { Name = "McRib", Price = 3.69m },
            //     new MenuItem { Name = "Big Mac", Price = 4.91m },
            //     new MenuItem { Name = "Bacon Quarter Pounder with Cheese", Price = 5.39m },
            //     new MenuItem { Name = "Quarter Pounder with Cheese", Price = 4.91m },

            //     new MenuItem { Name = "Cheeseburger", Price = 1.19m },
            //     new MenuItem { Name = "McDouble", Price = 1.99m },
            //     new MenuItem { Name = "Bacon McDouble", Price = 2.00m },

            //     new MenuItem { Name = "McChicken", Price = 1.00m },
            //     new MenuItem { Name = "4 Piece McNuggets", Price = 1.79m },
            //     new MenuItem { Name = "6 Piece McNuggets", Price = 2.39m },
            //     new MenuItem { Name = "10 Piece McNuggets", Price = 4.09m },
            //     new MenuItem { Name = "20 Piece McNuggets", Price = 5.99m },

            //     // Cookies
            //     new MenuItem { Name = "1 Cookie", Price = 0.69m },
            //     new MenuItem { Name = "2 Cookies", Price = 1.29m },
            //     new MenuItem { Name = "3 Pack of Cookies", Price = 1.80m },

            //     // Shakes

            //     // McFlurry
            //     new MenuItem { Name = "Regular Chips Ahoy! McFlurry", Price = 2.99m },

            //     // Pies
            //     new MenuItem { Name = "Apple Pie", Price = 1.19m },

            //     // French Fries
            //     new MenuItem { Name = "Small French Fries", Price = 1.59m },
            //     new MenuItem { Name = "Medium French Fries", Price = 2.19m },
            //     new MenuItem { Name = "Large French Fries", Price = 2.59m },
            // };

            var total = (decimal)18.66/*19.24*/;
        
            Calculate(0, 0, total, new List<MenuItem>(), menuItems);
        }

        private static void Calculate(int currentIndex, decimal runningTotal, decimal total, List<MenuItem> tempMenuItems, List<MenuItem> menuItems) 
        {
            if (runningTotal == total)
            {
                var lineItems = tempMenuItems
                    .Select(item => $"{item.Name} {item.Price}")
                    .ToList();

                Console.WriteLine(string.Join(", ", lineItems));
            }
            else
            {
                for (var i = currentIndex; i < menuItems.Count; i++)
                {
                    if (runningTotal + menuItems[i].Price > total)
                        continue;

                    tempMenuItems.Add(menuItems[i]);

                    Calculate(i + 1, runningTotal + menuItems[i].Price, total, tempMenuItems, menuItems);
                    
                    tempMenuItems.RemoveAt(tempMenuItems.Count - 1);
                }
            }
        }
    }
}
