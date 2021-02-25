Imports System.Data.SqlClient
Module QueryCommands

    Public connection As SqlConnection
    Public command, command1, command2, command3, command4 As SqlCommand
    Public adaptor As SqlDataAdapter
    Public tableData1, tableData2, tableData3 As DataTable
    Public bindingsource As BindingSource
    Public cs As String = " server = DESKTOP-8RMBCQR\SQLEXPRESS; Database = WeDev_Payroll_db; Integrated Security = true"


#Region "save record"
    Public Sub save(ByVal query As String)
        Try
            connection = New SqlConnection(cs)
            connection.Open()
            Command = New SqlCommand(query, connection)
            Command.ExecuteNonQuery()
            connection.Close()
            MsgBox("information accepted")
        Catch Ex As Exception
            MsgBox(Ex.Message)
        Finally
            connection.Close()
        End Try
    End Sub
#End Region

    'update codes
#Region "update record"
    Public Sub update(ByVal query As String)
        Try
            connection = New SqlConnection(cs)
            connection.Open()
            Command = New SqlCommand(query, connection)
            Command.ExecuteNonQuery()
            connection.Close()
            MsgBox("update is sucessfull")
        Catch Ex As Exception
            MsgBox("ex. meessage")
        Finally
            connection.Close()
        End Try
    End Sub
#End Region
    'delet codes
#Region "delete record"
    Public Sub delete(ByVal query As String)
        Try
            connection = New SqlConnection(cs)
            connection.Open()
            Command = New SqlCommand(query, connection)
            Command.ExecuteNonQuery()
            connection.Close()
            MsgBox("deleted sucessfully")
        Catch Ex As Exception
            MsgBox("ex. meessage")
        Finally
            connection.Close()
        End Try
    End Sub
#End Region

End Module
