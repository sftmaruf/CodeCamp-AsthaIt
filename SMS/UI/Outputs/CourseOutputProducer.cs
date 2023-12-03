using Models;
using UI.Interfaces;

namespace UI;

public class CourseOutputProducer : IOutputProducer<CourseModel>
{
    public void ShowDetails(CourseModel item)
    {
        throw new NotImplementedException();
    }

    public void ShowList(IReadOnlyList<CourseModel> items)
    {
        Console.WriteLine($"Id\t\tCredit\t\tName");
        foreach(var item in items)
        {
            Console.WriteLine($"{item.Id}\t\t{item.Credit}\t\t{item.Name}");
        }
    }
}