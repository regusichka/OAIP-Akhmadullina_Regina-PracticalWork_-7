using System;

namespace oaip.pract2
{ 
    public class DynamicContainer<T>
    {
     public class Restaurant
        {
            public int Number;
            public string Name;
            public string Category;
            public decimal Price;
            public string Ingredients;

            public Restaurant(int number, string name, string category, decimal price, string ingredients)
            {
                Number = number;
                Name = name;
                Categoryc = category;
                Price = price;
                Ingredients = ingredients;
            }
        }
    }
}
