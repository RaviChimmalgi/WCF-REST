' NOTE: You can use the "Rename" command on the context menu to change the class name "Service1" in code, svc and config file together.

Imports System.Collections.Generic
Imports System.Linq
Imports System.Runtime.Serialization
Imports System.ServiceModel
Imports System.ServiceModel.Web
Imports System.Text
Imports System.Configuration
Imports System.Data
Imports System.Data.SqlClient
Imports System.ServiceModel.Activation
Imports System.IO


<AspNetCompatibilityRequirements(RequirementsMode:=AspNetCompatibilityRequirementsMode.Required)> _
<ServiceBehavior(Namespace:="WCFRESTService")> _
Public Class Service1
    Implements IService1

    Private con As New SqlConnection("Data Source=TE-LAPTOP-001\SQL2008R2;Initial Catalog=timeClock;Integrated Security=True")
    Public Sub New()
    End Sub
    Public Function GetTimeClockLog() As String Implements IService1.GetTimeClockLog
        Dim DS As New DataSet
        Dim query As String = "Select * From users"
        Dim adapter As New SqlDataAdapter
        Try
            con.Open()
            Dim cmd As SqlCommand = New SqlCommand(query, con)
            adapter.SelectCommand = cmd
            adapter.Fill(DS)
            adapter.Dispose()
            cmd.Dispose()
            con.Close()
        Catch ex As Exception

        End Try

        Dim s As String

        Using memoryStream = New MemoryStream()
            Using streamWriter As TextWriter = New StreamWriter(memoryStream)
                Dim xmlSerializer = New System.Xml.Serialization.XmlSerializer(GetType(DataSet))
                xmlSerializer.Serialize(streamWriter, DS)
                s = Encoding.UTF8.GetString(memoryStream.ToArray())
            End Using
        End Using


        Return s

    End Function
    Public Function InsertUserDetails(ByVal user As String) As String Implements IService1.InsertUserDetails
        'MsgBox(userInfo.User_Name + " " + userInfo.time_now)
        Dim strMessage As String = String.Empty
        Dim errorMessage As String = String.Empty
        Dim numcount As Integer = 0
        Dim time As DateTime = DateTime.Now
        numcount = getusercount(user)
        If (numcount = 0) Then

            Try


                con.Open()
                Dim cmd As New SqlCommand("spInsertLog", con)
                cmd.CommandType = CommandType.StoredProcedure

                cmd.Parameters.AddWithValue("@username", user)
                cmd.Parameters.AddWithValue("@timein", time)


                cmd.ExecuteNonQuery()
                strMessage = "You have Signed In at: " + time

            Catch ex As Exception
                errorMessage = ex.ToString
            Finally
                con.Close()
            End Try
            'MsgBox("You have Signed In at: " + userInfo.time_in)

        ElseIf (numcount = 1) Then
            'MsgBox("Error, You need to SignOut before you can SignIn")
            strMessage = "Error, you need to SignOut before you can SignIn"
        End If


        Return strMessage + errorMessage
    End Function

    Public Function UpdateUserDetails(ByVal user As String) As String Implements IService1.UpdateUserDetails
        Dim message As String = String.Empty
        Dim time As DateTime = DateTime.Now
        Dim numcount As Integer = 0
        'MsgBox(userInfo.User_Name)
        numcount = getusercount(user)
        If (numcount = 1) Then


            Try
                con.Open()

                Dim cmd As New SqlCommand("spUpdateLog", con)
                cmd.CommandType = CommandType.StoredProcedure

                cmd.Parameters.AddWithValue("@username", user)
                cmd.Parameters.AddWithValue("@timeou", time)

                cmd.ExecuteNonQuery()
                message = "You have Signed Out at: " + time
            Catch ex As Exception
                'MsgBox("ERROR")
            Finally
                con.Close()
            End Try
            'MsgBox("You have Signed Out at: " + userInfo.time_now)

        ElseIf (numcount = 0) Then
            'MsgBox("Error: You need to SignIn before you can SignOut")
            message = "Error, you need to SignIn before you can SignOut"
        End If

        Return message
    End Function

    

    Public Function getusercount(ByVal username As String) As Integer
        Dim count As Int32 = 0
        Try
            con.Open()
            Dim cmd As New SqlCommand("spgetcount", con)
            cmd.CommandType = CommandType.StoredProcedure

            cmd.Parameters.AddWithValue("@username", username)
            count = Convert.ToInt32(cmd.ExecuteScalar())


        Catch ex As Exception
        Finally
            con.Close()
        End Try


        Return count
    End Function
End Class
