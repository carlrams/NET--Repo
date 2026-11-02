Imports Microsoft.AspNet.SignalR
Imports Microsoft.Owin
Imports Owin

Public Class Startup

    Dim DataSource As String = "10.10.30.10"
    Dim catalog As String = "cldc_contractorportal"
    Dim UserID As String = "jfevidal"
    Dim Password As String = "jfevidal"

    Public Sub Configuration(app As IAppBuilder)
        Dim sqlConnectionString As String = "Data Source=" & DataSource & ";Initial Catalog=" & catalog & ";User ID=" & UserID & ";Password=" & Password & ";"
        GlobalHost.DependencyResolver.UseSqlServer(sqlConnectionString)
        app.MapSignalR()
    End Sub

End Class