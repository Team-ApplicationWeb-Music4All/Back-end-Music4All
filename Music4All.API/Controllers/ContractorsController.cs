using System.Net.Mime;
using System.Security;
using Microsoft.AspNetCore.Mvc;

namespace Music4All.API.Controllers;

//[Authorize]
[Route("api/v1/[controller]")]
[ApiController]
[Produces(MediaTypeNames.Application.Json)]
public class ContractorsController : ControllerBase
{
    
}