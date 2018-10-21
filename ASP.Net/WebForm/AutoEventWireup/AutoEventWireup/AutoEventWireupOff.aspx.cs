using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace AutoEventWireup
{
    public partial class AutoEventWireupOff : System.Web.UI.Page
    {
        protected override void OnInit(EventArgs e)
        {
            Load += Page_LoadCustom;
            base.OnInit(e);
        }

        /// <summary>
        /// With AutoEventWireup set in the markup as false this method will not be called
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void Page_Load(object sender, EventArgs e)
        {
            Response.Write(nameof(Page_Load));
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            Response.Write(nameof(Button1_Click));
        }

        protected void Page_LoadCustom(object sender, EventArgs e)
        {
            Response.Write(nameof(Page_LoadCustom));
        }
    }
}