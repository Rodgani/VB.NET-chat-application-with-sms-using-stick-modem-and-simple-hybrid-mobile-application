Imports MySql.Data.MySqlClient
Public Class WHERE_TO_GO
   

    Private Sub WHERE_TO_GO_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Label3.Text = Eemp.Textbox1.Text
        TextBox3.Text = Eemp.TextBox3.Text
        TextBox4.Text = Eemp.TextBox4.Text
        TextBox5.Text = Eemp.TextBox5.Text
        TextBox6.Text = Eemp.Textbox6.Text
    End Sub
    Public Sub savingmo()
        If TextBox1.Text <> "" And TextBox2.Text <> "" Then
            Try
                con = New MySqlConnection(conn)
                Dim gotoko As String = "insert into employee_location (Employee_ID,Employee_location,Purpose,date,Lastname,Firstname,Middlename,Department) values('" & Label3.Text & "','" & TextBox1.Text & "','" & TextBox2.Text & "','" & Label4.Text & "','" & Eemp.TextBox3.Text & "','" & Eemp.TextBox4.Text & "','" & Eemp.TextBox5.Text & "','" & Eemp.Textbox6.Text & "')"
                executequery(gotoko)
                Eemp.PictureBox2.Enabled = True
                MessageBox.Show("Location Save")
                TextBox1.Clear()
                TextBox2.Clear()
            Catch ex As Exception
                MsgBox(ex.Message)
            End Try
        Else
            MessageBox.Show("Fill up all fields")
        End If

    End Sub
    Private Sub MaterialRaisedButton1_Click(sender As Object, e As EventArgs) Handles MaterialRaisedButton1.Click
        savingmo()
    End Sub
End Class