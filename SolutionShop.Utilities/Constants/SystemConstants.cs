﻿using System;
using System.Collections.Generic;
using System.Text;

namespace SolutionShop.Utilities.Constants
{
    public class SystemConstants
    {
        public const string MainConnectionString = "Shop";
        public const string CartSession = "CartSession";

        public class AppSettings
        {
            public const string DefaultLanguageId = "DefaultLanguageId";
            public const string Token = "Token";
            public const string BaseAddress = "BaseAddress";
        }

        public class Details
        {
            public const string IdDetails = "DetailId";
        }

        public class ProductSettings
        {
            public const int NumberOfFeaturedProduct = 4;
            public const int NumberOfLastestProduct = 6;
        }

        public class ProductConstants
        {
            public const string NA = "N/A";
        }
    }
}