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
    public partial class content : System.Web.UI.Page
    {
        private string seq = string.Empty;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                if (Request.Params["seq"] != null)
                    seq = Request.Params["seq"].ToString();

                if (seq == string.Empty)
                {
                    Response.Redirect("list.aspx");
                    Response.End();
                }

                getContent();
            }
        }

        private void getContent()
        {
            string ConnectStr = "server=(local);database=NetBoard;user id=sa;password=124578";

            SqlConnection Con = new SqlConnection(ConnectStr);
            SqlCommand Cmd = new SqlCommand();
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
                    ViewState["seq"] = reader[0].ToString();

                    name.Text = reader[1].ToString();
                    title.Text = reader[2].ToString();
                    date.Text = reader[3].ToString();
                    strcontent.Text = ReplaceBR(reader[4].ToString());
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
        protected string ReplaceBR(string s)
        {
            return s.Replace("\n", "<BR>");
        }

        private bool IsPasswordValid()
        {
            bool flag = false;

            string ConnectStr = "server=(local);database=NetBoard;user id=sa;password=124578";

            SqlConnection Con = new SqlConnection(ConnectStr);
            SqlCommand Cmd = new SqlCommand();
            Cmd.Connection = Con;

            Cmd.CommandText = "UP_IS_PASSWORD_VALID";
            Cmd.CommandType = CommandType.StoredProcedure;

            Cmd.Parameters.Add("@seq", SqlDbType.Int);
            Cmd.Parameters["@seq"].Value = ViewState["seq"].ToString();
            Cmd.Parameters.Add("@pwd", SqlDbType.VarChar, 20);
            Cmd.Parameters["@pwd"].Value = pwd.Text;

            try
            {
                Con.Open();

                if (Cmd.ExecuteScalar() != null)
                    flag = true;
            }
            catch (Exception ex)
            {
                Error.Text = "ERROR : " + ex.Source + " - " + ex.Message;
                Error.Visible = true;
            }

            if (Con.State == ConnectionState.Open) Con.Close();

            Cmd = null;
            Con = null;

            return flag;
        }

        protected void btnEdit_Click(object sender, ImageClickEventArgs e)
        {
            bool isValid = IsPasswordValid();

            if (isValid)
            {
                Response.Redirect("insert.aspx?seq=" + ViewState["seq"].ToString());
            }
            else
            {
                Error.Text = "비밀번호 불일치!!";
            }
            Error.Visible = true;
        }

        private void DeleteRecord()
        {
            string ConnectStr = "server=(local);database=NetBoard;user id=sa;password=124578";

            SqlConnection Con = new SqlConnection(ConnectStr);
            SqlCommand Cmd = new SqlCommand();
            Cmd.Connection = Con;

            Cmd.CommandText = "UP_DELETE_BOARD";
            Cmd.CommandType = CommandType.StoredProcedure;

            Cmd.Parameters.Add("@seq", SqlDbType.Int);
            Cmd.Parameters["@seq"].Value = ViewState["seq"].ToString();

            try
            {
                Con.Open();
                Cmd.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                Error.Text = "ERROR : " + ex.Source + " - " + ex.Message;
                Error.Visible = true;
            }

            if (Con.State == ConnectionState.Open) Con.Close();

            Cmd = null;
            Con = null;
        }

        protected void btnDelete_Click(object sender, ImageClickEventArgs e)
        {
            bool isValid = IsPasswordValid();

            if (isValid)
            {
                DeleteRecord();
                Response.Redirect("list.aspx");
            }
            else
                Error.Text = "비밀번호 불일치!!";

            Error.Visible = true;
        }
    }
}