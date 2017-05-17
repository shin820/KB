using AutoMapper;
using KB.Dto.Article;
using KB.Dto.KB;
using KB.Dto.Tag;
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
            CreateMap<t_KB_Article, ArticleDto>();
            CreateMap<t_KB_Article, ArticleDetailDto>();
            CreateMap<ArticleDto, t_KB_Article>();

            // KnowlgeBase
            CreateMap<t_KB_KnowledgeBase, KBDto>();
            CreateMap<KBDto, t_KB_KnowledgeBase>();

            // Tag
            CreateMap<t_KB_Tag, TagDto>();
            CreateMap<TagDto, t_KB_Tag>();
        }
    }
}
