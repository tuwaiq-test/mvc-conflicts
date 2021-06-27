using Microsoft.AspNetCore.Mvc;
using mvc_crud_conflict.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace mvc_crud_conflict.Controllers
{
    public class NotesController : Controller
    {
        public List<NoteModel> notes = new()
        {
            new NoteModel() { Id = 1, Note = "The first nete by Rio Dan", CreatedAt = DateTime.Now }
        };
        public NotesController()
        { 
        
        }
            public IActionResult Index()
        {
            ViewData["Notes"] = notes;
            return View();
        }
    }
}
