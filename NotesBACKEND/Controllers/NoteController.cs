using System.Text.Json;
using Microsoft.AspNetCore.Mvc;
using MySqlX.XDevAPI.Common;
using NotesBACKEND.Services;

namespace NotesBACKEND.Controllers;

[ApiController]
[Route("NotesController")]
public class NoteController
{
    private List<Note> noteList = new List<Note>(); //will load notes here through a NoteService
    private NoteService _noteService = new NoteService();

    // This method gets a note from NoteService
    [HttpGet("/note/{id}")]
    public String getNote(int id)
    {
        //TODO: implement custom exception handler
        try
        {
            return _noteService.getNoteById(id).ToString();
        }
        catch (NullReferenceException e)
        {
            return "Note not found";
        }
    }
  
    [HttpGet("getAllNotes")]
    public ApiResponse<Note> getAllNotes()
    {
        var list = _noteService.getAllNotes();
        var serialize = JsonSerializer.Serialize(list);
        var model = new ApiResponse<Note>(200,list.Count, list);
        return model;
    }


    [HttpPost("/note")]
    public bool createNote(int id,string title, string content)
    {
        Note note = new Note(id, title, content);
        try
        {
            _noteService.insertNote(note);
            return true;
        }
        catch (Exception e)
        {
            Console.WriteLine(e.StackTrace);
            return false;
        }
    }
    
    [HttpPost("/delete")]
    public bool deleteNote(int id)
    {
        try
        {
            _noteService.deleteNote(id);
            return true;
        }
        catch (Exception e)
        {
            return false;
        }
    }
    
    [HttpPost("/update/{id}")]
    public void updateNote(int id, string? content = null, string? title = null)
    {
        if(content is null)
            _noteService.updateTitle(id, title);
        else
            _noteService.updateContent(id, content);
    }

}



