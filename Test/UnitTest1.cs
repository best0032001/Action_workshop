using ContosoUniversity.Models;
using Microsoft.EntityFrameworkCore;
using workshop.Model;

namespace Test
{
    [TestClass]
    public class UnitTest1
    {
        DbContextOptionsBuilder<ApplicationDBContext> optionsBuilder;
        ApplicationDBContext _applicationDBContext;
        public  UnitTest1()
        {
            var optionsBuilder = new DbContextOptionsBuilder<ApplicationDBContext>();
            optionsBuilder.UseSqlServer(@"Server=127.0.0.1;Database=workshop;user id=sa;password=Password[12345];Trust Server Certificate = true");
            _applicationDBContext = new ApplicationDBContext(optionsBuilder.Options);
        }

        [TestMethod]
        public void TestGetPerson()
        {
            List<Person> _peoples = _applicationDBContext.People.ToList();
            Assert.IsTrue(_peoples.Count > 0);

            foreach (Person person in _peoples)
            {
                Console.WriteLine("Person : " + person.FullName);
            }
 
        }
        [TestMethod]
        public void TestGetDepartment()
        {
          
            List<Department> _departments = _applicationDBContext.Departments.AsSplitQuery().Include(i => i.Administrator).ToList();

            foreach (Department department in _departments)
            {
                Console.Write("Department : " + department.Name);
                Console.WriteLine("  Administrator : " + department.Administrator.FullName);
            }
        }
    }
}