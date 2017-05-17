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
            CreateMap<t_KB_Article, Article>()
                .ConstructUsing(s => new Article(s.Id, s.SiteId));
            CreateMap<t_KB_Article, ArticleDetail>()
                .ConstructUsing(s => new ArticleDetail(s.Id, s.SiteId));
            CreateMap<Article, t_KB_Article>();

            // KnowlgeBase
            CreateMap<t_KB_KnowledgeBase, KnowlegeBase>()
                .ConstructUsing(s => new KnowlegeBase(s.Id, s.SiteId));
            CreateMap<KnowlegeBase, t_KB_KnowledgeBase>();

            // Tag
            CreateMap<t_KB_Tag, Tag>()
                .ConstructUsing(s => new Tag(s.Id, s.SiteId));
            CreateMap<Tag, t_KB_Tag>();
        }
    }
}
