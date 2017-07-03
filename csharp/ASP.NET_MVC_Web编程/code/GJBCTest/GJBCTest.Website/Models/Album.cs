using GJBCTest.Website.Common;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace GJBCTest.Website.Models
{
    public class Album
    {
        
        public virtual int AlbumId { get; set; }
        [DisplayName("Genre")]
        public virtual  int GenreId { get; set; }
        [DisplayName("Artist")]
        public virtual  int ArtistId { get; set; }//外键属性，foreign key property
        [Required(ErrorMessage="An Album title is required")]
        [StringLength(200)]
        [DataType(DataType.MultilineText)]
        public virtual  string Title { get; set; }
        [Range(typeof(decimal),"0.00","49.99")]
        public virtual decimal Price { get; set; }
        public virtual string AlbumArtUrl { get; set; }
        public virtual Genre Genre { get; set; } //导航属性 
        public virtual Artist Artist { get; set; }
    }
}