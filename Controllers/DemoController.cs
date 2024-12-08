using CollegeApp.MyLogging;
using Microsoft.AspNetCore.Mvc;

namespace CollegeApp.Controllers;
[ApiController]
[Route("api/[controller]")]
public class DemoController : ControllerBase
{
    //strongly couple tecq
//    private readonly IMyLogger _logger;

//    public DemoController()
//    {
//        _logger = new LogToDB();
//    }
    public readonly IMyLogger _logger;

    public DemoController(IMyLogger logger) // this will inject the object in the logger and then we assign that to local variable.
    {//how does this function knows which log to call for that we need to add AddScopped in our program.cs file
        _logger = logger;
    }

    [HttpGet]
    public ActionResult Index()
    {
        _logger.Log("Index method started");
        return Ok();
    }
}