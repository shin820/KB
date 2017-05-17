using KB.AppService.KnowlegeBase;
using KB.Dto.KB;
using System;
using System.Collections.Generic;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Http;
using System.Web.Http.Description;

namespace KB.WebApi.Controllers
{
    public class KnowlegeBasesController : ApiController
    {
        private IKnowlegeBaseService _kbAppService;

        public KnowlegeBasesController(IKnowlegeBaseService kbAppService)
        {
            _kbAppService = kbAppService;
        }

        public IQueryable<KBDto> GetKnowlegeBases()
        {
            return _kbAppService.FindAll();
        }

        [ResponseType(typeof(KBDto))]
        public IHttpActionResult GetKnowlegeBase(int id)
        {
            KBDto kb = _kbAppService.Find(id);
            if (kb == null)
            {
                return NotFound();
            }

            return Ok(kb);
        }

        [ResponseType(typeof(void))]
        public IHttpActionResult PutKnowlegeBase(int id, KBDto kb)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            try
            {
                _kbAppService.Update(id, kb);
            }
            catch (DbUpdateConcurrencyException)
            {
                if (_kbAppService.Find(id) == null)
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return StatusCode(HttpStatusCode.NoContent);
        }

        [ResponseType(typeof(KBDto))]
        public IHttpActionResult PostKnowlegeBase(KBDto createRequest)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var kb = _kbAppService.Insert(createRequest);

            return CreatedAtRoute("DefaultApi", new { id = kb.Id }, kb);
        }

        [ResponseType(typeof(KBDto))]
        public IHttpActionResult DeleteKnowlegeBase(int id)
        {
            var kb = _kbAppService.Find(id);
            if (kb == null)
            {
                return NotFound();
            }

            _kbAppService.Delete(id);

            return Ok(kb);
        }
    }
}