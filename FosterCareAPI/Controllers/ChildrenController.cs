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
        public IActionResult GetAll()
        {
            try
            {
                var children = _childrenService.GetAll();
                var childrenModels = children.Select(b => b.ToApiModel());
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
                var children = _childrenService.Get(childrenId);
                var childrenModels = children.ToApiModel();
                return Ok(childrenModels);
            }
            catch (Exception ex)
            {
                ModelState.AddModelError("GetChildren", ex.Message);
                return BadRequest(ModelState);
            }
        }

        // POST api/values
        [HttpPost]
        public IActionResult Post([FromBody] Children children)
        {
            try
            {
                return Ok(_childrenService.Add(children).ToApiModel());
            }
            catch (Exception ex)
            {
                ModelState.AddModelError("AddChildren", ex.Message);
                return BadRequest(ModelState);
            }
        }

        // PUT api/values/5
        [HttpPut("{id}")]
        public IActionResult Put(int id, [FromBody] Children children)
        {
            try
            {
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
            try
            {
                _childrenService.Remove(id);
                return Ok();
            }
            catch (Exception ex)
            {
                ModelState.AddModelError("DeleteChildren", ex.Message);
                return BadRequest(ModelState);
            }
        }
    }
}
