using System.Net.WebSockets;
using MediatR;
using SMS.Application.Common.Interfaces;
using SMS.Domain.Entities;

namespace SMS.Application.Features.Students.Commands.CreateStudentRegistration;

public record CreateStudentRegistrationCommandHandler : IRequestHandler<CreateStudentRegistrationCommand>
{
    private readonly IUnitOfWork _unitOfWork;

    public CreateStudentRegistrationCommandHandler(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public async Task Handle(CreateStudentRegistrationCommand request, CancellationToken cancellationToken)
    {
        var student = await _unitOfWork.Students.GetByIdAsync(request.StudentId);

        if(student != null)
        {
            var studentCourseRegistration = new StudentRegistration {
                SemesterId = request.SemesterId,
                StudentId = request.StudentId
            };

            student.StudentRegistrations.Add(studentCourseRegistration);
            _unitOfWork.Students.Edit(student);

            foreach(var courseId in request.CourseIds)
            {
                studentCourseRegistration
                    .StudentRegistrationCourses.Add(new(){
                        CourseId = courseId,
                        StudentRegistrationId = studentCourseRegistration.Id
                });
            }

            await _unitOfWork.SaveChangesAsync(cancellationToken);
        }
    }
}