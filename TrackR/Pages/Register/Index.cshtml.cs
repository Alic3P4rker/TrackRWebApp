using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using TrackR.Commands;
using TrackR.Models;


public class RegisterModel : PageModel
{
    private readonly IMediator _mediator;
    private readonly ILogger<RegisterModel> _logger;

    [BindProperty]
    public User model { get; set; }

    public RegisterModel(ILogger<RegisterModel> logger, IMediator mediator)
    {
        _mediator = mediator;
        _logger = logger;
    }

    public async Task<IActionResult> OnPost()
    {
        if (!ModelState.IsValid)
        {
            return Page();
        }

        CreateUserCommand command = new CreateUserCommand(model.name, model.email, model.password);
        await _mediator.Send(command);

        if (!ModelState.IsValid)
        {
            return Page();
        }

        return RedirectToPage("/Account/Login");
    }
}