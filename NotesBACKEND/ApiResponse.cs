using System.Text.Json;

namespace NotesBACKEND;

public class ApiResponse<T> where T : Note
{
   public ApiResponse(int statusCode, int count, IEnumerable<T> data)
   {
      StatusCode = statusCode;
      Count = count;
      Data = data;
   }

   public int StatusCode { get; set; } 
   public int Count { get; set; }
   public IEnumerable<T> Data { get; set; }

}