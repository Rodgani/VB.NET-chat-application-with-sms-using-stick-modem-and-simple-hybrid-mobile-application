Imports MaterialSkin


Public Class notifmessage

    Private Sub formskin()
        Dim sknmngr As MaterialSkinManager = MaterialSkinManager.Instance
        sknmngr.AddFormToManage(Me)
        sknmngr.Theme = MaterialSkinManager.Themes.LIGHT
        SkinManager.ColorScheme = New ColorScheme(Primary.Blue500, Primary.Blue700, Primary.Green700, Accent.Green700, TextShade.WHITE)
    End Sub

    Private Sub notifmessage_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        formskin()
        My.Computer.Audio.Play(My.Resources.Naruto_SMS_Cute_Voice_Text_Alert_Tone_Ringtone, AudioPlayMode.BackgroundLoop)
    End Sub

    Private Sub Button1_Click_1(sender As Object, e As EventArgs) Handles Button1.Click
        Me.Close()
        My.Computer.Audio.Stop()
        If admin.Label2.Text <> "" Then
            admin.MaterialTabControl1.SelectTab(3)
        End If
        If Head.Label2.Text <> "" Then
            Head.MaterialTabControl1.SelectTab(2)
        End If
        If Eemp.Label2.Text <> "" Then
            Eemp.MaterialTabControl1.SelectTab(2)
        End If
        If recep.Label2.Text <> "" Then
            recep.MaterialTabControl1.SelectTab(2)
        End If
    End Sub
End Class