using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using RentAndSell.Car.API.Models;

namespace RentAndSell.Car.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        [HttpPost("Login")]
        public ActionResult Login(LoginViewModel model)
        {
            LoginResultViewModel LoginResult = new LoginResultViewModel();
            LoginResult.BasicAuth = "Basic abc123xyz";
            LoginResult.IsLogin = true;
            LoginResult.ErrorMessage = "";

            return Ok(LoginResult);
        }
    }
}
