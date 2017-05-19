using AutoMapper;
using KB.ApplicationService.Dto.Articles;
using KB.ApplicationService.Dto.KB;
using KB.ApplicationService.Dto.Tags;
using KB.Entity;

namespace KB.ApplicationService
{
    public class DtoMappings : Profile
    {
        public DtoMappings()
        {
            // Article
            CreateMap<Article, ArticleInfo>();
            CreateMap<Article, ArticleDetail>();
            CreateMap<ArticleInfo, Article>();

            // KnowlgeBase
            CreateMap<KnowledgeBase, KnowlegeBaseInfo>();
            CreateMap<KnowlegeBaseInfo, KnowledgeBase>();

            // Tag
            CreateMap<Tag, TagInfo>();
            CreateMap<TagInfo, Tag>();
        }
    }
}
