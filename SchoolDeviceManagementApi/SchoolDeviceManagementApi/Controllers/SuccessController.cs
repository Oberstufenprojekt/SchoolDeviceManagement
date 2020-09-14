using Microsoft.AspNetCore.Mvc;

namespace SchoolDeviceManagementApi.Controllers
{
    [ApiController]
    [Route("success")]
    public class SuccessController
    {
        [HttpGet]
        public string Get()
        {
            return "API is working correctly!";
        }
    }
}