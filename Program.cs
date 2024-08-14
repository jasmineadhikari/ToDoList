using System;
using TodoListApp;

class Program
{
    static void Main(string[] args)
    {
        ITodoOperations todoManager = new TodoManager(); 
        var consoleUI = new ConsoleUI.ConsoleUI(todoManager);
        consoleUI.Run();
    }
}