namespace WhosYourMummy.Models.ViewModels
{
    public class BurialTextileViewModel
    {
        public List<BurialTextileData> JoinedData { get; set; }
        public IQueryable<Burialmain> Burialmains { get; set; }
        public IQueryable<BurialmainTextile> BurialmainTextiles { get; set; }
        public IQueryable<Textile> Textiles { get; set; }
        public string Id { get; set; }
        public string Sex { get; set; }
        public string Year { get; set; }
        public string Depth { get; set; }
        public string Age { get; set; }
        public string Head { get; set; }
        public string Hair { get; set; }
        public string Face { get; set; }
        public string Wrap { get; set; }
        public string Area { get; set; }

        public int TotalPages { get; set; }
        public int CurrentPage { get; set; }
    }

}
