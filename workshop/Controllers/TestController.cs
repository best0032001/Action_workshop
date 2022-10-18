using ITSC_API_GATEWAY_LIB;
using Microsoft.AspNetCore.Mvc;
using System.Net;
using workshop.Model.Entitys;

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

            return Ok(userEntity);
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
