using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using AspNetCoreToDo.Models;
using AspNetCoreToDo.Services;

namespace AspNetCoreToDo.Controllers{
    public class ToDoController:Controller{

        private readonly IToDoItemService _toDoItemService;

        public ToDoController(IToDoItemService toDoItemService){
            _toDoItemService = toDoItemService;
        }
        //IActionResult
        public async Task<IActionResult> Index(){
            // Get to-do items from database
            var items = await _toDoItemService.GetIncompleteItemsAsync();
            // Put items into a model
            var model = new ToDoViewModel()
            {
                Items = items
            };
            return View(model);
            // Render view using the model
        }

        [ValidateAntiForgeryToken]
        public async Task<IActionResult> AddItem(ToDoItem newItem)
        {
            if (!ModelState.IsValid)
            {
                Console.WriteLine("error");
                return RedirectToAction("Index");
            }
            var successful = await _toDoItemService.AddItemAsync(newItem);
            if (!successful)
            {
                return BadRequest("Could not add item.");
            }
            return RedirectToAction("Index");
        }

        [ValidateAntiForgeryToken]
        public async Task<IActionResult> MarkDone(Guid id)
        {
            if (id == Guid.Empty)
            {
                return RedirectToAction("Index");
            }
            var successful = await _toDoItemService.MarkDoneAsync(id);
            if (!successful)
            {
                return BadRequest("Could not mark item as done.");
            }
            return RedirectToAction("Index");
        }

    }
}