using KB.Application.AppServices;
using KB.Application.Dto.KB;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net;
using System.Web.Http;
using System.Web.Http.Description;

namespace KB.WebApi.Controllers
{
    public class KnowlegeBasesController : ApiController
    {
        private IKnowlegeBaseAppService _kbAppService;

        public KnowlegeBasesController(IKnowlegeBaseAppService kbAppService)
        {
            _kbAppService = kbAppService;
        }

        public IQueryable<KnowlegeBaseDto> GetKnowlegeBases()
        {
            return _kbAppService.FindAll();
        }

        [ResponseType(typeof(KnowlegeBaseDto))]
        public IHttpActionResult GetKnowlegeBase(int id)
        {
            KnowlegeBaseDto kb = _kbAppService.Find((int)id);
            if (kb == null)
            {
                return NotFound();
            }

            return Ok(kb);
        }

        [ResponseType(typeof(void))]
        public IHttpActionResult PutKnowlegeBase(int id, KnowlegeBaseDto kb)
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

        [ResponseType(typeof(KnowlegeBaseDto))]
        public IHttpActionResult PostKnowlegeBase(KnowlegeBaseDto createRequest)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var kb = _kbAppService.Insert(createRequest);

            return CreatedAtRoute("DefaultApi", new { id = kb.Id }, kb);
        }

        [ResponseType(typeof(KnowlegeBaseDto))]
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