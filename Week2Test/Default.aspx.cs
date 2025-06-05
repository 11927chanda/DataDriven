using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Week2Test
{
    public partial class Default : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            //  lblTitle.Text = " I'm losing my mind";

            //1. Open the connection
            String _connectionString = "Data Source=SQL5110.site4now.net;Initial Catalog=db_9ab8b7_25dda11927;User Id=db_9ab8b7_25dda11927_admin;Password=dSZm274x;";

            //Create connection
            SqlConnection conn = new SqlConnection();
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
                row["USerLevel"] = reader["USerLevel"];

                dt.Rows.Add(row);
            }

            //6. Display
            gvResult.DataSource = dt;
            gvResult.DataBind();

            //7. Close connection
            conn.Close();
        }
    }
}