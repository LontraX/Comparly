﻿using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Comparly.Data.Services.AzureBlobStorageService.Interface
{
    public interface IStorageService
    {
        void Upload(IFormFile formFile);
    }
}
