using MediatR;
using TrackR.Models;

namespace TrackR.Commands;

public record LoginCommand(
    string emailAddress,
    string password
): IRequest<Token>;