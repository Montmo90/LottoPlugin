using System.Xml.Serialization;

namespace LottoPlugin.Models
{
    public struct TranslateStruct
    {
        public TranslateStruct(string id, string value)
        {
            this.id = id;
            this.value = value;
        }

        [XmlAttribute]
        public string id;
        [XmlAttribute]
        public string value;

    }
}
