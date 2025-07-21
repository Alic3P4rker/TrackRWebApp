using TrackR.Enums;

namespace TrackR.Models;

public record Application (
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
);