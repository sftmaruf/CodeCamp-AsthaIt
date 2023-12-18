using SMS.Domain.Entities;

namespace SMS.Application.Common.Interfaces;

public interface ICourseRepository : IRepository<Course, Guid>
{
}