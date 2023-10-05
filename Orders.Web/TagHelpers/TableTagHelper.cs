using Microsoft.AspNetCore.Razor.TagHelpers;

namespace Orders.Web.TagHelpers
{
	[HtmlTargetElement("table")]
	public class TableTagHelper : TagHelper
	{
		public string TblProps { get; set; } = "table table-striped table-hover";

		public override void Process(TagHelperContext context, TagHelperOutput output)
		{
			output.TagName = "table";
			output.Attributes.Add("class", TblProps);


			base.Process(context, output);
		}
	}
}
