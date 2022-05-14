using MySql.Data.MySqlClient;

namespace NotesBACKEND;

public class SQLCustomHandler : SQLCustomHandlerInterface<Note>
{
   private MySqlConnection mySqlConnection;
   
   public SQLCustomHandler()
   {
      string connString = "CONNSTRING HARDCODED FOR NOW";
      mySqlConnection = new MySqlConnection(connString);
   }
   
   public Note getSingleEntryByPK(int id)
   {  
      Note note = null;
      mySqlConnection.Open();
      string query = "SELECT * FROM NOTES WHERE ID=" + id;
      MySqlCommand cmd = new MySqlCommand(query, mySqlConnection);

      MySqlDataReader reader = cmd.ExecuteReader();

      while (reader.Read())
      {
         note = new Note(Convert.ToInt32(reader[0]), Convert.ToString(reader[1]), Convert.ToString(reader[2]));
         
      }
      mySqlConnection.Close();
      return note;
      
   }

   public List<Note> getEntries()
   {
      List<Note> noteList = new List<Note>();
      
      mySqlConnection.Open();
      string query = "SELECT * FROM NOTES"; 
      MySqlCommand cmd = new MySqlCommand(query, mySqlConnection);

      MySqlDataReader reader = cmd.ExecuteReader();

      while (reader.Read())
      {
         noteList.Add(new Note(Convert.ToInt32(reader[0]), Convert.ToString(reader[1]), Convert.ToString(reader[2])));

      }
      mySqlConnection.Close();
      return noteList; 
   }
}