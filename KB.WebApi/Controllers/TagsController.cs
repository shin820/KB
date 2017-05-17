using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net;
using System.Web.Http;
using System.Web.Http.Description;
using KB.Object.Tags;
using KB.BizService.Tags;

namespace tag.WebApi.Controllers
{
    public class TagsController : ApiController
    {
        private ITagService _tagAppService;

        public TagsController(ITagService tagAppService)
        {
            _tagAppService = tagAppService;
        }

        public IQueryable<Tag> GetTags()
        {
            return _tagAppService.FindAll();
        }

        [ResponseType(typeof(Tag))]
        public IHttpActionResult GetTag(int id)
        {
            Tag tag = _tagAppService.Find(id);
            if (tag == null)
            {
                return NotFound();
            }

            return Ok(tag);
        }

        [ResponseType(typeof(void))]
        public IHttpActionResult PutTag(int id, Tag tag)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            try
            {
                _tagAppService.Update(id, tag);
            }
            catch (DbUpdateConcurrencyException)
            {
                if (_tagAppService.Find(id) == null)
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

        [ResponseType(typeof(Tag))]
        public IHttpActionResult PostTag(Tag createRequest)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var tag = _tagAppService.Insert(createRequest);

            return CreatedAtRoute("DefaultApi", new { id = tag.Id }, tag);
        }

        [ResponseType(typeof(Tag))]
        public IHttpActionResult DeleteTag(int id)
        {
            var tag = _tagAppService.Find(id);
            if (tag == null)
            {
                return NotFound();
            }

            _tagAppService.Delete(id);

            return Ok(tag);
        }
    }
}