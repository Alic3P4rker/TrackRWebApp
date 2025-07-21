using AutoMapper;
using MediatR;
using TrackR.Abstractions.Repositories;
using TrackR.API.Entities;
using TrackR.Models;

namespace TrackR.Commands;

public class CreateApplicationCommandHandler : IRequestHandler<CreateApplicationCommand, Application>
{
    private readonly IApplicationRepository _repository;
    private readonly IMapper _mapper;

    public CreateApplicationCommandHandler(IApplicationRepository repository, IMapper mapper)
    {
        _repository = repository;
        _mapper = mapper;
    }

    async Task<Application> IRequestHandler<CreateApplicationCommand, Application>.Handle(CreateApplicationCommand request, CancellationToken cancellationToken)
    {
        ApplicationEntity applicationEntity = _mapper.Map<ApplicationEntity>(request);
        await _repository.CreateApplicationAsync(applicationEntity, cancellationToken);
        await _repository.SaveChangesAsync(cancellationToken);

        Application application = _mapper.Map<Application>(applicationEntity);
        return application;
    }
}