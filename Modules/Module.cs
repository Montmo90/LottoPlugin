using LottoPlugin.Models;
using LottoPlugin.Utils;

namespace LottoPlugin.Modules
{
    public static class Module
    {
        public static void LoadConfig()
        {
            var config = Module.Config;
            lock (config)
            {
                Module.Config = ConfigUtils.Load<Config>(LottoPlugin.Instance, Module.ConfigFile);
            }
        }

        public static bool SaveConfig()
        {
            var config = Module.Config;
            bool result;
            lock (config)
            {
                result = ConfigUtils.Save<Config>(LottoPlugin.Instance, Module.Config, Module.ConfigFile);
            }
            return result;
        }

        public static void LoadPlayersPlay()
        {
            var playersPlay = Module.PlayersPlay;
            lock (playersPlay)
            {
                Module.PlayersPlay = ConfigUtils.Load<PlayersPlay>(LottoPlugin.Instance, Module.PlayersPlayFile);
            }
        }

        public static bool SavePlayersPlay()
        {
            var playersPlay = Module.PlayersPlay;
            bool result;
            lock (playersPlay)
            {
                result = ConfigUtils.Save<PlayersPlay>(LottoPlugin.Instance, Module.PlayersPlay, Module.PlayersPlayFile);
            }
            return result;
        }

        public static void LoadPlayersWin()
        {
            var playersWin = Module.PlayersWin;
            lock (playersWin)
            {
                Module.PlayersWin = ConfigUtils.Load<PlayersWin>(LottoPlugin.Instance, Module.PlayersWinFile);
            }
        }

        public static bool SavePlayersWin()
        {
            var playersWin = Module.PlayersWin;
            bool result;
            lock (playersWin)
            {
                result = ConfigUtils.Save<PlayersWin>(LottoPlugin.Instance, Module.PlayersWin, Module.PlayersWinFile);
            }
            return result;
        }

        public static void LoadTranslates()
        {
            var translates = Module.Translates;
            lock (translates)
            {
                Module.Translates = ConfigUtils.Load<Translates>(LottoPlugin.Instance, Module.TranslatesFile);
            }
        }

        public static bool SaveTranslates()
        {
            var translates = Module.Translates;
            bool result;
            lock (translates)
            {
                result = ConfigUtils.Save<Translates>(LottoPlugin.Instance, Module.Translates, Module.TranslatesFile);
            }
            return result;
        }

        public static string ConfigFile = "LottoConfig.cfg";
        public static Config Config = new Config();
        public static string PlayersPlayFile = "LottoPlayersPlay.xml";
        public static PlayersPlay PlayersPlay = new PlayersPlay();
        public static string PlayersWinFile ="LottoPlayersWin.xml";
        public static PlayersWin PlayersWin = new PlayersWin();
        public static string TranslatesFile = "LottoTranslates.xml";
        public static Translates Translates = new Translates();
    }
}
