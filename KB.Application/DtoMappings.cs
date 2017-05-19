using AutoMapper;
using KB.Application.Dto.Articles;
using KB.Application.Dto.KB;
using KB.Application.Dto.Tags;
using KB.Domain.Entities;

namespace KB.Application
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
