Imports System.Net
Imports System.IO
Imports System.Xml

Partial Public Class _Default
    Inherits System.Web.UI.Page

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

    End Sub

    Protected Sub Button1_Click(ByVal sender As Object, ByVal e As EventArgs) Handles Button1.Click
        Dim webrequest As New WebClient
        Dim user As String = DropDownList1.SelectedItem.Text
        Dim data As Stream = webrequest.OpenRead("http://localhost:62131/Service1.svc/Login/" + user)


        Dim reader As New StreamReader(data)
        Dim s As String = reader.ReadToEnd()
        Dim doc As New XmlDocument
        doc.LoadXml(s)
        Dim element As XmlNode = doc.DocumentElement.FirstChild
        Dim result As String = element.InnerText
        MsgBox(user & ": " & result)
        Console.WriteLine(result)
        data.Close()
        reader.Close()

    End Sub

    Protected Sub Button2_Click(ByVal sender As Object, ByVal e As EventArgs) Handles Button2.Click
        Dim webrequest As New WebClient
        Dim user As String = DropDownList1.SelectedItem.Text
        Dim data As Stream = webrequest.OpenRead("http://localhost:62131/Service1.svc/Logout/" + user)


        Dim reader As New StreamReader(data)
        Dim s As String = reader.ReadToEnd()
        Dim doc As New XmlDocument
        doc.LoadXml(s)
        Dim element As XmlNode = doc.DocumentElement.FirstChild
        Dim result As String = element.InnerText
        MsgBox(user & ": " & result)

        data.Close()
        reader.Close()
    End Sub

    Protected Sub Button4_Click(ByVal sender As Object, ByVal e As EventArgs) Handles Button4.Click
        Dim webrequest As New WebClient

        Dim data As Stream = webrequest.OpenRead("http://localhost:62131/Service1.svc/GetTimeClockLog")


        Dim reader As New StreamReader(data)
        Dim s As String = reader.ReadToEnd()
        Dim doc As New XmlDocument
        doc.LoadXml(s)
        Dim ds As New DataSet


        Dim element As XmlNode = doc.DocumentElement.FirstChild
        Dim result As String = element.InnerText
        Console.WriteLine(result)
        TextBox1.Text = result
        data.Close()
        reader.Close()
    End Sub
End Class