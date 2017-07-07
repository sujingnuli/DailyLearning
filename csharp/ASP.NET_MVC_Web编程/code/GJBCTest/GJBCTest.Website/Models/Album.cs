using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
namespace GJBCTest.Website.Models
{
    public class Album
    {
        public virtual int AlbumId {get; set; }
        [DisplayName("Genre")]
        public virtual int GenreId { get; set; }
        [DisplayName("Artist")]
        public virtual int ArtistId { get; set; }
        [Required(ErrorMessage="An album title is required")]
        [StringLength(160)]
        public virtual string Title { get; set; }
        [Required(ErrorMessage="Price is required")]
        [DisplayFormat(DataFormatString="{0:c}")]
        [Range(0.01,100.00,ErrorMessage="Price must be between 0.01 and 100.00")]
        public virtual decimal Price { get; set; }
        public virtual string AlbumArtUrl { get; set; }
       
        public virtual Genre Genre { get; set; }//导航属性
        public virtual Artist Artist { get; set; }

    }
}
