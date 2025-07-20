using TrackR.API.Entities;

namespace TrackR.Abstractions.Repositories;

public interface IApplicationRepository
{
    Task CreateApplicationAsync(ApplicationEntity applicationEntity, CancellationToken cancellationToken);
    Task DeleteApplicationAsync(ApplicationEntity applicationEntity, CancellationToken cancellationToken);
    Task<ApplicationEntity?> GetApplicationByIdAsync(Guid applicationId, CancellationToken cancellationToken);
    Task<ApplicationEntity?> GetApplicationByNameAsync(string name, CancellationToken cancellationToken);
    Task UpdateApplicationAsync(ApplicationEntity applicationEntity, CancellationToken cancellationToken);
    Task SaveChangesAsync(CancellationToken cancellationToken);
}