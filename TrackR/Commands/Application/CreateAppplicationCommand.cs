using MediatR;
using TrackR.Enums;
using TrackR.Models;

namespace TrackR.Commands;

public record CreateApplicationCommand(
    // Application properties
    string name,
    string description,
    string location,
    DateTime applicationDate,
    ApplicationStatus status,
    string position,

    // Contact information
    string contactName,
    string contactEmail,
    string contactPhone,
    string contactAddress,
    string contactCity,
    string contactState,
    string contactZipCode,
    string contactCountry,
    string contactWebsite
): IRequest<Application>;