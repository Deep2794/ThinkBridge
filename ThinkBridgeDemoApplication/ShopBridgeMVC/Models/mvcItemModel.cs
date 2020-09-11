using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace ShopBridgeMVC.Models
{
    public class mvcItemModel
    {
        public int ItemID { get; set; }

        [Required(ErrorMessage = "Item Name is Required")]
        public string ItemName { get; set; }
        [Required(ErrorMessage = "Item Description is Required")]
        public string ItemDesc { get; set; }
        [Required(ErrorMessage = "Item Price is Required")]
        public Nullable<decimal> ItemPrice { get; set; }    
    }
}