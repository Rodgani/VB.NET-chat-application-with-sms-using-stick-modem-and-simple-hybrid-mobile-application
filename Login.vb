Imports MySql.Data.MySqlClient
Public Class Login

    Private Sub login()
        Try


            con = New MySqlConnection(conn)
            Dim update As String = "Update employee_account SET Login = '" & DateTimePicker1.Value & "',Status='" & "Online" & "' WHERE  Employee_ID= '" & Label5.Text & " '"
            executequery(update)
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub

    Private Sub BunifuThinButton21_Click(sender As Object, e As EventArgs) Handles BunifuThinButton21.Click
   

        Try
            con = New MySqlConnection(conn)
            con.Open()
            Dim usrfound As Boolean = False
            Dim query As New MySqlCommand("select * from employee_account where username = '" & User.Text & "'", con)
            reader = query.ExecuteReader
            While reader.Read

                If reader(2).ToString = User.Text And reader(3).ToString = Pass.Text And reader(4).ToString = "Admin" Then
                    My.Settings.Username = reader(2).ToString
                    Label5.Text = reader(1).ToString
                    My.Settings.displaypic = reader(9).ToString
                    admin.Label2.Text = User.Text
                    admin.Refresh()
                    usrfound = True
                    Exit While
                End If

            End While
            reader.Close()
            If usrfound = True Then
                MessageBox.Show("successfull login")
                login()
                Me.Hide()
                admin.Show()
            Else
                reader = query.ExecuteReader
                While reader.Read

                    If reader(2).ToString = User.Text And reader(3).ToString = Pass.Text And reader(4).ToString = "Office Employee" Then
                        My.Settings.Username = reader(2).ToString
                        Label5.Text = reader(1).ToString
                        My.Settings.displaypic = reader(9).ToString
                        Eemp.Label2.Text = User.Text
                        Eemp.Refresh()
                        usrfound = True
                        Exit While
                    End If

                End While
                reader.Close()
                If usrfound = True Then
                    MessageBox.Show("successfull login")
                    login()
                    Me.Hide()
                    Eemp.Show()
                Else
                    reader = query.ExecuteReader
                    While reader.Read

                        If reader(2).ToString = User.Text And reader(3).ToString = Pass.Text And reader(4).ToString = "Department Head" Then
                            My.Settings.Username = reader(2).ToString
                            Label5.Text = reader(1).ToString
                            My.Settings.displaypic = reader(9).ToString
                            Head.Label2.Text = User.Text
                            Head.Refresh()
                            usrfound = True
                            Exit While
                        End If

                    End While
                    reader.Close()
                    If usrfound = True Then
                        MessageBox.Show("successfull login")
                        login()
                        Me.Hide()
                        Head.Show()
                    Else
                        reader = query.ExecuteReader
                        While reader.Read

                            If reader(2).ToString = User.Text And reader(3).ToString = Pass.Text And reader(4).ToString = "Receptionist" Then
                                My.Settings.Username = reader(2).ToString
                                Label5.Text = reader(1).ToString
                                My.Settings.displaypic = reader(9).ToString
                                recep.Label2.Text = User.Text
                                recep.Refresh()
                                usrfound = True
                                Exit While
                            End If

                        End While
                        reader.Close()
                        If usrfound = True Then
                            MessageBox.Show("successfull login")
                            login()
                            Me.Hide()
                            recep.Show()
                        Else
                            MessageBox.Show("Incorrect Password Or Username")
                        End If
                    End If
                End If
            End If

        Catch ex As Exception
            MsgBox(ex.Message)
        End Try




    End Sub

  
    Private Sub Login_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        con = New MySqlConnection(conn)
        con.Open()
        If Not My.Settings.Username = String.Empty Then
            User.Text = My.Settings.Username
            My.Settings.Save()
            User.ForeColor = Color.Green
        End If
    End Sub

    Private Sub Label3_Click(sender As Object, e As EventArgs) Handles Label3.Click
        End
    End Sub

    Private Sub BunifuImageButton4_Click(sender As Object, e As EventArgs) Handles BunifuImageButton4.Click

    End Sub

    Private Sub PictureBox1_Click(sender As Object, e As EventArgs)

    End Sub

   
End Class
