using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Primitives;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AuthCloud.Shared.Languages
{
    internal static class Extensions //TODO: Move to rest
    {
        public static ILanguage GetLanguage(this Controller controller)
        {
            return controller.Request.GetLanguage();
        }

        public static ILanguage GetLanguage(this HttpRequest request)
        {
            if (request.Headers.TryGetValue("Accept-Language", out StringValues acceptLanguage))
            {
                foreach (string language in ((string)acceptLanguage).Split(";"))
                {
                    if (language.Contains("de"))
                    {
                        return new LanguageDE();
                    }
                    else if (language.Contains("en"))
                    {
                        return new LanguageEN();
                    }
                }
            }

            return new LanguageEN(); //default
        }
    }
}
