namespace Bot.Instagram.Profile
{
    public static class Instagram
    {
        public static Profile GetProfileByUser(string username)
        {
            var profile = new Profile(username);

            return profile;
        }
    }
}
