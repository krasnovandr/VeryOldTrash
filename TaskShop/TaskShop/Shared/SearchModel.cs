using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TaskShop.Shared
{
    public class SearchModel
    {
        public int GoodsId { get; set; }
        public string GoodsCategory { get; set; }
        public String Producer { get; set; }
        public String Model { get; set; }
        public int Price { get; set; }
        
    }
}