Public Class Form3
    Dim type As Integer
    Private Sub Button4_Click(sender As Object, e As EventArgs) Handles Button4.Click
        Form1.Show()
        Me.Hide()
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        type = 1
        Button5.Enabled = True
    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        type = 2
        Button5.Enabled = True
    End Sub

    Private Sub Button3_Click(sender As Object, e As EventArgs) Handles Button3.Click
        type = 3
        Button5.Enabled = True
    End Sub

    Private Sub Button5_Click(sender As Object, e As EventArgs) Handles Button5.Click
        If type = 1 Then
            MsgBox("hi",, "玩法介紹")
            Form4.Show()
            Me.Hide()
        ElseIf type = 2 Then
            MsgBox("hi",, "玩法介紹")
            Form4.Show()
            Me.Hide()
        ElseIf type = 3 Then
            MsgBox("hi",, "玩法介紹")
            Form4.Show()
            Me.Hide()
        End If
    End Sub

    Private Sub Form3_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Button5.Enabled = False
    End Sub
End Class