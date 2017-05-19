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
