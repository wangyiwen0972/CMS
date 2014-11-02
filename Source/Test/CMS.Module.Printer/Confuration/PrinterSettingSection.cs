namespace CMS.Module.Printer.Confuration
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    using System.Configuration;

    public class PrinterSettingSection:ConfigurationSection
    {
        public PrinterSettingSection() { }

        [ConfigurationProperty("currentPrinter")]
        public PrinterSettingElement CurrentPrinter
        {
            get
            {
                return (
                  (PrinterSettingElement)this["currentPrinter"]);
            }
            set
            {
                this["currentPrinter"] = value;
            }

        }
    }

    public class PrinterSettingElement:ConfigurationElement
    {
        public PrinterSettingElement() { }

        public PrinterSettingElement(string attributeName, string attributeValue)
        {
            this.Name = attributeName;
            this.Value = attributeValue;
        }

        [ConfigurationProperty("name",IsRequired=true)]
        public string Name
        {
            get
            {
                return (string)this["name"];
            }
            set { this["name"] = value; }
        }

        [ConfigurationProperty("value")]
        public string Value
        {
            get
            {
                return (string)this["value"];
            }
            set { this["value"] = value; }
        }
    }
}
