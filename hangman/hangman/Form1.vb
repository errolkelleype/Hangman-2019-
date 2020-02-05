'Imports System.Data.OleDb
Public Class Form1


    Private Sub btnStart_Click_1(sender As Object, e As EventArgs) Handles btnStart.Click
        Dim strWord As String
        Dim objRandom As New Random
        Dim intTeller As Integer
        Dim arrWord(3) As String
        Dim intWrongGuess As Integer = 0
        Dim intRandom As Integer
        Dim blnPresent As Boolean
        Dim chrGuess As Char = ""
        Dim cstrletters As String = "abcdefghijklmnopqrstuvwxyz"

        lblHint.Visible = True
        Label1.Visible = True
        lblWord.Text = String.Empty
        PictureBox1.Visible = True
        lstLetters.Items.Clear()

        intRandom = objRandom.Next(1, 4)
        arrWord(1) = "pet"
        arrWord(2) = "house"
        arrWord(3) = "gang"

        strWord = arrWord(intRandom)

        Select Case intRandom
            Case Is = 1
                Me.lblWord.Text = "___"
                lblHint.Text = "an animal that you keep in your home to give you company and pleasure."
            Case Is = 2
                Me.lblWord.Text = "_____"
                lblHint.Text = "also knows as home."
            Case Is = 3
                Me.lblWord.Text = "____"
                lblHint.Text = "group of associates."
        End Select

        strWord.ToCharArray()

        Do
            chrGuess = InputBox("Give a letter from a-z! And Try to find the correct word").ToLower()

            If InStr(cstrletters, chrGuess) = 0 Then
                MessageBox.Show("you can only use letters!!")
            Else
                If lstLetters.Items.Contains(chrGuess) = False Then
                    blnPresent = False
                    lstLetters.Items.Add(chrGuess)

                    For intTeller = 0 To Integer.Parse(arrWord(intRandom).Length - 1) Step 1
                        If strWord(intTeller) = chrGuess Then
                            Me.lblWord.Text = lblWord.Text.Remove(intTeller, 1)
                            Me.lblWord.Text = lblWord.Text.Insert(intTeller, chrGuess)
                            blnPresent = True
                        End If
                    Next

                    If blnPresent = False Then
                        PictureBox1.Visible = True
                        PictureBox1.Image = ImageList1.Images(intWrongGuess)
                        intWrongGuess += 1
                    End If

                Else
                    MessageBox.Show("Letter already used before.choose another one")
                End If
            End If
        Loop Until lblWord.Text = arrWord(intRandom) Or intWrongGuess = 10

        If intWrongGuess = 10 Then
            MessageBox.Show("You Lost the game. to play again press the button. the word you had to find was " & arrWord(intRandom).ToString, "Lost")
        Else
            MessageBox.Show("you won the game. to start the next game press the button!", "WON")
        End If


    End Sub

    Private Sub Form1_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        'Dim connectionString As String = "Provider=Microsoft.ACE.OLEDB.12.0;Data Source=C:\Users\ASUS\Desktop\hangman\hangman\bin\Debug\Game1.accdb"
    End Sub
End Class
