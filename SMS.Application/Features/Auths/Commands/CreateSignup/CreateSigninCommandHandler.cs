using System.Security.Claims;
using MediatR;
using SMS.Application.Common.Interfaces;
using SMS.Application.Common.Interfaces.Authentications;

namespace SMS.Application.Features.Auths.Commands.CreateSignup;

public record CreateSigninCommandHandler : IRequestHandler<CreateSigninCommand, string>
{
    private readonly IUnitOfWork _unitOfWork;
    private readonly IAuthService _authService;

    public CreateSigninCommandHandler(IUnitOfWork unitOfWork, IAuthService authService)
    {
        _unitOfWork = unitOfWork;
        _authService = authService;
    }

    public async Task<string> Handle(CreateSigninCommand request, CancellationToken cancellationToken)
    {
        var student = await _unitOfWork.Students.GetDynamic(s => s.ClassId == request.StudentId, "Credential");

        var token = string.Empty;
        if(student == null) return token;
        if(student.Credential.Password != request.Password) return token;

        token = _authService.CreateToken(new() {
            new Claim(ClaimTypes.Name, student.FullName)
        });

        return token;
    }
}