using SMS.Domain.Entities;

namespace SMS.Application.Common.Interfaces;

public interface IStudentRepository : IRepository<Student, Guid>
{
}