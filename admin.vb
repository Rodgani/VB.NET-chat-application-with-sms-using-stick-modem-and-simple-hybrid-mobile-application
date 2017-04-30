Imports MySql.Data.MySqlClient
Public Class admin

    Private Sub logout()
        Try


            con = New MySqlConnection(conn)
            Dim update As String = "Update employee_account SET logout = '" & Login.DateTimePicker1.Value & "',Status='" & "Offline" & "' WHERE  username= '" & My.Settings.Username & " '"
            executequery(update)
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub
    Private Sub PictureBox2_Click(sender As Object, e As EventArgs) Handles PictureBox2.Click
        Dim log = MsgBox("Are you sure want to Sign Out?", MessageBoxButtons.YesNo, MessageBoxIcon.Information)
        If log = MsgBoxResult.Yes Then
            MaterialTabControl1.SelectTab(0)
            logout()
            TextBox1.Clear()
            TextBox2.Clear()
            TextBox3.Clear()
            TextBox4.Clear()
            MetroComboBox1.ResetText()
            MetroComboBox2.ResetText()
            TextBox6.Clear()
            Textbox7.ResetText()
            Login.Show()
            Me.Close()
            con.Close()

        End If
        If log = MsgBoxResult.No Then
            log = MsgBoxResult.Abort
        End If

    End Sub



    Private Sub BunifuFlatButton1_Click(sender As Object, e As EventArgs) Handles BunifuFlatButton1.Click
        MaterialTabControl1.SelectTab(0)
        If BunifuFlatButton1.Activecolor = Color.FromArgb(213, 219, 219) Then
            BunifuFlatButton1.Textcolor = Color.FromArgb(17, 122, 101)
            BunifuFlatButton2.Textcolor = Color.White
            BunifuFlatButton3.Textcolor = Color.White
            BunifuFlatButton4.Textcolor = Color.White

            BunifuFlatButton6.Textcolor = Color.White
            BunifuFlatButton7.Textcolor = Color.White
            BunifuFlatButton9.Textcolor = Color.White
            BunifuFlatButton8.Textcolor = Color.White
            BunifuFlatButton14.Textcolor = Color.White
            BunifuFlatButton13.Textcolor = Color.White
            Panel4.Visible = True
            Panel5.Visible = False
            Panel6.Visible = False
            Panel7.Visible = False

            Panel9.Visible = False
            Panel12.Visible = False
            Panel11.Visible = False
            Panel22.Visible = False

            Panel23.Visible = False

        End If


    End Sub

    Private Sub BunifuFlatButton2_Click(sender As Object, e As EventArgs) Handles BunifuFlatButton2.Click
        MaterialTabControl1.SelectTab(2)
        readfriends()
        grids()
        If BunifuFlatButton2.Activecolor = Color.FromArgb(213, 219, 219) Then
            BunifuFlatButton2.Textcolor = Color.FromArgb(17, 122, 101)
            BunifuFlatButton1.Textcolor = Color.White
            BunifuFlatButton3.Textcolor = Color.White
            BunifuFlatButton4.Textcolor = Color.White

            BunifuFlatButton6.Textcolor = Color.White
            BunifuFlatButton7.Textcolor = Color.White
            BunifuFlatButton9.Textcolor = Color.White
            BunifuFlatButton8.Textcolor = Color.White
            BunifuFlatButton14.Textcolor = Color.White
            BunifuFlatButton13.Textcolor = Color.White
            Panel4.Visible = False
            Panel5.Visible = True
            Panel6.Visible = False
            Panel7.Visible = False

            Panel9.Visible = False
            Panel10.Visible = False
            Panel12.Visible = False
            Panel11.Visible = False
            Panel22.Visible = False

            Panel23.Visible = False
        End If
    End Sub

    Private Sub BunifuFlatButton3_Click(sender As Object, e As EventArgs) Handles BunifuFlatButton3.Click

        messagemosiya()
        MaterialTabControl1.SelectTab(3)
        If BunifuFlatButton3.Activecolor = Color.FromArgb(213, 219, 219) Then
            BunifuFlatButton3.Textcolor = Color.FromArgb(17, 122, 101)
            BunifuFlatButton2.Textcolor = Color.White
            BunifuFlatButton1.Textcolor = Color.White
            BunifuFlatButton4.Textcolor = Color.White

            BunifuFlatButton6.Textcolor = Color.White
            BunifuFlatButton7.Textcolor = Color.White
            BunifuFlatButton9.Textcolor = Color.White
            BunifuFlatButton8.Textcolor = Color.White
            BunifuFlatButton14.Textcolor = Color.White
            BunifuFlatButton13.Textcolor = Color.White
            Panel4.Visible = False
            Panel5.Visible = False
            Panel6.Visible = True
            Panel7.Visible = False

            Panel9.Visible = False
            Panel10.Visible = False
            Panel12.Visible = False
            Panel11.Visible = False
            Panel22.Visible = False

            Panel23.Visible = False
        End If
    End Sub

    Private Sub BunifuFlatButton4_Click(sender As Object, e As EventArgs) Handles BunifuFlatButton4.Click
        lster()
        MaterialTabControl1.SelectTab(5)
        If BunifuFlatButton4.Activecolor = Color.FromArgb(213, 219, 219) Then
            BunifuFlatButton4.Textcolor = Color.FromArgb(17, 122, 101)
            BunifuFlatButton2.Textcolor = Color.White
            BunifuFlatButton3.Textcolor = Color.White
            BunifuFlatButton1.Textcolor = Color.White

            BunifuFlatButton6.Textcolor = Color.White
            BunifuFlatButton7.Textcolor = Color.White
            BunifuFlatButton9.Textcolor = Color.White
            BunifuFlatButton8.Textcolor = Color.White
            BunifuFlatButton14.Textcolor = Color.White
            BunifuFlatButton13.Textcolor = Color.White
            Panel4.Visible = False
            Panel5.Visible = False
            Panel6.Visible = False
            Panel7.Visible = True

            Panel9.Visible = False
            Panel10.Visible = False
            Panel12.Visible = False
            Panel11.Visible = False
            Panel22.Visible = False

            Panel23.Visible = False
        End If
    End Sub

   


    Private Sub BunifuFlatButton6_Click(sender As Object, e As EventArgs) Handles BunifuFlatButton6.Click
        editpro()
        MaterialFlatButton4.Visible = False
        Label34.Visible = False
        Label39.Visible = False
        MaterialSingleLineTextField6.Visible = False
        MaterialSingleLineTextField7.Visible = False
        MetroComboBox5.Visible = False
        Label40.Visible = False
        MaterialFlatButton5.Visible = False
        MaterialTabControl1.SelectTab(7)
        one.Visible = False
        two.Visible = False
        three.Visible = False
        four.Visible = False
        five.Visible = False
        sv.Visible = False
        emid.Visible = False
        usrnme.Visible = False
        odp.Visible = False
        newpass.Visible = False
        retype.Visible = False
        MetroComboBox3.Visible = False
        If BunifuFlatButton6.Activecolor = Color.FromArgb(213, 219, 219) Then
            BunifuFlatButton6.Textcolor = Color.FromArgb(17, 122, 101)
            BunifuFlatButton2.Textcolor = Color.White
            BunifuFlatButton3.Textcolor = Color.White
            BunifuFlatButton4.Textcolor = Color.White

            BunifuFlatButton1.Textcolor = Color.White
            BunifuFlatButton7.Textcolor = Color.White
            BunifuFlatButton9.Textcolor = Color.White
            BunifuFlatButton8.Textcolor = Color.White
            BunifuFlatButton14.Textcolor = Color.White
            BunifuFlatButton13.Textcolor = Color.White
            Panel4.Visible = False
            Panel5.Visible = False
            Panel6.Visible = False
            Panel7.Visible = False

            Panel9.Visible = True
            Panel10.Visible = False
            Panel12.Visible = False
            Panel11.Visible = False
            Panel22.Visible = False

            Panel23.Visible = False
        End If
    End Sub


    Private Sub BunifuFlatButton7_Click(sender As Object, e As EventArgs) Handles BunifuFlatButton7.Click
        SMS.Show()
        If BunifuFlatButton7.Activecolor = Color.FromArgb(213, 219, 219) Then
            BunifuFlatButton7.Textcolor = Color.FromArgb(17, 122, 101)
            BunifuFlatButton2.Textcolor = Color.White
            BunifuFlatButton3.Textcolor = Color.White
            BunifuFlatButton4.Textcolor = Color.White

            BunifuFlatButton1.Textcolor = Color.White
            BunifuFlatButton6.Textcolor = Color.White
            BunifuFlatButton9.Textcolor = Color.White
            BunifuFlatButton8.Textcolor = Color.White
            BunifuFlatButton14.Textcolor = Color.White
            BunifuFlatButton13.Textcolor = Color.White
            Panel4.Visible = False
            Panel5.Visible = False
            Panel6.Visible = False
            Panel7.Visible = False

            Panel9.Visible = False
            Panel10.Visible = True
            Panel12.Visible = False
            Panel11.Visible = False
            Panel22.Visible = False

            Panel23.Visible = False
        End If
    End Sub

    Private Sub BunifuFlatButton9_Click(sender As Object, e As EventArgs) Handles BunifuFlatButton9.Click
        dmsg()
        MaterialTabControl1.SelectTab(4)
        If BunifuFlatButton9.Activecolor = Color.FromArgb(213, 219, 219) Then
            BunifuFlatButton9.Textcolor = Color.FromArgb(17, 122, 101)
            BunifuFlatButton2.Textcolor = Color.White
            BunifuFlatButton3.Textcolor = Color.White
            BunifuFlatButton4.Textcolor = Color.White

            BunifuFlatButton1.Textcolor = Color.White
            BunifuFlatButton6.Textcolor = Color.White
            BunifuFlatButton8.Textcolor = Color.White
            BunifuFlatButton14.Textcolor = Color.White
            BunifuFlatButton13.Textcolor = Color.White
            Panel4.Visible = False
            Panel5.Visible = False
            Panel6.Visible = False
            Panel7.Visible = False

            Panel9.Visible = False
            Panel10.Visible = False
            Panel12.Visible = True
            Panel11.Visible = False
            Panel22.Visible = False

            Panel23.Visible = False
        End If
    End Sub

    Private Sub BunifuFlatButton8_Click(sender As Object, e As EventArgs) Handles BunifuFlatButton8.Click
        auto()
        MaterialTabControl1.SelectTab(6)
        If BunifuFlatButton8.Activecolor = Color.FromArgb(213, 219, 219) Then
            BunifuFlatButton8.Textcolor = Color.FromArgb(17, 122, 101)
            BunifuFlatButton2.Textcolor = Color.White
            BunifuFlatButton3.Textcolor = Color.White
            BunifuFlatButton4.Textcolor = Color.White

            BunifuFlatButton1.Textcolor = Color.White
            BunifuFlatButton6.Textcolor = Color.White
            BunifuFlatButton9.Textcolor = Color.White
            BunifuFlatButton14.Textcolor = Color.White
            BunifuFlatButton13.Textcolor = Color.White
            Panel4.Visible = False
            Panel5.Visible = False
            Panel6.Visible = False
            Panel7.Visible = False

            Panel9.Visible = False
            Panel10.Visible = False
            Panel12.Visible = False
            Panel11.Visible = True
            Panel22.Visible = False

            Panel23.Visible = False
        End If
    End Sub

    Private Sub BunifuFlatButton14_Click(sender As Object, e As EventArgs) Handles BunifuFlatButton14.Click

        If BunifuFlatButton14.Activecolor = Color.FromArgb(213, 219, 219) Then
            BunifuFlatButton14.Textcolor = Color.FromArgb(17, 122, 101)
            BunifuFlatButton2.Textcolor = Color.White
            BunifuFlatButton3.Textcolor = Color.White
            BunifuFlatButton4.Textcolor = Color.White

            BunifuFlatButton1.Textcolor = Color.White
            BunifuFlatButton6.Textcolor = Color.White
            BunifuFlatButton9.Textcolor = Color.White
            BunifuFlatButton8.Textcolor = Color.White
            BunifuFlatButton13.Textcolor = Color.White
            Panel4.Visible = False
            Panel5.Visible = False
            Panel6.Visible = False
            Panel7.Visible = False

            Panel9.Visible = False
            Panel10.Visible = False
            Panel12.Visible = False
            Panel11.Visible = False
            Panel22.Visible = True

            Panel10.Visible = False
            Panel23.Visible = False

        End If

        googlemap.Show()

    End Sub

    Private Sub BunifuFlatButton13_Click(sender As Object, e As EventArgs) Handles BunifuFlatButton13.Click
        MaterialTabControl1.SelectTab(10)
        If BunifuFlatButton13.Activecolor = Color.FromArgb(213, 219, 219) Then
            BunifuFlatButton13.Textcolor = Color.FromArgb(17, 122, 101)
            BunifuFlatButton2.Textcolor = Color.White
            BunifuFlatButton3.Textcolor = Color.White
            BunifuFlatButton4.Textcolor = Color.White

            BunifuFlatButton1.Textcolor = Color.White
            BunifuFlatButton6.Textcolor = Color.White
            BunifuFlatButton9.Textcolor = Color.White
            BunifuFlatButton8.Textcolor = Color.White
            BunifuFlatButton14.Textcolor = Color.White
            Panel4.Visible = False
            Panel5.Visible = False
            Panel6.Visible = False
            Panel7.Visible = False

            Panel9.Visible = False
            Panel10.Visible = False
            Panel12.Visible = False
            Panel11.Visible = False
            Panel22.Visible = False

            Panel10.Visible = False
            Panel23.Visible = True

        End If

    End Sub

    Public Sub dtcrt()
        Try
            con = New MySqlConnection(conn)
            Dim fd As String = "insert into employee_account(Employee_ID,username,password,accesslevel,datecreated,dp)values('" & TextBox1.Text & "','" & TextBox6.Text & "','" & TextBox7.Text & "','" & MetroComboBox2.SelectedItem & "','" & DateTimePicker1.Value & "','" & My.Settings.displaypic & "')"
            executequery(fd)

        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub
    Public Sub sve()
        Try
            con = New MySqlConnection(conn)
            If TextBox2.Text <> "" And TextBox3.Text <> "" And TextBox4.Text <> "" And MetroComboBox1.Text <> "" And TextBox6.Text <> "" And TextBox7.Text <> "" And MetroComboBox2.Text <> "" Then
                Dim emsert As String = "insert into employee(Employee_ID,Lastname,Firstname,Middlename,Department)values('" & TextBox1.Text & "','" & TextBox2.Text & "','" & TextBox3.Text & "','" & TextBox4.Text & "','" & MetroComboBox1.SelectedItem & "')"
                executequery(emsert)
                dtcrt()
                MessageBox.Show("Save")
                TextBox1.Clear()
                TextBox2.Clear()
                TextBox3.Clear()
                TextBox4.Clear()
                MetroComboBox1.ResetText()
                MetroComboBox2.ResetText()
                TextBox6.Clear()
                Textbox7.ResetText()
            Else
                MessageBox.Show("Fill Up All Fields")
            End If
          

        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub
    Dim id As String = "Emp-"
    Dim C As Integer = 1
    Public Sub auto()
        Try
            con = New MySqlConnection(conn)
            con.Open()
            comm = New MySqlCommand("select count(Employee_ID) FROM employee_account ", con)
            reader = comm.ExecuteReader

            While reader.Read
                TextBox1.Text = id
                TextBox1.Text += CStr(reader.Item(0) + C)
            End While
        Catch ex As Exception
            MessageBox.Show("Welcome")
        End Try
    End Sub
    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        sve()
        PictureBox3.ResetText()
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
    Private Sub admin_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Timer1.Start()
        Dim mems As System.IO.MemoryStream = New System.IO.MemoryStream(Convert.FromBase64String(My.Settings.displaypic))
        adminpic.Image = Drawing.Image.FromStream(mems)
        PictureBox1.Image = Drawing.Image.FromStream(mems)
        auto()
        readfriends()
        grids()
        dmsg()
        lstem()
        messagemosiya()
        editpro()
        details()
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

    Private Sub ListBox1_SelectedIndexChanged(sender As Object, e As EventArgs) Handles ListBox1.SelectedIndexChanged
        If Not ListBox1.SelectedIndex = -1 Then
            Dim pm As New pmform
            frdusrname = ListBox1.SelectedItem.ToString
            pm.ShowDialog()
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


    Private Sub Timer1_Tick(sender As Object, e As EventArgs) Handles Timer1.Tick
        Label29.Text = Now.Second
        If Label29.Text = "30" Then
            readfriends()
            messagemosiya()
            dmsg()
            lster()
            details()
        End If
        If Label29.Text = "50" Then
            readfriends()
            messagemosiya()
            dmsg()
            lster()
            details()
        End If
        If Label29.Text = "10" Then
            readfriends()
            messagemosiya()
            dmsg()
            lster()
            details()
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
        Label35.Text = DateAndTime.TimeOfDay
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


    Private Sub MaterialFlatButton1_Click(sender As Object, e As EventArgs) Handles MaterialFlatButton1.Click
        archive()
    End Sub

    Public Function msgs() As DataTable
        Dim arc As New DataTable
        Try
            con = New MySqlConnection(conn)
            con.Open()
            comm = New MySqlCommand("select idarchivemessages, username,Message,date FROM archivemessages", con)
            reader = comm.ExecuteReader
            arc.Load(reader)
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
        Return arc
    End Function

    Public Sub dmsg()
        DataGridView1.DataSource = msgs()
    End Sub

    Public Function lstem() As DataTable
        Dim tem As New DataTable
        Try
            con = New MySqlConnection(conn)
            con.Open()
            comm = New MySqlCommand("select Employee_ID,username,accesslevel,Lastname,Firstname,Middlename,Gender,Age,Address,Department FROM lstemployee", con)
            reader = comm.ExecuteReader
            tem.Load(reader)
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
        Return tem

    End Function

    Public Sub lster()
        DataGridView2.DataSource = lstem()
    End Sub

    Private Sub Panel17_Click(sender As Object, e As EventArgs) Handles Panel17.Click
        one.Visible = True
        two.Visible = True
        three.Visible = True
        four.Visible = True
        five.Visible = True
        sv.Visible = True
        emid.Visible = True
        usrnme.Visible = True
        odp.Visible = True
        newpass.Visible = True
        retype.Visible = True

        MetroComboBox3.Visible = False
        MaterialFlatButton4.Visible = False
        Label34.Visible = False
        Label39.Visible = False
        MaterialSingleLineTextField6.Visible = False
        MaterialSingleLineTextField7.Visible = False
        MetroComboBox5.Visible = False
        Label40.Visible = False
        MaterialFlatButton5.Visible = False
    End Sub

    Private Sub Panel18_Click(sender As Object, e As EventArgs) Handles Panel18.Click
        MetroComboBox3.Visible = True
        MaterialFlatButton4.Visible = True
        Label34.Visible = True
        Label39.Visible = True
        MaterialSingleLineTextField6.Visible = True
        MaterialSingleLineTextField7.Visible = True
        MetroComboBox5.Visible = True
        Label40.Visible = True
        MaterialFlatButton5.Visible = True


        one.Visible = False
        two.Visible = False
        three.Visible = False
        four.Visible = False
        five.Visible = False
        sv.Visible = False
        emid.Visible = False
        usrnme.Visible = False
        odp.Visible = False
        newpass.Visible = False
        retype.Visible = False
    End Sub

    Public Sub search()
        Try
            con = New MySqlConnection(conn)
            con.Open()
            comm = New MySqlCommand("select * from employee_account where Employee_ID='" & emid.Text & "'", con)
            reader = comm.ExecuteReader
            While reader.Read
                usrnme.Text = reader(2).ToString
                odp.Text = reader(3).ToString
              
            End While

        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub
    Public Sub changepass()
        Try
            con = New MySqlConnection(conn)
            con.Open()
            comm = New MySqlCommand("select * from employee_account where password ='" & odp.Text & "'", con)
            reader = comm.ExecuteReader
            While reader.Read
                If reader(3).ToString = odp.Text And newpass.Text = retype.Text And usrnme.Text <> "" And odp.Text <> "" And newpass.Text <> "" And retype.Text <> "" Then
                    con = New MySqlConnection(conn)
                    Dim changepassword As String = "update employee_account set password='" & retype.Text & "' where username='" & usrnme.Text & "'"
                    executequery(changepassword)
                    MessageBox.Show("Password was Changed")
                    usrnme.Clear()
                    odp.Clear()
                    newpass.Clear()
                    retype.Clear()
                Else
                    MessageBox.Show("Fill the corresponding details")
                End If
            End While


        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub
    Private Sub sv_Click(sender As Object, e As EventArgs) Handles sv.Click
        changepass()
        usrnme.Clear()
        odp.Clear()
        newpass.Clear()
        retype.Clear()
    End Sub

    Private Sub one_Click(sender As Object, e As EventArgs) Handles one.Click
        search()
    End Sub

    Public Sub searchs()
        Try
            con = New MySqlConnection(conn)
            con.Open()
            comm = New MySqlCommand("select * from employee_account where Employee_ID='" & MaterialSingleLineTextField6.Text & "'", con)
            reader = comm.ExecuteReader
            While reader.Read
                MaterialSingleLineTextField7.Text = reader(2).ToString
                MetroComboBox3.PromptText = reader(4).ToString
                searchss()
            End While

        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub
    Public Sub searchss()
        Try
            con = New MySqlConnection(conn)
            con.Open()
            comm = New MySqlCommand("select * from employee where Employee_ID='" & MaterialSingleLineTextField6.Text & "'", con)
            reader = comm.ExecuteReader
            While reader.Read
                MetroComboBox5.PromptText = reader(6).ToString
            End While

        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub
    Private Sub MaterialFlatButton4_Click(sender As Object, e As EventArgs) Handles MaterialFlatButton4.Click
        searchs()
    End Sub
    Public Sub depup()
        Try

            con = New MySqlConnection(conn)
            Dim ADA As String = "update employee set Department='" & MetroComboBox5.SelectedItem & "' where Employee_ID ='" & MaterialSingleLineTextField6.Text & "'"
            executequery(ADA)
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub
    Public Sub statusupdate()
        Try
            depup()
            con = New MySqlConnection(conn)
            If MaterialSingleLineTextField7.Text <> "" And MetroComboBox5.Text <> "" And MetroComboBox3.Text <> "" Then
                Dim updt As String = "update employee_account set accesslevel='" & MetroComboBox3.SelectedItem & "' where Employee_ID ='" & MaterialSingleLineTextField6.Text & "'"
                executequery(updt)
                MessageBox.Show("Save")
                MaterialSingleLineTextField6.Clear()
                MaterialSingleLineTextField7.Clear()
                MetroComboBox5.ResetText()
                MetroComboBox3.ResetText()
            Else

            End If

        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub

    Private Sub MaterialFlatButton5_Click(sender As Object, e As EventArgs) Handles MaterialFlatButton5.Click
        statusupdate()
    End Sub

   
    Private Sub MaterialRaisedButton1_Click(sender As Object, e As EventArgs) Handles MaterialRaisedButton1.Click
        If BunifuCustomTextbox1.Text <> "" Then
            Try
                con = New MySqlConnection(conn)
                con.Open()
                RichTextBox2.Text += vbNewLine & vbNewLine & DateTimePicker1.Value.ToString("D") & " " & Label35.Text & vbNewLine & My.Settings.Username & ": " & BunifuCustomTextbox1.Text
                comm = New MySqlCommand("UPDATE announcement SET announcementmsg='" & RichTextBox2.Text & "'", con)
                reader = comm.ExecuteReader
                BunifuCustomTextbox1.Clear()
            Catch ex As Exception
                MsgBox(ex.Message)
            End Try
        Else
            MessageBox.Show("Fill the textfiled")
        End If
       
    End Sub

    Private Sub RichTextBox2_TextChanged(sender As Object, e As EventArgs) Handles RichTextBox2.TextChanged
        RichTextBox2.SelectionStart() = RichTextBox2.TextLength
        RichTextBox2.ScrollToCaret()
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
            Dim insert As String = "INSERT INTO tbl_pm (username,fromuser,Message,isread) VALUES('" & frdusrname & "', '" & My.Settings.Username & "','" & DateTimePicker1.Value.ToString("D") + "/" & Label35.Text & ": " + RichTextBox1.Text & "','" & "Unread" & "')"
            executequery(insert)
            MessageBox.Show("Send")
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try

    End Sub

    Public Sub ed()
        If imgchoose.ShowDialog = vbOK Then
            Try
                My.Settings.displaypic = imgtobytes(imgchoose.FileName)
                My.Settings.Save()
               
                MsgBox("You change your profile picture")
                Dim mems As System.IO.MemoryStream = New System.IO.MemoryStream(Convert.FromBase64String(My.Settings.displaypic))
                PictureBox3.Image = Drawing.Image.FromStream(mems)

            Catch ex As Exception
                If ex.Message.Contains("Packets larger") Then
                    MsgBox("Piture dimensions are too large to store in database. Please use picture of lower dimensions like 640x480.", MsgBoxStyle.Critical, "Invalid Picture Dimensions")
                Else
                    MsgBox(ex.Message, MsgBoxStyle.Critical, "Data Error")
                End If

            End Try

        End If
    End Sub
   
    Private Sub PictureBox3_Click(sender As Object, e As EventArgs) Handles PictureBox3.Click
        ed()
    End Sub

    Public Sub editpros()
        Try
            con = New MySqlConnection(conn)
            con.Open()
            comm = New MySqlCommand("select * from employee_account where Employee_ID='" & Login.Label5.Text & "'", con)
            reader = comm.ExecuteReader

            While reader.Read
                Label36.Text = reader(4).ToString
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
                Label38.Text = reader(1).ToString
                TextBox12.Text = reader(2).ToString
                TextBox11.Text = reader(3).ToString
                TextBox10.Text = reader(4).ToString
                Label37.Text = reader(6).ToString
                TextBox5.Text = reader(7).ToString
                MetroComboBox4.Text = reader(5).ToString
                TextBox8.Text = reader(8).ToString
                TextBox9.Text = reader(9).ToString
                Label65.Text = reader(2).ToString
                Label63.Text = reader(3).ToString
                Label61.Text = reader(4).ToString
            End While
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub

    Private Sub BunifuFlatButton10_Click(sender As Object, e As EventArgs) Handles BunifuFlatButton10.Click
        editpro()
        MaterialTabControl1.SelectTab(8)
    End Sub
    Public Sub UP()
        Try
            con = New MySqlConnection(conn)
            Dim updt As String = "update employee set Lastname='" & TextBox12.Text & "',Firstname='" & TextBox11.Text & "',Middlename='" & TextBox10.Text & "',Age='" & TextBox5.Text & "',Gender='" & MetroComboBox4.SelectedItem & "',CellphoneNumber='" & TextBox8.Text & "',Address='" & TextBox9.Text & "' "
            executequery(updt)
            MessageBox.Show("Information Updated")
        Catch ex As Exception
            MessageBox.Show("No Changes")
        End Try

    End Sub

    Private Sub BunifuFlatButton12_Click(sender As Object, e As EventArgs) Handles BunifuFlatButton12.Click
        UP()

    End Sub

    Private Sub BunifuFlatButton11_Click(sender As Object, e As EventArgs) Handles BunifuFlatButton11.Click
        Dim log = MsgBox("Are you sure want to Cancel?", MessageBoxButtons.YesNo, MessageBoxIcon.Information)
        MaterialTabControl1.SelectTab(6)
        If log = MsgBoxResult.Yes Then
            TextBox1.ResetText()
            TextBox2.ResetText()
            TextBox3.Clear()
            TextBox4.Clear()
            TextBox5.Clear()
            TextBox6.ResetText()
            Textbox7.ResetText()
            MetroComboBox1.ResetText()
            TextBox9.Clear()
            TextBox8.Clear()

        End If
        If log = MsgBoxResult.No Then
            log = MsgBoxResult.Abort
        End If
    End Sub

    Private Sub hey_Click(sender As Object, e As EventArgs) Handles adminpic.Click
        image_dp.Show()
    End Sub

    Public Function emdt() As DataTable
        Dim emdts As New DataTable
        Try
            con = New MySqlConnection(conn)
            con.Open()
            comm = New MySqlCommand("select Employee_ID,Lastname,Firstname,Middlename,Department,Employee_location,Purpose,date from employee_location", con)
            reader = comm.ExecuteReader
            emdts.Load(reader)
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
        Return emdts
    End Function

    Public Sub details()
        DataGridView3.DataSource = emdt()
    End Sub

    

    Private Sub TextBox13_TextChanged(sender As Object, e As EventArgs) Handles TextBox13.TextChanged
        Try
            Dim dv As New DataView(emdt)
            dv.RowFilter = String.Format("Lastname like '%{0}%'", TextBox13.Text)
            DataGridView3.DataSource = dv
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub

   

End Class