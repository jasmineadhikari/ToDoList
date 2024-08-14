using System;
using System.Collections.Generic;
using System.IO;
using System.Text.Json;
using TodoListApp.Models;

namespace TodoListApp.Data
{
    public class DataStorage
    {
        private readonly string _filePath;

        public DataStorage(string filePath)
        {
            _filePath = filePath;
        }

        public void SaveTodos(IEnumerable<TodoItem> todos)
        {
            try
            {
                using (var writer = new StreamWriter(_filePath))
                {
                    var json = JsonSerializer.Serialize(todos);
                    writer.Write(json);
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"An error occurred while saving todos: {ex.Message}");
            }
        }

        public IEnumerable<TodoItem> LoadTodos()
        {
            try
            {
                if (!File.Exists(_filePath))
                {
                    return new List<TodoItem>();
                }

                using (var reader = new StreamReader(_filePath))
                {
                    var json = reader.ReadToEnd();
                    return JsonSerializer.Deserialize<List<TodoItem>>(json);
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"An error occurred while loading todos: {ex.Message}");
                return new List<TodoItem>();
            }
        }
    }
}