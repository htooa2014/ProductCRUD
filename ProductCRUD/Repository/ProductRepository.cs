using Microsoft.Data.SqlClient;
using ProductCRUD.Models;
using System.Data;
using Microsoft.Extensions.Configuration;
using Dapper;

namespace ProductCRUD.Repository
{
    public class ProductRepository
    {
        private readonly string _connectionString = string.Empty;

        public ProductRepository(IConfiguration configuration)
        {
            _connectionString = configuration.GetConnectionString("DefaultConnection") ?? string.Empty;
        }

        private IDbConnection Connection => new SqlConnection(_connectionString);

        public IEnumerable<Product> GetAllProducts()
        {
            using var db = Connection;
            return db.Query<Product>("SELECT * FROM Products WHERE IsDeleted=0 ORDER BY Created ASC");
        }

        public Product GetProductById(int id)
        {
            using var db = Connection;
            var product = db.QuerySingleOrDefault<Product>("SELECT * FROM Products WHERE IsDeleted=0 AND Id = @Id", new { Id = id });

            if (product == null)
            {
                throw new KeyNotFoundException($"Product with ID {id} not found.");
            }

            return product;

        }

        public void AddProduct(Product product)
        {
            using var db = Connection;
            string sql = "INSERT INTO Products (Name,Description, Price,IsDeleted) VALUES (@Name,@Description, @Price,0)";
            db.Execute(sql, product);
        }

        public void UpdateProduct(Product product)
        {
            using var db = Connection;
            string sql = "UPDATE Products SET Name = @Name, Description=@Description,Price = @Price WHERE Id = @Id";
            db.Execute(sql, product);
        }

        public void DeleteProduct(int id)
        {
            using var db = Connection;
            string sql = "UPDATE Products SET IsDeleted=1 WHERE Id = @Id";
            db.Execute(sql, new { Id = id });
        }
    }
}
