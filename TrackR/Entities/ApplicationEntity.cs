using TrackR.Enums;

namespace TrackR.API.Entities;

public class ApplicationEntity
{
    // Application properties
    public Guid Id { get; set; }
    public Guid UserId { get; set; }
    public string Name { get; set; }
    public string? Description { get; set; }
    public string? Location { get; set; }
    public DateTime ApplicationDate { get; set; }
    public ApplicationStatus Status { get; set; }
    public string? Postion { get; set; }

    // Contact information
    public string? ContactName { get; set; }
    public string? ContactEmail { get; set; }
    public string? ContactPhone { get; set; }
    public string? ContactAddress { get; set; }
    public string? ContactCity { get; set; }
    public string? ContactState { get; set; }
    public string? ContactZipCode { get; set; }
    public string? ContactCountry { get; set; }
    public string? ContactWebsite { get; set; }


    public ApplicationEntity()
    {
        Name = String.Empty;
    }
}