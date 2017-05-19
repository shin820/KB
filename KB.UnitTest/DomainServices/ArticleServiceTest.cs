using KB.DomainService.Services;
using KB.Entity;
using KB.Repository.Repositories;
using Moq;
using System.Collections.Generic;
using System.Linq;
using Xunit;

namespace KB.UnitTest.DomainServices
{
    public class ArticleServiceTest
    {
        [Fact]
        public void ShouldDeleleteTags_WhenDeleteArticle()
        {
            // assign
            var article = new Article
            {
                Id = 1,
                ArticleTags = new HashSet<ArticleTags>
                {
                    new ArticleTags{ArticleId=1,TagId=1}
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
            articleTagRelationMock.Verify(t => t.Delete(article.ArticleTags.First()));
        }
    }
}
