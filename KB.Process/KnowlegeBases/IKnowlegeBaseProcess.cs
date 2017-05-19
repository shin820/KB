using System.Linq;
using KB.Object.KB;

namespace KB.Process.KnowlegeBases
{
    public interface IKnowlegeBaseProcess
    {
        void Delete(int id);
        KnowlegeBaseInfo Find(int id);
        IQueryable<KnowlegeBaseInfo> FindAll();
        KnowlegeBaseInfo Insert(KnowlegeBaseInfo kbDto);
        void Update(int id, KnowlegeBaseInfo kbDto);
    }
}