using MySql.Data.MySqlClient;

namespace NotesBACKEND;

public interface SQLCustomHandlerInterface<T>
{
   public T getSingleEntryByPK(int PK);
   
   public List<T> getEntries();

   public void insertEntry(T cont);

   public void deleteEntry(T cont);


}