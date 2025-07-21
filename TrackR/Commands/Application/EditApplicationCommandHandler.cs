using AutoMapper;
using MediatR;
using TrackR.Abstractions.Repositories;
using TrackR.API.Entities;
using TrackR.Models;

namespace TrackR.Commands;

public class EditApplicationCommandHandler : IRequestHandler<EditApplicationCommand>
{
    private readonly IApplicationRepository _repository;
    private readonly IMapper _mapper;

    public EditApplicationCommandHandler(IApplicationRepository repository, IMapper mapper)
    {
        _repository = repository;
        _mapper = mapper;
    }

    async Task IRequestHandler<EditApplicationCommand>.Handle(EditApplicationCommand request, CancellationToken cancellationToken)
    {
        ApplicationEntity? applicationEntity = await _repository.GetApplicationByIdAsync(request.Id, cancellationToken);
        if (applicationEntity is null)
            throw new ArgumentNullException("Application doesn't exist");

        Application application = new Application(
            request.Id,
            request.Name,
            request.Location,
            request.ApplicationDate,
            request.Status,
            request.Position
        );

        _mapper.Map(application, applicationEntity);
        await _repository.UpdateApplicationAsync(applicationEntity, cancellationToken);
        await _repository.SaveChangesAsync(cancellationToken);
    }
}