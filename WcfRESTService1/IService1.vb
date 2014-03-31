' NOTE: If you change the interface name "IService1" here, you must also update the reference to "IService1" in Web.config.
Imports System.Collections.Generic
Imports System.Linq
Imports System.Runtime.Serialization
Imports System.ServiceModel
Imports System.ServiceModel.Web
Imports System.Text


<ServiceContract(Namespace:="WCFRESTService")> _
Public Interface IService1


    <OperationContract(Name:="InsertUserDetails")> _
    <WebGet(UriTemplate:="Login/{user}", RequestFormat:=WebMessageFormat.Xml, ResponseFormat:=WebMessageFormat.Xml, BodyStyle:=WebMessageBodyStyle.WrappedRequest)> _
    Function InsertUserDetails(ByVal user As String) As String

    <OperationContract()> _
    <WebGet(UriTemplate:="/Logout/{user}", RequestFormat:=WebMessageFormat.Xml, ResponseFormat:=WebMessageFormat.Xml, BodyStyle:=WebMessageBodyStyle.WrappedRequest)> _
    Function UpdateUserDetails(ByVal user As String) As String

    <OperationContract(Name:="GetTimeClockLog")> _
    <WebGet(UriTemplate:="/GetTimeClockLog", RequestFormat:=WebMessageFormat.Xml, ResponseFormat:=WebMessageFormat.Xml, BodyStyle:=WebMessageBodyStyle.WrappedRequest)> _
    Function GetTimeClockLog() As String

End Interface

    ' Use a data contract as illustrated in the sample below to add composite types to service operations.
<DataContract(Namespace:="WCFRESTService")> _
Public Class UserDetails


    Private username As String = String.Empty
    Private timenow As DateTime


<DataMember()> _
Public Property User_Name() As String
    Get
        Return username
    End Get
    Set(ByVal value As String)
        username = value
    End Set
End Property

    <DataMember()> _
    Public Property time_now() As DateTime
        Get
            Return timenow
        End Get
        Set(ByVal value As DateTime)
            timenow = value
        End Set
    End Property

End Class







