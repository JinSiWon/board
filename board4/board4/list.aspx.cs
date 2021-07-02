using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;


namespace board4
{
    public partial class list : System.Web.UI.Page
    {
        protected SqlConnection Con;
        protected SqlCommand Cmd;

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                Listing();
            }
        }

        private void Listing()
        {
            Con = new SqlConnection();
            Con.ConnectionString = "server=(local);database=NetBoard;user id=sa;password=124578";

            Cmd = new SqlCommand("UP_SELECT_BOARDLIST", Con);
            Cmd.CommandType = CommandType.StoredProcedure;

            SqlDataAdapter adp = new SqlDataAdapter(Cmd);

            DataSet ds = new DataSet();

            adp.Fill(ds, "Board");

            DataGrid.DataSource = ds;
            DataGrid.DataBind();
        }

    }
}