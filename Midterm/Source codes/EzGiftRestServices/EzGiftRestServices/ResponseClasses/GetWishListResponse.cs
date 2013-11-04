using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace EzGiftRestServices
{
    public class GetWishListResponse
    {
        public List<WishItem> Records { get; set; }

        public string Result { get; set; }
    }
}
