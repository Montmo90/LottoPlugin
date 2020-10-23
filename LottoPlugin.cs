using NLog;
using Torch;
using Torch.API;
using LottoPlugin.Modules;
using System;
using System.Collections.Generic;
using Sandbox.Game;
using VRageMath;
using LottoPlugin.Utils;

namespace LottoPlugin
{
    public class LottoPlugin : TorchPluginBase
    {
        public override void Init(ITorchBase torch)
        {
            LottoPlugin.Instance = this;
            base.Init(torch);
            Module.LoadConfig();
            Module.LoadPlayersPlay();
            Module.LoadPlayersWin();
            Module.LoadTranslates();
        }
        
        public void Start()
        {
            Module.Config.NextDraw = ConfigUtils.NextDraw();
        }

        public override void Update()
        {
            if(!Module.Config.DrawAuto || DateTime.Now < Module.Config.NextDraw)
                return;

            Draw();
        }

        public static void Draw(int number = -1)
        {
            Module.Config.NumberTotalDraw++;

            var random = new Random();
            var randomNumber = number == -1 ? random.Next(0, Module.Config.MaxNumber) : number;

            MyVisualScriptLogicProvider.SendChatMessageColored(String.Format(TranslatesUtils.GetGeneralId("draw"), randomNumber), Color.Red, TranslatesUtils.GetGeneralId("lotto"));

            var listPlayersWin = ListPlayersWin(randomNumber);
            if (listPlayersWin.Count == 0)
            {
                MyVisualScriptLogicProvider.SendChatMessageColored(TranslatesUtils.GetGeneralId("dontWin"), Color.Red, TranslatesUtils.GetGeneralId("lotto"));
            }
            else
            {
                Module.Config.NumberTotalPlayersWin++;
                var gain = Module.Config.GainPartage ? Module.Config.GainTotal / listPlayersWin.Count : Module.Config.GainTotal;
                foreach (var item in listPlayersWin)
                {
                    MyVisualScriptLogicProvider.SendChatMessageColored(String.Format(TranslatesUtils.GetGeneralId("win"), PlayersUtils.GetPlayerNameById(item.playerId)), Color.Red, TranslatesUtils.GetGeneralId("lotto"));
                    Module.PlayersWin.ListPlayersWin.Add(new Models.PlayersWinStruct(item.playerName, item.playerId, randomNumber, gain, DateTime.Now));
                }
                Module.Config.GainTotal = 0;
            }

            if (Module.Config.GainTotal + Module.Config.Gain > Module.Config.GainMax)
                Module.Config.GainTotal = Module.Config.GainMax;
            else
                Module.Config.GainTotal += Module.Config.Gain;

            var next = ConfigUtils.NextDraw();
            Module.Config.NextDraw = next;

            MyVisualScriptLogicProvider.SendChatMessageColored(String.Format(TranslatesUtils.GetGeneralId("next"), next, Module.Config.GainTotal), Color.Red, TranslatesUtils.GetGeneralId("lotto"));

            Module.PlayersPlay.ListPlayersPlay.Clear();

            Module.SaveConfig();
            Module.SavePlayersPlay();
            Module.SavePlayersWin();
        }

        public static List<Models.PlayersPlayStruct> ListPlayersWin (int randomNumber)
        {
            var listPlayersWin = new List<Models.PlayersPlayStruct>();
            foreach (var item in Module.PlayersPlay.ListPlayersPlay)
            {
                if (item.chiffre == randomNumber)
                    listPlayersWin.Add(item);
            }
            return listPlayersWin;
        }

        public static LottoPlugin Instance { get; private set; }
        public static readonly Logger Log = LogManager.GetCurrentClassLogger();

    }
}
