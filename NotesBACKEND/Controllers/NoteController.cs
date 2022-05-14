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
    public String getAllNotes()
    {
        return "wip";
    }

  /*  public void deleteNote()
    {
        //TODO: implement NoteService.deleteNoteById(id)
    }

    public void updateNote(int id, string content = null, string title = null)
    {
        //TODO: implement NoteService.updateNoteById(id, ?content, ?title)
        
    }*/
    
}



