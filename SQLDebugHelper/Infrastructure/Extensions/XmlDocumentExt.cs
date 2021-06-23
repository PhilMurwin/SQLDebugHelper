using System;
using System.Text;
using System.Xml;
using System.Xml.Linq;

namespace SQLDebugHelper.Infrastructure.Extensions
{
    public static class XmlDocumentExt
    {
        public static string Beautify( this XmlDocument doc )
        {
            StringBuilder sb = new StringBuilder();
            XmlWriterSettings settings = new XmlWriterSettings
            {
                Indent = true,
                IndentChars = "  ",
                NewLineChars = "\r\n",
                NewLineHandling = NewLineHandling.Replace
            };
            using ( XmlWriter writer = XmlWriter.Create( sb, settings ) )
            {
                doc.Save( writer );
            }
            return sb.ToString();
        }

        public static XmlDocument LoadXmlString( this XmlDocument doc, string xmlString )
        {
            var xDoc = new XmlDocument();
            xDoc.LoadXml( xmlString );

            return xDoc;
        }

        public static bool IsXmlString( this string xmlString )
        {
            var isXML = false;

            if ( !string.IsNullOrEmpty( xmlString ) && xmlString.TrimStart().StartsWith( "<" ) )
            {
                try
                {
                    var xDoc = XDocument.Parse( xmlString );
                    isXML = true;
                }
                catch ( Exception ) { }
            }

            return isXML;
        }
    }
}
