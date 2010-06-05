using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace NDueTime.Demo
{
	public partial class _Default : System.Web.UI.Page
	{
		public string LibraryVersionNumber 
		{
			get 
			{
				Version version = System.Reflection.Assembly.GetAssembly(typeof(RelativeDateTime)).GetName().Version;

				return String.Format("{0}.{1}.{2}", version.Major, version.Minor, version.Build);
			}
		}

		protected void Page_Load(object sender, EventArgs e)
		{
			Parse.Click += Parse_Click;
		}

		private void Parse_Click(object sender, EventArgs e)
		{
			string result;

			try
			{
				result = RelativeDateTime.Parse(RelativeTimeExpression.Text).ToString("g");
			}
			catch(FormatException ex)
			{
				result = ex.Message;
			}

			ParsedDateTime.Text = result;
		}
	}
}
