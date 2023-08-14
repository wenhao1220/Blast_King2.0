Public Class Form2
    Private back As Button
    Private main As Button
    Private Sub Form2_Load(sender As Object, e As EventArgs) Handles MyBase.Load

    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Form1.Show()
        Me.Hide()
    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        Button1.Visible = False
        Button1.Enabled = False
        Button2.Visible = False
        Button2.Enabled = False

        back = New Button
        Me.Controls.Add(back)
        back.Location = Button1.Location
        back.Size = Button1.Size
        back.Text = "BACK"
        AddHandler back.Click, AddressOf back_Click

        main = New Button
        Me.Controls.Add(main)
        main.Location = Button2.Location
        main.Size = Button2.Size
        main.Text = "回主畫面"
        AddHandler main.Click, AddressOf main_Click

    End Sub

    Private Sub back_click(sender As Object, e As MouseEventArgs)
        Button1.Visible = True
        Button1.Enabled = True
        Button2.Visible = True
        Button2.Enabled = True
        back.Visible = False
        back.Enabled = False

    End Sub

    Private Sub main_click(sender As Object, e As MouseEventArgs)
        Form1.Show()
        Me.Hide()
    End Sub
End Class