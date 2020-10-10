using System.Collections.Generic;
using Torch;

namespace LottoPlugin.Models
{
    public class PlayersPlay : ViewModel
    {
        public PlayersPlay()
        {
            this.ListPlayersPlay = new List<PlayersPlayStruct>();
        }
        public List<PlayersPlayStruct> ListPlayersPlay { get; set; }
    }
}