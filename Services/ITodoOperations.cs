namespace TodoListApp
{
    public interface ITodoOperations
    {
        void AddTodo(TodoItem todo);
        void RemoveTodo(int id);
        void MarkAsCompleted(int id);
        IEnumerable<TodoItem> GetTodos();
    }
}