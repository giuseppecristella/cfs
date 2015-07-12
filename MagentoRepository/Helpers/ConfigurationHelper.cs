﻿using System.Collections.Generic;

namespace MagentoComunication.Helpers
{
    public enum CacheKey
    {
        Cart,
        FilteredProducts,
        CategoryAssignedProducts,
        ProductInfo,
        Inventories,
        ProductImages,
        LinkedProducts,
        CategoryLevel,
        CategoryInfo,
        ShippingMethods,
        SessionId,
        Customer,
        CustomerAddresses,
        OrderInfo,
        Orders
    }

    public static class ConfigurationHelper
    {
        public const string RootCategory = "3";
        // Da rifattorizzare
        public const string ComplementiCatId = "40";
        public const string Arredi = "48";
        public const string IdeeRegalo = "49";
        public const string Materassi = "50";
        public const string Maioliche = "51";
        public static readonly string[] HomeCategories = { "44", "45" };
        public const string SellaCurrencyCode = "242";

        public const string CartKey = "";

        public static readonly Dictionary<CacheKey, string> CacheKeyNames = new Dictionary<CacheKey, string>()
    {
      { CacheKey.Cart, "Cart" },
      { CacheKey.SessionId, "SessionId" },
      { CacheKey.FilteredProducts, "FilteredProducts§" },
      { CacheKey.CategoryAssignedProducts, "CategoryAssignedProducts§" },
      { CacheKey.ProductInfo, "ProductInfo§" },
      { CacheKey.Inventories, "Inventories§" },
      { CacheKey.ProductImages, "ProductImages§" },
      { CacheKey.LinkedProducts, "LinkedProducts§" },
      { CacheKey.CategoryLevel, "CategoryLevel§" },
      { CacheKey.CategoryInfo, "CategoryInfo§" },
      { CacheKey.ShippingMethods, "ShippingMethods§" },
      { CacheKey.Customer, "Customer§" },
      { CacheKey.CustomerAddresses, "CustomerAddresses§" },
      { CacheKey.OrderInfo, "OrderInfo§" },
      { CacheKey.Orders, "Orders" }
    };

    }
}
