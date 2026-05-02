using System;
using System.Collections.Generic;
using System.Text;

namespace SabzMarket.UI
{
    public static class CurrentUser
    {
        public static long SellerId {  get; set; }
        public static long UserId { get; set; }
        public static string? UserName { get; set; }
    }
}
