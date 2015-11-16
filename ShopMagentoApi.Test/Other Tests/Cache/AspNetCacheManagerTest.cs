﻿using System;
using System.Web;

namespace MagentoBusinessApi.Test
{
    public class AspNetCacheManagerTest : Shop.Common.Cache.ICacheManager
  {

    public void Add(string key, object value)
    {
      HttpContext.Current.Cache[key] = value;
    }

    public bool Contains(string key)
    {
      return HttpContext.Current.Cache[key] != null;
    }

    public int Count()
    {
      throw new NotImplementedException();
    }

    public T Get<T>(string key)
    {
      return (HttpContext.Current.Cache[key] != null) ? (T)HttpContext.Current.Cache[key] : default(T);
    }

    public T SafeGet<T>(string key, Func<T> getData)
    {
      throw new NotImplementedException();
    }

    public bool Remove(string key)
    {
      throw new NotImplementedException();
    }
  }
}