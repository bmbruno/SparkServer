using System;
using System.Configuration;

namespace SparkServer.Application
{
    /// <summary>
    /// Provides strongly-typed access to configuration settings.
    /// </summary>
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

        public static string SigningKey
        {
            get
            {
                var value = ConfigurationManager.AppSettings["ssoSigningKey"];

                if (value != null)
                    return value.ToString();

                return string.Empty;
            }
        }

        public static string SSOLoginURL
        {
            get
            {
                var value = ConfigurationManager.AppSettings["ssoLoginURL"];

                if (value != null)
                    return value.ToString();

                return string.Empty;
            }
        }

        public static string SSOLogoutURL
        {
            get
            {
                var value = ConfigurationManager.AppSettings["ssoLogoutURL"];

                if (value != null)
                    return value.ToString();

                return string.Empty;
            }
        }

        public static Guid SiteID
        {
            get
            {
                var value = ConfigurationManager.AppSettings["ssoSiteID"];

                if (value != null)
                    return Guid.Parse(value);

                return Guid.Empty;
            }
        }
    }

}