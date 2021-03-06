﻿using System.Collections.Generic;
using dk.via.ftc.businesslayer.Models;
using System.Threading.Tasks;

namespace dk.via.businesslayer.Data.Services
{
    public interface IProductService
    {
        public Task<ProductStrain> GetProductAsyncByStrain(int strain_id);
        public Task<IList<ProductStrain>> GetProductsAllProductsAsync();
    }
}