using System.Collections.Generic;

namespace TodoListApp
{
    public class TodoManager : ITodoOperations
    {
        private List<TodoItem> _todos = new List<TodoItem>();

        public void AddTodo(TodoItem todo)
        {
            _todos.Add(todo);
        }

        public void RemoveTodo(int id)
        {
            var todo = _todos.FirstOrDefault(t => t.Id == id);
            if (todo != null)
            {
                _todos.Remove(todo);
            }
        }

        public void MarkAsCompleted(int id)
        {
            var todo = _todos.FirstOrDefault(t => t.Id == id);
            if (todo != null)
            {
                todo.IsCompleted = true;
            }
        }

        public IEnumerable<TodoItem> GetTodos()
        {
            return _todos;
        }
    }
}