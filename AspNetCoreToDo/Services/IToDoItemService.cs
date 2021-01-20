using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using AspNetCoreToDo.Models;

namespace AspNetCoreToDo.Services
{
    public interface IToDoItemService
    {
        Task<ToDoItem[]> GetIncompleteItemsAsync();
        Task<bool> AddItemAsync(ToDoItem newItem);
        Task<bool> MarkDoneAsync(Guid id);
    }
}

