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
            this.General = new List<TranslateStruct>();

            General.Add(new TranslateStruct("lotto", "Lotto"));

            General.Add(new TranslateStruct("draw", "Tirage du Lotto !"));
            General.Add(new TranslateStruct("dontWin", "Il n'y a pas de gagnant !"));
            General.Add(new TranslateStruct("win", "Le gagant est {0}"));
            General.Add(new TranslateStruct("next", "Prochain tirage le {0}, pour un montant de {1:N0} SC"));

            General.Add(new TranslateStruct("changed", "Value changed !"));

            General.Add(new TranslateStruct("sunday", "Sunday"));
            General.Add(new TranslateStruct("monday", "Monday"));
            General.Add(new TranslateStruct("tuesday", "Tuesday"));
            General.Add(new TranslateStruct("wednesday", "Wednesday"));
            General.Add(new TranslateStruct("thursday", "Thursday"));
            General.Add(new TranslateStruct("friday", "Friday"));
            General.Add(new TranslateStruct("saturday", "Saturday"));
        }

        public void HelpFunction() {
            this.Help = new List<TranslateStruct>();

            Help.Add(new TranslateStruct("title", "Lotto Help"));

            Help.Add(new TranslateStruct("info", "> !lotto info - Show information"));
            Help.Add(new TranslateStruct("play", "> !lotto play <number> - Play Lotto"));
            Help.Add(new TranslateStruct("recove", "> !lotto recove - Allows you to recover your gain"));
            
            Help.Add(new TranslateStruct("settings", "Settings:"));
            Help.Add(new TranslateStruct("config", "> !lotto config - Show configuration"));
            Help.Add(new TranslateStruct("open", "> !lotto open <bool> - Open or close the Lotto"));
            Help.Add(new TranslateStruct("number", "> !lotto number max <number> - Change the max number the player can play"));

            Help.Add(new TranslateStruct("ticket", "Ticket:"));
            Help.Add(new TranslateStruct("prix", "> !lotto ticket prix <number> - Change the ticket price"));
            Help.Add(new TranslateStruct("multiple", "> !lotto ticket multiple <bool> - Players can play Lotto multiple times"));

            Help.Add(new TranslateStruct("gain", "Gain:"));
            Help.Add(new TranslateStruct("gainNumber", "> !lotto gain <number> - Changes the winnings that are added to each Lotto whether it is ganged or lost"));
            Help.Add(new TranslateStruct("max", "> !lotto gain max <number> - Changes the maximum Lotto win"));
            Help.Add(new TranslateStruct("cumulate", "> !lotto gain cumulate <bool> - Cumulate Lotto winnings as long as it is not won"));
            Help.Add(new TranslateStruct("add", "> !lotto gain add <number> - Adds an amount to the Lotto win"));
            Help.Add(new TranslateStruct("remove", "> !lotto gain remove <number> - Remove an amount from the Lotto win"));
            Help.Add(new TranslateStruct("partage", "> !lotto gain partage <bool> - Share the winnings among the winners or give the same winnings to each winner"));
            
            Help.Add(new TranslateStruct("draw", "Draw:"));
            Help.Add(new TranslateStruct("start", "> !Lotto draw start - Perform a manual Lotto draw"));
            Help.Add(new TranslateStruct("auto", "> !lotto draw auto <bool> - Activate or deactivate the automatic draft"));
            Help.Add(new TranslateStruct("days", "> !lotto draw days <b> <b> <b> <b> <b> <b> <b> - Change the automatic day draw (Sunday Monday Tuesday Wednesday Thursday Friday Saturday)"));
            Help.Add(new TranslateStruct("hour", "> !lotto draw hour <HH:mm> - Set the Lotto draw time (ex: 06:00pm or 18:00)"));

            Help.Add(new TranslateStruct("save", "> !Lotto save - Save all files"));
            Help.Add(new TranslateStruct("reload", "> !Lotto reload - Reload all files"));
        }

        public void InfoFunction()
        {
            this.Info = new List<TranslateStruct>();

            Info.Add(new TranslateStruct("title", "Lotto Information"));

            Info.Add(new TranslateStruct("open", "Le lotto est ouvert"));
            Info.Add(new TranslateStruct("close", "Le lotto est fermé"));

            Info.Add(new TranslateStruct("next", "Le prochain tirage est le {0}"));

            Info.Add(new TranslateStruct("play", "Vous avez déjà joué au Lotto avec le numéro {0}"));
            Info.Add(new TranslateStruct("dont", "Vous n'avez pas encore joué au Lotto"));

            Info.Add(new TranslateStruct("prix", "Le prix du ticket est de : {0:N0} SC"));
            Info.Add(new TranslateStruct("multiple", "Vous pouvez acheter plusieurs Ticket"));
            Info.Add(new TranslateStruct("dontMultiple", "Vous pouvez acheter qu'un seul ticket"));
            Info.Add(new TranslateStruct("number", "Le chiffre pouvant être joué est entre 0 et {0}"));
            Info.Add(new TranslateStruct("gain", "Le gain du Lotto est de : {0:N0} SC"));

            Info.Add(new TranslateStruct("dontRecove", "Vous n'avez pas de gain à récupérer"));
            Info.Add(new TranslateStruct("recove", "Vous avez {0} gain à récupérer pour un montant total de {1:N0} SC"));
        }

        public void ConfigFunction()
        {
            this.Config = new List<TranslateStruct>();

            Config.Add(new TranslateStruct("title", "Lotto Configuration"));

            Config.Add(new TranslateStruct("open", "> The Lotto is open : {0}"));
            Config.Add(new TranslateStruct("max", "> The max number the player can play : {0}"));

            Config.Add(new TranslateStruct("prix", "> The ticket price : {0:N0} SC"));
            Config.Add(new TranslateStruct("multiple", "> Players can play Lotto multiple times : {0}"));
            
            Config.Add(new TranslateStruct("gainTotal", "> The gain : {0:N0} SC"));
            Config.Add(new TranslateStruct("gain", "> The winnings that are added to each Lotto whether it is ganged or lost : {0:N0} SC"));
            Config.Add(new TranslateStruct("maxi", "> The maximum Lotto win : {0:N0} SC"));
            Config.Add(new TranslateStruct("cumulate", "> Cumulate Lotto winnings as long as it is not won : {0}"));
            Config.Add(new TranslateStruct("partage", "> Share the winnings among the winners or give the same winnings to each winner : {0}"));

            Config.Add(new TranslateStruct("auto", "> The automatic draw : {0}"));
            Config.Add(new TranslateStruct("days", "> The automatic day draw {0}{1}{2}{3}{4}{5}{6}"));
            Config.Add(new TranslateStruct("hour", "> The Lotto draw hour : {0}"));
            Config.Add(new TranslateStruct("next", "> Next draw : {0}"));

        }

        public void RespondFunction()
        {
            this.Respond = new List<TranslateStruct>();

            Respond.Add(new TranslateStruct("dontPlay", "Vous ne pouvez pas jouer au Lotto car il est fermé"));
            Respond.Add(new TranslateStruct("money", "Vous n'avez pas assez d'argent"));
            Respond.Add(new TranslateStruct("thank", "Merci, vous venez de jouer au Lotto"));

            Respond.Add(new TranslateStruct("recove", "Vous venez de récupérer votre gain de : {0:N0} SC"));
            
            Respond.Add(new TranslateStruct("add", "Error : The value to be added exceeds the maximum Lotto win"));
            Respond.Add(new TranslateStruct("remove", "Error : Value to be removed too high, the gain cannot be negative"));
            Respond.Add(new TranslateStruct("days", "Error : Minimum one day must be at true"));
            Respond.Add(new TranslateStruct("auto", "Warning : The auto-draw function is disabled"));
            Respond.Add(new TranslateStruct("hour", "Error : The hour format is not compatible. Please use format 06:00pm or 18:00"));

            Respond.Add(new TranslateStruct("save", "All files are saved !"));
            Respond.Add(new TranslateStruct("reload", "All files are reload !"));

        }
        public List<TranslateStruct> General { get; set; }
        public List<TranslateStruct> Help { get; set; }
        public List<TranslateStruct> Info { get; set; }
        public List<TranslateStruct> Config { get; set; }
        public List<TranslateStruct> Respond { get; set; }


    }
}
