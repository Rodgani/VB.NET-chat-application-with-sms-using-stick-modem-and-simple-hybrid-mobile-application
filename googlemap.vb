Public Class googlemap


    Private Sub WebKitBrowser1_Load(sender As Object, e As EventArgs) Handles WebKitBrowser1.Load

        WebKitBrowser1.Navigate("http://maps.google.com/?q=" & (TextBox1.Text))

        'WebKitBrowser1.Navigate("https://www.google.com.ph/maps/place/C+%26+E+Publishing,+Inc.+-+Quezon+City/@14.6423787,121.0327104,17z/data=!3m1!4b1!4m5!3m4!1s0x3397b7aac287d789:0x282658e648e538fa!8m2!3d14.6423787!4d121.0348991")
        '  End If
    End Sub
End Class