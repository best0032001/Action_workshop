using ContosoUniversity.Models;
using Microsoft.EntityFrameworkCore;
using workshop.Model;
using workshop.QueryableExtensions;

namespace Test
{
    [TestClass]
    public class UnitTest1
    {
        DbContextOptionsBuilder<ApplicationDBContext> optionsBuilder;
        ApplicationDBContext applicationDBContext;
        public UnitTest1()
        {
            var optionsBuilder = new DbContextOptionsBuilder<ApplicationDBContext>();
            optionsBuilder.UseSqlServer(@"Server=127.0.0.1;Database=workshop;user id=sa;password=Password[12345];Trust Server Certificate = true");
            applicationDBContext = new ApplicationDBContext(optionsBuilder.Options);
        }

        [TestMethod]
        public void TestGetPerson()
        {
            List<Person> peoples = applicationDBContext.People.ToList();
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

            List<Department> departments = applicationDBContext.Departments.AsSplitQuery().Include(i => i.Administrator).ToList();

            foreach (Department department in departments)
            {
                Console.Write("Department : " + department.Name);
                Console.WriteLine("  Administrator : " + department.Administrator.FullName);
            }
        }

        [TestMethod]
        public void TestGetStudentEnrollment()
        {
            List<Student> students = applicationDBContext.Students.AsSplitQuery().Include(students => students.Enrollments).ThenInclude(enrollment => enrollment.Course).ToList();
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
            List<Instructor> instructors = applicationDBContext.Instructors.Include(i => i.CourseAssignments).ThenInclude(c => c.Course).ToList();
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

        [TestMethod]
        public void TestPagingMobileFeedCourse()
        {
            int pageSize = 2;
            int nextIndex = 0;
            int previousIndex = 0;
            List<Course> courses = null;
            courses = getPagingMobileFeedCourse(pageSize, nextIndex, previousIndex);
            Assert.IsTrue(courses.Count == 2);
            foreach (Course course in courses)
            {
                Console.Write("course name : " + course.Title);
                Console.WriteLine(" course id : " + course.CourseID);
            }
            // next
            Console.WriteLine(" next page");
            nextIndex = courses[1].CourseID;
            courses = getPagingMobileFeedCourse(pageSize, nextIndex, previousIndex);
            Assert.IsTrue(courses.Count == 2);
            foreach (Course course in courses)
            {
                Console.Write("course name : " + course.Title);
                Console.WriteLine(" course id : " + course.CourseID);
            }
            // previous
            Console.WriteLine(" previous page");
            nextIndex = 0;
            previousIndex = courses[0].CourseID;
            courses = getPagingMobileFeedCourse(pageSize, nextIndex, previousIndex);
            Assert.IsTrue(courses.Count == 2);
            foreach (Course course in courses)
            {
                Console.Write("course name : " + course.Title);
                Console.WriteLine(" course id : " + course.CourseID);
            }

        }
        private List<Course> getPagingMobileFeedCourse(int pageSize, int nextIndex, int previousIndex)
        {
            List<Course> courses = null;

            if (nextIndex == 0 && previousIndex == 0)
            {
                courses = applicationDBContext.Courses.OrderBy(o => o.CourseID)
                   .Take(pageSize)
                   .ToList();
            }
            else if (nextIndex > 0)
            {
                courses = applicationDBContext.Courses.Where(w => w.CourseID > nextIndex)
                   .OrderBy(o => o.CourseID)
                   .Take(pageSize)
                   .ToList();
            }
            else if (previousIndex > 0)
            {
                courses = applicationDBContext.Courses.Where(w => w.CourseID < previousIndex)
                    .OrderByDescending(od => od.CourseID)
                    .Take(pageSize)
                    .OrderBy(o => o.CourseID)
                    .ToList();
            }
            return courses;
        }

        [TestMethod]
        public void TestPagingCourse()
        {
            int pageSize = 2;
            int pageInddex = 1;

            PagedResult<Course> pagedResult = applicationDBContext.Courses.OrderBy(o => o.CourseID).GetPaged(pageInddex, pageSize);
            Console.Write(" PageCount : " + pagedResult.TotalPages);
            Console.Write(" PageSize : " + pagedResult.PageSize);
            Console.Write(" CurrentPage : " + pagedResult.CurrentPage);
            Console.WriteLine(" RowCount : " + pagedResult.TotalItems);
            List<Course> courses = pagedResult.Rows.ToList();
            Assert.IsTrue(courses.Count == 2);
            foreach (Course course in courses)
            {
                Console.Write("course name : " + course.Title);
                Console.WriteLine(" course id : " + course.CourseID);
            }

            pageInddex = 2;
            pagedResult = applicationDBContext.Courses.OrderBy(o => o.CourseID).GetPaged(pageInddex, pageSize);
            Console.Write(" PageCount : " + pagedResult.TotalPages);
            Console.Write(" PageSize : " + pagedResult.PageSize);
            Console.Write(" CurrentPage : " + pagedResult.CurrentPage);
            Console.WriteLine(" RowCount : " + pagedResult.TotalItems);
            courses = pagedResult.Rows.ToList();
            Assert.IsTrue(courses.Count == 2);
            foreach (Course course in courses)
            {
                Console.Write("course name : " + course.Title);
                Console.WriteLine(" course id : " + course.CourseID);
            }

        }
    }
}