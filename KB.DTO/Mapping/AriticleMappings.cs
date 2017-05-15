using AutoMapper;
using KB.Dto.Article;
using KB.Entity;

namespace KB.Dto.Mapping
{
    public class AriticleMappings : Profile
    {
        public AriticleMappings()
        {
            CreateMap<t_KB_Article, ArticleListReponse>();
            CreateMap<t_KB_Article, ArticleDetailResponse>();
            CreateMap<ArticleUpdateRequest, t_KB_Article>();
            CreateMap<ArticleCreateRequest, t_KB_Article>();
        }
    }
}
