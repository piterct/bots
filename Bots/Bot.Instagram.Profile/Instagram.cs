using System.Net;

namespace Bot.Instagram.Profile
{
    public static class Instagram
    {
        public static Profile GetProfileByUser(string username)
        {
            var profile = new Profile(username);
            string url = @"https://www.instagram.com/" + username + "/";
            string markup;

            using (WebClient client = new WebClient())
            {
                markup = client.DownloadString(url);
            }

            HtmlAgilityPack.HtmlDocument html = new HtmlAgilityPack.HtmlDocument();
            html.LoadHtml(markup);

            var list = html.DocumentNode.SelectNodes("//meta");

            foreach (var node in list)
            {
                string property = node.GetAttributeValue("property", "");
            }

            return profile;
        }
    }
}
