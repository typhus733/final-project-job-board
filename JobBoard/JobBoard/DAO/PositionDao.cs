﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace JobBoard.DAO
{
    public class PositionDao
    {
        private readonly DapperContext _context;

        public PositionDao(DapperContext context)
        {
            _context = context;
        }

    }
}