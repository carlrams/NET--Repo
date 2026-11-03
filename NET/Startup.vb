Imports Microsoft.AspNet.SignalR
Imports Microsoft.Owin
Imports Owin

Public Class Startup

    Dim DataSource As String = ""
    Dim catalog As String = "cldc_contractorportal"
    Dim UserID As String = ""
    Dim Password As String = ""

    Public Sub Configuration(app As IAppBuilder)
        Dim sqlConnectionString As String = "Data Source=" & DataSource & ";Initial Catalog=" & catalog & ";User ID=" & UserID & ";Password=" & Password & ";"
        GlobalHost.DependencyResolver.UseSqlServer(sqlConnectionString)
        app.MapSignalR()
    End Sub

End Class