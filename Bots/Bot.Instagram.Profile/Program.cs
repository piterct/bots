using System;

namespace Bot.Instagram.Profile
{
    class Program
    {
        static void Main(string[] args)
        {

           Profile profile =  Instagram.GetProfileByUser("i.love.code");
          

            Console.ReadKey();
        }
    }
}
