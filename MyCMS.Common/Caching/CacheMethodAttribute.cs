﻿using System;

namespace MyCMS.Utilities.Caching
{
    [AttributeUsage(AttributeTargets.Method)]
    public class CacheMethodAttribute : Attribute
    {
        public CacheMethodAttribute()
        {
            SecondsToCache = 10;
        }

        public double SecondsToCache { get; set; }
    }
}
