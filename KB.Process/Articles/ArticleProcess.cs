using AutoMapper;
using AutoMapper.QueryableExtensions;
using KB.BizService.Articles;
using KB.Entity;
using KB.Object.Articles;
using System.Linq;

namespace KB.Process.Articles
{
    public class ArticleProcess : IArticleProcess
    {
        private IArticleService _articleService;
        public ArticleProcess(IArticleService articleService)
        {
            _articleService = articleService;
        }

        public ArticleDetail Find(int id)
        {
            var article = _articleService.Find(id);
            var articleDto = Mapper.Map<ArticleDetail>(article);
            return articleDto;
        }

        public IQueryable<Article> FindAll()
        {
            return _articleService.FindAll()
                .ProjectTo<Article>();
        }

        public void Delete(int id)
        {
            _articleService.Delete(id);
        }

        public void Update(int id, Article articleDto)
        {
            t_KB_Article article = _articleService.Find(id);
            if (article != null)
            {
                articleDto.Id = id;
                article = Mapper.Map(articleDto, article);
                _articleService.Update(article);
            }
        }

        public Article Insert(Article articleDto)
        {
            t_KB_Article article = Mapper.Map<t_KB_Article>(articleDto);
            _articleService.Insert(article);

            return Mapper.Map<Article>(article);
        }

        public void AddTag(int articleId, int tagId)
        {
            _articleService.AddTag(articleId, tagId);
        }

        public void RemoveTag(int articleId, int tagId)
        {
            _articleService.RemoveTag(articleId, tagId);
        }
    }
}
