﻿using System;

namespace StackitApi
{
    public class AppException : Exception
    {
        public AppException() : base() { }

        public AppException(string message) : base(message) { }
    }
}
