using ECW.ApplicationCore.DTOs.Authentication;
using ECW.ApplicationCore.Interfaces;
using ECW.Infrastructure.Identity;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace ECW.API.Controllers;

public class AuthController : BaseController
{
    private readonly SignInManager<AppUser> _signInManager;
    private readonly UserManager<AppUser> _userManager;
    private readonly ITokenClaimsService _tokenClaimsService;

    public AuthController(
        SignInManager<AppUser> signInManager,
        UserManager<AppUser> userManager,
        ITokenClaimsService tokenClaimsService)
    {
        _signInManager = signInManager;
        _userManager = userManager;
        _tokenClaimsService = tokenClaimsService;
    }

    [HttpPost("signin")]
    public async Task<IActionResult> SignInAsync(AuthRequest request)
    {
        var response = new AuthResponse();
        var result = await _signInManager.PasswordSignInAsync(request.Username, request.Password, false, true);

        response.Result = result.Succeeded;
        response.Username = request.Username;

        if (result.Succeeded)
            response.Token = await _tokenClaimsService.GetTokenAsync(request.Username);
        
        return Ok(response);
    }

    [HttpPost("register")]
    public async Task<IActionResult> RegisterAsync(AuthRequest request)
    {
        var response = new AuthResponse();
        var userExist = await _userManager.FindByEmailAsync(request.Username);

        if (userExist != null)
        {
            response.Message = new List<string> { "Email already in use." };
            
            return BadRequest(response);
        }

        var user = new AppUser()
        {
            Email = request.Username,
            UserName = request.Username,
            EmailConfirmed = true
        };

        var result = await _userManager.CreateAsync(user, request.Password);
        if (result.Succeeded)
        {
            response.Username = request.Username;
            response.Result = true;
            response.Token = await _tokenClaimsService.GetTokenAsync(request.Username);

            return Ok(response);
        }

        response.Message = result.Errors.Select(e => e.Description).ToList();
        return BadRequest(response);
    }
}