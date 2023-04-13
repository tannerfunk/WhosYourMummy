using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WhosYourMummy.Data;
using WhosYourMummy.Models.ViewModels;

namespace WhosYourMummy.Models
{
    public class EFMummyRepository : IMummyRepository
    {
        private MummiesDbContext context { get; set; }



        public EFMummyRepository(MummiesDbContext temp) => context = temp;

        public IQueryable<Burialmain> Burialmains => context.Burialmains;

        public IQueryable<BurialmainTextile> BurialmainTextiles => context.BurialmainTextiles;

        public IQueryable<Textile> Textiles => context.Textiles;

        public void Add<T>(T entity) where T : class
        {
            context.Add(entity);
        }

        public void Remove<T>(T entity) where T : class
        {
            context.Remove(entity);
        }


    }


}
