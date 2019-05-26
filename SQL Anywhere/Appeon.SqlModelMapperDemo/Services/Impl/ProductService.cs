using SnapObjects.Data;
using Appeon.SqlModelMapperDemo.Models;
using System.Collections.Generic;

namespace Appeon.SqlModelMapperDemo.Services
{
    public class ProductService : ServiceBase<Product>, IProductService
    {
        public ProductService(OrderContext context)
            : base(context)
        {
        }
                
        public void SaveProductPhoto(int productId, string photoName, byte[] photo)
        { 

            var productPhoto = new ProductPhoto()
            {
                LargePhotoFileName = photoName,
                LargePhoto = photo
            };
            
            _context.SqlModelMapper.TrackCreate(productPhoto);

            var pordProdPhoto = new ProductProductPhoto()
            {
                Primary = 1,
                ProductID = productId               
            };

            _context.SqlModelMapper.Track(
                (savecontext) => {
                    pordProdPhoto.ProductPhotoID = productPhoto.ProductPhotoID;
                });

            _context.SqlModelMapper.TrackCreate(pordProdPhoto)
                                .SaveChanges();
        }       

        public int SaveProductAndPrice(IModelEntry<Product> prod, 
                                       IEnumerable<IModelEntry<HistoryPrice>> price)
        {
            var master = _context.SqlModelMapper.TrackMaster(prod)
                                             .TrackDetails(hp => hp.HistoryPrices, price)
                                             .MasterModel;

            _context.SqlModelMapper.SaveChanges();

             return master.Productid;
        }

        public int SaveSubCateAndProduct(IModelEntry<SubCategory> subcate, 
                                         IModelEntry<Product> prod)
        {
            return _context.SqlModelMapper.TrackMaster(subcate)
                                       .TrackDetail(mapper => mapper.Products, prod)
                                       .SaveChanges()
                                       .AffectedCount;
        }

        public int SaveHistoryPrices(IModelEntry<SubCategory> subcate, 
                                     IModelEntry<Product> prod, 
                                     IEnumerable<IModelEntry<HistoryPrice>> price)
        {
            return _context.SqlModelMapper.TrackMaster(subcate)
                              .TrackDetail(pro => pro.Products, prod)
                              .TrackGrandDetails<Product, HistoryPrice>(pro => pro.Products, 
                                         hprice => hprice.HistoryPrices, price)
                              .SaveChanges()
                              .AffectedCount;
        }
    }
}
