namespace Catalog.API.Models
{
    public class Product
    {
        /*
        Default! = Burada default! ifadesi şu anlama gelir: 

        Default kelimesi, o tür için varsayılan değeri döndürür. Bir string için varsayılan değer null'dır. 

        !(null-forgiving operator) operatörü ise, derleyiciye:

        "Bu değerin null olabileceğini biliyorum ama bu durumu önemsemiyorum, kontrol etme" demenin bir yoludur. 

        Bu kullanımıyla default!, Description ve ImageFile özelliklerinin başlangıç değerlerinin null olabileceğini belirtiyor

        ancak bu özelliklerin ileride mutlaka bir değere atanacağını garanti ediyor.
        */

        public Guid Id { get; set; }

        public string Name { get; set; }

        public List<string> Category { get; set; }

        public string Description { get; set; } = default!;

        public string ImageFile { get; set; } = default!;

        public decimal Price { get; set; }

        public Product()
        {
            Category = new List<string>();
        }

        public Product(string name, List<string> category, string description, string imageFile, decimal price)
        {
            Name = name;
            Category = category;
            Description = description;
            ImageFile = imageFile;
            Price = price;
        }
    }
}
