﻿using System;

namespace NLog.Layouts.GelfLayout.Test
{
    static class FakeException
    {
        public static Exception Throw() 
        {
            try { throw new ArgumentException("funny exception :D", new Exception("very funny exception ::D")); }
            catch (Exception e) { return e; }
        }
    }
}
