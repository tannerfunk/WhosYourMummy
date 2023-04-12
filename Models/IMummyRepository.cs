using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;


namespace WhosYourMummy.Models
{
    public interface IMummyRepository
    {
        IQueryable<Burialmain> Burialmains { get; }
    }
}
