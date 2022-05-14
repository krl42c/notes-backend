using System.Net.Mime;
using MySql.Data.MySqlClient;

namespace NotesBACKEND;



public class SQLCustomHandler : SQLCustomHandlerInterface<Note>
{
   private MySqlConnection mySqlConnection;
   
   public SQLCustomHandler()
   {
      string connString = "CONN STRING"; //server=localhost;user=root;database=notesapp;port=3306;password=*******
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

   public void insertEntry(Note cont)
   {
      mySqlConnection.Open();
      string query = "insert into notes(id,title,content) values (@id, @title, @content)";
      
      MySqlCommand cmd = new MySqlCommand(query, mySqlConnection);

      cmd.Parameters.AddWithValue("@id",cont.getId());
      cmd.Parameters.AddWithValue("@title", cont.getTitle());
      cmd.Parameters.AddWithValue("@content", cont.getContent());
      
      cmd.ExecuteNonQuery();
   }

   public void deleteEntry(Note cont)
   {
      mySqlConnection.Open();
      string query = "delete from notes where id=@id";
      
      MySqlCommand cmd = new MySqlCommand(query, mySqlConnection);
      cmd.Parameters.AddWithValue("@id", cont.getId());
      cmd.ExecuteNonQuery();
   }

   public void deleteEntry(int id)
   {
      mySqlConnection.Open();
      string query = "delete from notes where id=@id";
      
      MySqlCommand cmd = new MySqlCommand(query, mySqlConnection);
      cmd.Parameters.AddWithValue("@id", id);
      cmd.ExecuteNonQuery();
   }
}