using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace Module4_HW6.Models
{
    public class Artist
    {
        public int ArtistId { get; set; }
        public string ArtistName { get; set; }
        public DateTime DateOfBirth { get; set; }

        [RegularExpression(@"^(380)[0-9]{9}$")]
        public string? Phone { get; set; }
        public string? Email { get; set; }
        [RegularExpression(@"^http(s)?://([\w-]+.)+[\w-]+(/[\w- ./?%&=])?$")]
        public string? InstagramUrl { get; set; }
        public virtual List<ArtistsSongs> ArtistsSongs { get; set; }
            = new List<ArtistsSongs>();
    }
}
