using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using RentAndSell.Car.API.Data.Entities.Concrete;
using RentAndSell.Car.API.Models;
using System.Text;

namespace RentAndSell.Car.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly UserManager<Kullanici> _userManager;
        private readonly SignInManager<Kullanici> _signInManager;

        public AuthController(UserManager<Kullanici> userManager, SignInManager<Kullanici> signInManager)
        {
            _userManager = userManager;
            _signInManager = signInManager;
        }

        [HttpPost("Login")]
        public ActionResult Login(LoginViewModel model)
        {
           LoginResultViewModel LoginResult = new LoginResultViewModel();
           Kullanici? kullanici = _userManager.FindByNameAsync(model.UserName).Result;

            if (kullanici is null)
            { 
                LoginResult.IsLogin = false;
                LoginResult.ErrorMessage = "Kullanıcı veya şifreniz yanlış";
                return Ok(LoginResult);
            }

           bool passwordChecked = _userManager.CheckPasswordAsync(kullanici,model.Password).Result;

            if (!passwordChecked)
            { 
                LoginResult.IsLogin = false ;
                LoginResult.ErrorMessage = "Kullanıcı verya şifreniz yanlış";
                return Ok(LoginResult);
            }

            var usernamePassword = $"{model.UserName}:{model.Password}";
            var base64EncodeUserNamePassword = Convert.ToBase64String(Encoding.UTF8.GetBytes(usernamePassword));
            var basicAuth = $"Basic{base64EncodeUserNamePassword}";

            LoginResult.IsLogin = true;
            LoginResult.BasicAuth = basicAuth;
            

            return Ok(LoginResult);
        }
    }
}
