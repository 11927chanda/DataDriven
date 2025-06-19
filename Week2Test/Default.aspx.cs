using System;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Web.UI.WebControls;

namespace Week2Test
{
    public partial class Default : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            //  lblTitle.Text = " I'm losing my mind";

            //1. Open the connection
            String _connectionString = "";
            if (ConfigurationManager.ConnectionStrings["DevelopmentConnectionString"].ConnectionString.Equals("Dev"))
            {
                _connectionString = AppConstant.AppConnection.DevConnection;

            }
            else if (ConfigurationManager.ConnectionStrings["DevelopmentConnectionString"].ConnectionString.Equals("Test"))
            {
                _connectionString = AppConstant.AppConnection.TestConnection;

            }
            else
            {
                _connectionString = AppConstant.AppConnection.DevConnection;

            }


            //Create connection

            SqlConnection conn = new SqlConnection();
            try
            {
                conn.ConnectionString = _connectionString;
                conn.Open();

                //2. Prepare consume intsruction
                SqlCommand command = new SqlCommand("SELECT * FROM TAbUser", conn);

                //3. Consume
                SqlDataReader reader = command.ExecuteReader();

                //4. Prepare storage 
                DataTable dt = new DataTable();
                dt.Columns.Add("UserID", typeof(Int32));
                dt.Columns.Add("UserName", typeof(String));
                dt.Columns.Add("UserLevel", typeof(Int32));

                //5.Perform consumption
                while (reader.Read())
                {
                    DataRow row = dt.NewRow();
                    row["UserID"] = reader["UID"];
                    row["UserName"] = reader["UserName"];
                    row["UserLevel"] = reader["UserLevel"];

                    dt.Rows.Add(row);
                }

                //6. Display
                gvResult.DataSource = dt;
                gvResult.DataBind();

                //7. Close connection
                conn.Close();
            }
            catch (InvalidOperationException ex)
            {
                //
            }
            catch (SqlException ex)
            {
                //
            }
            catch (ConfigurationErrorsException ex)
            {
                //
            }
            catch (Exception ex)
            {
                //
            }

           
        }
        protected void gvResult_RowDataBound(object sender, GridViewRowEventArgs e) 
        {
            if (e.Row.RowType.Equals(DataControlRowType.DataRow))
            {
                Image img = new Image();

                //checkbox
                //  CheckBox checkbox = new CheckBox();

                DropDownList ddl = new DropDownList();

                if (e.Row.Cells[(int)AppConstant.TAbUser.UserLevel].Text.Equals(AppConstant.UserLevel.User))
                {
                    img.ImageUrl = "~/images/pawn.gif";

                }
                else if (e.Row.Cells[(int)AppConstant.TAbUser.UserLevel].Text.Equals(AppConstant.UserLevel.Supervisor))
                {
                    img.ImageUrl = "~/images/knight.gif";
                }
                else
                {
                    img.ImageUrl = "~/images/king.gif";
                }
                e.Row.Cells[(int)AppConstant.TAbUser.UserLevel].Controls.Add(img);
               // e.Row.Cells[0].Controls.Add(checkbox);

                for (int i = 1; i<= Int32.Parse(e.Row.Cells[(int)AppConstant.TAbUser.UID].Text); i ++)
                {
                    ddl.Items.Add(i.ToString());
                }

                e.Row.Cells[0].Controls.Add(ddl);
            }
        }
    }
}