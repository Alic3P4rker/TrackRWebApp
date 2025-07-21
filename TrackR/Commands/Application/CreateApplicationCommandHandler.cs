using AutoMapper;
using MediatR;
using TrackR.Abstractions.Repositories;
using TrackR.API.Entities;
using TrackR.Models;

namespace TrackR.Commands;

public class CreateApplicationCommandHandler : IRequestHandler<CreateApplicationCommand>
{
    private readonly IApplicationRepository _repository;
    private readonly IMapper _mapper;

    public CreateApplicationCommandHandler(IApplicationRepository repository, IMapper mapper)
    {
        _repository = repository;
        _mapper = mapper;
    }

    async Task IRequestHandler<CreateApplicationCommand>.Handle(CreateApplicationCommand request, CancellationToken cancellationToken)
    {
        ApplicationEntity applicationEntity = _mapper.Map<ApplicationEntity>(request);
        applicationEntity.UserId = request.userId;
        await _repository.CreateApplicationAsync(applicationEntity, cancellationToken);
        await _repository.SaveChangesAsync(cancellationToken);
    }
}