using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Security.Cryptography;
using System.Text;

namespace Shop
{
    public class SqlOperations
    {
        static SqlConnection sqlConnection = Connection.GetConnection();
        public static string Title = string.Empty;

        //Выборка начальных продуктов
        public static List<Product> SelectStartProducts()
        {
            List<Product> products = new List<Product>();
            try
            {
                using (SqlCommand cmd = new SqlCommand("SELECT * FROM [Product] JOIN [Category] ON " +
                "[Product].[idCategory] = [Category].[idCategory] WHERE [Product].[idCategory] = 1", sqlConnection))
                {
                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            products.Add(new Product(reader["ImageName"].ToString(), reader["ProductName"].ToString(),
                                int.Parse(reader["Price"].ToString())));
                            Title = reader["CategoryName"].ToString();
                        }
                        reader.Close();
                    }
                }
            }
            catch (System.Exception)
            {
            }
            return products;
        }

        //Выборка продуктов по категории
        public static List<Product> SelectProducts(string category)
        {
            List<Product> products = new List<Product>();
            try
            {
                using (SqlCommand cmd = new SqlCommand($"SELECT * FROM [Product] JOIN [Category] ON " +
                $"[Product].[idCategory] = [Category].[idCategory] WHERE [Product].[idCategory] = {category}", sqlConnection))
                {
                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            products.Add(new Product(reader["ImageName"].ToString(), reader["ProductName"].ToString(),
                                int.Parse(reader["Price"].ToString())));
                            Title = reader["CategoryName"].ToString();
                        }
                        reader.Close();
                    }
                }
            }
            catch (System.Exception)
            {
            }
            return products;
        }

        //Добавление категории
        public static bool AddCategory(string categoryname)
        {
            try
            {
                using (SqlCommand cmd = new SqlCommand($"INSERT INTO [Category] VALUES('{categoryname}')", sqlConnection))
                {
                    cmd.ExecuteNonQuery();
                }
            }
            catch (System.Exception)
            {
                return false;
            }
            return true;
        }


        //Получение id продукта
        public static string GetProductId(string productname)
        {
            string idProduct = string.Empty;
            try
            {
                using (SqlCommand cmd = new SqlCommand($"SELECT * FROM [Product] " +
                        $"WHERE [Product].[ProductName] = '{productname}'", sqlConnection))
                {
                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            idProduct = reader["idProduct"].ToString();
                        }
                        reader.Close();
                    }
                }
            }
            catch (System.Exception) { }
            return idProduct;
        }

        //Получение категорий
        public static List<Category> GetCategory()
        {
            List<Category> categories = new List<Category>();
            try
            {
                using (SqlCommand cmd = new SqlCommand("SELECT * FROM [Category]", sqlConnection))
                {
                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            categories.Add(new Category(reader["CategoryName"].ToString()));
                            categories.Last().idCategory = int.Parse(reader["idCategory"].ToString());
                        }
                        reader.Close();
                    }
                }
            }
            catch (System.Exception) { }
            return categories;
        }

        //Удаление категории
        public static bool DeleteCategory(string categoryname)
        {
            try
            {
                using (SqlCommand cmd = new SqlCommand($"DELETE FROM [Category] WHERE [Category].[CategoryName] = '{categoryname}'", sqlConnection))
                {
                    cmd.ExecuteNonQuery();
                    return true;
                }
            }
            catch (System.Exception) { }
            return false;
        }

        //Получение id категории
        public static string GetCategoryId(string categoryname)
        {
            string idCategory = string.Empty;
            try
            {
                using (SqlCommand cmd = new SqlCommand($"SELECT * FROM [Category] " +
                        $"WHERE [Category].[CategoryName] = '{categoryname}'", sqlConnection))
                {
                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            idCategory = reader["idCategory"].ToString();
                        }
                        reader.Close();
                    }
                }
            }
            catch (System.Exception) { }
            return idCategory;
        }

        //Добавление продукта
        public static bool AddProduct(string productname, int price, string imagename, string idCategory)
        {
            try
            {
                using (SqlCommand cmd = new SqlCommand($"INSERT INTO [Product] VALUES('{productname}', '{imagename}', {price}, " +
                    $"{idCategory})", sqlConnection))
                {
                    cmd.ExecuteNonQuery();
                }
            }
            catch (System.Exception)
            {
                return false;
            }
            return true;
        }

        //Удаление продукта
        public static bool DeleteProduct(string idProduct)
        {
            try
            {
                using (SqlCommand cmd = new SqlCommand($"DELETE FROM [Product] WHERE [Product].[idProduct] = {idProduct}", sqlConnection))
                {
                    cmd.ExecuteNonQuery();
                    return true;
                }
            }
            catch (System.Exception) { }
            return false;
        }

        //Существует ли категория
        public static bool isCategoryExist(string category)
        {
            try
            {
                using (SqlCommand cmd = new SqlCommand($"SELECT * FROM [Category] " +
                          $"WHERE [Category].[CategoryName] = '{category}'", sqlConnection))
                {
                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            return true;
                        }
                        reader.Close();
                    }
                }

            }
            catch (System.Exception) { }

            return false;
        }

        //Выборка продуктов по названию
        public static List<Product> SelectExistProducts(string productname)
        {
            List<Product> products = new List<Product>();
            try
            {
                using (SqlCommand cmd = new SqlCommand($"SELECT * FROM [Product]", sqlConnection))
                {
                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            if (reader["ProductName"].ToString().ToLower().Contains(productname.ToLower()))
                            {
                                products.Add(new Product(reader["ImageName"].ToString(), reader["ProductName"].ToString(),
                               int.Parse(reader["Price"].ToString())));
                            }
                        }
                        reader.Close();
                    }
                }
            }
            catch (System.Exception){}
            return products;
        }


        //Удаление всех продуктов в категории
        public static bool DeleteAllProductInCategory(string categoryname)
        {
            try
            {
                using (SqlCommand cmd = new SqlCommand($"DELETE [Product] FROM [Product] JOIN [Category] ON " +
                    $"[Product].[idCategory] = [Category].[idCategory] WHERE [Category].[CategoryName] = '{categoryname}'", sqlConnection))
                {
                    cmd.ExecuteNonQuery();
                    return true;
                }
            }
            catch (System.Exception) { }
            return false;
        }
    }
}
