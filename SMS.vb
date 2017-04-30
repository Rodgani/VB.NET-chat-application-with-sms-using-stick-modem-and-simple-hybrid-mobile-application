Imports System.Management
Imports System.Threading
Imports System.Text.RegularExpressions
Imports MySql.Data.MySqlClient
Public Class SMS
    Dim rcvdata As String = ""
    Dim index As String = ""
  
    Public Function ModemsConnected() As String
        Dim modems As String = ""

        Try
            Dim searcher As New ManagementObjectSearcher( _
                "root\CIMV2", _
                "SELECT * FROM Win32_POTSModem")

            For Each queryObj As ManagementObject In searcher.Get()
                If queryObj("Status") = "OK" Then
                    modems = modems & (queryObj("AttachedTo") & " - " & queryObj("Description") & "***")
                End If
            Next
        Catch err As ManagementException
            MessageBox.Show("An error occurred while querying for WMI data: " & err.Message)
            Return ""
        End Try
        Return modems
    End Function

    Private Sub ComboBox1_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ComboBox1.SelectedIndexChanged
        If ComboBox1.Text <> "" Then
            connec()
        End If
    End Sub

    Private Sub ComboBox1_SelectedValueChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles ComboBox1.SelectedValueChanged
        Label1.Text = Trim(Mid(ComboBox1.Text, 1, 5))

    End Sub
    Private Sub serialport1_datareceived(ByVal sender As Object, ByVal e As System.IO.Ports.SerialDataReceivedEventArgs) Handles SerialPort1.DataReceived
        Dim datain As String = ""
        Dim numbytes As Integer = SerialPort1.BytesToRead
        For i As Integer = 1 To numbytes
            datain &= Chr(SerialPort1.ReadChar)

        Next
        test(datain)
    End Sub
    Private Sub test(ByVal indata As String)
        rcvdata &= indata

    End Sub

    Public Sub connec()
        Try
            With SerialPort1
                .PortName = Label1.Text
                .BaudRate = 9600
                .Parity = IO.Ports.Parity.None
                .DataBits = 8
                .StopBits = IO.Ports.StopBits.One
                .Handshake = IO.Ports.Handshake.None
                .RtsEnable = True
                .ReceivedBytesThreshold = 1
                .NewLine = vbCr
                .ReadTimeout = 1000
                .Open()

            End With
            If SerialPort1.IsOpen Then
                Label3.Text = "connected"
                If Label3.Text = "connected" Then
                    ListView1.Items.Clear()
                    det()
                End If
            Else
                Label3.Text = "got some error"
            End If
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub


    Private Sub cmdsend_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdsend.Click
        Try
            With SerialPort1
                .Write("at" & vbCrLf)
                Threading.Thread.Sleep(1000)
                .Write("at+cmgf=1" & vbCrLf)
                Threading.Thread.Sleep(1000)
                .Write("at+cmgs=" & Chr(34) & txtnumber.Text & Chr(34) & vbCrLf)
                .Write(txtmessage.Text & Chr(26))
                Threading.Thread.Sleep(1000)
                MsgBox(rcvdata.ToString)



            End With
            If rcvdata.ToString.Contains(">") Then
                MsgBox("Message Sent")
            Else
                MsgBox("Message not sent")

            End If
        Catch ex As Exception

        End Try
    End Sub

    Public Sub det()
        Try
            With SerialPort1
                rcvdata = ""
                .Write("AT" & vbCrLf)
                Threading.Thread.Sleep(1000)
                .Write("AT+CMGF=1" & vbCrLf)
                Threading.Thread.Sleep(1000)
                .Write("AT+CPMS=""SM""" & vbCrLf)
                Threading.Thread.Sleep(1000)
                .Write("AT+CMGL=""ALL""" & vbCrLf)
                Threading.Thread.Sleep(1000)
                'MsgBox(rcvdata.ToString)
                readmsg()
            End With
        Catch ex As Exception

        End Try
    End Sub

    Private Sub readmsg()
        Try
            Dim lineoftext As String
            Dim i As Integer
            Dim arytextfile() As String
            lineoftext = rcvdata.ToString
            arytextfile = Split(lineoftext, "+CMGL", , CompareMethod.Text)
            For i = 1 To UBound(arytextfile)
                Dim input As String = arytextfile(i)
                Dim result() As String
                Dim pattern As String = "(:)|(,"")|("","")"
                result = Regex.Split(input, pattern)
                Dim lvi As New ListViewItem
                Dim concat() As String
                With ListView1.Items.Add("null")
                    'for index
                    .SubItems.AddRange(New String() {result(2)})
                    'for status
                    .SubItems.AddRange(New String() {result(4)})
                    'for number
                    Dim my_string, position As String
                    my_string = result(6)
                    position = my_string.Length - 2
                    my_string = my_string.Remove(position, 2)
                    .SubItems.Add(my_string)
                    'for date and time
                    concat = New String() {result(8) & result(9) & result(10) & result(11) & result(12).Substring(0, 2)}
                    .SubItems.AddRange(concat)
                    'for the message
                    Dim lineoftexts As String
                    Dim arytextfiles() As String
                    lineoftexts = arytextfile(i)
                    arytextfiles = Split(lineoftexts, "+32", , CompareMethod.Text)
                    .SubItems.Add(arytextfiles(1))

                End With

            Next
        Catch ex As Exception

        End Try
    End Sub


   
    Private Sub ListView1_MouseDoubleClick(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles ListView1.MouseDoubleClick
        `With ListView1.SelectedItems(0)
        index = .SubItems(1).Text
        MsgBox(index)
        End With
        googlemap.Show()
        googlemap.TextBox1.Text = ListView1.FocusedItem.SubItems(5).Text
    End Sub
    Public Sub dlte()
        Try
            With SerialPort1
                'delete
                .Write("AT")
                Threading.Thread.Sleep(1000)
                .Write("AT+CMGF=1")
                Threading.Thread.Sleep(1000)
                .Write("AT+CPMS=""SM""" & vbCrLf)
                Threading.Thread.Sleep(1000)
                'at comands for delete  
                .Write("AT+CMGD=" & index & ",0")
                Threading.Thread.Sleep(1000)
                MsgBox(rcvdata.ToString)
                If rcvdata.ToString.Contains("ERROR") Then
                    MsgBox("Error")
                Else
                    MsgBox("Message Deleted")
                    archive()
                End If
            End With
        Catch ex As Exception

        End Try
    End Sub

    Private Sub Button2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button2.Click
        dlte()
    End Sub
    Public Sub delteall()
        Try
            With SerialPort1
                .Write("AT")
                Threading.Thread.Sleep(1000)
                .Write("AT+CMGF=1")
                Threading.Thread.Sleep(1000)
                .Write("AT+CPMS=""SM""" & vbCrLf)
                Threading.Thread.Sleep(1000)

                .Write("AT+CMGD=1,4")
                Threading.Thread.Sleep(1000)
                MsgBox(rcvdata.ToString)
                If rcvdata.ToString.Contains("Error") Then
                    MsgBox("Got Some Error")
                Else
                    MsgBox("message deleted")
                    deletemoall()
                End If
            End With

        Catch ex As Exception

        End Try
    End Sub
    Private Sub Button3_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button3.Click
        delteall()
    End Sub


    Private Sub Timer1_Tick(sender As Object, e As EventArgs) Handles Timer1.Tick
        Label5.Text = Now.Second
        If Label5.Text = "10" Then
            ListView1.Items.Clear()
            det()
        End If
        If Label5.Text = "30" Then
            ListView1.Items.Clear()
            det()
        End If
        If Label5.Text = "50" Then
            ListView1.Items.Clear()
            det()
        End If
    End Sub

    Private Sub SMS_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        contact()
        Timer1.Start()
        Dim ports() As String
        ports = Split(ModemsConnected(), "***")
        For i As Integer = 0 To ports.Length - 2
            ComboBox1.Items.Add(ports(i))

        Next
    End Sub

    Private Sub txtnumber_TextChanged(sender As Object, e As EventArgs) Handles txtnumber.TextChanged
        If txtnumber.Text <> "" Then
            cmdsend.Enabled = True
        End If
        If txtnumber.Text = "" Then
            cmdsend.Enabled = False
        End If
    End Sub

  

    Public Sub archive()
        Try
            If Not ListView1.FocusedItem.Index = -1 Then
                con = New MySqlConnection(conn)
                Dim sert As String = "insert into employee_coordinatesdetails(Employee_ID,Coordinates,date)values('" & ListView1.FocusedItem.SubItems(3).Text & "','" & ListView1.FocusedItem.SubItems(5).Text & "','" & ListView1.FocusedItem.SubItems(4).Text & "')"
                executequery(sert)
                ListView1.FocusedItem.Remove()
                MessageBox.Show("Deleted")
            End If
        Catch ex As Exception

        End Try
    End Sub
    Public Sub deletemoall()
        Try
            If Not ListView1.FocusedItem.Index = -1 Then
                con = New MySqlConnection(conn)
                Dim sert As String = "insert into employee_coordinatesdetails(Employee_ID,Coordinates,date)values('" & ListView1.FocusedItem.SubItems(3).Text & "','" & ListView1.FocusedItem.SubItems(4).Text & "','" & ListView1.FocusedItem.SubItems(5).Text & "')"
                executequery(sert)
                ListView1.FocusedItem.Remove()
                MessageBox.Show("Deleted")
            End If
        Catch ex As Exception

        End Try
    End Sub

    Public Sub contact()
        Try
            con = New MySqlConnection(conn)
            con.Open()
            comm = New MySqlCommand("select * from employee", con)
            reader = comm.ExecuteReader
            ListBox1.Items.Clear()
            While reader.Read
                    ListBox1.Items.Add(reader(3).ToString)
            End While
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub

    Private Sub ListBox1_MouseClick(sender As Object, e As MouseEventArgs) Handles ListBox1.MouseClick
        Try
            con = New MySqlConnection(conn)
            con.Open()
            comm = New MySqlCommand("select * from employee where Firstname='" & ListBox1.SelectedItem.ToString & "'", con)
            reader = comm.ExecuteReader
            ListBox1.Items.Clear()
            While reader.Read
                txtnumber.Text = reader(8).ToString
            End While
            contact()
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub

    Private Sub Button4_Click(sender As Object, e As EventArgs) Handles Button4.Click
        Coords.Show()
    End Sub
End Class
