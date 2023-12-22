using MediatR;
using SMS.Domain.DTOs;

namespace SMS.Application.Features.Auths.Commands.CreateSignup;

public record CreateSigninCommand : IRequest<string>
{
    public string StudentId { get; set; } = string.Empty;
    public string Password { get; set; } = string.Empty;
}