using MediatR;
using TrackR.Models;

namespace TrackR.Commands;

public record CreateUserCommand
(
    string name,
    string email,
    string password
): IRequest<UserDetailsDto>;