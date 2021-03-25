﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProductCatalogAPI.Domain
{
    public class CatalogItem
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description  { get; set; }
        public decimal Price { get; set; }
        public string PictureUrl { get; set; }
        public int BrandId { get; set; }
        public int TypeId { get; set; }
        public int SizeId { get; set; }

        public CatalogBrand CatalogBrand { get; set; }
        public CatalogSize CatalogSize{ get; set; }
        public CatalogType CatalogType { get; set; }

    }
}
