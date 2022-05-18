namespace NotesBACKEND;

public class Note
{
   public int id { get; set; }
   public String title { get; set; } 
   public String content { get; set; }


   public Note(int id, string title, string content)
   {
      this.id = id;
      this.title = title;
      this.content = content;
   }

   public Note()
   {
      
   }

   public override string ToString()
   {
      return "ID: " + id + "\n" +
             "Title:" + title + "\n" +
             "Conntent" + content;
   }

}