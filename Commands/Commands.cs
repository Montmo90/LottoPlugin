using System;
using System.Collections.Generic;
using System.Text;
using LottoPlugin.Models;
using LottoPlugin.Modules;
using LottoPlugin.Utils;
using Torch.Commands;
using Torch.Commands.Permissions;
using Torch.Mod;
using Torch.Mod.Messages;
using Torch.Utils.SteamWorkshopTools;
using VRage.Game.ModAPI;

namespace LottoPlugin.Commands
{
    [Category("lotto")]
    public class Commands : CommandModule
    {
        public LottoPlugin Plugin => (LottoPlugin)Context.Plugin;

        #region All players
        [Command("help", "Show information")]
        [Permission(MyPromoteLevel.None)]
        public void Help()
        {
            var stringBuilder = new StringBuilder();
            stringBuilder.AppendLine(TranslatesUtils.GetHelpId("info"));
            stringBuilder.AppendLine(TranslatesUtils.GetHelpId("play"));
            stringBuilder.AppendLine(TranslatesUtils.GetHelpId("recove"));
            if (base.Context.Player.PromoteLevel == MyPromoteLevel.Admin)
            {
                stringBuilder.AppendLine("");
                stringBuilder.AppendLine("########## ADMIN ##########");
                stringBuilder.AppendLine("");
                stringBuilder.AppendLine(TranslatesUtils.GetHelpId("settings"));
                stringBuilder.AppendLine(TranslatesUtils.GetHelpId("config"));
                stringBuilder.AppendLine(TranslatesUtils.GetHelpId("open"));
                stringBuilder.AppendLine(TranslatesUtils.GetHelpId("number"));
                stringBuilder.AppendLine("");
                stringBuilder.AppendLine(TranslatesUtils.GetHelpId("ticket"));
                stringBuilder.AppendLine(TranslatesUtils.GetHelpId("prix"));
                stringBuilder.AppendLine(TranslatesUtils.GetHelpId("multiple"));
                stringBuilder.AppendLine("");
                stringBuilder.AppendLine(TranslatesUtils.GetHelpId("gain"));
                stringBuilder.AppendLine(TranslatesUtils.GetHelpId("gainNumber"));
                stringBuilder.AppendLine(TranslatesUtils.GetHelpId("max"));
                stringBuilder.AppendLine(TranslatesUtils.GetHelpId("cumulate"));
                stringBuilder.AppendLine(TranslatesUtils.GetHelpId("add"));
                stringBuilder.AppendLine(TranslatesUtils.GetHelpId("remove"));
                stringBuilder.AppendLine(TranslatesUtils.GetHelpId("partage"));
                stringBuilder.AppendLine("");
                stringBuilder.AppendLine(TranslatesUtils.GetHelpId("draw"));
                stringBuilder.AppendLine(TranslatesUtils.GetHelpId("start"));
                stringBuilder.AppendLine(TranslatesUtils.GetHelpId("startNumber"));
                stringBuilder.AppendLine(TranslatesUtils.GetHelpId("auto"));
                stringBuilder.AppendLine(TranslatesUtils.GetHelpId("days"));
                stringBuilder.AppendLine(TranslatesUtils.GetHelpId("hour"));
                stringBuilder.AppendLine("");
                stringBuilder.AppendLine(TranslatesUtils.GetHelpId("save"));
                stringBuilder.AppendLine(TranslatesUtils.GetHelpId("reload"));
            }
            DialogMessage dialogMessage = new DialogMessage(TranslatesUtils.GetHelpId("title"), "Montmorency Lotto", stringBuilder.ToString());
            ModCommunication.SendMessageTo(dialogMessage, base.Context.Player.SteamUserId);
        }

        [Command("info", "Show information")]
        [Permission(MyPromoteLevel.None)]
        public void Info()
        {
            var stringBuilder = new StringBuilder();

            stringBuilder.AppendLine(Module.Config.Open ? TranslatesUtils.GetInfoId("open") : TranslatesUtils.GetInfoId("close"));
            stringBuilder.AppendLine(String.Format(TranslatesUtils.GetInfoId("next"), Module.Config.NextDraw));
            stringBuilder.AppendLine("");

            List<int> listPlayerNumbers = PlayersUtils.PlayerNumbers(base.Context.Player.IdentityId);
            if (listPlayerNumbers.Count != 0) 
            { 
                foreach (var item in listPlayerNumbers)
                {
                    stringBuilder.AppendLine(String.Format(TranslatesUtils.GetInfoId("play"), item));
                }
            }
            else
            {
                stringBuilder.AppendLine(TranslatesUtils.GetInfoId("dont"));
                stringBuilder.AppendLine(TranslatesUtils.GetHelpId("play"));
            }

            stringBuilder.AppendLine("");
            stringBuilder.AppendLine(String.Format(TranslatesUtils.GetInfoId("prix"), Module.Config.TicketPrix));
            stringBuilder.AppendLine(Module.Config.TicketMultiple ? TranslatesUtils.GetInfoId("multiple") : TranslatesUtils.GetInfoId("dontMultiple"));
            stringBuilder.AppendLine(String.Format(TranslatesUtils.GetInfoId("number"), Module.Config.MaxNumber));
            stringBuilder.AppendLine(String.Format(TranslatesUtils.GetInfoId("gain"), Module.Config.GainTotal));
            stringBuilder.AppendLine("");

            var win = PlayersUtils.PlayerWinLotto(base.Context.Player.IdentityId);
            if (win == null)
            {
                stringBuilder.AppendLine(TranslatesUtils.GetInfoId("dontRecove"));
            }
            else {
                long allGain = 0L;
                foreach (var item in win)
                {
                    allGain += item.gain;
                }

                stringBuilder.AppendLine(String.Format(TranslatesUtils.GetInfoId("recove"), win.Count, allGain));
            }

            stringBuilder.AppendLine("");
            stringBuilder.AppendLine("");
            stringBuilder.AppendLine("");
            stringBuilder.AppendLine(String.Format(TranslatesUtils.GetGeneralId("stats"), Module.Config.NumberTotalDraw, Module.Config.NumberTotalPlayersWin));

            DialogMessage dialogMessage = new DialogMessage(TranslatesUtils.GetInfoId("title"), TranslatesUtils.GetGeneralId("lotto"), stringBuilder.ToString());
            ModCommunication.SendMessageTo(dialogMessage, base.Context.Player.SteamUserId);
        }

        [Command("play", "Play Lotto")]
        [Permission(MyPromoteLevel.None)]
        public void Play(int number)
        {
            if(!Module.Config.Open)
            {
                base.Context.Respond(TranslatesUtils.GetRespondId("dontPlay"), TranslatesUtils.GetGeneralId("lotto"), null);
                return;
            }

            base.Context.Player.TryGetBalanceInfo(out long money);
            if (money < Module.Config.TicketPrix)
            {
                base.Context.Respond(TranslatesUtils.GetRespondId("money"), TranslatesUtils.GetGeneralId("lotto"), null);
                return;
            }

            List<int> listPlayerNumbers = PlayersUtils.PlayerNumbers(base.Context.Player.IdentityId);
            if (listPlayerNumbers.Count > 0 && !Module.Config.TicketMultiple)
            {
                foreach (var item in listPlayerNumbers)
                {
                    base.Context.Respond(String.Format(TranslatesUtils.GetInfoId("play"), item), TranslatesUtils.GetGeneralId("lotto"), null);
                }
                return;
            }

            Module.PlayersPlay.ListPlayersPlay.Add(new PlayersPlayStruct(base.Context.Player.DisplayName, base.Context.Player.IdentityId, number, DateTime.UtcNow));
            base.Context.Player.RequestChangeBalance(-Module.Config.TicketPrix);
            base.Context.Respond(TranslatesUtils.GetRespondId("thank"), TranslatesUtils.GetGeneralId("lotto"), null);

            Module.SavePlayersPlay();
        }

        [Command("recove", "Allows you to recover your gain")]
        [Permission(MyPromoteLevel.None)]
        public void Recove()
        {
            var win = PlayersUtils.PlayerWinLotto(base.Context.Player.IdentityId);
            
            if(win == null)
            {
                base.Context.Respond(TranslatesUtils.GetInfoId("dontRecove"), TranslatesUtils.GetGeneralId("lotto"), null);
                return;
            }

            foreach (var item in win)
            {
                base.Context.Respond(String.Format(TranslatesUtils.GetRespondId("recove"), item.gain), TranslatesUtils.GetGeneralId("lotto"), null);
                base.Context.Player.RequestChangeBalance(item.gain);
            }
        }
        #endregion

        #region Config
        [Command("config", "Show configuration")]
        [Permission(MyPromoteLevel.Admin)]
        public void Config()
        {
            var stringBuilder = new StringBuilder();
            stringBuilder.AppendLine(TranslatesUtils.GetHelpId("settings"));
            stringBuilder.AppendLine(String.Format(TranslatesUtils.GetConfigId("open"), Module.Config.Open));
            stringBuilder.AppendLine(String.Format(TranslatesUtils.GetConfigId("max"), Module.Config.MaxNumber));
            stringBuilder.AppendLine("");
            stringBuilder.AppendLine(TranslatesUtils.GetHelpId("ticket"));
            stringBuilder.AppendLine(String.Format(TranslatesUtils.GetConfigId("prix"), Module.Config.TicketPrix));
            stringBuilder.AppendLine(String.Format(TranslatesUtils.GetConfigId("multiple"), Module.Config.TicketMultiple));
            stringBuilder.AppendLine("");
            stringBuilder.AppendLine(TranslatesUtils.GetHelpId("gain"));
            stringBuilder.AppendLine(String.Format(TranslatesUtils.GetConfigId("gainTotal"), Module.Config.GainTotal));
            stringBuilder.AppendLine(String.Format(TranslatesUtils.GetConfigId("gain"), Module.Config.Gain));
            stringBuilder.AppendLine(String.Format(TranslatesUtils.GetConfigId("maxi"), Module.Config.GainMax));
            stringBuilder.AppendLine(String.Format(TranslatesUtils.GetConfigId("cumulate"), Module.Config.GainCumulate));
            stringBuilder.AppendLine(String.Format(TranslatesUtils.GetConfigId("partage"), Module.Config.GainPartage));
            stringBuilder.AppendLine("");
            stringBuilder.AppendLine(TranslatesUtils.GetHelpId("draw"));
            stringBuilder.AppendLine(String.Format(TranslatesUtils.GetConfigId("auto"), Module.Config.DrawAuto));
            stringBuilder.AppendLine(String.Format(TranslatesUtils.GetConfigId("days"), (Module.Config.DrawDays.Sunday ? ", " + TranslatesUtils.GetGeneralId("sunday") : ""),
                                                                                        (Module.Config.DrawDays.Monday ? ", " + TranslatesUtils.GetGeneralId("monday") : ""),
                                                                                        (Module.Config.DrawDays.Tuesday ? ", " + TranslatesUtils.GetGeneralId("tuesday") : ""),
                                                                                        (Module.Config.DrawDays.Wednesday ? ", " + TranslatesUtils.GetGeneralId("wednesday") : ""),
                                                                                        (Module.Config.DrawDays.Thursday ? ", " + TranslatesUtils.GetGeneralId("thursday") : ""),
                                                                                        (Module.Config.DrawDays.Friday ? ", " + TranslatesUtils.GetGeneralId("friday") : ""),
                                                                                        (Module.Config.DrawDays.Saturday ? ", " + TranslatesUtils.GetGeneralId("saturday") : "")));
            stringBuilder.AppendLine(String.Format(TranslatesUtils.GetConfigId("hout"), Module.Config.DrawHours));
            stringBuilder.AppendLine(String.Format(TranslatesUtils.GetConfigId("next"), Module.Config.NextDraw));
            DialogMessage dialogMessage = new DialogMessage(TranslatesUtils.GetConfigId("title"), TranslatesUtils.GetGeneralId("lotto"), stringBuilder.ToString());
            ModCommunication.SendMessageTo(dialogMessage, base.Context.Player.SteamUserId);
        }

        [Command("open", "Open or close the Lotto")]
        [Permission(MyPromoteLevel.Admin)]
        public void Open(bool open)
        {
            Module.Config.Open = open;
            base.Context.Respond(TranslatesUtils.GetGeneralId("changed"), TranslatesUtils.GetGeneralId("lotto"), null);
            Module.SaveConfig();
        }

        [Command("number max", "Change the max number the player can play")]
        [Permission(MyPromoteLevel.Admin)]
        public void MaxNumber(int number)
        {
            Module.Config.MaxNumber = number;
            base.Context.Respond(TranslatesUtils.GetGeneralId("changed"), TranslatesUtils.GetGeneralId("lotto"), null);
            Module.SaveConfig();
        }
        #endregion

        #region Tickets
        [Command("ticket prix", "Change the ticket price")]
        [Permission(MyPromoteLevel.Admin)]
        public void TicketPrix(int prix)
        {
            Module.Config.TicketPrix = prix;
            base.Context.Respond(TranslatesUtils.GetGeneralId("changed"), TranslatesUtils.GetGeneralId("lotto"), null);
            Module.SaveConfig();
        }

        [Command("ticket multiple", "Players can play Lotto multiple times")]
        [Permission(MyPromoteLevel.Admin)]
        public void TicketMultiple(bool multiple)
        {
            Module.Config.TicketMultiple = multiple;
            base.Context.Respond(TranslatesUtils.GetGeneralId("changed"), TranslatesUtils.GetGeneralId("lotto"), null);
            Module.SaveConfig();
        }
        #endregion

        #region Gain
        [Command("gain", "Changes the winnings that are added to each Lotto whether it is ganged or lost")]
        [Permission(MyPromoteLevel.Admin)]
        public void Gain(int gain)
        {
            Module.Config.Gain = gain;
            base.Context.Respond(TranslatesUtils.GetGeneralId("changed"), TranslatesUtils.GetGeneralId("lotto"), null);
            Module.SaveConfig();
        }

        [Command("gain max", "Changes the maximum Lotto win")]
        [Permission(MyPromoteLevel.Admin)]
        public void GainMax(int gainMax)
        {
            Module.Config.GainMax = gainMax;
            base.Context.Respond(TranslatesUtils.GetGeneralId("changed"), TranslatesUtils.GetGeneralId("lotto"), null);
            Module.SaveConfig();
        }

        [Command("gain cumulate", "Cumulate Lotto winnings as long as it is not won")]
        [Permission(MyPromoteLevel.Admin)]
        public void GainCumulate(bool cumulate)
        {
            Module.Config.GainCumulate = cumulate;
            base.Context.Respond(TranslatesUtils.GetGeneralId("changed"), TranslatesUtils.GetGeneralId("lotto"), null);
            Module.SaveConfig();
        }

        [Command("gain add", "Adds an amount to the Lotto win")]
        [Permission(MyPromoteLevel.Admin)]
        public void GainAdd(int add)
        {
            if ((Module.Config.GainTotal + add) > Module.Config.GainMax)
            {
                base.Context.Respond(TranslatesUtils.GetRespondId("add"), TranslatesUtils.GetGeneralId("lotto"), null);
                return;
            }

            Module.Config.GainTotal += add;
            base.Context.Respond(TranslatesUtils.GetGeneralId("changed"), TranslatesUtils.GetGeneralId("lotto"), null);
            Module.SaveConfig();
        }

        [Command("gain remove", "Remove an amount from the Lotto win")]
        [Permission(MyPromoteLevel.Admin)]
        public void GainRemove(int remove)
        {
            if((Module.Config.GainTotal - remove) < 0)
            {
                base.Context.Respond(TranslatesUtils.GetRespondId("remove"), TranslatesUtils.GetGeneralId("lotto"), null);
                return;
            }

            Module.Config.GainTotal -= remove;
            base.Context.Respond(TranslatesUtils.GetGeneralId("changed"), TranslatesUtils.GetGeneralId("lotto"), null);
            Module.SaveConfig();
        }

        [Command("gain partage", "Share the winnings among the winners or give the same winnings to each winner")]
        [Permission(MyPromoteLevel.Admin)]
        public void GainPartage(bool partage)
        {
            Module.Config.GainPartage = partage;
            base.Context.Respond(TranslatesUtils.GetGeneralId("changed"), TranslatesUtils.GetGeneralId("lotto"), null);
            Module.SaveConfig();
        }
        #endregion

        #region Draw
        [Command("draw start", "Perform a manual Lotto draw")]
        [Permission(MyPromoteLevel.Admin)]
        public void Draw(int number = -1)
        {            
            LottoPlugin.Draw(number);
        }

        [Command("draw auto", "Activate or deactivate the automatic draft")]
        [Permission(MyPromoteLevel.Admin)]
        public void DrawAuto(bool auto)
        {
            Module.Config.DrawAuto = auto;
            base.Context.Respond(TranslatesUtils.GetGeneralId("changed"), TranslatesUtils.GetGeneralId("lotto"), null);
            Module.SaveConfig();
        }

        [Command("draw days", "Change the automatic day draw (Sunday Monday Tuesday Wednesday Thursday Friday Saturday)")]
        [Permission(MyPromoteLevel.Admin)]
        public void DrawDays(bool sun, bool mon, bool tue, bool wed, bool thu, bool fri, bool sat)
        {
            if (!sun && !mon && !tue && !wed && !thu && !fri && !sat)
            {
                base.Context.Respond(TranslatesUtils.GetRespondId("days"), TranslatesUtils.GetGeneralId("lotto"), null);
                return;
            }

            Module.Config.DrawDays = new DayOfWeekStruct(sun, mon, tue, wed, thu, fri, sat);
            Module.Config.NextDraw = ConfigUtils.NextDraw();
            base.Context.Respond(TranslatesUtils.GetGeneralId("changed"), TranslatesUtils.GetGeneralId("lotto"), null);
            if(!Module.Config.DrawAuto)
                base.Context.Respond(TranslatesUtils.GetRespondId("auto"), TranslatesUtils.GetGeneralId("lotto"), null);
            Module.SaveConfig();
        }

        [Command("draw hour", "Set the Lotto draw time (ex: 06:00pm or 18:00)")]
        [Permission(MyPromoteLevel.Admin)]
        public void DrawHours(string hours)
        {
            if (!ConfigUtils.IsValidTimeFormat(hours))
            {
                base.Context.Respond(TranslatesUtils.GetRespondId("hour"), TranslatesUtils.GetGeneralId("lotto"), null);
                return;
            }

            Module.Config.DrawHours = hours;
            Module.Config.NextDraw = ConfigUtils.NextDraw();
            base.Context.Respond(TranslatesUtils.GetGeneralId("changed"), TranslatesUtils.GetGeneralId("lotto"), null);
            if (!Module.Config.DrawAuto)
                base.Context.Respond(TranslatesUtils.GetRespondId("auto"), TranslatesUtils.GetGeneralId("lotto"), null);
            Module.SaveConfig();
        }
        #endregion

        #region Save/Reload
        [Command("save", "Save all files")]
        [Permission(MyPromoteLevel.Admin)]
        public void Save()
        {
            Module.SaveConfig();
            Module.SavePlayersPlay();
            Module.SavePlayersWin();
            Module.SaveTranslates();

            base.Context.Respond(TranslatesUtils.GetRespondId("save"), TranslatesUtils.GetGeneralId("lotto"), null);
        }

        [Command("reload", "Reload all files")]
        [Permission(MyPromoteLevel.Admin)]
        public void ReLoad()
        {
            Module.LoadConfig();
            Module.LoadPlayersPlay();
            Module.LoadPlayersWin();
            Module.LoadTranslates();

            base.Context.Respond(TranslatesUtils.GetRespondId("reload"), TranslatesUtils.GetGeneralId("lotto"), null);
        }
        #endregion
    }
}
