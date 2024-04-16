using Microsoft.AspNetCore.Mvc;

using Ms.Core.ApplicationServices;

namespace Ms.Endpoints.Api.Controllers;

[Route("api/[controller]")]
[ApiController]
public class Person(PersonApplicationService applicationService) : ControllerBase
{
    private PersonApplicationService ApplicationService { get; } = applicationService;

    [HttpPost]
    public IActionResult AddPerson(CreatePersonInputDto createPersonInputDto)
    {
        ApplicationService.AddPerson(createPersonInputDto);
        return Ok();
    }
    [HttpPut]
    public IActionResult AddNumberToPerson(AddNumberToPersonInputDto inputDto)
    {
        ApplicationService.AddNumberToPerson(inputDto);
        return Ok();
    }
}