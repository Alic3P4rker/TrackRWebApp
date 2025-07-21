using AutoMapper;
using MediatR;
using TrackR.Abstractions.Repositories;
using TrackR.API.Entities;
using TrackR.Models;

namespace TrackR.Queries;

public class RetrieveApplicationsQueryHandler : IRequestHandler<RetrieveApplicationsQuery, IEnumerable<Application>>
{
    private readonly IApplicationRepository _repository;
    private readonly IMapper _mapper;

    public RetrieveApplicationsQueryHandler(IApplicationRepository repository, IMapper mapper)
    {
        _repository = repository;
        _mapper = mapper;
    }

    async Task<IEnumerable<Application>> IRequestHandler<RetrieveApplicationsQuery, IEnumerable<Application>>
        .Handle(RetrieveApplicationsQuery query, CancellationToken cancellationToken)
    {
        IEnumerable<ApplicationEntity> applicationEntities = await _repository.RetrieveApplicationsByUserIdAsync(query.userId, cancellationToken);
        IEnumerable<Application> applications = _mapper.Map<IEnumerable<Application>>(applicationEntities);
        return applications;
    }
}