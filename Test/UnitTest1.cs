using ContosoUniversity.Models;
using Microsoft.EntityFrameworkCore;
using workshop.Model;

namespace Test
{
    [TestClass]
    public class UnitTest1
    {

        [TestMethod]
        public void TestGetPerson()
        {

            var optionsBuilder = new DbContextOptionsBuilder<ApplicationDBContext>();
            // optionsBuilder.UseSqlServer(@"Server=.\;Database=EFCoreWebDemo;Persist Security Info=True;User ID=sa;Password=best_Mfec0032001");
            optionsBuilder.UseSqlServer(@"Server=127.0.0.1;Database=workshop;user id=sa;password=Password[12345];Trust Server Certificate = true");

            ApplicationDBContext _applicationDBContext = new ApplicationDBContext(optionsBuilder.Options);


            List<Person> _peopleList = _applicationDBContext.People.ToList();
            Assert.IsTrue(_peopleList.Count > 0);




        }
    }
}