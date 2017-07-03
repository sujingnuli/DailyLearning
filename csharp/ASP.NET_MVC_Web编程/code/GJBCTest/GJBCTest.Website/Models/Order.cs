using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace GJBCTest.Website.Models
{
    public class Order
    {
        [ScaffoldColumn(false)]
        public int OrderId { get; set; }
        [ScaffoldColumn(false)]
        public DateTime OrderDate { get; set; }
        public string UserName { get; set; }
        [Required]
        [StringLength(160,MinimumLength=3)]
        [Display(Name="First Name")]
        public string FirstName { get; set; }
        [Required]
        [StringLength(160)]
        [Display(Name="Last Name")]
        public string LastName { get; set; }
        public string Address { get; set; }
        public string City { get; set; }
        public string State { get; set; }
        public string PostalCode { get; set; }
        public string country { get; set; }
        public string phone { get; set; }
        [RegularExpression(@"[A-Za-z0-9._%+-]+@[A-Za-z0-9.-]+\.[A-Za-z]{3,4}")]
        public string Email { get; set; }
        [ReadOnly(true)]
        [DisplayFormat(ApplyFormatInEditMode=false,DataFormatString="{0:c}")]
        public decimal Total { get; set; }
        public List<OrderDetail> OrderDetails { get; set; }
    }
}