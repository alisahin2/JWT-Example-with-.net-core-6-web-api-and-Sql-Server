using JwtExample.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace JwtExample.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeeController : ControllerBase
    {

        // First step: try with Postman = run this request and take the url and put it on the postman URL area. 
        // Second step: fill Headers tab: value parameter should be like this -> Bearer createdToken(eyJhbGciOiJIUzI1NiIsInR5cCI6IkpXVCJ9.eyJleHAiOjE2Nzk3MjczNjgsImlzcyI6ImFsaXNhaGluIiwiYXVkIjoiVXNlciJ9.hkyUlNzV6y9KRQnJBzYvBaVn0Jqpht-71-RCx2aqhGk)
        // Last step: run this get request
        // you will have "Authenticated with JWT"
        [Authorize]
        [HttpGet]
        [Route("GetData")]
        public string GetData()
        {
            return "Authenticated with JWT";
        }


        //if you want to run this request firstly run GetData()
        [HttpGet]
        [Route("Details")]
        public string Details()
        {
            return "Authenticated with JWT";
        }

        [Authorize]
        [HttpPost]
        public string AddUser(Users user)
        {
            return "User added with username" + user.Username;
        }
    }
}
