using MediatR;
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
        await _mediator.Send(loginCommand);

        return RedirectToPage("/Index");
    }
}