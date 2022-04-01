using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace JobBoard.DAO
{
    public class CandidateDao
    {
        private readonly DapperContext _context;

        public CandidateDao(DapperContext context)
        {
            _context = context;
        }

    }
}
