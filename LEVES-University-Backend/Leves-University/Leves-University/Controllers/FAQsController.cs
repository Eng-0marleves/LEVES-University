﻿using Leves_University.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Linq;

namespace Leves_University.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FAQsController : ControllerBase
    {
        private readonly LevesEntities context;

        public FAQsController(LevesEntities context)
        {
            this.context = context;
        }

        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public ActionResult<IEnumerable<FAQs>> GetAll()
        {
            var FAQsList = context.FAQs.ToList();
            return Ok(FAQsList);
        }

        [HttpGet("{id:int}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public ActionResult<FAQs> GetOne(int id)
        {
            if (id <= 0)
            {
                return BadRequest();
            }

            var faq = context.FAQs.FirstOrDefault(f => f.ID == id);
            if (faq == null)
            {
                return NotFound();
            }

            return Ok(faq);
        }

        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public ActionResult<FAQs> Add([FromBody] FAQs faq)
        {
            if (faq == null)
            {
                return BadRequest();
            }

            if (faq.ID > 0)
            {
                return StatusCode(StatusCodes.Status500InternalServerError);
            }

            context.FAQs.Add(faq);
            context.SaveChanges();

            return CreatedAtAction(nameof(GetOne), new { id = faq.ID }, faq);
        }

        [HttpDelete("{id:int}", Name = "Delete")]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        public ActionResult Delete(int id)
        {
            if (id == null)
            {
                return BadRequest();
            }

            var faq = context.FAQs.FirstOrDefault(u => u.ID == id);
            if (faq == null)
            {
                return NotFound();
            }
            context.FAQs.Remove(faq);
            return NoContent();
        }

        [HttpPut("{id:int}")]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        public ActionResult Update(int id, [FromBody]FAQs faq_i)
        {
            if (id == null)
            {
                return BadRequest();
            }
            var faq = context.FAQs.FirstOrDefault(u => u.ID == id);
            if (faq == null)
            {
                return NotFound();
            }
            faq.Header = faq_i.Header;
            faq.Content = faq_i.Content;
            return NoContent();
        }
    }
}