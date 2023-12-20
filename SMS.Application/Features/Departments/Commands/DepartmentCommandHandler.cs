using MediatR;
using SMS.Application.Common.Interfaces;
using SMS.Domain.Entities;

namespace SMS.Application.Features.Departments.Commands;

public record CreateDepartmentCommandHandler : IRequestHandler<CreateDepartmentCommand>
{
    private IUnitOfWork _unitOfWork;

    public CreateDepartmentCommandHandler(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public async Task Handle(CreateDepartmentCommand request, CancellationToken cancellationToken)
    {
        var department = request.ToDepartment();

        await _unitOfWork.Departments.AddAsync(department);
        await _unitOfWork.SaveChangesAsync(cancellationToken);
    }
}