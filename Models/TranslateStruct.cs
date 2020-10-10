using System.Xml.Serialization;

namespace LottoPlugin.Models
{
    public struct TranslateStruct
    {
        public TranslateStruct(string id, string value)
        {
            this.value = value;
            this.id = id;
        }

        [XmlAttribute]
        public string value;
        [XmlAttribute]
        public string id;
    }
}
