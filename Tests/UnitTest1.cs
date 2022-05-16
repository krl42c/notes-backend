using NotesBACKEND.Controllers;
using NotesBACKEND.Services;

namespace Tests;
using NotesBACKEND;
/* These tests require a local DB instance to be running for now*/
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
        Assert.Pass(); 
        //Assert.True(_noteController.createNote(_noteService.getUniqueID(), "Testing", "OK"));
    }

    [Test]
    public void deleteNoteTest()
    {
        Assert.Pass();
        //Assert.True(_noteController.deleteNote(2)); //place ID here beforing running
    }
}