Imports Microsoft.VisualBasic
#Region "#usings"
Imports DevExpress.Web.ASPxScheduler
Imports System
Imports System.Data.SqlClient
#End Region ' #usings

Partial Public Class _Default
	Inherits System.Web.UI.Page

	Protected Sub Page_Load(ByVal sender As Object, ByVal e As EventArgs)
	End Sub

	Protected Sub Page_Init(ByVal sender As Object, ByVal e As EventArgs)
		 ASPxScheduler1.Start = New DateTime(2008, 07, 13)
	End Sub
	#Region "#appointmentrowinserted"
	Protected Sub ASPxScheduler1_AppointmentRowInserted(ByVal sender As Object, ByVal e As ASPxSchedulerDataInsertedEventArgs)
		Dim connection As New SqlConnection(CarsSchedulingDataSource.ConnectionString)
		Dim id As Object = Nothing
		connection.Open()
		Try
			Using cmd As New SqlCommand("SELECT IDENT_CURRENT('CarScheduling')", connection)
				id = Convert.ToInt32(cmd.ExecuteScalar())
			End Using
			e.KeyFieldValue = id
		Finally
			connection.Close()
		End Try
	End Sub
	#End Region ' #appointmentrowinserted
End Class
