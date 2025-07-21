using System.Threading.Tasks;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using TrackR.Commands;
using TrackR.Enums;
using TrackR.Models;
using TrackR.Queries;

namespace TrackR.Pages;

[Authorize]
public class IndexModel : PageModel
{
    private readonly IMediator _mediator;
    private readonly ILogger<IndexModel> _logger;

    [BindProperty]
    public Application model { get; set; }

    [BindProperty]
    public Application editModel { get; set; }

    [BindProperty(SupportsGet = false)]
    public Guid DeleteId { get; set; }

    [BindProperty]
    public ApplicationStatus SelectedApplicationStatus { get; set; }
    public SelectList StatusOptions { get; set; }
    public IEnumerable<Application> Applications { get; private set; } = new List<Application>();

    public IndexModel(ILogger<IndexModel> logger, IMediator mediator)
    {
        _logger = logger;
        _mediator = mediator;
    }

    public async Task OnPost()
    {
        Guid userId = new Guid("08ddc83a-4e9a-482b-808d-1697f8e3f2b7");
        CreateApplicationCommand command = new CreateApplicationCommand
        (
            userId,
            model.name,
            model.location,
            model.applicationDate,
            model.status,
            model.position
        );

        await _mediator.Send(command);

        StatusOptions = new SelectList(Enum.GetValues(typeof(ApplicationStatus)));
        RetrieveApplicationsQuery query = new RetrieveApplicationsQuery(userId);
        Applications = await _mediator.Send(query);
    }

    public async Task OnGet()
    {
        StatusOptions = new SelectList(Enum.GetValues(typeof(ApplicationStatus)));
        Guid userId = new Guid("08ddc83a-4e9a-482b-808d-1697f8e3f2b7");
        RetrieveApplicationsQuery query = new RetrieveApplicationsQuery(userId);
        Applications = await _mediator.Send(query);
    }

    public async Task<IActionResult> OnPostEdit()
    {
        EditApplicationCommand command = new EditApplicationCommand(
            editModel.id,
            editModel.name,
            editModel.position,
            editModel.location,
            editModel.applicationDate,
            editModel.status
        );
        await _mediator.Send(command);
        return RedirectToPage();
    }

    public async Task<IActionResult> OnPostDelete()
    {
        DeleteApplicationCommand command = new DeleteApplicationCommand(DeleteId);
        await _mediator.Send(command);
        return RedirectToPage();
    }
}
