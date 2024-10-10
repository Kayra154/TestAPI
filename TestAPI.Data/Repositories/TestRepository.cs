using Dapper;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TestAPI.Entity.Modeller;
using TestAPI.Entity.Modeller.Dto;
using TestAPIProject.Data;
using System.Data.SqlClient;
using System.Data.Common;


namespace TestAPI.Data.Repositories
{
    public class TestRepository : ITestRepository
    {
        private readonly string _connectionString;

        public TestRepository(string connectionString)
        {
            _connectionString = connectionString;
        }

        private IDbConnection Connection => new SqlConnection(_connectionString);

        public IEnumerable<TestDTO> GetAll()
        {
            using (var dbConnection = Connection)
            {
                dbConnection.Open();
                var sql = "SELECT * FROM MyTest";
                return dbConnection.Query<TestDTO>(sql);
            }
        }

        public TestDTO GetById(int id)
        {
            using (var dbConnection = Connection)
            {
                dbConnection.Open();
                var sql = "SELECT * FROM MyTest WHERE Id = @Id";
                return dbConnection.QueryFirstOrDefault<TestDTO>(sql, new { Id = id });
            }
        }

        public TestDTO GetByName(string name)
        {
            using (var dbConnection = Connection)
            {
                dbConnection.Open();
                var sql = "SELECT * FROM MyTest WHERE Name = @Name";
                return dbConnection.QueryFirstOrDefault<TestDTO>(sql,new { Name = name });
            }

        }

        public void ChangeWorkDetail(int key, int daily, int weekly)
        {
            using (var dbConnection = Connection)
            {
                dbConnection.Open();
                var sql = "UPDATE MyTest SET dailyHours = @dailyHours, weeklyWorkdayAmount = @weeklyWorkdayAmount WHERE Id = @Id";
                dbConnection.QueryFirstOrDefault<TestDTO>(sql, new { Id = key, dailyHours=daily, weeklyWorkdayAmount=weekly });
            }
        }
        public void ChangeName(int key, string name, string url)
        {
            using (var dbConnection = Connection)
            {
                dbConnection.Open();
                var sql = "UPDATE MyTest SET Name = @Name, ImageUrl = @ImageUrl WHERE Id = @Id";
                dbConnection.QueryFirstOrDefault(sql, new { Id=key, Name = name, ImageUrl = url });
            }
        }

        public void Add(TestDTO testDto)
        {
            using (var dbConnection = Connection)
            {
                dbConnection.Open();
                var sql = "INSERT INTO MyTest (Name, dailyHours, weeklyWorkdayAmount, ImageUrl, CreateDate, UpdateDate) " +
                          "VALUES (@Name, @dailyHours, @weeklyWorkdayAmount, @ImageUrl, @CreateDate, @UpdateDate)";
                dbConnection.Execute(sql, new
                {
                    testDto.Name,
                    testDto.dailyHours,
                    testDto.weeklyWorkdayAmount,
                    testDto.ImageUrl,
                    CreateDate = DateTime.Now,
                    UpdateDate= DateTime.Now
                });
            }
        }

        public void Update(TestDTO testDto)
        {
            using (var dbConnection = Connection)
            {
                dbConnection.Open();
                var sql = "UPDATE MyTest SET Name = @Name, dailyHours = @dailyHours, weeklyWorkdayAmount = @weeklyWorkdayAmount, ImageUrl = @ImageUrl, UpdateDate = @UpdateDate WHERE Id = @Id";
                dbConnection.Execute(sql, new
                {
                    testDto.Id,
                    testDto.Name,
                    testDto.dailyHours,
                    testDto.weeklyWorkdayAmount,
                    testDto.ImageUrl,
                    UpdateDate = DateTime.Now
                });
            }
        }

        public void Delete(int id)
        {
            using (var dbConnection = Connection)
            {
                dbConnection.Open();
                var sql = "DELETE FROM MyTest WHERE Id = @Id";
                dbConnection.Execute(sql, new { Id = id });
            }
        }

        public void DeleteName(string name)
        {
            using (var dbConnection = Connection)
            {
                dbConnection.Open();
                var sql = "DELETE FROM MyTest WHERE Name = @Name";
                dbConnection.Execute(sql, new { Name = name });
            }
        }
    }
}
