using System.Text.Json;

namespace NotesBACKEND;

public class JsonFileReader
{
    public static T? readFile<T>(string path)
    {
        string text = File.ReadAllText(path);
        return JsonSerializer.Deserialize<T>(text);
    }
}