using System;
using FosterCareAPI.Core.Models;
using FosterCareAPI.ApiModels;
using FosterCareAPI.Core.Services;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace FosterCareAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ChildrenController : ControllerBase
    {
        private readonly IChildrenService _childrenService;

        public ChildrenController(IChildrenService _childrenService)
        {
            _childrenService = ChildrenService;
        }
        // GET api/values
        [HttpGet]
        public IActionResult Get()
        {
            try
            {
                var childrenModels = _childrenService
                    .GetAll()
                    .ToApiModels();

                return Ok(childrenModels);

            }
            catch (Exception ex)
            {
                ModelState.AddModelError("GetChildren", ex.Message);
                return BadRequest(ModelState);
            }
        }

        // GET api/values/5
        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            try
            {
                var child = _childrenService.Get(id);
                var childrenModels = child.ToApiModel();
                return Ok(childrenModels);
            }
            catch (System.Exception ex)
            {
                ModelState.AddModelError("GetChildren", ex.Message);
                return BadRequest(ModelState);
            }
        }

        // POST api/values
        [HttpPost]
        public IActionResult Post([FromBody] ChildrenModel newchildren)
        {
            try
            {
                _childrenService.Add(newchildren.ToDomainModel());
            }
            catch (System.Exception ex)
            {
                ModelState.AddModelError("AddChildren", ex.Message);
                return BadRequest(ModelState);
            }

            return CreatedAtAction("Get", new { Id = newChildren.Id }, newchildren);
        }

        // PUT api/values/5
        [HttpPut("{id}")]
        public IActionResult Put(int id, [FromBody] Children child)
        {
            try
            {
                var children = _childrenService.Update(updatedChildren.ToDomainModel());
                if (children == null) return NotFound();
                return Ok(_childrenService.Update(children).ToApiModel());
            }
            catch (Exception ex)
            {
                ModelState.AddModelError("UpdateChildren", ex.Message);
                return BadRequest(ModelState);
            }
        }

        // DELETE api/values/5
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
                var children = _childrenService.Get(id);
                if (children == null) return NotFound();
                _childrenService.Remove(children);
                return NoContent();
        }
    }
}
