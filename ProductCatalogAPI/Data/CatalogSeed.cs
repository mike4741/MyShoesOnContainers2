using Microsoft.EntityFrameworkCore;
using ProductCatalogAPI.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProductCatalogAPI.Data
{
    public static class CatalogSeed
    {

        public static void Seed(CatalogContext catalogContext)
        {
            catalogContext.Database.Migrate();

            if (!catalogContext.catalogBrands.Any())
            {
                catalogContext.catalogBrands.AddRange(GetCatalogBrand());
                catalogContext.SaveChanges();
            }
          
            if (!catalogContext.catalogSizes.Any())
            {
                catalogContext.catalogSizes.AddRange(GetCatalogSize());
                catalogContext.SaveChanges();
            }
            if (!catalogContext.catalogTypes.Any())
            {
                catalogContext.catalogTypes.AddRange(GetCatalogType());
                catalogContext.SaveChanges();
            }
            if (!catalogContext.catalogItems.Any())
            {
                catalogContext.catalogItems.AddRange(GetCatalogItem());
                catalogContext.SaveChanges();
            }
        }

        internal static void seed()
        {
            throw new NotImplementedException();
        }

        private static IEnumerable< CatalogItem> GetCatalogItem()
        {
            return new List<CatalogItem>()
            {
             new CatalogItem
             {    TypeId = 2,
                  BrandId = 3, 
                  SizeId = 3,
                  Description = "some description item 1" , 
                  Name = "Item1", 
                  Price = 199.5M,
                  PictureUrl = "http://externalcatalogbaseurltobereplaced/api/pic/1" 
             },
                 new CatalogItem
             {    TypeId = 1,
                  BrandId = 2,
                  SizeId = 2,
                  Description = "some description item2",
                  Name = "item2",
                  Price = 149.5M,
                  PictureUrl = "http://externalcatalogbaseurltobereplaced/api/pic/2"
             },
                 new CatalogItem
             {    TypeId = 2,
                  BrandId = 3,
                  SizeId = 1,
                  Description = "some description item 3",
                  Name = "item 3",
                  Price = 299.5M,
                  PictureUrl = "http://externalcatalogbaseurltobereplaced/api/pic/3"
             }

            };
        }

        private static  IEnumerable<CatalogBrand> GetCatalogBrand()
        {
            return new List<CatalogBrand>()
             {
                 new CatalogBrand
                 {
                      Brand = "Adidas"
                 },
                 new CatalogBrand
                 {
                      Brand = "Nike"
                 },
                 new CatalogBrand
                 {
                      Brand = "Puma"
                 },
                 new CatalogBrand
                 {
                      Brand = "Reebok"
                 },
                 new CatalogBrand
                      {
                     Brand = "Other"
                      }
             };
        }

        private static IEnumerable< CatalogSize> GetCatalogSize()
        {
            return new List<CatalogSize>() {
               new CatalogSize()
               {
                     Size =8
               },
               new CatalogSize()
               {
                     Size =9
               },
               new CatalogSize()
               {
                     Size = 10
               },
               new CatalogSize()
               {
                   Size = 11
               }

           };
        }

        private static IEnumerable< CatalogType> GetCatalogType()
        {
            return new List<CatalogType>
            {
                 new CatalogType
                 {
                      Type = "Runing"
                 },
                 new CatalogType
                 {
                     Type = "BasketBall"
                 },
                 new CatalogType
                 {
                     Type = "Walking"
                 }

            };
        }
    }  
 }

