using Amazon.Runtime;
using Amazon.S3;
using Amazon.S3.Model;
using SabzMarket.Application.Interfaces.Services;
using SabzMarket.Infrastructure.Configuration;
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
        public S3FileStorageService(IAmazonS3 s3Client,S3Settings settings)
        {
            _s3Client = s3Client;
            _serviceURL=settings.ServiceURL;
            _bucketName=settings.BucketName;
        }
        public async Task<string> SaveAsync(string filePath)
        {
            string objectKey = Path.GetFileName(filePath).Replace(" ", "_");

            var putRequest = new PutObjectRequest
            {
                BucketName = _bucketName,
                Key = objectKey,
                FilePath = filePath,
                CannedACL = S3CannedACL.PublicRead // فایل Public بشه
            };

            await _s3Client.PutObjectAsync(putRequest);

            string fileUrl = $"{_serviceURL}/{_bucketName}/{objectKey}";
            return fileUrl;
        }
    }
}