using AutoMapper;
using AutoMapper.QueryableExtensions;
using KB.BizService.KnowlegeBases;
using KB.Entity;
using KB.Object.KB;
using System.Linq;

namespace KB.Process.KnowlegeBases
{
    public class KnowlegeBaseProcess : IKnowlegeBaseProcess
    {
        private IKnowlegeBaseService _service;
        public KnowlegeBaseProcess(
                IKnowlegeBaseService service
            )
        {
            _service = service;
        }

        public KnowlegeBase Find(int id)
        {
            var article = _service.Find(id);
            return Mapper.Map<KnowlegeBase>(article);
        }

        public IQueryable<KnowlegeBase> FindAll()
        {
            return _service.FindAll()
                .ProjectTo<KnowlegeBase>();
        }

        public void Delete(int id)
        {
            _service.Delete(id);
        }

        public void Update(int id, KnowlegeBase kbDto)
        {
            t_KB_KnowledgeBase kb = _service.Find(id);
            if (kb != null)
            {
                kb.Id = id;
                kb = Mapper.Map(kbDto, kb);
                _service.Update(kb);
            }
        }

        public KnowlegeBase Insert(KnowlegeBase kbDto)
        {
            t_KB_KnowledgeBase kb = Mapper.Map<t_KB_KnowledgeBase>(kbDto);
            _service.Insert(kb);

            return Mapper.Map<KnowlegeBase>(kb);
        }
    }
}
