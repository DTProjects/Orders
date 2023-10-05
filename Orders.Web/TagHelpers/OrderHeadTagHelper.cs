using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.AspNetCore.Razor.TagHelpers;
using Microsoft.Extensions.Options;
using static System.Formats.Asn1.AsnWriter;
using System.Collections.Generic;

namespace Orders.Web.TagHelpers
{
	[HtmlTargetElement("orderhead")]
	public class OrderHeadTagHelper : TagHelper
	{
		public string HeadTheme { get; set; } = "table-dark";
		public List<string> Captions = new List<string>() { "Order Number", "First Name", "Last Name", "Order Quantity", "Options" };

		public override void Process(TagHelperContext context, TagHelperOutput output)
		{
			output.TagName = "thead";
			output.TagMode = TagMode.StartTagAndEndTag;
			output.Attributes.SetAttribute("class", HeadTheme);

			TagBuilder row = new TagBuilder("tr");

			foreach (string cap in Captions)
			{
				TagBuilder header = new TagBuilder("th");
				header.Attributes.Add("scope", "col");
				header.InnerHtml.Append(cap);
				row.InnerHtml.AppendHtml(header);
			}

			output.Content.SetHtmlContent(row);
		}
	}
}
