using System.Collections.Generic;
using Torch;

namespace LottoPlugin.Models
{
    public class PlayersWin : ViewModel
    {
        public PlayersWin()
        {
            this.ListPlayersWin = new List<PlayersWinStruct>();
        }
        public List<PlayersWinStruct> ListPlayersWin { get; set; }
    }
}
