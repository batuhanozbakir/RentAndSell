﻿using Microsoft.AspNetCore.Authentication;
using Microsoft.Extensions.Options;
using Microsoft.Identity.Client;
using System.Security.Claims;
using System.Text;
using System.Text.Encodings.Web;

namespace RentAndSell.Car.API.Services
{
    public class YetkiKontrolYakalayicisi : AuthenticationHandler<AuthenticationSchemeOptions>
    {
        public YetkiKontrolYakalayicisi(IOptionsMonitor<AuthenticationSchemeOptions> options, ILoggerFactory logger, UrlEncoder encoder) : base(options, logger, encoder)
        {

        }

        //Api da login etme authentication ekleme.
        protected override async Task<AuthenticateResult> HandleAuthenticateAsync()
        {
            if(Request.Headers.ContainsKey("Authorication"))
            {
                string authorication = Request.Headers["Authorication"];
                string base64Encode = authorication.Split("Basic ")[1];
                string authDecode = Encoding.UTF8.GetString(Convert.FromBase64String(base64Encode));
                string[] credentials = authDecode.Split(":");
                string userName = credentials[0];
                string password = credentials[1];

                if(userName == "admin" && password == "123456*Admin")
                {
                    List<Claim> claims = new List<Claim>()
                    {
                new Claim(ClaimTypes.NameIdentifier, "1001"),
                new Claim(ClaimTypes.Name, userName),
                new Claim(ClaimTypes.Email, userName + "goksel@bilgeadam.com")
                    };

                    ClaimsIdentity clasimsIdentity = new ClaimsIdentity(claims, Scheme.Name);
                    ClaimsPrincipal claimsPrincipal = new ClaimsPrincipal(clasimsIdentity);

                    AuthenticationTicket gecisBileti = new AuthenticationTicket(claimsPrincipal, Scheme.Name);

                    return AuthenticateResult.Success(gecisBileti);
                }
                return AuthenticateResult.Fail("Kullanıcı adı veya şifreniz yanlıştır");
            }
            return AuthenticateResult.Fail("Yetkisiz giriş denemesi.");  
        }
    }
}
