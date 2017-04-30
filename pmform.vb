Imports MySql.Data.MySqlClient
Imports MaterialSkin

Public Class pmform

    Private Sub MaterialFlatButton1_Click(sender As Object, e As EventArgs) Handles MaterialFlatButton1.Click
        If TextBox1.Text = String.Empty Then
            MsgBox("Please write a valid message", MsgBoxStyle.Exclamation, "Invalid Messsage")
            Exit Sub
        End If
        sendmessages()
    End Sub

    Public Sub sendmessages()
        Try
            con = New MySqlConnection(conn)
            Dim insert As String = "INSERT INTO tbl_pm (username,fromuser,Message,isread) VALUES('" & frdusrname & "', '" & My.Settings.Username & "','" & DateTimePicker1.Value.ToString("D") + ":  " + TextBox1.Text & "','" & "Unread" & "')"
            executequery(insert)
            MessageBox.Show("send already")
            TextBox1.Clear()
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try

    End Sub

    Private Sub pmform_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Me.Text += ": " + frdusrname
        formskin()
    End Sub

    Private Sub formskin()
        Dim sknmngr As MaterialSkinManager = MaterialSkinManager.Instance
        sknmngr.AddFormToManage(Me)
        sknmngr.Theme = MaterialSkinManager.Themes.LIGHT
        SkinManager.ColorScheme = New ColorScheme(Primary.Blue700, Primary.Blue700, Primary.Green700, Accent.Green700, TextShade.WHITE)
    End Sub


End Class