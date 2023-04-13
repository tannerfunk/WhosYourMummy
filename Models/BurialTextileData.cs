using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WhosYourMummy.Models
{
    public class BurialTextileData
    {
        [Key]
        public long BurialId { get; set; }
        public long TextileId { get; set; }
        public string TextileName { get; set; }
        public string? ExcavationYear { get; set; }
        public string? Area { get; set; }
        public string? Sex { get; set; }

    }
}
