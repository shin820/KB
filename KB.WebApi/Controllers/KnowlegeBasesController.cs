using KB.Object.KB;
using KB.Process.KnowlegeBases;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net;
using System.Web.Http;
using System.Web.Http.Description;

namespace KB.WebApi.Controllers
{
    public class KnowlegeBasesController : ApiController
    {
        private IKnowlegeBaseProcess _kbAppService;

        public KnowlegeBasesController(IKnowlegeBaseProcess kbAppService)
        {
            _kbAppService = kbAppService;
        }

        public IQueryable<KnowlegeBase> GetKnowlegeBases()
        {
            return _kbAppService.FindAll();
        }

        [ResponseType(typeof(KnowlegeBase))]
        public IHttpActionResult GetKnowlegeBase(int id)
        {
            KnowlegeBase kb = _kbAppService.Find((int)id);
            if (kb == null)
            {
                return NotFound();
            }

            return Ok(kb);
        }

        [ResponseType(typeof(void))]
        public IHttpActionResult PutKnowlegeBase(int id, KnowlegeBase kb)
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

        [ResponseType(typeof(KnowlegeBase))]
        public IHttpActionResult PostKnowlegeBase(KnowlegeBase createRequest)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var kb = _kbAppService.Insert(createRequest);

            return CreatedAtRoute("DefaultApi", new { id = kb.Id }, kb);
        }

        [ResponseType(typeof(KnowlegeBase))]
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