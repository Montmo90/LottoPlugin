using System;
using System.Collections.Generic;
using LottoPlugin.Modules;
using Sandbox.Game.World;

namespace LottoPlugin.Utils
{
    public static class PlayersUtils
    {
        public static List<int> PlayerNumbers(long playerId)
        {
            List<int> numbers = new List<int>();

            foreach (var item in Module.PlayersPlay.ListPlayersPlay)
            {
                if (item.playerId == playerId)
                {
                    numbers.Add(item.chiffre);
                }
            }
            return numbers;
        }

        public static MyIdentity GetIdentityById(long playerId)
        {
            foreach (MyIdentity myIdentity in MySession.Static.Players.GetAllIdentities())
            {
                bool flag = myIdentity.IdentityId == playerId;
                if (flag)
                {
                    return myIdentity;
                }
            }
            return null;
        }
        public static string GetPlayerNameById(long playerId)
        {
            MyIdentity identityById = GetIdentityById(playerId);
            bool flag = identityById != null;
            string result;
            if (flag)
            {
                result = identityById.DisplayName;
            }
            else
            {
                result = "Nobody";
            }
            return result;
        }

        public static List<Models.PlayersWinStruct> PlayerWinLotto (long playerId)
        {
            List<Models.PlayersWinStruct> win = new List<Models.PlayersWinStruct>();
            foreach (var item in Module.PlayersWin.ListPlayersWin)
            {
                if (playerId == item.playerId && item.recoveGain == false)
                {
                    item.recoveGain = true;
                    item.recoveDateTime = DateTime.Now;
                    Module.SavePlayersWin();
                    win.Add(item);
                }
            }
            return win.Count == 0 ? null : win;
        }
    }
}
