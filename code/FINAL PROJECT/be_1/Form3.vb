Imports System
Imports System.Windows.Forms
Imports Microsoft.VisualBasic
Imports System.Security.Cryptography
Imports System.IO
Imports System.Math
Imports System.String
Imports System.Data
Imports System.Data.SqlClient
Imports System.Data.SqlClient.SqlException
Imports System.Data.SqlClient.SqlError
Imports System.Runtime.InteropServices
Imports System.ArgumentException

Public Class Form3
    Dim sCommand As SqlCommand
    Dim sCommand1 As SqlCommand
    Dim sAdapter As SqlDataAdapter
    Dim sBuilder As SqlCommandBuilder
    Dim sDs As DataSet
    Dim sTable As DataTable
    Dim dr As SqlDataReader
    Private Sub Form3_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

        Dim sql33 As String
        Form1.conn()


        sql33 = "select * from coherent1"

        sql_grid_execute(sql33, "coherent1")
        grid("coherent1")


    End Sub

    Public Function sql_grid_execute(ByVal sqlst As String, ByVal tablename As String) As SqlDataReader

        Try
            sCommand = New SqlCommand(sqlst, Form1.connection)
            sAdapter = New SqlDataAdapter(sCommand)
            sBuilder = New SqlCommandBuilder(sAdapter)
            sDs = New DataSet()
            sAdapter.Fill(sDs, tablename)
            sTable = sDs.Tables(tablename)

        Catch ex As Exception
            MsgBox(ex.Message & " Error Connecting to database!")
        End Try

        ' MsgBox("Success sql_grid")
        Return dr

    End Function

    Public Sub grid(ByRef tablename1 As String)

        DataGrid1.DataSource = sDs.Tables(tablename1)
        DataGrid1.ReadOnly = True
        Try
            DataGrid1.DataSource = DataGridViewSelectionMode.FullRowSelect
        Catch ex As Exception
            ' MsgBox(ex.Message & " Error Connecting to database!")
        End Try
        ' MsgBox("grid")

    End Sub

End Class