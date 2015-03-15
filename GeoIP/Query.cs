// <copyright file="Query.cs">
//  Copyright (c) 2015. MIT License.
// </copyright>

namespace GeoIP
{
    using System.Drawing;
    using System.Net;

    /// <summary>Queries for IP Geolocation</summary>
    public class Query
    {
        #region Fields
        /// <summary>The status code returned from the server</summary>
        private string statusCode = string.Empty;

        /// <summary>The status message associated with the status code</summary>
        private string statusMessage = string.Empty;

        /// <summary>The IP address</summary>
        private string address = string.Empty;

        /// <summary>The country code</summary>
        private string countryCode = string.Empty;

        /// <summary>The country name</summary>
        private string countryName = string.Empty;

        /// <summary>The country flag</summary>
        private Bitmap countryImage = null;
        #endregion

        /// <summary>Initializes a new instance of the <see cref="Query"/> class.</summary>
        /// <param name="key">The ipinfodb.com API key.</param>
        /// <param name="addressToQuery">The IP address to query.</param>
        public Query(string key, IPAddress addressToQuery)
        {
            string[] arr = null;

            using (WebClient wc = new WebClient())
            {
                arr = wc.DownloadString("http://api.ipinfodb.com/v3/ip-country/?key=" + key + "&ip=" + addressToQuery).Split(new char[] { ';' });
            }

            if (arr.Length == 5)
            {
                this.StatusCode = arr[0];
                this.StatusMessage = arr[1];
                this.IPAddress = arr[2];
                if (arr[3].Length == 2)
                {
                    this.CountryCode = arr[3];
                }
                else
                {
                    this.CountryCode = "XX";
                }

                if (arr[4].Length > 1)
                {
                    this.CountryName = arr[4];
                }
                else
                {
                    this.CountryName = "Unknown";
                }

                this.CountryImage = GetImage.GetBitmap(this.CountryCode);
            }
        }

        #region Properties
        /// <summary>Gets or sets the status code.</summary>
        /// <value>The status code.</value>
        public string StatusCode
        {
            get
            {
                return this.statusCode;
            }

            protected set
            {
                this.statusCode = value;
            }
        }

        /// <summary>Gets or sets the status message.</summary>
        /// <value>The status message.</value>
        public string StatusMessage
        {
            get
            {
                return this.statusMessage;
            }

            protected set
            {
                this.statusMessage = value;
            }
        }

        /// <summary>Gets or sets the IP address.</summary>
        /// <value>The IP address.</value>
        public string IPAddress
        {
            get
            {
                return this.address;
            }

            protected set
            {
                this.address = value;
            }
        }

        /// <summary>Gets or sets the country code.</summary>
        /// <value>The country code.</value>
        public string CountryCode
        {
            get
            {
                return this.countryCode;
            }

            protected set
            {
                this.countryCode = value;
            }
        }

        /// <summary>Gets or sets the name of the country.</summary>
        /// <value>The name of the country.</value>
        public string CountryName
        {
            get
            {
                return this.countryName;
            }

            protected set
            {
                this.countryName = value;
            }
        }

        /// <summary>Gets or sets the country flag.</summary>
        /// <value>The country flag.</value>
        public Bitmap CountryImage
        {
            get
            {
                return this.countryImage;
            }

            protected set
            {
                this.countryImage = value;
            }
        }
        #endregion
    }
}
