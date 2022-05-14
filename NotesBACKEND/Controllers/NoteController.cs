using Microsoft.AspNetCore.Mvc;

namespace NotesBACKEND.Controllers;

[ApiController]
[Route("/note")]
public class NoteController
{
    private List<Note> noteList = new List<Note>(); //will load notes here through a NoteService

    // This method gets a note from NoteService
    [HttpGet(Name = "GetNote")]
    public String getNote(int id)
    {
        //TODO: implement NoteService.getNoteById(id)
        return null;
    }
   
    public List<Note> getAllNotes()
    {
        //Returning object for now, will see later if changes are needed
        return noteList;
    }

    public void deleteNote(int id)
    {
        //TODO: implement NoteService.deleteNoteById(id)
    }

    public void updateNote(int id, string content = null, string title = null)
    {
        //TODO: implement NoteService.updateNoteById(id, ?content, ?title)
        
    }
    
}



