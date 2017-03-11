Imports System.Windows.Forms

Public Class StarRating

    Private Sub StarRating_Load(sender As Object, e As EventArgs) Handles MyBase.Load

    End Sub


    Public Sub SetRating(dRating As Double)

        Dim lRating As Integer = dRating

        'two loops

        '5 (5 golden 0 gray) 
        'first loop will draw the golden stars 
         

        For i As Integer = 1 To lRating
            Dim pStar As New PictureBox
            pStar.Width = picStar.Width
            pStar.Height = picStar.Height
            pStar.Visible = True
            pStar.Left = picStar1.Left + (i - 1) * picStar1.Width
            pStar.Image = picStar.Image
             
            Me.Controls.Add(pStar)
        Next

        '3 (3 golden 2 (5 -3 ) gray)  3
        'second loop will draw the gray stars 

        For i As Integer = 1 To 5 - lRating
            Dim pStar As New PictureBox
            pStar.Width = picGrayStar.Width
            pStar.Height = picGrayStar.Height
            pStar.Visible = True
            pStar.Left = picStar1.Left + (5 - i) * picGrayStar.Width
            pStar.Image = picGrayStar.Image

            Me.Controls.Add(pStar)
        Next



    End Sub
End Class
