using MediatR;
using SMS.Application.Common.Interfaces;

namespace SMS.Application.Features.Students.Commands.CreateStudent;

public class CreateStudentCommandHandler : IRequestHandler<CreateStudentCommand>
{
    private readonly IUnitOfWork _unitOfWork;

    public CreateStudentCommandHandler(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public async Task Handle(CreateStudentCommand request, CancellationToken cancellationToken)
    {
        var student = request.ToStudent(request);

        await _unitOfWork.Students.AddAsync(student);
        await _unitOfWork.SaveChangesAsync(cancellationToken);
    }
}