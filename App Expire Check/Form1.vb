Imports Microsoft.Win32
Public Class Form1
    Private Sub CheckAppLoad() Handles Me.Load
        Button1.PerformClick() 'checking......
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Button1.Enabled = False

        Dim mysitecheck As String = "http://aplikasicheck.000webhostapp.com/checkexpire " ' <-- rubah & masukan webmu untuk mengontrol aplikasi.
        Dim myaccess As New System.Net.WebClient

        Dim readfile As New System.IO.StreamReader(myaccess.OpenRead(mysitecheck))
        Dim dataReceived As String = readfile.ReadToEnd()
        MessageBox.Show(dataReceived, "", MessageBoxButtons.OK,
                        MessageBoxIcon.Information)
        Button1.Enabled = True
        Label1.Text = dataReceived


        If Label1.Text = "true" Then
            MsgBox("Expire", MsgBoxStyle.Critical, "")
            Registry.SetValue("hkey_local_machine\software\checkapp", "check", "expire")
            Dim GetReg = Registry.GetValue("hkey_local_machine\software\checkapp", "check", Nothing)
            If GetReg = "expire" Then
                Me.Close()
                '//aplikasi akan keluar
            Else
                '// lanjut menggunakan...
                MsgBox("Ok..", MsgBoxStyle.Information, "")
            End If
        End If
        readfile.Close()
    End Sub
End Class
