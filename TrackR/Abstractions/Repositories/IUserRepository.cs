using TrackR.API.Entities;

namespace  TrackR.Abstractions.Repositories;

public interface IUserRepository
{
    Task CreateUserAsync(UserEntity userEntity, CancellationToken cancellationToken);
    Task DeleteUserAsync(UserEntity userEntity, CancellationToken cancellationToken);
    Task<UserEntity?> GetUserByIdAsync(Guid userId, CancellationToken cancellationToken);
    Task<UserEntity?> GetUserByEmailAsync(string email, CancellationToken cancellationToken);
    Task UpdateUserAsync(UserEntity userEntity, CancellationToken cancellationToken);
    Task SaveChangesAsync(CancellationToken cancellationToken);
}