using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net;
using System.Web.Http;
using System.Web.Http.Description;
using KB.Object.Articles;
using KB.BizService.Articles;

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
        public IQueryable<Article> GetArticles()
        {
            return _articleAppService.FindAll();
        }

        // GET: api/articles/5
        [ResponseType(typeof(ArticleDetail))]
        public IHttpActionResult GetArticle(int id)
        {
            ArticleDetail article = _articleAppService.Find(id);
            if (article == null)
            {
                return NotFound();
            }

            return Ok(article);
        }

        // PUT: api/articles/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutArticle(int id, Article article)
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
        [ResponseType(typeof(Article))]
        public IHttpActionResult PostArticle(Article createRequest)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var article = _articleAppService.Insert(createRequest);

            return CreatedAtRoute("DefaultApi", new { id = article.Id }, article);
        }

        // DELETE: api/articles/5
        [ResponseType(typeof(ArticleDetail))]
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