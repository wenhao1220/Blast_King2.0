Public Class Form4
    Public role1
    Dim w_tick As Double
    Dim t1, t2 As Integer
    Dim life1 As Integer = 3
    Dim life2 As Integer = 3
    Dim WithEvents w_timer As New Timer
    Public Row = 15
    Public Col = 15
    Public BB = 30
    Public Box As Integer = 40
    Dim BOT(Row, Col) As PictureBox

    Private Sub Form1_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Label1.Text = life1
        Label2.Text = life2

        For i As Integer = 0 To Row
            For j As Integer = 0 To Col
                BOT(i, j) = New PictureBox
                Me.Controls.Add(BOT(i, j))
                BOT(i, j).Name = "PictureBox" & ((2 + 1) * i + j + 1)
                BOT(i, j).SizeMode = PictureBoxSizeMode.StretchImage
                BOT(i, j).Width = BB
                BOT(i, j).Height = BB
                BOT(i, j).Top = 35 + BB * i
                BOT(i, j).Left = 10 + BB * j
                'AddHandler BOT(i, j).Click, AddressOf abc_Click
            Next j
        Next i
        PictureBox1.Width = BB
        PictureBox1.Height = BB
        PictureBox1.Location = BOT(4, 1).Location
        PictureBox2.Width = BB
        PictureBox2.Height = BB
        PictureBox2.Location = BOT(4, 15).Location
        GetBox(Box)
    End Sub

    Sub GetBox(BoomNumber As Integer)
        Dim r As New Random
        Do
            Dim Number = r.Next((Row + 1) * (Col + 1) - 1)
            Dim No1 = Number \ (Row + 1)
            Dim No2 = Number Mod (Col + 1)

            If (BOT(No1, No2).Tag <> 1) Then
                BOT(No1, No2).Tag = 1
                BOT(No1, No2).BackgroundImage = My.Resources.ResourceManager.GetObject("box")
                BOT(No1, No2).BackgroundImageLayout = ImageLayout.Stretch
                BoomNumber -= 1
            End If
        Loop While (BoomNumber <> 0)
    End Sub

    Sub GetBomb(sender As Object, e As EventArgs)

    End Sub

    Private Sub Form1_KeyDown(sender As Object, e As KeyEventArgs) Handles Me.KeyDown

        Select Case e.KeyCode
            Case 87
                PictureBox1.Top = PictureBox1.Top - BB
                If PictureBox1.Top >= Me.ClientSize.Height - PictureBox1.Size.Height Or PictureBox1.Top <= 0 Then
                    PictureBox1.Top = PictureBox1.Top + BB
                End If

                For i As Integer = 0 To Row
                    For j As Integer = 0 To Col
                        If BOT(i, j).Tag = 1 Then
                            If PictureBox1.Location = BOT(i, j).Location Then
                                PictureBox1.Top = PictureBox1.Top + BB
                            End If
                        End If
                    Next j
                Next i

            Case 83
                PictureBox1.Top = PictureBox1.Top + BB
                If PictureBox1.Top >= Me.ClientSize.Height - PictureBox1.Size.Height Or PictureBox1.Top <= 0 Then
                    PictureBox1.Top = PictureBox1.Top - BB
                End If

                For i As Integer = 0 To Row
                    For j As Integer = 0 To Col
                        If BOT(i, j).Tag = 1 Then
                            If PictureBox1.Location = BOT(i, j).Location Then
                                PictureBox1.Top = PictureBox1.Top - BB
                            End If
                        End If
                    Next j
                Next i

            Case 65
                PictureBox1.Left = PictureBox1.Left - BB
                If PictureBox1.Left >= Me.ClientSize.Width - PictureBox1.Size.Width Or PictureBox1.Left <= 0 Then
                    PictureBox1.Left = PictureBox1.Left + BB
                End If

                For i As Integer = 0 To Row
                    For j As Integer = 0 To Col
                        If BOT(i, j).Tag = 1 Then
                            If PictureBox1.Location = BOT(i, j).Location Then
                                PictureBox1.Left = PictureBox1.Left + BB
                            End If
                        End If
                    Next j
                Next i

            Case 68
                PictureBox1.Left = PictureBox1.Left + BB
                If PictureBox1.Left >= Me.ClientSize.Width - PictureBox1.Size.Width Or PictureBox1.Left <= 0 Then
                    PictureBox1.Left = PictureBox1.Left - BB
                End If

                For i As Integer = 0 To Row
                    For j As Integer = 0 To Col
                        If BOT(i, j).Tag = 1 Then
                            If PictureBox1.Location = BOT(i, j).Location Then
                                PictureBox1.Left = PictureBox1.Left - BB
                            End If
                        End If
                    Next j
                Next i

            Case 32
                For i As Integer = 0 To Row
                    For j As Integer = 0 To Col
                        If PictureBox1.Location = BOT(i, j).Location Then
                            If t1 = 0 Then
                                t1 = 1
                                BOT(i, j).Image = My.Resources.ResourceManager.GetObject("Bomb")
                                wait(3)
                                BOT(i, j).Image = My.Resources.ResourceManager.GetObject("爆炸")

                                If PictureBox1.Location = BOT(i, j).Location Then
                                    PictureBox1.Visible = False
                                    life1 = life1 - 1
                                    Label1.Text = life1
                                    If life1 = 0 Then
                                        Label1.Text = life1
                                        PictureBox1.Visible = False
                                        PictureBox1.Enabled = False
                                    End If
                                End If

                                If PictureBox2.Location = BOT(i, j).Location Then
                                    PictureBox2.Visible = False
                                    life2 = life2 - 1
                                    Label2.Text = life2
                                    If life2 = 0 Then
                                        PictureBox2.Visible = False
                                        PictureBox2.Enabled = False
                                    End If
                                End If

                                If i <> Row Then
                                    BOT(i + 1, j).Image = My.Resources.ResourceManager.GetObject("縱向噴射")
                                    If PictureBox1.Location = BOT(i + 1, j).Location Then
                                        PictureBox1.Visible = False
                                        life1 = life1 - 1
                                        Label1.Text = life1
                                        If life1 = 0 Then
                                            Label1.Text = life1
                                            PictureBox1.Visible = False
                                            PictureBox1.Enabled = False
                                        End If
                                    End If

                                    If PictureBox2.Location = BOT(i + 1, j).Location Then
                                        PictureBox2.Visible = False
                                        life2 = life2 - 1
                                        Label2.Text = life2
                                        If life2 = 0 Then
                                            PictureBox2.Visible = False
                                            PictureBox2.Enabled = False
                                        End If
                                    End If
                                End If

                                If i <> 0 Then
                                    BOT(i - 1, j).Image = My.Resources.ResourceManager.GetObject("縱向噴射")
                                    If PictureBox1.Location = BOT(i - 1, j).Location Then
                                        PictureBox1.Visible = False
                                        life1 = life1 - 1
                                        Label1.Text = life1
                                        If life1 = 0 Then
                                            Label1.Text = life1
                                            PictureBox1.Visible = False
                                            PictureBox1.Enabled = False
                                        End If
                                    End If

                                    If PictureBox2.Location = BOT(i - 1, j).Location Then
                                        PictureBox2.Visible = False
                                        life2 = life2 - 1
                                        Label2.Text = life2
                                        If life2 = 0 Then
                                            PictureBox2.Visible = False
                                            PictureBox2.Enabled = False
                                        End If
                                    End If
                                End If

                                If j <> Col Then
                                    BOT(i, j + 1).Image = My.Resources.ResourceManager.GetObject("橫向噴射")
                                    If PictureBox1.Location = BOT(i, j + 1).Location Then
                                        PictureBox1.Visible = False
                                        life1 = life1 - 1
                                        Label1.Text = life1
                                        If life1 = 0 Then
                                            Label1.Text = life1
                                            PictureBox1.Visible = False
                                            PictureBox1.Enabled = False
                                        End If
                                    End If

                                    If PictureBox2.Location = BOT(i, j + 1).Location Then
                                        PictureBox2.Visible = False
                                        life2 = life2 - 1
                                        Label2.Text = life2
                                        If life2 = 0 Then
                                            PictureBox2.Visible = False
                                            PictureBox2.Enabled = False
                                        End If
                                    End If
                                End If

                                If j <> 0 Then
                                    BOT(i, j - 1).Image = My.Resources.ResourceManager.GetObject("橫向噴射")
                                    If PictureBox1.Location = BOT(i, j - 1).Location Then
                                        PictureBox1.Visible = False
                                        life1 = life1 - 1
                                        Label1.Text = life1
                                        If life1 = 0 Then
                                            Label1.Text = life1
                                            PictureBox1.Visible = False
                                            PictureBox1.Enabled = False
                                        End If
                                    End If

                                    If PictureBox2.Location = BOT(i, j - 1).Location Then
                                        PictureBox2.Visible = False
                                        life2 = life2 - 1
                                        Label2.Text = life2
                                        If life2 = 0 Then
                                            PictureBox2.Visible = False
                                            PictureBox2.Enabled = False
                                        End If
                                    End If
                                End If

                                wait(0.5)

                                BOT(i, j).Image = Nothing
                                If i <> Row Then
                                    BOT(i + 1, j).BackgroundImage = Nothing
                                    BOT(i + 1, j).Image = Nothing
                                    BOT(i + 1, j).Tag = 0
                                End If

                                If i <> 0 Then
                                    BOT(i - 1, j).BackgroundImage = Nothing
                                    BOT(i - 1, j).Image = Nothing
                                    BOT(i - 1, j).Tag = 0
                                End If

                                If j <> Col Then
                                    BOT(i, j + 1).BackgroundImage = Nothing
                                    BOT(i, j + 1).Image = Nothing
                                    BOT(i, j + 1).Tag = 0
                                End If

                                If j <> 0 Then
                                    BOT(i, j - 1).BackgroundImage = Nothing
                                    BOT(i, j - 1).Image = Nothing
                                    BOT(i, j - 1).Tag = 0
                                End If

                                If life1 <> 0 Then
                                    PictureBox1.Visible = True
                                End If

                                If life2 <> 0 Then
                                    PictureBox2.Visible = True
                                End If
                                t1 = 0
                            End If
                        End If
                    Next j
                Next i

            Case 38
                PictureBox2.Top = PictureBox2.Top - BB
                If PictureBox2.Top >= Me.ClientSize.Height - PictureBox2.Size.Height Or PictureBox2.Top <= 0 Then
                    PictureBox2.Top = PictureBox2.Top + BB
                End If

                For i As Integer = 0 To Row
                    For j As Integer = 0 To Col
                        If BOT(i, j).Tag = 1 Then
                            If PictureBox2.Location = BOT(i, j).Location Then
                                PictureBox2.Top = PictureBox2.Top + BB
                            End If
                        End If
                    Next j
                Next i

            Case 40
                PictureBox2.Top = PictureBox2.Top + BB
                If PictureBox2.Top >= Me.ClientSize.Height - PictureBox2.Size.Height Or PictureBox2.Top <= 0 Then
                    PictureBox2.Top = PictureBox2.Top - BB
                End If

                For i As Integer = 0 To Row
                    For j As Integer = 0 To Col
                        If BOT(i, j).Tag = 1 Then
                            If PictureBox2.Location = BOT(i, j).Location Then
                                PictureBox2.Top = PictureBox2.Top - BB
                            End If
                        End If
                    Next j
                Next i

            Case 37
                PictureBox2.Left = PictureBox2.Left - BB
                If PictureBox2.Left >= Me.ClientSize.Width - PictureBox2.Size.Width Or PictureBox2.Left <= 0 Then
                    PictureBox2.Left = PictureBox2.Left + BB
                End If

                For i As Integer = 0 To Row
                    For j As Integer = 0 To Col
                        If BOT(i, j).Tag = 1 Then
                            If PictureBox2.Location = BOT(i, j).Location Then
                                PictureBox2.Left = PictureBox2.Left + BB
                            End If
                        End If
                    Next j
                Next i

            Case 39
                PictureBox2.Left = PictureBox2.Left + BB
                If PictureBox2.Left >= Me.ClientSize.Width - PictureBox2.Size.Width Or PictureBox2.Left <= 0 Then
                    PictureBox2.Left = PictureBox2.Left - BB
                End If

                For i As Integer = 0 To Row
                    For j As Integer = 0 To Col
                        If BOT(i, j).Tag = 1 Then
                            If PictureBox2.Location = BOT(i, j).Location Then
                                PictureBox2.Left = PictureBox2.Left - BB
                            End If
                        End If
                    Next j
                Next i

            Case 13
                For i As Integer = 0 To Row
                    For j As Integer = 0 To Col
                        If PictureBox2.Location = BOT(i, j).Location Then
                            If t2 = 0 Then
                                t1 = 1
                                BOT(i, j).Image = My.Resources.ResourceManager.GetObject("Bomb")
                                wait(3)
                                BOT(i, j).Image = My.Resources.ResourceManager.GetObject("爆炸")

                                If PictureBox1.Location = BOT(i, j).Location Then
                                    PictureBox1.Visible = False
                                    life1 = life1 - 1
                                    Label1.Text = life1
                                    If life1 = 0 Then
                                        PictureBox1.Visible = False
                                        PictureBox1.Enabled = False
                                    End If
                                End If

                                If PictureBox2.Location = BOT(i, j).Location Then
                                    PictureBox2.Visible = False
                                    life2 = life2 - 1
                                    Label2.Text = life2
                                    If life2 = 0 Then
                                        PictureBox2.Visible = False
                                        PictureBox2.Enabled = False
                                    End If
                                End If

                                If i <> Row Then
                                    BOT(i + 1, j).Image = My.Resources.ResourceManager.GetObject("縱向噴射")
                                    If PictureBox1.Location = BOT(i + 1, j).Location Then
                                        PictureBox1.Visible = False
                                        life1 = life1 - 1
                                        Label1.Text = life1
                                        If life1 = 0 Then
                                            PictureBox1.Visible = False
                                            PictureBox1.Enabled = False
                                        End If
                                    End If

                                    If PictureBox2.Location = BOT(i + 1, j).Location Then
                                        PictureBox2.Visible = False
                                        life2 = life2 - 1
                                        Label2.Text = life2
                                        If life2 = 0 Then
                                            PictureBox2.Visible = False
                                            PictureBox2.Enabled = False
                                        End If
                                    End If
                                End If

                                If i <> 0 Then
                                    BOT(i - 1, j).Image = My.Resources.ResourceManager.GetObject("縱向噴射")
                                    If PictureBox1.Location = BOT(i - 1, j).Location Then
                                        PictureBox1.Visible = False
                                        life1 = life1 - 1
                                        Label1.Text = life1
                                        If life1 = 0 Then
                                            PictureBox1.Visible = False
                                            PictureBox1.Enabled = False
                                        End If
                                    End If

                                    If PictureBox2.Location = BOT(i - 1, j).Location Then
                                        PictureBox2.Visible = False
                                        life2 = life2 - 1
                                        Label2.Text = life2
                                        If life2 = 0 Then
                                            PictureBox2.Visible = False
                                            PictureBox2.Enabled = False
                                        End If
                                    End If
                                End If

                                If j <> Col Then
                                    BOT(i, j + 1).Image = My.Resources.ResourceManager.GetObject("橫向噴射")
                                    If PictureBox1.Location = BOT(i, j + 1).Location Then
                                        PictureBox1.Visible = False
                                        life1 = life1 - 1
                                        Label1.Text = life1
                                        If life1 = 0 Then
                                            PictureBox1.Visible = False
                                            PictureBox1.Enabled = False
                                        End If
                                    End If

                                    If PictureBox2.Location = BOT(i, j + 1).Location Then
                                        PictureBox2.Visible = False
                                        life2 = life2 - 1
                                        Label2.Text = life2
                                        If life2 = 0 Then
                                            PictureBox2.Visible = False
                                            PictureBox2.Enabled = False
                                        End If
                                    End If
                                End If

                                If j <> 0 Then
                                    BOT(i, j - 1).Image = My.Resources.ResourceManager.GetObject("橫向噴射")
                                    If PictureBox1.Location = BOT(i, j - 1).Location Then
                                        PictureBox1.Visible = False
                                        life1 = life1 - 1
                                        Label1.Text = life1
                                        If life1 = 0 Then
                                            PictureBox1.Visible = False
                                            PictureBox1.Enabled = False
                                        End If
                                    End If

                                    If PictureBox2.Location = BOT(i, j - 1).Location Then
                                        PictureBox2.Visible = False
                                        life2 = life2 - 1
                                        Label2.Text = life2
                                        If life2 = 0 Then
                                            PictureBox2.Visible = False
                                            PictureBox2.Enabled = False
                                        End If
                                    End If
                                End If

                                wait(0.5)

                                BOT(i, j).Image = Nothing
                                If i <> Row Then
                                    BOT(i + 1, j).BackgroundImage = Nothing
                                    BOT(i + 1, j).Image = Nothing
                                    BOT(i + 1, j).Tag = 0
                                End If

                                If i <> 0 Then
                                    BOT(i - 1, j).BackgroundImage = Nothing
                                    BOT(i - 1, j).Image = Nothing
                                    BOT(i - 1, j).Tag = 0
                                End If

                                If j <> Col Then
                                    BOT(i, j + 1).BackgroundImage = Nothing
                                    BOT(i, j + 1).Image = Nothing
                                    BOT(i, j + 1).Tag = 0
                                End If

                                If j <> 0 Then
                                    BOT(i, j - 1).BackgroundImage = Nothing
                                    BOT(i, j - 1).Image = Nothing
                                    BOT(i, j - 1).Tag = 0
                                End If

                                t2 = 0
                            End If
                        End If
                    Next j
                Next i

        End Select
    End Sub

    Private Sub wait(ByVal second As Double)
        w_tick = 0
        w_timer.Interval = second * 1000
        w_timer.Enabled = True
        Do Until w_tick >= 1
            Application.DoEvents()
        Loop
        w_timer.Enabled = False
        w_timer.Interval = 1
    End Sub

    Private Sub w_timer_tick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles w_timer.Tick
        w_tick += 1
    End Sub
End Class