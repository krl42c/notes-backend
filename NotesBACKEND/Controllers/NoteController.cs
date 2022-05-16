using System.Net;
using System.Text.Json;
using System.Web.Http;
using Microsoft.AspNetCore.Mvc;
using NotesBACKEND.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace NotesBACKEND.Controllers;

[ApiController]
[Microsoft.AspNetCore.Mvc.Route("NotesController")]
public class NoteController
{
    private List<Note> noteList = new List<Note>(); //will load notes here through a NoteService
    private NoteService _noteService = new NoteService();

    // This method gets a note from NoteService
    [Microsoft.AspNetCore.Mvc.HttpGet("/note/{id}")]
    public ActionResult<Note> getNote(int id)
    {
        if (_noteService.exists(id))
        {
            return _noteService.getNoteById(id);
        }
        var data = new { error = "No note found with given ID" };
        return new NotFoundObjectResult(data);
    }


    [Microsoft.AspNetCore.Mvc.HttpGet("getAllNotes")]
    public ApiResponse<Note> getAllNotes()
    {
        var list = _noteService.getAllNotes();
        var serialize = JsonSerializer.Serialize(list);
        var model = new ApiResponse<Note>(200,list.Count, list);
        return model;
    }


    [Microsoft.AspNetCore.Mvc.HttpPost("/note")]
    public ActionResult<Note> createNote(string title, string content)
    {
        Note note = new Note(_noteService.getUniqueID(), title, content);
        var error = new { error = "Note couldn't be created" };
        _noteService.insertNote(note);
        
        if (_noteService.exists(note.id))
            return note;

        return new StatusCodeResult(StatusCodes.Status500InternalServerError);
    }
    
    [Microsoft.AspNetCore.Mvc.HttpPost("/delete")]
    public ActionResult deleteNote(int id)
    {
        if (_noteService.exists(id))
        {
            _noteService.deleteNote(id);
            return new StatusCodeResult(StatusCodes.Status200OK);
        }
        return new StatusCodeResult(StatusCodes.Status500InternalServerError);
    }
    
    [Microsoft.AspNetCore.Mvc.HttpPost("/update/{id}")]
    public void updateNote(int id, string? content = null, string? title = null)
    {
        if(content is null)
            _noteService.updateTitle(id, title);
        else
            _noteService.updateContent(id, content);
    }

}



