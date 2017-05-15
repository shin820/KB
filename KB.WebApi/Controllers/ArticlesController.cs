﻿using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net;
using System.Web.Http;
using System.Web.Http.Description;
using KB.Service.AppServices;
using KB.Dto.Article;

namespace KB.WebApi.Controllers
{
    public class ArticlesController : ApiController
    {
        private IArticleAppService _articleAppService;

        public ArticlesController(IArticleAppService articleAppService)
        {
            _articleAppService = articleAppService;
        }

        // GET: api/articles
        public IQueryable<ArticleListReponse> GetArticles()
        {
            return _articleAppService.FindAll();
        }

        // GET: api/articles/5
        [ResponseType(typeof(ArticleDetailResponse))]
        public IHttpActionResult GetArticle(int id)
        {
            ArticleDetailResponse article = _articleAppService.Find(id);
            if (article == null)
            {
                return NotFound();
            }

            return Ok(article);
        }

        // PUT: api/articles/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutArticle(int id, ArticleUpdateRequest article)
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
        [ResponseType(typeof(ArticleDetailResponse))]
        public IHttpActionResult PostArticle(ArticleCreateRequest createRequest)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var article = _articleAppService.Insert(createRequest);

            return CreatedAtRoute("DefaultApi", new { id = article.Id }, article);
        }

        // DELETE: api/articles/5
        [ResponseType(typeof(ArticleDetailResponse))]
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
    }
}