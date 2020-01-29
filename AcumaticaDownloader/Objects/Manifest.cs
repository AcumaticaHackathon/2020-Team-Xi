using System.Xml.Serialization;

namespace AcumaticaDeployer
{
    [XmlRoot(ElementName = "generalInfo")]
    public class GeneralInfo
    {
        [XmlAttribute(AttributeName = "version")]
        public string Version { get; set; }

        [XmlAttribute(AttributeName = "type")]
        public string Type { get; set; }

        [XmlAttribute(AttributeName = "date")]
        public string Date { get; set; }

        [XmlAttribute(AttributeName = "name")]
        public string Name { get; set; }

        [XmlAttribute(AttributeName = "description")]
        public string Description { get; set; }

        [XmlAttribute(AttributeName = "exportMode")]
        public string ExportMode { get; set; }

        [XmlAttribute(AttributeName = "host")]
        public string Host { get; set; }

        [XmlAttribute(AttributeName = "master")]
        public string Master { get; set; }

        [XmlAttribute(AttributeName = "IsSafe")]
        public string IsSafe { get; set; }

        [XmlAttribute(AttributeName = "Size")]
        public string Size { get; set; }
    }

    [XmlRoot(ElementName = "packageManifest")]
    public class PackageManifest
    {
        [XmlElement(ElementName = "generalInfo")]
        public GeneralInfo GeneralInfo { get; set; }
    }
}