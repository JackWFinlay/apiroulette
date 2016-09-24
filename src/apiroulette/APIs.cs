using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace apiroulette
{
    public class APIs
    {
        private static string[] apis = {
            "http://api.giphy.com/v1/gifs/search?q=querystring&api_key=dc6zaTOxFJmzC",
            "http://api.giphy.com/v1/gifs/translate?s=querystring&api_key=dc6zaTOxFJmzC",
            "https://qrng.anu.edu.au/API/jsonI.php?length=1&type=uint8",
            "http://jsonip.com/",
            "https://en.wikipedia.org/w/api.php?action=query&titles=querystring&prop=revisions&rvprop=content&format=json",
            "https://www.mediawiki.org/w/api.php?action=query&titles=querystring&prop=revisions&rvprop=content&format=json",
            "https://nl.wikipedia.org/w/api.php?action=query&titles=querystring&prop=revisions&rvprop=content&format=json",
            "https://commons.wikimedia.org/w/api.php?action=query&titles=querystring&prop=revisions&rvprop=content&format=json"

        };

        public static string GetQueryString(string q)
        {
            Random random = new Random();
            int index = random.Next(0, apis.Length);

            string unmergedQueryString = apis[index];
            string mergedString = unmergedQueryString.Replace("querystring", q);

            return mergedString;   
        }
    }
}
