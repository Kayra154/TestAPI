using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TestAPI.Data.Repositories;
using TestAPI.Entity.Modeller.Dto;

namespace TestAPI.Buisness.Services
{
    public class TestService : ITestService
    {
        private readonly ITestRepository _testRepository;
        

        public TestService(ITestRepository testRepository)
        {
            _testRepository = testRepository;
        }

        public IEnumerable<TestDTO> GetAllTests()
        {
            return _testRepository.GetAll();
        }

        public TestDTO GetTestById(int id)
        {
            return _testRepository.GetById(id);
        }

        public TestDTO GetTestByName(string name)
        {
            return _testRepository.GetByName(name);
        }

        public void CreateTest(TestDTO test)
        {
            _testRepository.Add(test);
        }

        public void UpdateTest(TestDTO test)
        {
            _testRepository.Update(test);
        }

        public void UpdateWorkDetail(int key, int daily, int weekly)
        {
            _testRepository.ChangeWorkDetail(key, daily, weekly);
        }
        public void UpdateName(int key, string name, string url)
        {
            _testRepository.ChangeName(key, name, url);
        }

        public void DeleteTest(int id)
        {
            _testRepository.Delete(id);
        }

        public void DeleteTestByName(string name)
        {
            _testRepository.DeleteName(name);
        }
    }
}
