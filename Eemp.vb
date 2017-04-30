Imports MySql.Data.MySqlClient
Public Class Eemp
    Private Sub logout()
        Try


            con = New MySqlConnection(conn)
            Dim update As String = "Update employee_account SET logout = '" & DateTimePicker1.Value & "',Status='" & "Offline" & "' WHERE  username= '" & My.Settings.Username & " '"
            executequery(update)
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub

    Private Sub PictureBox2_Click(sender As Object, e As EventArgs) Handles PictureBox2.Click
        Dim go = MsgBox("Are you Going to somewhere?", MessageBoxButtons.YesNo, MessageBoxIcon.Information)
        If go = MsgBoxResult.Yes Then
            WHERE_TO_GO.Show()
        End If
        If go = MsgBoxResult.No Then
            Dim log = MsgBox("Are you sure want to Sign Out?", MessageBoxButtons.YesNo, MessageBoxIcon.Information)
            If log = MsgBoxResult.Yes Then
                logout()
                Login.Show()
                Me.Close()
                con.Close()
            End If
            If log = MsgBoxResult.No Then
                log = MsgBoxResult.Abort
            End If
        End If
    End Sub



    Private Sub BunifuFlatButton1_Click(sender As Object, e As EventArgs) Handles BunifuFlatButton1.Click
        MaterialTabControl1.SelectTab(0)
        If BunifuFlatButton1.Activecolor = Color.FromArgb(213, 219, 219) Then
            BunifuFlatButton1.Textcolor = Color.FromArgb(17, 122, 101)
            BunifuFlatButton2.Textcolor = Color.White
            BunifuFlatButton3.Textcolor = Color.White
            BunifuFlatButton6.Textcolor = Color.White

            Panel4.Visible = True
            Panel5.Visible = False
            Panel6.Visible = False
            Panel9.Visible = False


        End If


    End Sub



    Private Sub BunifuFlatButton3_Click(sender As Object, e As EventArgs) Handles BunifuFlatButton3.Click
        MaterialTabControl1.SelectTab(2)
        If BunifuFlatButton3.Activecolor = Color.FromArgb(213, 219, 219) Then
            BunifuFlatButton3.Textcolor = Color.FromArgb(17, 122, 101)
            BunifuFlatButton2.Textcolor = Color.White
            BunifuFlatButton1.Textcolor = Color.White
            BunifuFlatButton6.Textcolor = Color.White
            Panel4.Visible = False
            Panel5.Visible = False
            Panel6.Visible = True
            Panel9.Visible = False
        End If
    End Sub


    Private Sub BunifuFlatButton6_Click(sender As Object, e As EventArgs) Handles BunifuFlatButton6.Click
        editpro()
        MaterialTabControl1.SelectTab(3)
        If BunifuFlatButton6.Activecolor = Color.FromArgb(213, 219, 219) Then
            BunifuFlatButton6.Textcolor = Color.FromArgb(17, 122, 101)
            BunifuFlatButton2.Textcolor = Color.White
            BunifuFlatButton3.Textcolor = Color.White

            BunifuFlatButton1.Textcolor = Color.White

            Panel4.Visible = False
            Panel5.Visible = False
            Panel6.Visible = False

            Panel9.Visible = True

        End If
    End Sub


    Private Sub BunifuFlatButton2_Click(sender As Object, e As EventArgs) Handles BunifuFlatButton2.Click
        MaterialTabControl1.SelectTab(1)
        If BunifuFlatButton2.Activecolor = Color.FromArgb(213, 219, 219) Then
            BunifuFlatButton2.Textcolor = Color.FromArgb(17, 122, 101)
            BunifuFlatButton6.Textcolor = Color.White
            BunifuFlatButton3.Textcolor = Color.White
            BunifuFlatButton1.Textcolor = Color.White
            Panel4.Visible = False
            Panel5.Visible = True
            Panel6.Visible = False
            Panel9.Visible = False

        End If
    End Sub

    Private Sub Panel2_Paint(sender As Object, e As PaintEventArgs) Handles Panel2.Paint

    End Sub

    Private Sub BunifuThinButton21_Click(sender As Object, e As EventArgs) Handles BunifuThinButton21.Click
        Panel14.Visible = True
        editpro()
    End Sub

    Private Sub BunifuImageButton4_Click(sender As Object, e As EventArgs)
        Dim log = MsgBox("Are you sure want to Cancel?", MessageBoxButtons.YesNo, MessageBoxIcon.Information)

        If log = MsgBoxResult.Yes Then
            Panel14.Hide()
            TextBox1.Text = ""
            TextBox2.Text = ""
            TextBox3.Text = ""
            TextBox4.Text = ""
            TextBox5.Text = ""
        End If
        If log = MsgBoxResult.No Then
            log = MsgBoxResult.Abort
        End If

    End Sub

    Private Sub Button3_Click(sender As Object, e As EventArgs) Handles Button3.Click
        If RichTextBox1.Text = String.Empty Then
            MsgBox("Please write a valid message", MsgBoxStyle.Exclamation, "Invalid Messsage")
            Exit Sub
        End If
        sendmessage()
        RichTextBox1.Clear()
        RichTextBox1.Visible = False
        Button3.Visible = False
    End Sub
    Public Sub sendmessage()
        Try
            con = New MySqlConnection(conn)
            Dim insert As String = "INSERT INTO tbl_pm (username,fromuser,Message,isread) VALUES('" & frdusrname & "', '" & My.Settings.Username & "','" & Login.DateTimePicker1.Value.ToString("D") + "/" & Label31.Text & ": " + RichTextBox1.Text & "','" & "Unread" & "')"
            executequery(insert)
            MessageBox.Show("Send")
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try

    End Sub

    Private Sub Timer1_Tick(sender As Object, e As EventArgs) Handles Timer1.Tick
        WHERE_TO_GO.Label4.Text = Date.Now
        Label31.Text = DateAndTime.TimeOfDay
        Label32.Text = Now.Second
        If Label32.Text = "30" Then
            messagemosiya()
            grids()
            readfriends()
        End If
        If Label32.Text = "50" Then
            messagemosiya()
            grids()
            readfriends()
        End If
        If Label32.Text = "10" Then
            messagemosiya()
            grids()
            readfriends()
        End If
        Try
            con = New MySqlConnection(conn)
            con.Open()
            comm = New MySqlCommand("SELECT announcementmsg FROM announcement", con)
            reader = comm.ExecuteReader
            While reader.Read()
                If Not reader(0).ToString = RichTextBox2.Text Then
                    RichTextBox2.Text = reader(0).ToString
                End If
            End While
            reader.Close()
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub


    Public Sub archive()
        Try
            If Not ListView2.FocusedItem.Index = -1 Then
                con = New MySqlConnection(conn)
                Dim sert As String = "insert into archivemessages(username,message,date)values('" & My.Settings.Username & "','" & ListView2.FocusedItem.SubItems(1).Text & "','" & DateTimePicker1.Value & "')"
                executequery(sert)
                bura()
                MessageBox.Show("Deleted")
            End If
        Catch ex As Exception

        End Try

    End Sub
    Public Sub bura()
        If Not ListView2.FocusedItem.Index = -1 Then
            con = New MySqlConnection(conn)
            con.Open()
            comm = New MySqlCommand("DELETE FROM tbl_pm WHERE message='" & ListView2.FocusedItem.SubItems(1).Text & "' AND username='" & My.Settings.Username & "'", con)
            comm.ExecuteNonQuery()
            ListView2.FocusedItem.Remove()
        End If
    End Sub
    Public Sub messagemosiya()
        Try
            con = New MySqlConnection(conn)
            con.Open()

            comm = New MySqlCommand("SELECT * FROM tbl_pm WHERE Username='" & My.Settings.Username & "'", con)
            reader = comm.ExecuteReader
            ListView2.Items.Clear()
            Dim index As Integer = 0
            While reader.Read()
                lst = ListView2.Items.Add(reader(2).ToString)
                lst.SubItems.Add(reader(3).ToString)
                lst.SubItems.Add(reader(4).ToString)
                If reader(4).ToString = "Unread" Then
                    notifmessage.Show()
                    ListView2.Items.Item(index).Font = New Font(ListView2.Font.FontFamily, ListView2.Font.Size, FontStyle.Bold)
                End If
                msg(index) = reader(3).ToString
                index += 1
            End While
            reader.Close()
            con.Close()
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub

    Private Sub ListView2_MouseClick(sender As Object, e As MouseEventArgs) Handles ListView2.MouseClick
        If e.Button = Windows.Forms.MouseButtons.Left Then
            If Not ListView2.FocusedItem.Index = -1 Then
                con = New MySqlConnection(conn)
                con.Open()
                comm = New MySqlCommand("UPDATE tbl_pm SET isread='Read' WHERE Message='" & ListView2.FocusedItem.SubItems(1).Text & "'", con)
                reader = comm.ExecuteReader
                Dim reply = MsgBox("From: " & ListView2.FocusedItem.Text & vbNewLine & vbNewLine & "Messages: " & ListView2.FocusedItem.SubItems(1).Text & vbNewLine & vbNewLine & "To: " & My.Settings.Username & vbNewLine & vbNewLine & "Do you want to reply?", MsgBoxStyle.YesNo, "Private Message")
                ' Dim reply = MsgBox(vbNewLine & "Do you want to reply?", MsgBoxStyle.YesNo, "Private Message")
                If reply = vbYes Then
                    'Dim pmform As New pmform
                    message = ListView2.FocusedItem.SubItems(1).Text
                    frdusrname = ListView2.FocusedItem.Text
                    'pmform.ShowDialog()
                    RichTextBox1.Visible = True
                    Button3.Visible = True
                    'RichTextBox1.Text = ListView2.FocusedItem.Text & vbNewLine & vbNewLine & ListView2.FocusedItem.SubItems(1).Text & vbNewLine & vbNewLine & My.Settings.Username & vbNewLine
                Else
                    comm = New MySqlCommand("UPDATE tbl_pm SET isread='Unread' WHERE Message='" & ListView2.FocusedItem.SubItems(1).Text & "'", con)
                End If
            End If

        End If
    End Sub


    Private Sub ListBox1_SelectedIndexChanged(sender As Object, e As EventArgs) Handles ListBox1.SelectedIndexChanged
        If Not ListBox1.SelectedIndex = -1 Then
            Dim pm As New pmform
            frdusrname = ListBox1.SelectedItem.ToString
            pm.ShowDialog()
        End If
    End Sub

    Private Sub readfriends()

        con = New MySqlConnection(conn)
        con.Open()
        comm = New MySqlCommand("SELECT * from employee_account", con)
        reader = comm.ExecuteReader
        ListBox1.Items.Clear()
        While reader.Read()
                If Not reader(2).ToString = My.Settings.Username Then
                    ListBox1.Items.Add(reader(2).ToString)
            End If
        End While
        reader.Close()
        con.Close()
    End Sub

    Private Sub Eemp_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Timer1.Start()
        Dim mems As System.IO.MemoryStream = New System.IO.MemoryStream(Convert.FromBase64String(My.Settings.displaypic))
        hey.Image = Drawing.Image.FromStream(mems)
        Ptbx1.Image = Drawing.Image.FromStream(mems)
        messagemosiya()
        readfriends()
        grids()
        editpro()
    End Sub

    Public Sub grids()

        Try
            con = New MySqlConnection(conn)
            con.Open()
            comm = New MySqlCommand("select * from contact", con)
            reader = comm.ExecuteReader
            ListView1.Items.Clear()
            While reader.Read
                If Not reader(2).ToString = My.Settings.Username Then
                    lst = ListView1.Items.Add(reader(0).ToString)
                    lst.SubItems.Add(reader(2).ToString)
                    lst.SubItems.Add(reader(3).ToString)
                    lst.SubItems.Add(reader(4).ToString)
                    lst.SubItems.Add(reader(5).ToString)
                    lst.SubItems.Add(reader(6).ToString)
                    lst.SubItems.Add(reader(7).ToString)
                End If


            End While
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub



    Private Sub searc_TextChanged(sender As Object, e As EventArgs) Handles searc.TextChanged
        Try
            con = New MySqlConnection(conn)
            con.Open()
            comm = New MySqlCommand("select * from contact where username='" & searc.Text & "'", con)
            reader = comm.ExecuteReader
            ListView1.Items.Clear()
            While reader.Read
                If Not reader(2).ToString = My.Settings.Username Then

                    lst = ListView1.Items.Add(reader(0).ToString)
                    lst.SubItems.Add(reader(2).ToString)
                    lst.SubItems.Add(reader(3).ToString)
                    lst.SubItems.Add(reader(4).ToString)
                    lst.SubItems.Add(reader(5).ToString)
                    lst.SubItems.Add(reader(6).ToString)
                    lst.SubItems.Add(reader(7).ToString)
                End If
            End While
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
        If searc.Text = "" Then
            grids()
        End If
    End Sub

    Private Sub RichTextBox2_TextChanged(sender As Object, e As EventArgs) Handles RichTextBox2.TextChanged
        RichTextBox2.SelectionStart() = RichTextBox2.TextLength
        RichTextBox2.ScrollToCaret()
    End Sub
    Public Sub editpros()
        Try
            con = New MySqlConnection(conn)
            con.Open()
            comm = New MySqlCommand("select * from employee_account where Employee_ID='" & Login.Label5.Text & "'", con)
            reader = comm.ExecuteReader

            While reader.Read
                TextBox2.Text = reader(4).ToString
            End While
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub
    Public Sub editpro()
        editpros()
        Try
            con = New MySqlConnection(conn)
            con.Open()
            comm = New MySqlCommand("select * from employee where Employee_ID='" & Login.Label5.Text & "'", con)
            reader = comm.ExecuteReader

            While reader.Read
                TextBox1.Text = reader(1).ToString
                TextBox3.Text = reader(2).ToString
                TextBox4.Text = reader(3).ToString
                TextBox5.Text = reader(4).ToString
                TextBox6.Text = reader(6).ToString
                TextBox7.Text = reader(7).ToString
                MetroComboBox1.Text = reader(5).ToString
                TextBox8.Text = reader(8).ToString
                TextBox9.Text = reader(9).ToString
                Label20.Text = reader(2).ToString
                Label19.Text = reader(3).ToString
                Label18.Text = reader(4).ToString
            End While
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub

    Private Sub dppic_Click(sender As Object, e As EventArgs) Handles hey.Click
        image_dp.Show()
    End Sub

    Private Sub BunifuFlatButton5_Click(sender As Object, e As EventArgs) Handles BunifuFlatButton5.Click
        Dim log = MsgBox("Are you sure want to Cancel?", MessageBoxButtons.YesNo, MessageBoxIcon.Information)

        If log = MsgBoxResult.Yes Then
            Panel14.Hide()
            Textbox1.ResetText()
            Textbox2.ResetText()
            TextBox3.Clear()
            TextBox4.Clear()
            TextBox5.Clear()
            Textbox6.ResetText()
            TextBox7.Clear()
            MetroComboBox1.ResetText()
            TextBox9.Clear()
            TextBox8.Clear()

        End If
        If log = MsgBoxResult.No Then
            log = MsgBoxResult.Abort
        End If
    End Sub

    Public Sub UP()
        Try
            con = New MySqlConnection(conn)
            Dim updt As String = "update employee set Lastname='" & TextBox3.Text & "',Firstname='" & TextBox4.Text & "',Middlename='" & TextBox5.Text & "',Age='" & TextBox7.Text & "',Gender='" & MetroComboBox1.SelectedItem & "',CellphoneNumber='" & TextBox8.Text & "',Address='" & TextBox9.Text & "' "
            executequery(updt)
            MessageBox.Show("Information Updated")
        Catch ex As Exception
            MessageBox.Show("No Changes")
        End Try
       
    End Sub

    Private Sub BunifuFlatButton4_Click(sender As Object, e As EventArgs) Handles BunifuFlatButton4.Click
        UP()
    End Sub

    Private Sub MaterialFlatButton1_Click(sender As Object, e As EventArgs) Handles MaterialFlatButton1.Click
        archive()
    End Sub
End Class