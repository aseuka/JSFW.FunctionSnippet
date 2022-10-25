using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Xml;

namespace JSFW.FunctionSnippet
{
    public static class Ux
    {
        /// <summary>
        /// 컨트롤 비동기 호출! 
        /// </summary>
        /// <typeparam name="TControl"></typeparam>
        /// <param name="ctrl"></param>
        /// <param name="action"></param>
        public static void DoAsync<TControl>(this TControl ctrl, Action<TControl> action) where TControl : Control
        {
            if (ctrl.InvokeRequired)
            {
                ctrl.Invoke(action, ctrl);
            }
            else
            {
                action(ctrl);
            }
        }

        /// <summary>
        /// Object To XML
        /// </summary>
        /// <typeparam name="T">Type of Object</typeparam>
        /// <param name="value">object Instance</param>
        /// <returns></returns>
        public static string Serialize<T>(this T value)
        {
            if (value == null) return string.Empty;
            string xml = "";
            try
            {
                var xmlSerializer = new System.Xml.Serialization.XmlSerializer(typeof(T));
                using (var stringWriter = new System.IO.StringWriter())
                {
                    using (var xmlWriter = XmlWriter.Create(stringWriter, new XmlWriterSettings { Indent = true }))
                    {
                        xmlSerializer.Serialize(xmlWriter, value);
                        xml = stringWriter.ToString();
                    }
                }
            }
            catch (Exception exc)
            {
                // 변환 중 Error!
            }
            return xml;
        }

        /// <summary>
        /// Xml String !
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="xml"></param>
        /// <returns></returns>
        public static T DeSerialize<T>(this string xml) where T : class, new()
        {
            T obj = default(T);
            try
            {
                var xmlSerializer = new System.Xml.Serialization.XmlSerializer(typeof(T));
                using (var stringReader = new System.IO.StringReader(xml))
                {
                    using (var reader = XmlReader.Create(stringReader, new XmlReaderSettings()))
                    {
                        obj = xmlSerializer.Deserialize(reader) as T;
                    }
                }
            }
            catch
            {
            }
            return obj;
        }
    }
}
