using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TestAPI.Entity.Modeller.Dto;

namespace TestAPI.Buisness.Services
{
    public interface ITestService
    {
        IEnumerable<TestDTO> GetAllTests();

        TestDTO GetTestById(int id);

        TestDTO GetTestByName(string name);

        void CreateTest(TestDTO test);

        void UpdateTest(TestDTO test);

        void UpdateWorkDetail(int key, int daily, int weekly);

        void UpdateName(int key, string name, string url);

        void DeleteTest(int id);

        void DeleteTestByName(string name);
        
    }
}
