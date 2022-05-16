namespace NotesBACKEND;

public class DbAuth
{
    public DbAuth(string server, string user, string database, int port, string password)
    {
        this.server = server;
        this.user = user;
        this.database = database;
        this.port = port;
        this.password = password;
    }

    public string server { get; set; }
    public string user { get; set; }
    public string database { get; set; }
    public int port { get; set; }
    public string password { get; set; } // probably horrible things will happen
}