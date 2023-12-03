using System.Runtime.Intrinsics.X86;
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
}