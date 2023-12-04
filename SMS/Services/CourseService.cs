using Data;
using Entities;
using Services.Interfaces;
using Utility;

namespace Services;

public class CourseService : ICourseService
{
    private readonly IUnitOfWork _unitOfWork;

    public CourseService(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork; 
    }

    public IResult<IReadOnlyList<Course>> GetAllCourses()
    {
        var result = _unitOfWork.CourseRepository.GetAll();
        if(!result.IsSuccess) return Result<IReadOnlyList<Course>>.Fail();

        return Result<IReadOnlyList<Course>>.Success(result.Data!.AsReadOnly());
    }

    public IResult<IReadOnlyList<Course>> GetCoursesByDepartment(string departmentName)
    {
        return _unitOfWork.CourseRepository
            .GetFilteredCourses(x => x.Departments.Exists(d => d.Name == departmentName));
    }

    public IResult<Course> GetById(string id)
    {
        return _unitOfWork.CourseRepository.GetById(id);
    }
}