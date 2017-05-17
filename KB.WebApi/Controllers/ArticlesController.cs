using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net;
using System.Web.Http;
using System.Web.Http.Description;
using KB.Service.AppServices;
using KB.Dto.Article;
using System.Net.Http;

namespace KB.WebApi.Controllers
{
    [RoutePrefix("api/articles")]
    public class ArticlesController : ApiController
    {
        private IArticleAppService _articleAppService;

        public ArticlesController(IArticleAppService articleAppService)
        {
            _articleAppService = articleAppService;
        }

        // GET: api/articles
        public IQueryable<ArticleDto> GetArticles()
        {
            return _articleAppService.FindAll();
        }

        // GET: api/articles/5
        [ResponseType(typeof(ArticleDetailDto))]
        public IHttpActionResult GetArticle(int id)
        {
            ArticleDetailDto article = _articleAppService.Find(id);
            if (article == null)
            {
                return NotFound();
            }

            return Ok(article);
        }

        // PUT: api/articles/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutArticle(int id, ArticleDto article)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            try
            {
                _articleAppService.Update(id, article);
            }
            catch (DbUpdateConcurrencyException)
            {
                if (_articleAppService.Find(id) == null)
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

        // POST: api/articles
        [ResponseType(typeof(ArticleDto))]
        public IHttpActionResult PostArticle(ArticleDto createRequest)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var article = _articleAppService.Insert(createRequest);

            return CreatedAtRoute("DefaultApi", new { id = article.Id }, article);
        }

        // DELETE: api/articles/5
        [ResponseType(typeof(ArticleDetailDto))]
        public IHttpActionResult DeleteArticle(int id)
        {
            var article = _articleAppService.Find(id);
            if (article == null)
            {
                return NotFound();
            }

            _articleAppService.Delete(id);

            return Ok(article);
        }

        [HttpPost]
        [Route("{articleId}/tags/{tagId}")]
        public IHttpActionResult AddTag(int articleId, int tagId)
        {
            // todo : error handling.
            _articleAppService.AddTag(articleId, tagId);
            return StatusCode(HttpStatusCode.Created);
        }

        [HttpDelete]
        [Route("{articleId}/tags/{tagId}")]
        public IHttpActionResult RemoveTag(int articleId, int tagId)
        {
            // todo : error handling.
            _articleAppService.RemoveTag(articleId, tagId);
            return StatusCode(HttpStatusCode.NoContent);
        }
    }
}