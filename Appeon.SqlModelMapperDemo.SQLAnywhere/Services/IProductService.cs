﻿using SnapObjects.Data;
using Appeon.SqlModelMapperDemo.SQLAnywhere.Models;
using System.Collections.Generic;

namespace Appeon.SqlModelMapperDemo.SQLAnywhere.Services
{
    public interface IProductService
    {
        IList<Product> Retrieve(bool includeEmbedded, params object[] parameters);

        Product RetrieveByKey(bool includeEmbedded, params object[] parameters);

        void SaveProductPhoto(int productId, string photoname, byte[] photo);        
        
        int SaveProductAndPrice(IModelEntry<Product> prod, 
                                IEnumerable<IModelEntry<HistoryPrice>> price);

        int SaveSubCateAndProduct(IModelEntry<SubCategory> subcate, 
                                  IModelEntry<Product> prod);

        int SaveHistoryPrices(IModelEntry<SubCategory> subcate, 
                              IModelEntry<Product> prod, 
                              IEnumerable<IModelEntry<HistoryPrice>> price);

    }
}
