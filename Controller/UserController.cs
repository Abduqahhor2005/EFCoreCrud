using EFCoreCrud.Entity;
using EFCoreCrud.Service;
using Microsoft.AspNetCore.Mvc;

namespace EFCoreCrud.Controller;
[ApiController]
[Route("api/users")]
public class UserController(IUserService userService) : ControllerBase
{
    [HttpGet]
    [ProducesResponseType(StatusCodes.Status200OK)]
    public async Task<ActionResult<IEnumerable<User>>> GetUsers()
    {
        return Ok(await userService.GetAll());
    }

    [HttpGet("{id:int}")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<ActionResult<User?>> GetUserById([FromRoute]int id)
    {
        User? user = await userService.GetById(id);
        if (user == null) return NotFound();
        return Ok(await userService.GetById(id));
    }
    [HttpPost]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<ActionResult<User>> CreateUser([FromBody]User? user)
    {
        if (user == null) return BadRequest();
        return Ok(await userService.Create(user));
    }
    [HttpPut]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<ActionResult<User>> UpdateUser([FromBody]User? user)
    {
        if (user == null) return BadRequest();
        return Ok(await userService.Update(user));
    }

    [HttpDelete("{id:int}")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<ActionResult> DeleteUser(int id)
    {
        bool res = await userService.Delete(id);
        if (res!=true) return NotFound();
        return Ok(res);
    }
}