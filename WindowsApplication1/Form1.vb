Imports System.Net
Imports System.IO
Imports System.Xml

'Imports System.ServiceModel.Web

Public Class Form1

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click


        Dim webrequest As New WebClient
        Dim user As String = ComboBox1.SelectedItem.ToString
        Dim data As Stream = webrequest.OpenRead("http://localhost:62131/Service1.svc/Login/" + user)


        Dim reader As New StreamReader(data)
        Dim s As String = reader.ReadToEnd()
        Dim doc As New XmlDocument
        doc.LoadXml(s)
        Dim element As XmlNode = doc.DocumentElement.FirstChild
        Dim result As String = element.InnerText
        MsgBox(user & result)
        Console.WriteLine(result)
        data.Close()
        reader.Close()




        'Dim objService As New ServiceReference1.Service1Client()
        'Dim userinfo As New UserDetails()
        'userinfo.User_Name = ListBox1.SelectedItem.ToString
        'userinfo.time_now = DateTime.Now


        'Dim result As String = objService.InsertUserDetails(userinfo)
        'MsgBox(result)



    End Sub

    Private Sub Button2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button2.Click
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

    Private Sub Button3_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button3.Click

        Dim webrequest As New WebClient
        Dim user As String = ComboBox1.SelectedItem.ToString
        Dim data As Stream = webrequest.OpenRead("http://localhost:62131/Service1.svc/Logout/" + user)


        Dim reader As New StreamReader(data)
        Dim s As String = reader.ReadToEnd()
        Dim doc As New XmlDocument
        doc.LoadXml(s)
        Dim element As XmlNode = doc.DocumentElement.FirstChild
        Dim result As String = element.InnerText
        MsgBox(user & result)
        Console.WriteLine(result)
        data.Close()
        reader.Close()
    End Sub
End Class
