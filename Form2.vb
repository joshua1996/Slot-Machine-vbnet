﻿Public Class Form2
    Dim frame(5) As Bitmap
    Dim framePrize(6, 1) As Bitmap
    Dim r As New Random
    Dim position As Integer = r.Next(0, 6)
    Dim position2 As Integer = r.Next(0, 6)
    Dim position3 As Integer = r.Next(0, 6)
    Dim endT As Integer
    Dim winSpin As Integer
    Dim isWin As Boolean

    Private Sub Form2_Load(sender As System.Object, e As System.EventArgs) Handles MyBase.Load
        Form3.ShowDialog()
        spriteSheet()
        Console.WriteLine(position & position2 & position3)
        PictureBox1.Image = frame(position)
        PictureBox2.Image = frame(position2)
        PictureBox3.Image = frame(position3)

        Dim prize As Bitmap = My.Resources.prizes_sprites
        For x As Integer = 0 To 6
            For y As Integer = 0 To 1
                framePrize(x, y) = New Bitmap(30, 30)
                Dim gr As Graphics = Graphics.FromImage(framePrize(x, y))
                gr.DrawImage(prize, 0, 0, New Rectangle(30 * x, 30 * y, 30, 30), GraphicsUnit.Pixel)
            Next
           
        Next


        'For Each a In Panel1.Controls
        '    If a.GetType() Is Label7 Then
        '        Dim chk As PictureBox
        '        chk = DirectCast(a, PictureBox)
        '        chk.Image = framePrize(5, 0)
        '    End If
        'Next
        For Each a In Panel1.Controls
            a.Image = framePrize(5, 0)
        Next
        For Each a In Panel2.Controls
            a.Image = framePrize(3, 0)

        Next
        For Each a In Panel3.Controls
            a.Image = framePrize(1, 0)
        Next

        PictureBox15.Image = framePrize(2, 1)
        PictureBox14.Image = framePrize(3, 1)
        PictureBox13.Image = framePrize(4, 1)

        For Each a In Panel5.Controls
            a.Image = framePrize(4, 0)
        Next
        For Each a In Panel6.Controls
            a.Image = framePrize(0, 0)
        Next
        For Each a In Panel7.Controls
            a.Image = framePrize(2, 0)
        Next
        For Each a In Panel8.Controls
            a.Image = framePrize(0, 1)
        Next
        For Each a In Panel9.Controls
            a.Image = framePrize(6, 0)
        Next
    End Sub

    Private Sub spriteSheet()
        Dim img As Bitmap = My.Resources.reel_strip
        For x As Integer = 0 To 5
            frame(x) = New Bitmap(121, 120)
            Dim gr As Graphics = Graphics.FromImage(frame(x))
            gr.DrawImage(img, 0, 0, New Rectangle(0, 120 * x, 121, 120), GraphicsUnit.Pixel)
        Next



    End Sub

    Private Sub Timer1_Tick(sender As System.Object, e As System.EventArgs) Handles Timer1.Tick

        PictureBox1.Image = frame(position)
        If position = 5 Then
            position = 0
        End If
        position += 1

        '   Console.WriteLine(endT)
    End Sub

    Private Sub Timer2_Tick(sender As System.Object, e As System.EventArgs) Handles Timer2.Tick

        PictureBox2.Image = frame(position2)
        If position2 = 5 Then
            position2 = 0
        End If
        position2 += 1
    End Sub

    Private Sub Timer3_Tick(sender As System.Object, e As System.EventArgs) Handles Timer3.Tick

        PictureBox3.Image = frame(position3)
        If position3 = 5 Then
            position3 = 0
        End If
        position3 += 1
        endT += 1
    End Sub

    Private Sub Button1_Click(sender As System.Object, e As System.EventArgs) Handles Button1.Click
        'For Each a As Panel In Panel11.Controls
        '    a.BackColor = Nothing
        'Next
        For Each a As Panel In Panel11.Controls
            a.BackColor = DefaultBackColor
        Next
        Label5.Text = Val(Label5.Text) - Val(Label6.Text)
        Button1.Enabled = False
        Timer1.Enabled = True
        Timer2.Enabled = True
        Timer3.Enabled = True
        Timer4.Enabled = True
    End Sub


    Private Sub Timer4_Tick(sender As System.Object, e As System.EventArgs) Handles Timer4.Tick
        If endT > r.Next(20, 30) Then
            Timer1.Enabled = False
            If endT > r.Next(40, 50) Then
                Timer2.Enabled = False
                If endT > r.Next(60, 70) Then
                    Timer3.Enabled = False
                    endT = 0
                    result()
                    checkLose()
                    If Label6.Text = 0 Then
                        Label6.Text = 1
                    End If
                    Button1.Enabled = True
                    
                End If
            End If
        End If
    End Sub

    Private Sub result()

        If PictureBox1.Image Is frame(5) And PictureBox2.Image Is frame(5) And PictureBox3.Image Is frame(5) Then
            Panel1.BackColor = Color.Yellow
            winSpin = Label7.Text
            Timer5.Enabled = True
            Label4.Text = Label7.Text
            isWin = True
            '  checkLose()
        End If
        If PictureBox1.Image Is frame(3) And PictureBox2.Image Is frame(3) And PictureBox3.Image Is frame(3) Then
            Panel2.BackColor = Color.Yellow
            winSpin = Label8.Text
            Timer5.Enabled = True
            Label4.Text = Label8.Text
            isWin = True
            ' checkLose()
        End If
        If PictureBox1.Image Is frame(1) And PictureBox2.Image Is frame(1) And PictureBox3.Image Is frame(1) Then
            Panel3.BackColor = Color.Yellow
            winSpin = Label9.Text
            Timer5.Enabled = True
            Label4.Text = Label9.Text
            ' checkLose()
            isWin = True
        End If
        If (PictureBox1.Image Is frame(0) Or PictureBox1.Image Is frame(2)) And (PictureBox2.Image Is frame(1) Or PictureBox2.Image Is frame(4)) And (PictureBox3.Image Is frame(3) Or PictureBox3.Image Is frame(5)) Then ''''''''
            Panel4.BackColor = Color.Yellow
            winSpin = Label10.Text
            Timer5.Enabled = True
            Label4.Text = Label10.Text
            ' checkLose()
            isWin = True
        End If
        If PictureBox1.Image Is frame(4) And PictureBox2.Image Is frame(4) And PictureBox3.Image Is frame(4) Then
            Panel5.BackColor = Color.Yellow
            winSpin = Label11.Text
            Timer5.Enabled = True
            Label4.Text = Label11.Text
            '  checkLose()
            isWin = True
        End If
        If PictureBox1.Image Is frame(0) And PictureBox2.Image Is frame(0) And PictureBox3.Image Is frame(0) Then
            Panel6.BackColor = Color.Yellow
            winSpin = Label12.Text
            Timer5.Enabled = True
            Label4.Text = Label12.Text
            '  checkLose()
            isWin = True
        End If
        If PictureBox1.Image Is frame(2) And PictureBox2.Image Is frame(2) And PictureBox3.Image Is frame(2) Then
            Panel7.BackColor = Color.Yellow
            winSpin = Label13.Text
            Timer5.Enabled = True
            Label4.Text = Label13.Text
            '  checkLose()
            isWin = True
        End If
        If (PictureBox1.Image Is frame(0) Or PictureBox1.Image Is frame(2) Or PictureBox1.Image Is frame(4)) And (PictureBox2.Image Is frame(0) Or PictureBox2.Image Is frame(2) Or PictureBox2.Image Is frame(4)) And (PictureBox3.Image Is frame(0) Or PictureBox3.Image Is frame(2) Or PictureBox3.Image Is frame(4)) Then '''''
            Panel8.BackColor = Color.Yellow
            winSpin = Label15.Text
            Timer5.Enabled = True
            Label4.Text = Label15.Text
            '   checkLose()
            isWin = True
        End If

        If Val(Label5.Text) < Val(Label6.Text) Then
            Label6.Text = Label5.Text

        End If

        'If Label5.Text = 0 Then
        '    MsgBox("game over")
        '    Form3.ShowDialog()

        'End If
    End Sub

    Private Sub checkLose()
       
        If Label5.Text = 0 And isWin = False Then
            MsgBox("game over")
            Form3.ShowDialog()

        End If
    End Sub

    Private Sub Button2_Click(sender As System.Object, e As System.EventArgs) Handles Button2.Click
        If Val(Label6.Text) < 10 And Val(Label5.Text) > Val(Label6.Text) Then
            Label6.Text = Val(Label6.Text) + 1
        End If
    End Sub

    Private Sub Button3_Click(sender As System.Object, e As System.EventArgs) Handles Button3.Click
        If Val(Label6.Text) > 1 Then
            Label6.Text = Val(Label6.Text) - 1
        End If
    End Sub

    Private Sub Label6_Click(sender As System.Object, e As System.EventArgs) Handles Label6.Click
    
    End Sub

    Private Sub Label6_TextChanged(sender As Object, e As System.EventArgs) Handles Label6.TextChanged
        Dim scoreArr() As Integer = {4, 7, 12, 14, 15, 16, 20, 50, 200}
        Dim int As Integer
        For Each a As Label In Panel12.Controls
            a.Text = scoreArr(int) * Val(Label6.Text)
            int += 1
        Next
    End Sub

    Private Sub Timer5_Tick(sender As System.Object, e As System.EventArgs) Handles Timer5.Tick
        For i As Integer = 1 To winSpin '7
            Label5.Text = Val(Label5.Text) + 1
        Next
        Timer5.Enabled = False
    End Sub
End Class '120