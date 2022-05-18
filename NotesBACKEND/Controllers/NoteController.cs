using System.Net;
using System.Text.Json;
using System.Web.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using NotesBACKEND.Models;

namespace NotesBACKEND.Controllers;

[ApiController]
[Microsoft.AspNetCore.Mvc.Route("NotesController")]
public class NoteController
{
    private List<Note> noteList = new List<Note>(); //will load notes here through a NoteService
    private NoteContext _noteContext = new NoteContext();
    // This method gets a note from NoteService
    [Microsoft.AspNetCore.Mvc.HttpGet("/note/{id}")]
    public async Task<ActionResult<Note>> getNote(int id)
    {
        var note = await _noteContext.Notes.FindAsync(id);
        return note;
    }

    [Microsoft.AspNetCore.Mvc.HttpGet("getAllNotes")]
    public async Task<List<Note>> getAllNotes()
    {
        var noteList = await _noteContext.Notes.ToListAsync();
        return noteList;
    }

    [Microsoft.AspNetCore.Mvc.HttpPost("/note")]
    public async Task<ActionResult<Note>> createNote(string title, string content)
    {
        //Note note = new Note(_noteService.getUniqueID(), title, content);
        int id = _noteContext.Notes.ToList().Last().id + 1;
        Note note = new Note(id, title, content);
        _noteContext.Notes.Add(note);
        await _noteContext.SaveChangesAsync();
        return note;
    }
    
    [Microsoft.AspNetCore.Mvc.HttpPost("/delete")]
    public async Task<ActionResult> deleteNote(int id)
    {
        Note note = new Note () { id = id };
        _noteContext.Notes.Remove(note);
        await _noteContext.SaveChangesAsync();
        return new NoContentResult();
    }
    
    [Microsoft.AspNetCore.Mvc.HttpPost("/update/{id}")]
    public async Task<ActionResult<Note>> updateNote(int id, string? content = null, string? title = null)
    {
        Note note = new Note(id, content, title);
        _noteContext.Notes.Update(note);
        await _noteContext.SaveChangesAsync();
        return note;
    }
}



