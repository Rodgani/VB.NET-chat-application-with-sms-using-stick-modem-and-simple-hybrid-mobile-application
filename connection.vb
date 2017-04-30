Imports MySql.Data.MySqlClient
Imports System.IO
Imports System.Security.Cryptography
Module connection
    Public conn As String = "server=zxc;userid=Tennzxc;password=1251920;database=cande"
    Public con As MySqlConnection = New MySqlConnection
    Public reader As MySqlDataReader
    Public comm As MySqlCommand = New MySqlCommand
    Public Sub executequery(query As String)
        Dim command As New MySqlCommand(query, con)
        con.Open()
        command.ExecuteNonQuery()
    End Sub
    Public lst As ListViewItem
    Public frdusrname As String
    Public message As String = String.Empty
    Public msg(2000) As String


    Function imgtobytes(ByVal imgPath As String) As String
        Try
            Dim dp_image As Image = Image.FromFile(imgPath)
            Dim mems As MemoryStream = New MemoryStream()
            dp_image.Save(mems, System.Drawing.Imaging.ImageFormat.Png)
            Dim imgbytes As Byte() = mems.ToArray()

            Dim strImg As String = Convert.ToBase64String(imgbytes)

            Return strImg


        Catch ex As Exception
            MsgBox(ex.Message & vbNewLine & "Failed to convert image to bytes.", MsgBoxStyle.Critical, "Error Occurred")
        End Try
        Return imgPath
    End Function
End Module
