using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using SeeSharp.Models;
using SeeSharp.Services;

namespace SeeSharp.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class GlassesController : ControllerBase
    {
        public GlassesController()
        {
        }

        [HttpGet]
            public ActionResult<List<GlassesPair>> GetAll() =>
                GlassesService.GetAll();

        [HttpGet("{id}")]
            public ActionResult<GlassesPair> Get(int id)
        {
            var glassesPair = GlassesService.Get(id);

            if(glassesPair == null)
            return NotFound();

            return glassesPair;
        }

        [HttpPost]
            public IActionResult Create(GlassesPair glassesPair)
        {            
            GlassesService.Add(glassesPair);
            return CreatedAtAction(nameof(Create), new { id = glassesPair.Id }, glassesPair);
        }

        [HttpPut("{id}")]
            public IActionResult Update(int id, GlassesPair glassesPair)
        {
            if (id != glassesPair.Id)
            return BadRequest();

            var existingGlassesPair = GlassesService.Get(id);
            if(existingGlassesPair is null)
            return NotFound();

            GlassesService.Update(glassesPair);           

            return NoContent();
        }

        [HttpDelete("{id}")]
            public IActionResult Delete(int id)
        {
            var glassesPair = GlassesService.Get(id);

            if (glassesPair is null)
            return NotFound();

            GlassesService.Delete(id);

            return NoContent();
        }
    }
}