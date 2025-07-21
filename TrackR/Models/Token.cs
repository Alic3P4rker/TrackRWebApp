namespace TrackR.Models;

public record Token (
    string accessToken,
    string refreshToken
);