using MediatR;
using TrackR.Models;

namespace TrackR.Queries;

public record RetrieveApplicationsQuery(
    Guid userId
): IRequest<IEnumerable<Application>>;