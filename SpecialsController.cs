using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Xml.Linq;

namespace BlazingPizza;

[Route("specials")]
[ApiController]
public class SpecialsController : Controller
{
    private readonly PizzaStoreContext _db;

    public SpecialsController(PizzaStoreContext db)
    {
        _db = db;
    }

    [HttpGet]
    public async Task<ActionResult<List<PizzaSpecial>>> GetSpecials()
    {
        return (await _db.Specials.ToListAsync()).OrderByDescending(s => s.BasePrice).ToList();
	}

	[HttpGet]
    [Route("/specials/{id}")]
	public async Task<ActionResult<PizzaSpecial>> GetSpecials(int id)
	{
		return (await _db.Specials.FirstOrDefaultAsync(option => option.Id.Equals(id)));
	}
}
