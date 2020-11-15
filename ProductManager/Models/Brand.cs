namespace ProductManager.Models
{
    public class Brand : IModel
    {
        public Brand(int id, string name, string street, string zip, string locality, string country)
        {
            Id = id;
            Name = name;
            Street = street;
            Zip = zip;
            Locality = locality;
            Country = country;
        }

        public int Id { get; set; }
        public string Name { get; set; }
        public string Street { get; set; }
        public string Zip { get; set; }
        public string Locality { get; set; }
        public string Country { get; set; }

        public override bool Equals(object obj)
        {
            var brand = obj as Brand;

            if(brand != null)
            {
                return
                    Name == brand.Name &&
                    Street == brand.Street &&
                    Zip == brand.Zip &&
                    Locality == brand.Locality &&
                    Country == brand.Country;
            } 
            else
            {
                return false;
            }
        }
    }
}