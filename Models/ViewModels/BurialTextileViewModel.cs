namespace WhosYourMummy.Models.ViewModels
{
    public class BurialTextileViewModel
    {
        public List<BurialTextileData> JoinedData { get; set; }
        public IQueryable<Burialmain> Burialmains { get; set; }
        public IQueryable<BurialmainTextile> BurialmainTextiles { get; set; }
        public IQueryable<Textile> Textiles { get; set; }

        public int TotalPages { get; set; }
        public int CurrentPage { get; set; }
    }

}
