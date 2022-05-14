using Microsoft.AspNetCore.Mvc;

namespace NotesBACKEND.Controllers;

[ApiController]
[Route("/note")]
public class NoteController
{
    [HttpGet(Name = "GetNote")]
    public String getNote()
    {
        return "Testing";
    }
}