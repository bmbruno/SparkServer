﻿using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Web;

namespace SparkServer.Application
{
    public static class Config
    {
        public static bool DebugMode
        {
            get
            {
                var value = ConfigurationManager.AppSettings["debugMode"];

                if (value != null)
                    return bool.Parse(value);
                else
                    return false;
            }
        }

        public static string AdminToken
        {
            get
            {
                var value = ConfigurationManager.AppSettings["adminToken"];

                if (value != null)
                    return value.ToString();
                else
                    return string.Empty;
            }
        }

        public static string MediaBannerPath
        {
            get
            {
                var value = ConfigurationManager.AppSettings["mediaBannerPath"];

                if (value != null)
                    return value.ToString();
                else
                    return string.Empty;
            }
        }

        public static string DomainName
        {
            get
            {
                var value = ConfigurationManager.AppSettings["domainName"];

                if (value != null)
                    return value.ToString();
                else
                    return string.Empty;
            }
        }

        public static string[] AdminWhitelist
        {
            get
            {
                var value = ConfigurationManager.AppSettings["adminWhitelist"];

                if (value != null)
                {
                    return value.Split(',');
                }
                else
                {
                    return new string[0];
                }
            }
        }
    }

}