using NotesBACKEND.Controllers;
using NotesBACKEND.Services;

namespace Tests;
using NotesBACKEND;

public class Tests
{
    private NoteController? _noteController;
    private NoteService? _noteService; 
    
    [SetUp]
    public void Setup()
    {
        _noteController = new NoteController();
        _noteService = new NoteService();
    }

    [Test]
    public void createNoteTest()
    {
        Assert.True(_noteController.createNote(_noteService.getUniqueID(), "Testing", "OK"));
    }

    [Test]
    public void deleteNoteTest()
    {
        Assert.True(_noteController.deleteNote(2)); //place ID here beforing running
    }
}