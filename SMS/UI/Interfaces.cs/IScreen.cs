using Models;
using UI.Interfaces;

namespace UI;

public interface IScreen {
    void ShowTitle(string title);
    void AddOptions(string[] labels);
    void ShowOptions();
    void ShowStudent(List<StudentModel> students);
    (string? response, bool forward) WaitForResponse();
    void ShowList<T>(IOutputProducer<T> outputProducer, IReadOnlyList<T> items);
    void ShowDetails<T>(IOutputProducer<T> outputProducer, T item);
};