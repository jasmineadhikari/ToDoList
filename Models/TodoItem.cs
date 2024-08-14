public class TodoItem
{
    public int Id { get; private set; }
    public string Title { get; private set; }
    public string Description { get; private set; }
    public bool IsCompleted { get; set; } 
    public DateTime DueDate { get; private set; }

    public TodoItem(int id, string title, string description, bool isCompleted, DateTime dueDate)
    {
        Id = id;
        Title = title ?? throw new ArgumentNullException(nameof(title));
        Description = description ?? throw new ArgumentNullException(nameof(description));
        IsCompleted = isCompleted;
        DueDate = dueDate;
    }
}