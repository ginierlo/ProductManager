namespace ProductManager.Models
{
    public class Product : IModel
    {
        public Product(int id, string name, Brand brand, Category category, decimal weight, decimal price)
        {
            Id = id;
            Name = name;
            Brand = brand;
            Category = category;
            Weight = weight;
            Price = price;
        }

        public int Id { get; set; }
        public string Name { get; set; }
        public Brand Brand { get; set; }
        public Category Category { get; set; }
        public decimal Weight { get; set; }
        public decimal Price { get; set; }

        public override bool Equals(object obj)
        {
            var product = obj as Product;

            if (product != null)
            {
                return
                    Name == product.Name &&
                    Brand.Equals(product.Brand) &&
                    Category == product.Category &&
                    Weight == product.Weight &&
                    Price == product.Price;
            }
            else
            {
                return false;
            }
        }
    }
}
