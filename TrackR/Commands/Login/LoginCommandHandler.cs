using Joyful.API.Services;
using MediatR;
using TrackR.Abstractions.Repositories;
using TrackR.API.Entities;
using TrackR.Models;
using TrackR.Services;

namespace TrackR.Commands;

public class LoginCommandHandler : IRequestHandler<LoginCommand, Token>
{
    private readonly IAuthenticationService _authentication;
    private readonly IUserRepository _repository;
    private readonly IPasswordService _password;

    public LoginCommandHandler(
        IAuthenticationService authentication,
        IUserRepository repository,
        IPasswordService password
    )
    {
        _authentication = authentication;
        _password = password;
        _repository = repository;
    }

    async Task<Token> IRequestHandler<LoginCommand, Token>.Handle(LoginCommand request, CancellationToken cancellationToken)
    {
        //Step 1: Retrieve user
        UserEntity? userEntity = await _repository.GetUserByEmailAsync(request.emailAddress, cancellationToken);
        if (userEntity is null)
            throw new ArgumentNullException("User nor found");

        //Step 2: Verify password
        bool isPasswordValid = _password.Verify(userEntity.PasswordHash, request.password);
        if (!isPasswordValid)
            throw new ArgumentException("Invalid email or password");

        //Step 3: Return a token
        Token token = await _authentication.CreateToken(userEntity, true);
        return token;
    }
}