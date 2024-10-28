using Microsoft.AspNetCore.Mvc;
using RestApi.Data;
using RestApi.Models;
using System;
using System.Runtime.InteropServices;
using System.Text.Unicode;
using static RestApi.Data.UserRepository;
using static System.Net.Mime.MediaTypeNames;

[Route("api/[controller]")]
[ApiController]
public class UserController : ControllerBase
{
    private readonly UserRepository _context;

    public UserController()
    {
        _context = new UserRepository();
    }

    [HttpOptions]
    public ActionResult AllowRequest()
    {
        return Ok("Allow: GET, POST, PUT, DELETE, HEAD");
    }

    [HttpHead]
    public ActionResult IsAlive()
    {
        return Ok("Content - Type: text / plain; charset = UTF - 8");
    }

    [HttpGet]
    public ActionResult<IEnumerable<UserModel>> GetUsers()
    {
        return Ok(_context.GetUsers());
    }

    [HttpGet("{id}")]
    public ActionResult<UserModel> GetUser(int id)
    {
        var user = _context.GetUser(id);

        if (user == null)
        {
            return NotFound();
        }

        return Ok(user);
    }

    [HttpPost]
    public ActionResult<UserModel> PostUser(UserModel user)
    {
        _context.AddUser(user);

        return Ok(user);
    }

    [HttpPut("{id}")]
    public ActionResult PutUser(int id, UserModel userUpdater)
    {
        var state = _context.UpdateUser(id, userUpdater);

        if (state == null)
        {
            return NotFound();
        }

        return Ok(state);
    }

    [HttpDelete("{id}")]
    public ActionResult DeleteUser(int id)
    {
        var state = _context.DeleteUser(id);

        if (state == null)
        {
            return NotFound();
        }

        return Ok(state);
    }
}