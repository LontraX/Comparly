﻿using Azure.Storage.Blobs;
using Comparly.Data.Services.AzureBlobStorageService.Interface;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Comparly.Data.Services.AzureBlobStorageService.Implementation
{
    public class StorageService : IStorageService
    {
        private readonly BlobServiceClient _blobServiceClient;
        private readonly IConfiguration _configuration;

        public StorageService(BlobServiceClient blobServiceClient, IConfiguration configuration)
        {
            _blobServiceClient = blobServiceClient;
            _configuration = configuration;
        }
        
        public void Upload(IFormFile formFile)
        {
            var containerName = _configuration.GetSection("AzureStorage:containerName").Value;

            var containerClient = _blobServiceClient.GetBlobContainerClient("");
            var blobClient = containerClient.GetBlobClient(formFile.FileName);
            using (var stream = formFile.OpenReadStream())
            {
                blobClient.UploadAsync(stream, true);
            }
        }
    }
}
