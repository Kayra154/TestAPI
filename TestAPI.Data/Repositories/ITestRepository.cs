using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TestAPI.Entity.Modeller;
using TestAPI.Entity.Modeller.Dto;
using System.Data.SqlClient;
using System.Xml.Serialization;


namespace TestAPI.Data.Repositories
{
    public interface ITestRepository
    {
        IEnumerable<TestDTO> GetAll();

        TestDTO GetById(int id);

        TestDTO GetByName(string name);

        void Add(TestDTO test);

        void Update(TestDTO test);

        void ChangeWorkDetail(int key,int daily, int weekly);

        void ChangeName(int key, string name, string url);

        void Delete(int id);

        public void DeleteName(string name);
    }
}
