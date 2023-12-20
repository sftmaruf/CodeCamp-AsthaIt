using SMS.Domain.Entities;

namespace SMS.Application.Common.Interfaces;

public interface IInstructorRepository : IRepository<Instructor, Guid>
{
}