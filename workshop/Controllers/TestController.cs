using ContosoUniversity.Models;
using ITSC_API_GATEWAY_LIB;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Net;
using workshop.Model;
using workshop.Model.Entitys;
using workshop.QueryableExtensions;

namespace workshop.Controllers
{
    [Route("api/")]
    [ApiController]
    public class TestController : ControllerBase
    {
        public TestController()
        {
        }


        /// <summary>
        /// API สำหรับ ดึง User
        /// </summary>
        /// <remarks>
        ///  demo [{OrganizationID:0,BudgetYear:0,BudgetName:0,BudgetCode:0,BudgetReferenceCode:0} , {OrganizationID:0,BudgetYear:0,BudgetName:0,BudgetCode:0,BudgetReferenceCode:0} ]
        /// </remarks>
        [HttpGet("v1/User")]
        [ProducesResponseType(typeof(UserEntity), (int)HttpStatusCode.OK)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> getTest()
        {
            UserEntity userEntity = new();

            userEntity.FullName = "test";

            var optionsBuilder = new DbContextOptionsBuilder<ApplicationDBContext>();
            optionsBuilder.UseSqlServer(@"Server=127.0.0.1;Database=workshop;user id=sa;password=Password[12345];Trust Server Certificate = true");
            var applicationDBContext = new ApplicationDBContext(optionsBuilder.Options);

            int pageSize = 2;
            int pageInddex = 1;

            PagedResult<Course> pagedResult = applicationDBContext.Courses.OrderBy(o => o.CourseID).GetPaged(pageInddex, pageSize);

            return Ok(pagedResult);
        }

        /// <summary>
        /// API สำหรับ เพิ่ม User
        /// </summary>
        /// <remarks>
        ///  demo [{OrganizationID:0,BudgetYear:0,BudgetName:0,BudgetCode:0,BudgetReferenceCode:0} , {OrganizationID:0,BudgetYear:0,BudgetName:0,BudgetCode:0,BudgetReferenceCode:0} ]
        /// </remarks>
        [HttpPost("v1/User")]
        [ProducesResponseType(typeof(UserEntity), (int)HttpStatusCode.OK)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> addTest([FromBody] UserEntity model)
        {
            UserEntity userEntity = new();

            userEntity.FullName = "test";

            return Ok(userEntity);
        }
    }


}
