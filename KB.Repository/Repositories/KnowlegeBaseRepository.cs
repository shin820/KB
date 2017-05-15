﻿using KB.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KB.Repository.Repositories
{
    public class KnowlegeBaseRepository : RepositoryBase<t_KB_KnowledgeBase>, IKnowlegeBaseRepository
    {
        public KnowlegeBaseRepository(KBDataContext dbContext) : base(dbContext)
        {
        }
    }

    public interface IKnowlegeBaseRepository : IRepositoryBase<t_KB_KnowledgeBase>
    {

    }
}
