using KB.BizService.Articles;
using KB.Entity;
using KB.Repository.Articles;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace KB.UnitTest.BizService
{
    public class ArticleServiceTest
    {
        [Fact]
        public void ShouldDeleleteTags_WhenDeleteArticle()
        {
            // assign
            var article = new t_KB_Article
            {
                Id = 1,
                t_KB_ArticlesTagsRelation = new HashSet<t_KB_ArticlesTagsRelation>
                {
                    new t_KB_ArticlesTagsRelation{ArticleId=1,TagId=1}
                }
            };
            var articleRepositoryMock = new Mock<IArticleRepository>();
            articleRepositoryMock.Setup(t => t.Find(article.Id)).Returns(article);
            var articleTagRelationMock = new Mock<IArticlesTagsRelationRepository>();

            var articleRepository = articleRepositoryMock.Object;
            var articleTagRelationRepositry = articleTagRelationMock.Object;

            ArticleService articleService = new ArticleService(articleRepository, null, articleTagRelationRepositry);

            // act
            articleService.Delete(article.Id);

            // assert
            articleTagRelationMock.Verify(t => t.Delete(article.t_KB_ArticlesTagsRelation.First()));
        }
    }
}
