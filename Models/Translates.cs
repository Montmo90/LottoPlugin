using System.Collections.Generic;
using Torch;

namespace LottoPlugin.Models
{
    public class Translates : ViewModel
    {
        public Translates()
        {
            GeneralFunction();
            HelpFunction();
            InfoFunction();
            ConfigFunction();
            RespondFunction();
        }

        public void GeneralFunction()
        {
            this.General = new TranslateStruct[] {
                new TranslateStruct("lotto", "Lotto"),

                new TranslateStruct("draw", "The result of the draw is {0}"),
                new TranslateStruct("dontWin", "There is no winner !"),
                new TranslateStruct("win", "The winner is {0}"),
                new TranslateStruct("next", "Next draw on {0}, for an amount of {1:N0} SC"),
                new TranslateStruct("stats", "There was {0} lotto draw with {1} winner(s)"),

                new TranslateStruct("changed", "Value changed !"),

                new TranslateStruct("sunday", "Sunday"),
                new TranslateStruct("monday", "Monday"),
                new TranslateStruct("tuesday", "Tuesday"),
                new TranslateStruct("wednesday", "Wednesday"),
                new TranslateStruct("thursday", "Thursday"),
                new TranslateStruct("friday", "Friday"),
                new TranslateStruct("saturday", "Saturday")
            };
        }

        public void HelpFunction() {
            this.Help = new TranslateStruct[] {
                new TranslateStruct("title", "Lotto Help"),

                new TranslateStruct("info", "> !lotto info - Show information"),
                new TranslateStruct("play", "> !lotto play <number> - Play Lotto"),
                new TranslateStruct("recove", "> !lotto recove - Allows you to recover your gain"),

                new TranslateStruct("settings", "Settings:"),
                new TranslateStruct("config", "> !lotto config - Show configuration"),
                new TranslateStruct("open", "> !lotto open <bool> - Open or close the Lotto"),
                new TranslateStruct("number", "> !lotto number max <number> - Change the max number the player can play"),

                new TranslateStruct("ticket", "Ticket:"),
                new TranslateStruct("prix", "> !lotto ticket prix <number> - Change the ticket price"),
                new TranslateStruct("multiple", "> !lotto ticket multiple <bool> - Players can play Lotto multiple times"),

                new TranslateStruct("gain", "Gain:"),
                new TranslateStruct("gainNumber", "> !lotto gain <number> - Changes the winnings that are added to each Lotto whether it is ganged or lost"),
                new TranslateStruct("max", "> !lotto gain max <number> - Changes the maximum Lotto win"),
                new TranslateStruct("cumulate", "> !lotto gain cumulate <bool> - Cumulate Lotto winnings as long as it is not won"),
                new TranslateStruct("add", "> !lotto gain add <number> - Adds an amount to the Lotto win"),
                new TranslateStruct("remove", "> !lotto gain remove <number> - Remove an amount from the Lotto win"),
                new TranslateStruct("partage", "> !lotto gain partage <bool> - Share the winnings among the winners or give the same winnings to each winner"),

                new TranslateStruct("draw", "Draw:"),
                new TranslateStruct("start", "> !Lotto draw start - Perform a manual Lotto draw"),
                new TranslateStruct("auto", "> !lotto draw auto <bool> - Activate or deactivate the automatic draft"),
                new TranslateStruct("days", "> !lotto draw days <b> <b> <b> <b> <b> <b> <b> - Change the automatic day draw (Sunday Monday Tuesday Wednesday Thursday Friday Saturday)"),
                new TranslateStruct("hour", "> !lotto draw hour <HH:mm> - Set the Lotto draw time (ex: 06:00pm or 18:00)"),

                new TranslateStruct("save", "> !Lotto save - Save all files"),
                new TranslateStruct("reload", "> !Lotto reload - Reload all files")
            };
        }

        public void InfoFunction()
        {
            this.Info = new TranslateStruct[] {
                new TranslateStruct("title", "Lotto Information"),

                new TranslateStruct("open", "The lotto is open"),
                new TranslateStruct("close", "The lotto is closed"),

                new TranslateStruct("next", "The next draw is the {0}"),

                new TranslateStruct("play", "You have already played Loto with the number {0}"),
                new TranslateStruct("dont", "You haven't played the lottery yet"),

                new TranslateStruct("prix", "The price of the ticket is: {0:N0} SC"),
                new TranslateStruct("multiple", "You can buy multiple tickets"),
                new TranslateStruct("dontMultiple", "You can only buy one ticket"),
                new TranslateStruct("number", "The number that can be played is between 0 and {0}"),
                new TranslateStruct("gain", "Lotto victory is: {0:N0} SC"),

                new TranslateStruct("dontRecove", "You have no gain to recover"),
                new TranslateStruct("recove", "You have {0} gain to recover for a total amount of {1:N0} SC")
            };
        }

        public void ConfigFunction()
        {
            this.Config = new TranslateStruct[] {
                new TranslateStruct("title", "Lotto Configuration"),

                new TranslateStruct("open", "> The Lotto is open: {0}"),
                new TranslateStruct("max", "> The max number the player can play: {0}"),

                new TranslateStruct("prix", "> The ticket price: {0:N0} SC"),
                new TranslateStruct("multiple", "> Players can play Lotto multiple times: {0}"),

                new TranslateStruct("gainTotal", "> The gain: {0:N0} SC"),
                new TranslateStruct("gain", "> The winnings that are added to each Lotto whether it is ganged or lost: {0:N0} SC"),
                new TranslateStruct("maxi", "> The maximum Lotto win: {0:N0} SC"),
                new TranslateStruct("cumulate", "> Cumulate Lotto winnings as long as it is not won: {0}"),
                new TranslateStruct("partage", "> Share the winnings among the winners or give the same winnings to each winner: {0}"),

                new TranslateStruct("auto", "> The automatic draw: {0}"),
                new TranslateStruct("days", "> The automatic day draw {0}{1}{2}{3}{4}{5}{6}"),
                new TranslateStruct("hour", "> The Lotto draw hour: {0}"),
                new TranslateStruct("next", "> Next draw: {0}")
            };
        }

        public void RespondFunction()
        {
            this.Respond = new TranslateStruct[] {
                new TranslateStruct("dontPlay", "You cannot play Lotto because it is closed"),
                new TranslateStruct("money", "You do not have enough money"),
                new TranslateStruct("thank", "Thank you, you just played Lotto"),

                new TranslateStruct("recove", "You have just recovered your earnings from: {0:N0} SC"),

                new TranslateStruct("add", "Error : The value to be added exceeds the maximum Lotto win"),
                new TranslateStruct("remove", "Error : Value to be removed too high, the gain cannot be negative"),
                new TranslateStruct("days", "Error : Minimum one day must be at true"),
                new TranslateStruct("auto", "Warning : The auto-draw function is disabled"),
                new TranslateStruct("hour", "Error : The hour format is not compatible. Please use format 06:00pm or 18:00"),

                new TranslateStruct("save", "All files are saved !"),
                new TranslateStruct("reload", "All files are reload !")
            };
        }

        public TranslateStruct[] General { get; set; }

        public TranslateStruct[] Help { get; set; }

        public TranslateStruct[] Info { get; set; }

        public TranslateStruct[] Config { get; set; }

        public TranslateStruct[] Respond { get; set; }
    }
}
