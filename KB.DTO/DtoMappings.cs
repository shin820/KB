using AutoMapper;
using KB.Dto.Article;
using KB.Dto.KB;
using KB.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KB.Dto
{
    public class DtoMappings : Profile
    {
        public DtoMappings()
        {
            // Article
            CreateMap<t_KB_Article, ArticleListReponse>();
            CreateMap<t_KB_Article, ArticleDetailResponse>();
            CreateMap<ArticleUpdateRequest, t_KB_Article>();
            CreateMap<ArticleCreateRequest, t_KB_Article>();

            // KnowlgeBase
            CreateMap<t_KB_KnowledgeBase, KBListResponse>();
            CreateMap<t_KB_KnowledgeBase, KBDetailResponse>();
            CreateMap<KBUpdateRequest, t_KB_KnowledgeBase>();
            CreateMap<KBCreateRequest, t_KB_KnowledgeBase>();
        }
    }
}
