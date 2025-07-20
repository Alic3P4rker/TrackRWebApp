using TrackR.API.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using TrackR.Abstractions.Repositories;
using TrackR.Context;

namespace TrackR.Repositories;

internal sealed class ApplicationRepository : IApplicationRepository
{
    private readonly TrackRDbContext _context;
    public ApplicationRepository(TrackRDbContext context)
    {
        _context = context;
    }
    public Task CreateApplicationAsync(ApplicationEntity applicationEntity, CancellationToken cancellationToken)
    {
        return _context.Applications.AddAsync(applicationEntity, cancellationToken)
            .AsTask();
    }

    public Task DeleteApplicationAsync(ApplicationEntity applicationEntity, CancellationToken cancellationToken)
    {
        _context.Applications.Remove(applicationEntity);
        return Task.CompletedTask;
    }

    public Task<ApplicationEntity?> GetApplicationByIdAsync(Guid applicationId, CancellationToken cancellationToken)
    {
        return _context.Applications
            .AsNoTracking()
            .FirstOrDefaultAsync(a => a.Id.Equals(applicationId), cancellationToken);
        
    }

    public Task<ApplicationEntity?> GetApplicationByNameAsync(string name, CancellationToken cancellationToken)
    {
        return _context.Applications
            .AsNoTracking()
            .FirstOrDefaultAsync(a => a.Name.Equals(name), cancellationToken);
    }

    public Task SaveChangesAsync(CancellationToken cancellationToken)
    {
        return _context.SaveChangesAsync(cancellationToken);
    }

    public Task UpdateApplicationAsync(ApplicationEntity applicationEntity, CancellationToken cancellationToken)
    {
        EntityEntry<ApplicationEntity> entry = _context.Applications.Update(applicationEntity);
        entry.State = EntityState.Modified;
        return Task.CompletedTask;
    }
}