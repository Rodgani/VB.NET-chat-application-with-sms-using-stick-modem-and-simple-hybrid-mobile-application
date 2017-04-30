Imports MySql.Data.MySqlClient
Public Class image_dp

  

    Private Sub chnagedp_Click(sender As Object, e As EventArgs) Handles chnagedp.Click
        If imgchoose.ShowDialog = vbOK Then
            Try
                My.Settings.displaypic = imgtobytes(imgchoose.FileName)
                My.Settings.Save()
                con = New MySqlConnection(conn)
                con.Open()
                comm = New MySqlCommand("UPDATE employee_account SET dp='" & My.Settings.displaypic & "' WHERE username='" & My.Settings.Username & "'", con)
                reader = comm.ExecuteReader
                MsgBox("You change your profile picture")
                Dim mems As System.IO.MemoryStream = New System.IO.MemoryStream(Convert.FromBase64String(My.Settings.displaypic))
                Eemp.hey.Image = Drawing.Image.FromStream(mems)
                Eemp.Ptbx1.Image = Drawing.Image.FromStream(mems)
                Head.pic.Image = Drawing.Image.FromStream(mems)
                Head.PictureBox1.Image = Drawing.Image.FromStream(mems)
                recep.pic.Image = Drawing.Image.FromStream(mems)
                recep.picpic.Image = Drawing.Image.FromStream(mems)
                pp.Image = Drawing.Image.FromStream(mems)
                admin.adminpic.Image = Drawing.Image.FromStream(mems)
                admin.PictureBox1.Image = Drawing.Image.FromStream(mems)
            Catch ex As Exception
                If ex.Message.Contains("Packets larger") Then
                    MsgBox("Piture dimensions are too large to store in database. Please use picture of lower dimensions like 640x480.", MsgBoxStyle.Critical, "Invalid Picture Dimensions")
                Else
                    MsgBox(ex.Message, MsgBoxStyle.Critical, "Data Error")
                End If

            End Try

        End If
    End Sub

    Private Sub image_dp_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Dim memss As System.IO.MemoryStream = New System.IO.MemoryStream(Convert.FromBase64String(My.Settings.displaypic))
        pp.Image = Drawing.Image.FromStream(memss)
    End Sub

   
End Class