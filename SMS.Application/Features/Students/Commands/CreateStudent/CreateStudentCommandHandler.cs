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
        var  defaultPassword = "123456";

        var student = request.ToStudent();
        await _unitOfWork.Students.AddAsync(student);

        student.Credential = new() {
            Password = defaultPassword,
            StudentId = student.Id
        };

        await _unitOfWork.SaveChangesAsync(cancellationToken);
    }
}