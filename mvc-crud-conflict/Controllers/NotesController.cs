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


         public IActionResult Delete(int id)
        {
            var note = notes.ToList().Find(a => a.Id == id);
            notes.Remove(note);
            return RedirectToAction("Index");
        }

        [HttpPost()]
        public IActionResult Edit(int Id, string theNote)
        {
            var note = notes.ToList().Find(note => note.Id == Id);
            if (note == null)
                return BadRequest();
            note.Note = theNote;
            notes.RemoveAt(note.Id - 1);
            notes.Insert(note.Id - 1, note);
            return View(note);
        }

        [HttpGet()]
        public IActionResult Edit(int id)
        {
            var note = notes.ToList().Find(note => note.Id == id);
            if (note == null)
                return BadRequest();
            return View(note);
        }
    }
}
