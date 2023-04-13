using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;


namespace WhosYourMummy.Models
{
    public interface IMummyRepository
    {
        IQueryable<Burialmain> Burialmains { get; }
        IQueryable<BurialmainTextile> BurialmainTextiles { get; }
        IQueryable<Textile> Textiles { get; }

        void Add<T>(T entity) where T : class;
        void Remove<T>(T entity) where T : class;

        //int SaveChanges();

        void AddBurialmain(Burialmain burialmain);

    }
}
