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
            CreateMap<Article, ArticleDto>();
            CreateMap<Article, ArticleDetailDto>();
            CreateMap<ArticleDto, Article>();

            // KnowlgeBase
            CreateMap<KnowledgeBase, KnowlegeBaseDto>();
            CreateMap<KnowlegeBaseDto, KnowledgeBase>();

            // Tag
            CreateMap<Tag, TagDto>();
            CreateMap<TagDto, Tag>();
        }
    }
}
