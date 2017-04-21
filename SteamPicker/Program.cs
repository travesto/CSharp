"using System;

namespace SteamPicker
{
    class Program
    {
        static void Main(string[] args)
        {
            string user = "7656119";
            string APIKey = "0302C497E509EA9127355FDD368D84CE";
            user += Console.ReadLine();
            string apiURL = "http://api.steampowered.com/IPlayerService/GetOwnedGames/v0001/?key=" + APIKey + "&steamid=" + user + "&format=json&include_appinfo=1";
            Console.Write(apiURL);
        }
    }
}
