using System;
using System.Collections.Generic;
using System.Text;

namespace WOTest.Core.Extensions
{
    public static class UriExtenstions
    {
        public static bool IsValidUri(this string url, UriKind uriKind = UriKind.Absolute)
        {
            Uri validUri = null;
            return Uri.TryCreate(url, uriKind, out validUri);
        }

        public static Uri ToUri(this string url, UriKind uriKind = UriKind.Absolute)
        {
            Uri validUri = null;
            Uri.TryCreate(url, uriKind, out validUri);

            return validUri;
        }
    }
}
