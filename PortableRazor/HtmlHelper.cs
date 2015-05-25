using System;
using System.IO;
using System.Reflection;
using System.Text;
using PortableRazor.Web;

namespace PortableRazor.Web.Mvc
{
	public partial class HtmlHelper {
		private TextWriter _writer;

		public HtmlHelper(TextWriter writer) {
			_writer = writer;
		}

		public IHtmlString Raw(string value) {
			return new HtmlString (value);
		}

		private string GenerateHtmlAttributes(object htmlAttributes) {
			var attrs = new StringBuilder ();
			if (htmlAttributes != null) {
                foreach (var property in htmlAttributes.GetType().GetRuntimeProperties())
                {
                    string htmlEncodedValue = System.Net.WebUtility.HtmlEncode(property.GetMethod.Invoke(htmlAttributes, null).ToString());
                    attrs.AppendFormat(@" {0}=""{1}""", property.Name.Replace('_', '-'), htmlEncodedValue);
                }
			}
			return attrs.ToString ();
		}
	}
}

