using Amazon.Runtime;
using Amazon.S3;
using Amazon.S3.Model;
using SabzMarket.Application.Interfaces.Services;
using SabzMarket.Infrastructure.Configuration.S3;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SabzMarket.Infrastructure.Storage
{
    public class S3FileStorageService : IFileStorageService
    {
        private readonly string _bucketName;
        private readonly string _serviceURL;
        private readonly IAmazonS3 _s3Client;
        public S3FileStorageService(IAmazonS3 s3Client, S3Settings settings)
        {
            _s3Client = s3Client;
            _serviceURL = settings.ServiceURL;
            _bucketName = settings.BucketName;
        }
        public async Task<string> SaveAsync(Stream fileStream, string fileName)
        {

            fileStream.Position = 0;
            string objectKey = Path.GetFileName(fileName).Replace(" ", "_");

            var putRequest = new PutObjectRequest
            {
                BucketName = _bucketName,
                Key = objectKey,
                InputStream = fileStream,
                CannedACL = S3CannedACL.PublicRead,
            };

            await _s3Client.PutObjectAsync(putRequest);




            string fileUrl = $"{_serviceURL}/{_bucketName}/{objectKey}";
            return fileUrl;
        }
    }
}