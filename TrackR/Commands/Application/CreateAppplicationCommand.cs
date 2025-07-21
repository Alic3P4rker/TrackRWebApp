using MediatR;
using TrackR.Enums;
using TrackR.Models;

namespace TrackR.Commands;

public record CreateApplicationCommand(
    Guid userId,
    string name,
    string location,
    DateOnly applicationDate,
    ApplicationStatus status,
    string position
): IRequest;