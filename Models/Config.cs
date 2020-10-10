using System;
using LottoPlugin.Utils;
using Torch;

namespace LottoPlugin.Models
{
    public class Config : ViewModel
    {
        public Config()
        {
            this.Open = false;
            this.MaxNumber = 50;
            this.TicketPrix = 50000L;
            this.TicketMultiple = false;
            this.GainTotal = 0L;
            this.GainMax = 10000000L;
            this.Gain = 1000000L;
            this.GainCumulate = true;
            this.GainPartage = true;
            this.DrawAuto = true;
            this.DrawDays = new DayOfWeekStruct(true, true, true, true, true, true, true);
            this.DrawHours = "18:00";
            this.NextDraw = new DateTime();
        }

        public bool Open { get; set; }
        public int MaxNumber { get; set; }
        public long TicketPrix { get; set; }
        public bool TicketMultiple { get; set; }
        public long GainTotal { get; set; }
        public long GainMax { get; set; }
        public long Gain { get; set; }
        public bool GainCumulate { get; set; }
        public bool GainPartage { get; set; }
        public bool DrawAuto { get; set; }
        public DayOfWeekStruct DrawDays { get; set; }
        public string DrawHours { get; set; }
        public DateTime NextDraw { get; set; }

    }
}
