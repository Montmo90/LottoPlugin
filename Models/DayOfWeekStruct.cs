using System.Xml.Serialization;

namespace LottoPlugin.Models
{
    public struct DayOfWeekStruct
    {
        public DayOfWeekStruct(bool sunday, bool monday, bool tuesday, bool wednesday, bool thursday, bool friday, bool saturday)
        {
            Sunday = sunday;
            Monday = monday;
            Tuesday = tuesday;
            Wednesday = wednesday;
            Thursday = thursday;
            Friday = friday;
            Saturday = saturday;
        }

        [XmlAttribute]
        public bool Sunday;
        [XmlAttribute]
        public bool Monday;
        [XmlAttribute]
        public bool Tuesday;
        [XmlAttribute]
        public bool Wednesday;
        [XmlAttribute]
        public bool Thursday;
        [XmlAttribute]
        public bool Friday;
        [XmlAttribute]
        public bool Saturday;       
    }
}
