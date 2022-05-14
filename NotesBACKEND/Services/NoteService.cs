using MySql.Data.MySqlClient;

namespace NotesBACKEND.Services;

public class NoteService
{
   // TODO: implementing db connection here for now, probably should move to another class and leave this free, will do later
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
}