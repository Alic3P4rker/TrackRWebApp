using MediatR;
using TrackR.Abstractions.Repositories;
using TrackR.API.Entities;

namespace TrackR.Commands;

public class DeleteApplicationCommandHandler : IRequestHandler<DeleteApplicationCommand>
{
    private readonly IApplicationRepository _repository;

    public DeleteApplicationCommandHandler(IApplicationRepository repository)
    {
        _repository = repository;
    }

    async Task IRequestHandler<DeleteApplicationCommand>.Handle(DeleteApplicationCommand request, CancellationToken cancellationToken)
    {
        ApplicationEntity? applicationEntity = await _repository.GetApplicationByIdAsync(request.applicationId, cancellationToken);
        if (applicationEntity is null)
            throw new ArgumentNullException("Application doesn't exist");

        await _repository.DeleteApplicationAsync(applicationEntity, cancellationToken);
        await _repository.SaveChangesAsync(cancellationToken);
    }
}