using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using MediatR;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using TrackR.Commands;
using TrackR.Models;


public class LoginModel : PageModel
{
    private readonly IMediator _mediator;
    private readonly ILogger<LoginModel> _logger;

    [BindProperty]
    public Login model { get; set; }

    public LoginModel(ILogger<LoginModel> logger, IMediator mediator)
    {
        _logger = logger;
        _mediator = mediator;
    }

    public async Task<IActionResult> OnPost()
    {
        LoginCommand loginCommand = new LoginCommand(model.email, model.password);
        Token token = await _mediator.Send(loginCommand);

        Response.Cookies.Append("accessToken", token.accessToken, new CookieOptions
        {
            HttpOnly = true,
            Secure = false,
            SameSite = SameSiteMode.Strict,
            Expires = DateTimeOffset.UtcNow.AddMinutes(10)
        });

        Response.Cookies.Append("refreshToken", token.refreshToken, new CookieOptions
        {
            HttpOnly = true,
            Secure = false,
            SameSite = SameSiteMode.Strict,
        });

        var handler = new JwtSecurityTokenHandler();
        var jwt = handler.ReadJwtToken(token.accessToken);
        var claims = jwt.Claims.ToList();

        var claimsIdentity = new ClaimsIdentity(claims, CookieAuthenticationDefaults.AuthenticationScheme);
        await HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme,
            new ClaimsPrincipal(claimsIdentity));

        return RedirectToPage("/Index");
    }
}