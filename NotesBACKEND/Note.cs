namespace NotesBACKEND;

public class Note
{
   private int id { get; }
   private String title { get; set; }
   private String content { get; set; }


   public Note(int id, string title, string content)
   {
      this.id = id;
      this.title = title;
      this.content = content;
   }

   public override string ToString()
   {
      return "ID: " + id + "\n" +
             "Title:" + title + "\n" +
             "Conntent" + content;
   }

   public String getContent()
   {
      return content;
   }

   public String getTitle()
   {
      return title;
   }

   public int getId()
   {
      return id;
   }
}