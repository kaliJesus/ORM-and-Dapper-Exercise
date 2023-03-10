using System;
using System.Data;
using System.IO;
using MySql.Data.MySqlClient;
using Microsoft.Extensions.Configuration;
using Microsoft.VisualBasic;

namespace ORM_Dapper
{
    public class Program
    {
        static void Main(string[] args)
        {
            var config = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("jsconfig1.json")
                .Build();

            string connString = config.GetConnectionString("DefaultConnection");

            IDbConnection conn = new MySqlConnection(connString);
            var departmentRepo = new DapperDepartmentRepository(conn);

            var departments = departmentRepo.GetAllDepartments();

            foreach (var department in departments) 
            {
                Console.WriteLine(department.DepartmentID);
                Console.WriteLine(department.Name);
                Console.WriteLine();
            }

            var productRepository = new DapperProductRepository(conn);
            var myProducts = productRepository.GetAllProducts();
            foreach (var products in myProducts)
            {
                Console.WriteLine(products.ProductID);
                Console.WriteLine(products.Name);
                Console.WriteLine(products.Price);
                Console.WriteLine(products.CategoryID);
                Console.WriteLine(products.OnSale);
                Console.WriteLine(products.StockLevel);

            }

        }
    }
}
