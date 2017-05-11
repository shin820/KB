using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net;
using System.Web.Http;
using System.Web.Http.Description;
using KB.Entity;
using KB.Service.AppServices;

namespace KB.WebApi.Controllers
{
    public class ArticleController : ApiController
    {
        private IArticleAppService _articleAppService;

        public ArticleController(IArticleAppService articleAppService)
        {
            _articleAppService = articleAppService;
        }

        // GET: api/Article
        public IQueryable<t_KB_Article> GetArticle()
        {
            return _articleAppService.FindAll();
        }

        // GET: api/Article/5
        [ResponseType(typeof(t_KB_Article))]
        public IHttpActionResult GetArticle(int id)
        {
            t_KB_Article article = _articleAppService.Find(id);
            if (article == null)
            {
                return NotFound();
            }

            return Ok(article);
        }

        // PUT: api/Article/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutArticle(int id, t_KB_Article article)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != article.Id)
            {
                return BadRequest();
            }

            try
            {
                _articleAppService.Update(article);
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

        // POST: api/Article
        [ResponseType(typeof(t_KB_Article))]
        public IHttpActionResult PostArticle(t_KB_Article article)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            _articleAppService.Insert(article);

            return CreatedAtRoute("DefaultApi", new { id = article.Id }, article);
        }

        // DELETE: api/Article/5
        [ResponseType(typeof(t_KB_Article))]
        public IHttpActionResult DeleteArticle(int id)
        {
            t_KB_Article article = _articleAppService.Find(id);
            if (article == null)
            {
                return NotFound();
            }

            _articleAppService.Delete(article);

            return Ok(article);
        }
    }
}