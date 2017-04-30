Imports MySql.Data.MySqlClient

Public Class Coords

    Private Sub Coords_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        details()

    End Sub

    Public Function emdt() As DataTable
        Dim emdts As New DataTable
        Try
            con = New MySqlConnection(conn)
            con.Open()
            comm = New MySqlCommand("select Coordinates,date from employee_coordinatesdetails", con)
            reader = comm.ExecuteReader
            emdts.Load(reader)
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
        Return emdts
    End Function

    Public Sub details()
        DataGridView1.DataSource = emdt()
    End Sub





    Private Sub TextBox1_TextChanged(sender As Object, e As EventArgs) Handles TextBox1.TextChanged
        Try
            Dim dv As New DataView(emdt)
            dv.RowFilter = String.Format("Lastname like '%{0}%'", TextBox1.Text)
            DataGridView1.DataSource = dv
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub
End Class