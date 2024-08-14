using System;
using System.Linq;
using TodoListApp; 

namespace ConsoleUI
{
    public class ConsoleUI
    {
        private readonly ITodoOperations _todoManager;

        public ConsoleUI(ITodoOperations todoManager)
        {
            _todoManager = todoManager ?? throw new ArgumentNullException(nameof(todoManager));
        }

        public void Run()
        {
            bool running = true;

            while (running)
            {
                Console.WriteLine("Todo List Application");
                Console.WriteLine("1. Add Todo");
                Console.WriteLine("2. Remove Todo");
                Console.WriteLine("3. Mark Todo as Completed");
                Console.WriteLine("4. View Todos");
                Console.WriteLine("5. Exit");

                string choice = Console.ReadLine();
                if (choice == null)
                {
                    Console.WriteLine("Invalid choice. Please select a valid option.");
                    continue;
                }

                switch (choice)
                {
                    case "1":
                        AddTodo();
                        break;
                    case "2":
                        RemoveTodo();
                        break;
                    case "3":
                        MarkAsCompleted();
                        break;
                    case "4":
                        ViewTodos();
                        break;
                    case "5":
                        running = false;
                        break;
                    default:
                        Console.WriteLine("Invalid choice. Please select a valid option.");
                        break;
                }
            }
        }

        private void AddTodo()
        {
            try
            {
                Console.Write("Enter Title: ");
                string title = Console.ReadLine();
                if (string.IsNullOrWhiteSpace(title))
                {
                    throw new ArgumentException("Title cannot be empty.");
                }

                Console.Write("Enter Description: ");
                string description = Console.ReadLine();

                Console.Write("Enter Due Date (yyyy-MM-dd): ");
                if (!DateTime.TryParse(Console.ReadLine(), out DateTime dueDate))
                {
                    throw new ArgumentException("Invalid date format.");
                }

                int id = new Random().Next(1, 1000);
                var todo = new TodoItem(id, title, description, false, dueDate);
                _todoManager.AddTodo(todo);

                Console.WriteLine("Todo added successfully.");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error: {ex.Message}");
            }
        }

        private void RemoveTodo()
        {
            try
            {
                Console.Write("Enter Todo ID to remove: ");
                if (!int.TryParse(Console.ReadLine(), out int id))
                {
                    throw new ArgumentException("Invalid ID format.");
                }

                _todoManager.RemoveTodo(id);

                Console.WriteLine("Todo removed successfully.");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error: {ex.Message}");
            }
        }

        private void MarkAsCompleted()
        {
            try
            {
                Console.Write("Enter Todo ID to mark as completed: ");
                if (!int.TryParse(Console.ReadLine(), out int id))
                {
                    throw new ArgumentException("Invalid ID format.");
                }

                _todoManager.MarkAsCompleted(id);

                Console.WriteLine("Todo marked as completed successfully.");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error: {ex.Message}");
            }
        }

        private void ViewTodos()
        {
            var todos = _todoManager.GetTodos();

            if (todos == null || !todos.Any())
            {
                Console.WriteLine("No todos available.");
                return;
            }

            Console.WriteLine("Todos:");
            foreach (var todo in todos)
            {
                Console.WriteLine($"ID: {todo.Id}, Title: {todo.Title}, Description: {todo.Description}, Completed: {todo.IsCompleted}, Due Date: {todo.DueDate.ToShortDateString()}");
            }
        }
    }
}
