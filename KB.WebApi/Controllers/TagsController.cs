using KB.Application.AppServices;
using KB.Application.Dto.Tags;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net;
using System.Web.Http;
using System.Web.Http.Description;

namespace KB.WebApi.Controllers
{
    public class TagsController : ApiController
    {
        private ITagAppService _tagAppService;

        public TagsController(ITagAppService tagAppService)
        {
            _tagAppService = tagAppService;
        }

        public IQueryable<TagDto> GetTags()
        {
            return _tagAppService.FindAll();
        }

        [ResponseType(typeof(TagDto))]
        public IHttpActionResult GetTag(int id)
        {
            TagDto tag = _tagAppService.Find(id);
            if (tag == null)
            {
                return NotFound();
            }

            return Ok(tag);
        }

        [ResponseType(typeof(void))]
        public IHttpActionResult PutTag(int id, TagDto tag)
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

        [ResponseType(typeof(TagDto))]
        public IHttpActionResult PostTag(TagDto createRequest)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var tag = _tagAppService.Insert(createRequest);

            return CreatedAtRoute("DefaultApi", new { id = tag.Id }, tag);
        }

        [ResponseType(typeof(TagDto))]
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