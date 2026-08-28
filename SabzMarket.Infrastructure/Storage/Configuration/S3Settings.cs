using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SabzMarket.Infrastructure.Storage.Configuration
{
    public class S3Settings
    {
        public string AccessKey { get; set; } = null!;
        public string SecretKey { get; set; } = null!;
        public string ServiceURL { get; set; } = null!;
        public string BucketName { get; set; } = null!;
        public string Region { get; set; } = null!;
    }
}
