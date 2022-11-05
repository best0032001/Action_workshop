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
        public UnitTest1()
        {
            var optionsBuilder = new DbContextOptionsBuilder<ApplicationDBContext>();
            optionsBuilder.UseSqlServer(@"Server=127.0.0.1;Database=workshop;user id=sa;password=Password[12345];Trust Server Certificate = true");
            _applicationDBContext = new ApplicationDBContext(optionsBuilder.Options);
        }

        [TestMethod]
        public void TestGetPerson()
        {
            List<Person> peoples = _applicationDBContext.People.ToList();
            Assert.IsTrue(peoples.Count > 0);

            foreach (Person person in peoples)
            {
                switch (person)
                {
                    case Student:
                        Console.Write("Person : " + person.FullName);
                        Console.WriteLine("  is : student");
                        break;
                    case Instructor:
                        Console.Write("Person : " + person.FullName);
                        Console.WriteLine("  is : instructor");
                        break;
                }
            }
        }
        [TestMethod]
        public void TestGetDepartment()
        {

            List<Department> departments = _applicationDBContext.Departments.AsSplitQuery().Include(i => i.Administrator).ToList();

            foreach (Department department in departments)
            {
                Console.Write("Department : " + department.Name);
                Console.WriteLine("  Administrator : " + department.Administrator.FullName);
            }
        }

        [TestMethod]
        public void TestGetStudentEnrollment()
        {
            List<Student> students = _applicationDBContext.Students.AsSplitQuery().Include(students => students.Enrollments).ThenInclude(enrollment => enrollment.Course).ToList();
            foreach (Student student in students)
            {
                Console.WriteLine("students : " + student.FullName);
                foreach (Enrollment enrollment in student.Enrollments)
                {
                    Console.WriteLine("         : enrollment : " + enrollment.Course.Title);
                }
            }
        }

        [TestMethod]
        public void TestGetInstructorCourseAssignmentst()
        {
            List<Instructor> instructors = _applicationDBContext.Instructors.Include(i => i.CourseAssignments).ThenInclude(c => c.Course).ToList();
            foreach (Instructor instructor in instructors)
            {
                Console.WriteLine("instructor : " + instructor.FullName);
                List<Course> Courses = instructor.CourseAssignments.Select(s => s.Course).ToList();
                foreach (Course course in Courses)
                {
                    Console.WriteLine("           : CourseAssignments : " + course.Title);
                }
            }
        }
    }
}