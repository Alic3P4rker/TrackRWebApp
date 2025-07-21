using AutoMapper;
using MediatR;
using TrackR.Abstractions.Repositories;
using TrackR.API.Entities;
using TrackR.Models;
using TrackR.Services;

namespace TrackR.Commands;

public class CreateUserCommandHandler : IRequestHandler<CreateUserCommand, UserDetailsDto>
{
    private readonly IPasswordService _password;
    private readonly IUserRepository _repository;
    private readonly IMapper _mapper;

    public CreateUserCommandHandler(IUserRepository repository, IMapper mapper, IPasswordService password)
    {
        _repository = repository;
        _mapper = mapper;
        _password = password;
    }

    async Task<UserDetailsDto> IRequestHandler<CreateUserCommand, UserDetailsDto>.Handle(CreateUserCommand request, CancellationToken cancellationToken)
    {
        //Step 1: Check if the user already exists
        UserEntity? tempUserEntity = await _repository.GetUserByEmailAsync(request.email, cancellationToken);
        if (tempUserEntity is not null)
            throw new ArgumentException("Email address already in use");

        //Step 2: Create user 
        UserEntity userEntity = _mapper.Map<UserEntity>(request);
        userEntity.PasswordHash = _password.Hash(request.password);
        userEntity.CreatedAt = DateTime.UtcNow;
        userEntity.UpdatedAt = DateTime.UtcNow;

        await _repository.CreateUserAsync(userEntity, cancellationToken);
        await _repository.SaveChangesAsync(cancellationToken);

        UserDetailsDto user = _mapper.Map<UserDetailsDto>(userEntity);

        return user;
    }
}