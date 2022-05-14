using Microsoft.AspNetCore.Mvc;
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
    public List<Note> getAllNotes()
    {
        return _noteService.getAllNotes();
    }


    [HttpPost("/note")]
    public bool createNote(string title, string content)
    {
        Note note = new Note(2, title, content);
        _noteService.insertNote(note);
        return true;
    }
    
    [HttpPost("/delete")]
    public void deleteNote(int id)
    {
        _noteService.deleteNote(id);
    }
/*
    public void updateNote(int id, string content = null, string title = null)
    {
        //TODO: implement NoteService.updateNoteById(id, ?content, ?title)
        
    } 
    */
}



