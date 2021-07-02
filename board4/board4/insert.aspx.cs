using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI.WebControls;
using System.Data.SqlClient;

using System.Collections;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Web.SessionState;
using System.Web.UI.HtmlControls;

namespace board4
{
    public partial class insert : System.Web.UI.Page
    {
        protected SqlConnection Con;
        protected SqlCommand Cmd;

        private string seq = string.Empty;

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                if (Request.Params["seq"] != null)
                    seq = Request.Params["seq"].ToString();

                if (seq != string.Empty)
                {
                    ViewState["seq"] = seq;
                    getContent();
                }
                else
                {
                    ViewState["seq"] = "";
                }
            }
            else
            {
                seq = ViewState["seq"].ToString();
            }

        }

        private void getContent()
        {
            Con = new SqlConnection("server=(local);database=NetBoard;user id=sa;password=124578");
            Cmd = new SqlCommand();
            Cmd.Connection = Con;

            Cmd.CommandType = CommandType.StoredProcedure;

            Cmd.Parameters.Add("@intseq", SqlDbType.Int);
            Cmd.Parameters["@intseq"].Value = seq;

            try
            {
                Con.Open();

                //레코드를 읽어오는 프로시저로 지정
                Cmd.CommandText = "UP_SELECT_BOARDCONTENT";

                SqlDataReader reader = Cmd.ExecuteReader(CommandBehavior.CloseConnection);
                if (reader.Read())
                {
                    name.Text = reader[1].ToString();
                    name.Enabled = false;
                    pwd.Enabled = false;
                    title.Text = reader[2].ToString();
                    content.Text = reader[4].ToString();
                }
                else
                {
                    Error.Text = "비밀번호 불일치!!";
                }

                reader.Close();
            }
            catch (Exception ex)
            {
                Error.Text = "ERROR : " + ex.Source + " - " + ex.Message;
                Error.Visible = true;

            }

            if (Con.State == ConnectionState.Open)
                Con.Close();

            Cmd = null;
            Con = null;

        }

        protected void PostButton_Click1(object sender, System.Web.UI.ImageClickEventArgs e)
        {
            Con = new SqlConnection();
            Con.ConnectionString = "server=(local);database=NetBoard;user id=sa;password=124578";

            if (seq == string.Empty)
            {
                Cmd = new SqlCommand("UP_INSERT_BOARDNEW", Con);
                Cmd.CommandType = CommandType.StoredProcedure;

                Cmd.Parameters.Add("@Writer", SqlDbType.VarChar, 20);
                Cmd.Parameters.Add("@Pwd", SqlDbType.VarChar, 20);
                Cmd.Parameters.Add("@Title", SqlDbType.VarChar, 100);
                Cmd.Parameters.Add("@Content", SqlDbType.Text);

                Cmd.Parameters["@Writer"].Value = name.Text;
                Cmd.Parameters["@Pwd"].Value = pwd.Text;
                Cmd.Parameters["@Title"].Value = title.Text;
                Cmd.Parameters["@Content"].Value = content.Text;
            }
            else
            {
                Cmd = new SqlCommand("UP_UPDATE_BOARD", Con);
                Cmd.CommandType = CommandType.StoredProcedure;

                Cmd.Parameters.Add("@seq", SqlDbType.Int);
                Cmd.Parameters.Add("@Title", SqlDbType.VarChar, 100);
                Cmd.Parameters.Add("@Content", SqlDbType.Text);

                Cmd.Parameters["@seq"].Value = seq;
                Cmd.Parameters["@Title"].Value = title.Text;
                Cmd.Parameters["@Content"].Value = content.Text;

                string script;
                script = "<script>alert('변경되었습니다');location.href='Content.aspx?seq={0}';</script>";
                script = string.Format(script, seq);
            }

            Con.Open();
            Cmd.ExecuteNonQuery();
            Con.Close();

            Cmd = null;
            Con = null;

            Response.Redirect("list.aspx");
        }
    }
}