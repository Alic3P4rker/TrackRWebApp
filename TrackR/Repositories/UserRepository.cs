using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using TrackR.Abstractions.Repositories;
using TrackR.API.Entities;
using TrackR.Context;

namespace TrackR.Repositories;

internal sealed class UserRepository : IUserRepository
{
    private readonly TrackRDbContext _context;

    public UserRepository(TrackRDbContext context)
    {
        _context = context;
    }
    public Task CreateUserAsync(UserEntity userEntity, CancellationToken cancellationToken)
    {
        return _context.Users.AddAsync(userEntity, cancellationToken)
            .AsTask();
    }

    public Task DeleteUserAsync(UserEntity userEntity, CancellationToken cancellationToken)
    {
        _context.Users.Remove(userEntity);
        return Task.CompletedTask;
    }

    public Task<UserEntity?> GetUserByEmailAsync(string email, CancellationToken cancellationToken)
    {
        return _context.Users
            .AsNoTracking()
            .FirstOrDefaultAsync(user => user.Email.Equals(email), cancellationToken);
    }

    public Task<UserEntity?> GetUserByIdAsync(Guid userId, CancellationToken cancellationToken)
    {
        return _context.Users
            .AsNoTracking()
            .FirstOrDefaultAsync(user => user.Id.Equals(userId), cancellationToken);
    }

    public Task SaveChangesAsync(CancellationToken cancellationToken)
    {
        return _context.SaveChangesAsync(cancellationToken);
    }

    public Task UpdateUserAsync(UserEntity userEntity, CancellationToken cancellationToken)
    {
        EntityEntry<UserEntity> entry = _context.Users.Update(userEntity);
        entry.State = EntityState.Modified;
        return Task.CompletedTask;
    }
}