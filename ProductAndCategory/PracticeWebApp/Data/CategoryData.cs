using PracticeWebApp.Models;

namespace PracticeWebApp.Data
{
    public class CategoryData
    {
        public static Random random = new Random();
        public static HashSet<int> availableNumbers = new HashSet<int>();
        
    public static List<Category> Categories { get; } = new List<Category>();
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
    static CategoryData()
        {
            Categories.Add(new Category { Id = GetUniqueRandomNumber(), Name = "Category 1", ProductIds = new List<int> {1, 2, 3, 5, 7, 8 }});
            Categories.Add(new Category { Id = GetUniqueRandomNumber(), Name = "Category 2", ProductIds = new List<int> {1, 3, 7 }});
            Categories.Add(new Category { Id = GetUniqueRandomNumber(), Name = "Category 3", ProductIds = new List<int> {3, 4, 5, 9 }});
            Categories.Add(new Category { Id = GetUniqueRandomNumber(), Name = "Category 4", ProductIds = new List<int> {6, 7, 9  }});
            Categories.Add(new Category { Id = GetUniqueRandomNumber(), Name = "Category 5", ProductIds = new List<int> { 6, 8, 9, 10 }});
            // Add more default categories as needed
        }
        public static void AddCategory(Category category)
        {
            Categories.Add(category);
            category.ProductIds = new List<int>();
            category.ProductIds.Add(category.AddProductNO);
            category.Id = GetUniqueRandomNumber();
        }
        public static void UpdateCategory(Category categoryToUpdate)
        {
            // Finding the category in the list by its Id
            Category existingCategory = Categories.FirstOrDefault(c => c.Id == categoryToUpdate.Id);

            if (existingCategory != null)
            {
                // Updating the properties of the existing category
                existingCategory.Name = categoryToUpdate.Name;
                existingCategory.ProductIds.Add(categoryToUpdate.AddProductNO);
                existingCategory.ProductIds.Remove(categoryToUpdate.RemoveProductNO);
            }
        }
        public static void DeleteCategory(Category categoryToDelete)
        {
            Category existingCategory = Categories.FirstOrDefault(c => c.Id == categoryToDelete.Id);
            if (existingCategory != null)
            {
                Categories.Remove(existingCategory);
                int deletedNumber = existingCategory.Id;
                availableNumbers.Add(deletedNumber);
            }
            
        }

    }
}
