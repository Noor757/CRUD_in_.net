using PracticeWebApp.Models;
using System.Drawing.Text;

namespace PracticeWebApp.Data
{
    public class ProductData
    {
        private const double V = 0.001;
        public static Random random = new Random();
        public static HashSet<int> availableNumbers = new HashSet<int>();
        public static List<Product> Products { get; } = new List<Product>();
        private static int GetUniqueRandomNumber()
        {
            int randomtemp;
            for (int i = 1; i <= 100; i++)
            {
                availableNumbers.Add(i);
            }
            do
            {
                randomtemp = availableNumbers.ElementAt(random.Next(availableNumbers.Count));
            } while (!availableNumbers.Remove(randomtemp));

            return randomtemp;
        }
        static ProductData()
        {
            Products.Add(new Product { Id = GetUniqueRandomNumber(), Name = "Product 1", Description = "xxxxxxx", Price = (decimal)V, CategoryIds = new List<int> { 1, 2 }});
            Products.Add(new Product { Id = GetUniqueRandomNumber(), Name = "Product 2", Description = "xxxxxxx", Price = (decimal)V, CategoryIds = new List<int> { 1 }});
            Products.Add(new Product { Id = GetUniqueRandomNumber(), Name = "Product 3", Description = "xxxxxxx", Price = (decimal)V, CategoryIds = new List<int> { 1, 2, 3 }});
            Products.Add(new Product { Id = GetUniqueRandomNumber(), Name = "Product 4", Description = "xxxxxxx", Price = (decimal)V, CategoryIds = new List<int> { 3 }});
            Products.Add(new Product { Id = GetUniqueRandomNumber(), Name = "Product 5", Description = "xxxxxxx", Price = (decimal)V, CategoryIds = new List<int> { 1, 3 }});
            Products.Add(new Product { Id = GetUniqueRandomNumber(), Name = "Product 6", Description = "xxxxxxx", Price = (decimal)V, CategoryIds = new List<int> { 4, 5 }});
            Products.Add(new Product { Id = GetUniqueRandomNumber(), Name = "Product 7", Description = "xxxxxxx", Price = (decimal)V, CategoryIds = new List<int> { 1, 2, 4 }});
            Products.Add(new Product { Id = GetUniqueRandomNumber(), Name = "Product 8", Description = "xxxxxxx", Price = (decimal)V, CategoryIds = new List<int> { 1, 5 }});
            Products.Add(new Product { Id = GetUniqueRandomNumber(), Name = "Product 9", Description = "xxxxxxx", Price = (decimal)V, CategoryIds = new List<int> { 4, 5, 3 }});
            Products.Add(new Product { Id = GetUniqueRandomNumber(), Name = "Product 10",Description = "xxxxxxx", Price = (decimal)V, CategoryIds = new List<int> { 5 }});
            // Add more default categories as needed
        }
        public static void AddProduct(Product product)
        {
            Products.Add(product);
            product.CategoryIds = new List<int>();
            product.CategoryIds.Add(product.AddCategoryNO);
            product.Id = GetUniqueRandomNumber();
        }
        public static void UpdateProduct(Product ProducttoUpdate)
        {
            // Finding the category in the list by its Id
            Product existingProduct = Products.FirstOrDefault(c => c.Id == ProducttoUpdate.Id);

            if (existingProduct != null)
            {
                // Updating the properties of the existing category
                existingProduct.Name = ProducttoUpdate.Name;
                existingProduct.Description = ProducttoUpdate.Description;
                existingProduct.Price = ProducttoUpdate.Price;
                existingProduct.CategoryIds.Add(ProducttoUpdate.AddCategoryNO);
                existingProduct.CategoryIds.Remove(ProducttoUpdate.RemoveCategoryNO);
            }
        }
        public static void DeleteProduct(Product productToDelete)
        {
            Product existingProduct = Products.FirstOrDefault(c => c.Id == productToDelete.Id);
            if (existingProduct != null)
            {
                Products.Remove(existingProduct);
                int deletedNumber = existingProduct.Id;
                availableNumbers.Add(deletedNumber);
            }

        }

    }
}

