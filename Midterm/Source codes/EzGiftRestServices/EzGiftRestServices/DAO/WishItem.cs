using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace EzGiftRestServices
{
    public class WishItem
    {
        public WishItem() { }
        public int UserId { get; set; }
        public int ItemId { get; set; }
        public string Upc { get; set; }
        public string Description { get; set; }
    }
}