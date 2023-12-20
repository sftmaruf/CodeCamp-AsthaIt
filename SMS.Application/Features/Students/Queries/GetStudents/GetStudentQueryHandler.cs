using MediatR;
using SMS.Application.Common.Interfaces;
using SMS.Domain.DTOs;
using SMS.Domain.Entities;

namespace SMS.Application.Features.Students.Queries.GetStudents;

public class GetStudentsQueryHandler : IRequestHandler<GetStudentsQuery, IReadOnlyList<StudentDto>>
{
    private IUnitOfWork _unitOfWork;

    public GetStudentsQueryHandler(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public async Task<IReadOnlyList<StudentDto>> Handle(GetStudentsQuery request, CancellationToken cancellationToken)
    {
        var items = await _unitOfWork.Students.GetAllAsync("Batch,StudentRegistrations,Batch.Department,Batch.Department.Degrees");

        var students = new List<StudentDto>();
        foreach(var item in items)
        {
            students.Add(new() {
                Id = item.Id,
                FirstName = item.FirstName,
                MiddleName = item.MiddleName,
                LastName = item.LastName,
                ClassId = item.ClassId,
                Department = item.Batch.Department.Name,
                Degree = item.Batch.Department.Degrees[0].Title,
                Batch = item.Batch.Name
            });
        }

        return students;
    }
}