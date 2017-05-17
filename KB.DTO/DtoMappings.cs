using AutoMapper;
using KB.Object.Articles;
using KB.Object.KB;
using KB.Object.Tags;
using KB.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KB.Object
{
    public class DtoMappings : Profile
    {
        public DtoMappings()
        {
            // Article
            CreateMap<t_KB_Article, Article>();
            CreateMap<t_KB_Article, ArticleDetail>();
            CreateMap<Article, t_KB_Article>();

            // KnowlgeBase
            CreateMap<t_KB_KnowledgeBase, KnowlegeBase>();
            CreateMap<KnowlegeBase, t_KB_KnowledgeBase>();

            // Tag
            CreateMap<t_KB_Tag, Tag>();
            CreateMap<Tag, t_KB_Tag>();
        }
    }
}
