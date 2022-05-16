using MySql.Data.MySqlClient;

namespace NotesBACKEND.Services;

public class NoteService
{
   private SQLCustomHandler _sqlCustomHandler;
   
   public NoteService()
   {
      _sqlCustomHandler = new SQLCustomHandler();
   }

   public Note getNoteById(int id)
   {
      return _sqlCustomHandler.getSingleEntryByPK(id);
   } 
   
   public List<Note> getAllNotes()
   {
      return _sqlCustomHandler.getEntries();
   }

   public void insertNote(Note note)
   {
        _sqlCustomHandler.insertEntry(note); 
   }

   public void deleteNote(Note note)
   {
     _sqlCustomHandler.deleteEntry(note); 
   }

   public void deleteNote(int id)
   {
      _sqlCustomHandler.deleteEntry(id);
   }

   public void updateContent(int id, string content)
   {
      _sqlCustomHandler.updateEntryContent(id,content);
   }

   public void updateTitle(int id, string title)
   {
      _sqlCustomHandler.updateEntryTitle(id, title);
   }

   public int getUniqueID()
   {
      return getAllNotes().Last().getId() + 1; //Get a new id by incrementing the last one
   }
}