﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WhosYourMummy.Models
{
    public class EFMummyRepository : IMummyRepository
    {
        private MummyDbContext context { get; set; }



        public EFMummyRepository(MummyDbContext temp) => context = temp;

        public IQueryable<Burialmain> Burialmains => context.Burialmains;


    }
}
