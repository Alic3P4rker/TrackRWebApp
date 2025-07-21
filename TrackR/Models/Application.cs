using TrackR.Enums;

namespace TrackR.Models;

public record Application (
    // Application properties
    Guid id,
    string name,
    string location,
    DateOnly applicationDate,
    ApplicationStatus status,
    string position
);