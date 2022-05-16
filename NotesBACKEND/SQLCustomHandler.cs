﻿using System.Net.Mime;
using MySql.Data.MySqlClient;

namespace NotesBACKEND;



public class SQLCustomHandler : SQLCustomHandlerInterface<Note>
{
   private MySqlConnection mySqlConnection;
   
   public SQLCustomHandler()
   {
      string connString;
      DbAuth? dbAuth = JsonFileReader.readFile<DbAuth>("dbConfig.json");
      if (dbAuth is not null)
      {
         connString = "server=" + dbAuth.server + ";user=" + dbAuth.user + ";database=" + dbAuth.database + ";port=" +
                      dbAuth.port + ";password=" + dbAuth.password;
      }
      else
      {
         throw new CustomException("User not found");
      }
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

   public bool noteExists(int id)
   {
      Note note = null;
      mySqlConnection.Open();
      string query = "SELECT * FROM NOTES WHERE ID=" + id;
      MySqlCommand cmd = new MySqlCommand(query, mySqlConnection);

      MySqlDataReader reader = cmd.ExecuteReader();
      while (reader.Read())
      {
         mySqlConnection.Close();
         return true;
      }
      mySqlConnection.Close();
      return false;
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

      cmd.Parameters.AddWithValue("@id",cont.id);
      cmd.Parameters.AddWithValue("@title", cont.title);
      cmd.Parameters.AddWithValue("@content", cont.content);
      
      cmd.ExecuteNonQuery();
      mySqlConnection.Close();
   }

   public void deleteEntry(Note cont)
   {
      mySqlConnection.Open();
      string query = "delete from notes where id=@id";
      
      MySqlCommand cmd = new MySqlCommand(query, mySqlConnection);
      cmd.Parameters.AddWithValue("@id", cont.id);
      cmd.ExecuteNonQuery();
      mySqlConnection.Close();
   }

   public void updateEntryContent(int id, string cont)
   {
      mySqlConnection.Open();
      string query = "update notes set content=@content where id=@id";

      MySqlCommand cmd = new MySqlCommand(query, mySqlConnection);
      cmd.Parameters.AddWithValue("@content", cont);
      cmd.Parameters.AddWithValue("@id", id);
      cmd.ExecuteNonQuery(); 
      mySqlConnection.Close();
   }

   public void updateEntryTitle(int id, string title)
   {
      mySqlConnection.Open();
      string query = "update notes set content=@content where id=@id";

      MySqlCommand cmd = new MySqlCommand(query, mySqlConnection);
      cmd.Parameters.AddWithValue("@content", title);
      cmd.Parameters.AddWithValue("@id", id);
      cmd.ExecuteNonQuery();     
      mySqlConnection.Close();
   }

   public void deleteEntry(int id)
   {
      mySqlConnection.Open();
      string query = "delete from notes where id=@id";
      
      MySqlCommand cmd = new MySqlCommand(query, mySqlConnection);
      cmd.Parameters.AddWithValue("@id", id);
      cmd.ExecuteNonQuery();
      mySqlConnection.Close();
   }
}