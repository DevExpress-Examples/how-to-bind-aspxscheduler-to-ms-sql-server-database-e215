#region #usings
using DevExpress.Web.ASPxScheduler;
using System;
using System.Data.SqlClient;
#endregion #usings

public partial class _Default : System.Web.UI.Page {

    protected void Page_Load(object sender, EventArgs e) {
	}

	protected void Page_Init(object sender, EventArgs e)
	{
	 	ASPxScheduler1.Start = new DateTime(2008, 07, 13);
	}
    #region #appointmentrowinserted
    protected void ASPxScheduler1_AppointmentRowInserted(object sender, ASPxSchedulerDataInsertedEventArgs e) {
        SqlConnection connection = new SqlConnection(CarsSchedulingDataSource.ConnectionString);
        object id = null;
        connection.Open();
        try
        {
            using (SqlCommand cmd = new SqlCommand("SELECT IDENT_CURRENT('CarScheduling')", connection))
                id = Convert.ToInt32(cmd.ExecuteScalar());
            e.KeyFieldValue = id;
        }
        finally
        {
            connection.Close();
        }
    }
    #endregion #appointmentrowinserted
}
