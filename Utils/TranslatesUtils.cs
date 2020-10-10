
using LottoPlugin.Modules;

namespace LottoPlugin.Utils
{
    public static class TranslatesUtils
    {
        public static string GetGeneralId(string id)
        {
            foreach (var item in Module.Translates.General)
            {
                if (item.id == id)
                    return item.value;
            }
            return "None";
        }

        public static string GetHelpId (string id)
        {
            foreach (var item in Module.Translates.Help)
            {
                if (item.id == id)
                    return item.value;
            }
            return "None";
        }
        public static string GetInfoId(string id)
        {
            foreach (var item in Module.Translates.Info)
            {
                if (item.id == id)
                    return item.value;
            }
            return "None";
        }
        public static string GetConfigId(string id)
        {
            foreach (var item in Module.Translates.Config)
            {
                if (item.id == id)
                    return item.value;
            }
            return "None";
        }
        public static string GetRespondId(string id)
        {
            foreach (var item in Module.Translates.Respond)
            {
                if (item.id == id)
                    return item.value;
            }
            return "None";
        }
    }
}
