using System;
using System.IO;
using System.Xml.Serialization;
using LottoPlugin.Modules;
using Torch;

namespace LottoPlugin.Utils
{    
    public static class ConfigUtils
    {
        public static T Load<T>(TorchPluginBase plugin, string fileName) where T : new()
        {
            string path = Path.Combine(plugin.StoragePath, "Lotto", fileName);
            T t = Activator.CreateInstance<T>();
            bool flag = File.Exists(path);
            if (flag)
            {
                using (StreamReader streamReader = new StreamReader(path))
                {
                    XmlSerializer xmlSerializer = new XmlSerializer(typeof(T));
                    t = (T)((object)xmlSerializer.Deserialize(streamReader));
                }
            }
            else
            {
                ConfigUtils.Save<T>(plugin, t, fileName);
            }
            return t;
        }

        public static bool Save<T>(TorchPluginBase plugin, T data, string fileName) where T : new()
        {
            try
            {
                bool dossier = Directory.Exists(Path.Combine(plugin.StoragePath, "Lotto"));
                if (!dossier)
                    Directory.CreateDirectory(Path.Combine(plugin.StoragePath, "Lotto"));

                string path = Path.Combine(plugin.StoragePath, "Lotto", fileName);
                using (StreamWriter streamWriter = new StreamWriter(path))
                {
                    XmlSerializer xmlSerializer = new XmlSerializer(typeof(T));
                    xmlSerializer.Serialize(streamWriter, data);
                }
                return true;
            }
            catch (Exception)
            {
            }
            return false;
        }

        public static bool IsValidTimeFormat(this string input)
        {
            DateTime dummyOutput;
            return DateTime.TryParse(input, out dummyOutput);
        }

        public static bool DayCanDraw(DateTime dateTime)
        {
            switch (dateTime.DayOfWeek)
            {
                case DayOfWeek.Sunday:
                    return Module.Config.DrawDays.Sunday;
                case DayOfWeek.Monday:
                    return Module.Config.DrawDays.Monday;
                case DayOfWeek.Tuesday:
                    return Module.Config.DrawDays.Tuesday;
                case DayOfWeek.Wednesday:
                    return Module.Config.DrawDays.Wednesday;
                case DayOfWeek.Thursday:
                    return Module.Config.DrawDays.Thursday;
                case DayOfWeek.Friday:
                    return Module.Config.DrawDays.Friday;
                case DayOfWeek.Saturday:
                    return Module.Config.DrawDays.Saturday;
                default:
                    return false;
            }
        }

        public static DateTime NextDraw()
        {
            var hours = DateTime.Parse(Module.Config.DrawHours);
            var now = DateTime.Now;
            var next = new DateTime(now.Year, now.Month, now.Day, hours.Hour, hours.Minute, 0);

            if (now > next || !DayCanDraw(next))
            {
                do
                {
                    next = next.AddDays(1);
                } while (!DayCanDraw(next));
            }

            return next;
        }
    }
}
