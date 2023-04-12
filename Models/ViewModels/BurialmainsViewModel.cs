using System;
using System.Collections.Generic;
using System.Drawing.Printing;
using System.Linq;
using System.Threading.Tasks;

namespace WhosYourMummy.Models.ViewModels
{
    public class BurialmainsViewModel
    {
        public IQueryable<Burialmain> Burialmains { get; set; }
        //public PageInfo PageInfo { get; set; }
    }
}
