namespace UI.Interfaces;

public interface IOutputProducer<T>
{
    void ShowList(IReadOnlyList<T> items);
    void ShowDetails(T item);
}