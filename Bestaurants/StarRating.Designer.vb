<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class StarRating
    Inherits System.Windows.Forms.UserControl

    'UserControl overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()> _
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        Try
            If disposing AndAlso components IsNot Nothing Then
                components.Dispose()
            End If
        Finally
            MyBase.Dispose(disposing)
        End Try
    End Sub

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(StarRating))
        Me.picGrayStar = New System.Windows.Forms.PictureBox()
        Me.picStar = New System.Windows.Forms.PictureBox()
        Me.picStar1 = New System.Windows.Forms.PictureBox()
        CType(Me.picGrayStar, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.picStar, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.picStar1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'picGrayStar
        '
        Me.picGrayStar.Image = CType(resources.GetObject("picGrayStar.Image"), System.Drawing.Image)
        Me.picGrayStar.Location = New System.Drawing.Point(78, 87)
        Me.picGrayStar.Name = "picGrayStar"
        Me.picGrayStar.Size = New System.Drawing.Size(16, 16)
        Me.picGrayStar.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize
        Me.picGrayStar.TabIndex = 29
        Me.picGrayStar.TabStop = False
        Me.picGrayStar.Visible = False
        '
        'picStar
        '
        Me.picStar.Image = CType(resources.GetObject("picStar.Image"), System.Drawing.Image)
        Me.picStar.Location = New System.Drawing.Point(100, 87)
        Me.picStar.Name = "picStar"
        Me.picStar.Size = New System.Drawing.Size(16, 16)
        Me.picStar.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize
        Me.picStar.TabIndex = 28
        Me.picStar.TabStop = False
        Me.picStar.Visible = False
        '
        'picStar1
        '
        Me.picStar1.Image = CType(resources.GetObject("picStar1.Image"), System.Drawing.Image)
        Me.picStar1.Location = New System.Drawing.Point(4, 3)
        Me.picStar1.Name = "picStar1"
        Me.picStar1.Size = New System.Drawing.Size(16, 16)
        Me.picStar1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize
        Me.picStar1.TabIndex = 30
        Me.picStar1.TabStop = False
        Me.picStar1.Visible = False
        '
        'StarRating
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.Controls.Add(Me.picStar1)
        Me.Controls.Add(Me.picGrayStar)
        Me.Controls.Add(Me.picStar)
        Me.Name = "StarRating"
        Me.Size = New System.Drawing.Size(116, 33)
        CType(Me.picGrayStar, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.picStar, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.picStar1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents picGrayStar As System.Windows.Forms.PictureBox
    Friend WithEvents picStar As System.Windows.Forms.PictureBox
    Friend WithEvents picStar1 As System.Windows.Forms.PictureBox

End Class
