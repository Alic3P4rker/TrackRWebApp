using MediatR;
using TrackR.Enums;

namespace TrackR.Commands;

public record EditApplicationCommand(
    Guid Id,
    string Name,
    string Position,
    string Location,
    DateOnly ApplicationDate,
    ApplicationStatus Status
): IRequest;