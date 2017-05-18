using System.Linq;
using KB.Object.KB;

namespace KB.Process.KnowlegeBases
{
    public interface IKnowlegeBaseProcess
    {
        void Delete(int id);
        KnowlegeBase Find(int id);
        IQueryable<KnowlegeBase> FindAll();
        KnowlegeBase Insert(KnowlegeBase kbDto);
        void Update(int id, KnowlegeBase kbDto);
    }
}