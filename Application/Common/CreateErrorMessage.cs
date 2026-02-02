using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SabzMarket.Application.Common
{
    public static class CreateErrorMessage
    {
        public static string ErrorMessage(this string message)
        {
            return string.Format($"{Messages.Error}{Environment.NewLine}{Messages.CodeError}{message}");

        }
    }
}
