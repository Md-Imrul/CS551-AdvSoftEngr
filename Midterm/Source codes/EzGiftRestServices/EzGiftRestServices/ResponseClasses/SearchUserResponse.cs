using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace EzGiftRestServices
{
    public class SearchUserResponse
    {
        public string Result { get; set; }
        public List<UserBasic> Records { get; set; }
    }
}
