using MediatR;

namespace TrackR.Commands;

public record DeleteApplicationCommand(
    Guid applicationId
): IRequest;