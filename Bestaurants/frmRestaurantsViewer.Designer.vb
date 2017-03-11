<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmRestaurantsViewer
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
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
        Me.cmbLayers = New System.Windows.Forms.ComboBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.cmdShow = New System.Windows.Forms.Button()
        Me.cmdHide = New System.Windows.Forms.Button()
        Me.cmdRestaurants = New System.Windows.Forms.Button()
        Me.cmdBars = New System.Windows.Forms.Button()
        Me.cmdLounges = New System.Windows.Forms.Button()
        Me.cmdDiners = New System.Windows.Forms.Button()
        Me.cmdCafes = New System.Windows.Forms.Button()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.cmbVenues = New System.Windows.Forms.ComboBox()
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.cmbCategories = New System.Windows.Forms.ComboBox()
        Me.Category = New System.Windows.Forms.Label()
        Me.lblDescription = New System.Windows.Forms.Label()
        Me.lblWebsite = New System.Windows.Forms.Label()
        Me.cmdSelect = New System.Windows.Forms.Button()
        Me.cmdFlash = New System.Windows.Forms.Button()
        Me.txtSearch = New System.Windows.Forms.TextBox()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.GroupBox1.SuspendLayout()
        Me.SuspendLayout()
        '
        'cmbLayers
        '
        Me.cmbLayers.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbLayers.FormattingEnabled = True
        Me.cmbLayers.Location = New System.Drawing.Point(58, 305)
        Me.cmbLayers.Name = "cmbLayers"
        Me.cmbLayers.Size = New System.Drawing.Size(219, 21)
        Me.cmbLayers.TabIndex = 0
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(14, 308)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(38, 13)
        Me.Label1.TabIndex = 1
        Me.Label1.Text = "Layers"
        '
        'cmdShow
        '
        Me.cmdShow.Location = New System.Drawing.Point(284, 305)
        Me.cmdShow.Name = "cmdShow"
        Me.cmdShow.Size = New System.Drawing.Size(75, 23)
        Me.cmdShow.TabIndex = 2
        Me.cmdShow.Text = "Show"
        Me.cmdShow.UseVisualStyleBackColor = True
        '
        'cmdHide
        '
        Me.cmdHide.Location = New System.Drawing.Point(365, 305)
        Me.cmdHide.Name = "cmdHide"
        Me.cmdHide.Size = New System.Drawing.Size(75, 23)
        Me.cmdHide.TabIndex = 3
        Me.cmdHide.Text = "Hide"
        Me.cmdHide.UseVisualStyleBackColor = True
        '
        'cmdRestaurants
        '
        Me.cmdRestaurants.Location = New System.Drawing.Point(18, 19)
        Me.cmdRestaurants.Name = "cmdRestaurants"
        Me.cmdRestaurants.Size = New System.Drawing.Size(75, 23)
        Me.cmdRestaurants.TabIndex = 4
        Me.cmdRestaurants.Tag = "1"
        Me.cmdRestaurants.Text = "Restaurants"
        Me.cmdRestaurants.UseVisualStyleBackColor = True
        '
        'cmdBars
        '
        Me.cmdBars.Location = New System.Drawing.Point(99, 19)
        Me.cmdBars.Name = "cmdBars"
        Me.cmdBars.Size = New System.Drawing.Size(75, 23)
        Me.cmdBars.TabIndex = 5
        Me.cmdBars.Tag = "3"
        Me.cmdBars.Text = "Bars"
        Me.cmdBars.UseVisualStyleBackColor = True
        '
        'cmdLounges
        '
        Me.cmdLounges.Location = New System.Drawing.Point(180, 19)
        Me.cmdLounges.Name = "cmdLounges"
        Me.cmdLounges.Size = New System.Drawing.Size(75, 23)
        Me.cmdLounges.TabIndex = 6
        Me.cmdLounges.Tag = "4"
        Me.cmdLounges.Text = "Lounges"
        Me.cmdLounges.UseVisualStyleBackColor = True
        '
        'cmdDiners
        '
        Me.cmdDiners.Location = New System.Drawing.Point(261, 19)
        Me.cmdDiners.Name = "cmdDiners"
        Me.cmdDiners.Size = New System.Drawing.Size(75, 23)
        Me.cmdDiners.TabIndex = 7
        Me.cmdDiners.Tag = "0"
        Me.cmdDiners.Text = "Diners"
        Me.cmdDiners.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.cmdDiners.UseVisualStyleBackColor = True
        '
        'cmdCafes
        '
        Me.cmdCafes.Location = New System.Drawing.Point(342, 19)
        Me.cmdCafes.Name = "cmdCafes"
        Me.cmdCafes.Size = New System.Drawing.Size(75, 23)
        Me.cmdCafes.TabIndex = 8
        Me.cmdCafes.Tag = "2"
        Me.cmdCafes.Text = "Cafes"
        Me.cmdCafes.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.cmdCafes.UseVisualStyleBackColor = True
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(14, 51)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(43, 13)
        Me.Label2.TabIndex = 10
        Me.Label2.Text = "Venues"
        '
        'cmbVenues
        '
        Me.cmbVenues.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbVenues.FormattingEnabled = True
        Me.cmbVenues.Location = New System.Drawing.Point(63, 48)
        Me.cmbVenues.Name = "cmbVenues"
        Me.cmbVenues.Size = New System.Drawing.Size(219, 21)
        Me.cmbVenues.TabIndex = 9
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.cmdCafes)
        Me.GroupBox1.Controls.Add(Me.cmdRestaurants)
        Me.GroupBox1.Controls.Add(Me.cmdBars)
        Me.GroupBox1.Controls.Add(Me.cmdLounges)
        Me.GroupBox1.Controls.Add(Me.cmdDiners)
        Me.GroupBox1.Location = New System.Drawing.Point(17, 332)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(423, 61)
        Me.GroupBox1.TabIndex = 11
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "Category"
        '
        'cmbCategories
        '
        Me.cmbCategories.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbCategories.FormattingEnabled = True
        Me.cmbCategories.Location = New System.Drawing.Point(63, 12)
        Me.cmbCategories.Name = "cmbCategories"
        Me.cmbCategories.Size = New System.Drawing.Size(219, 21)
        Me.cmbCategories.TabIndex = 12
        '
        'Category
        '
        Me.Category.AutoSize = True
        Me.Category.Location = New System.Drawing.Point(13, 15)
        Me.Category.Name = "Category"
        Me.Category.Size = New System.Drawing.Size(49, 13)
        Me.Category.TabIndex = 13
        Me.Category.Text = "Category"
        Me.Category.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'lblDescription
        '
        Me.lblDescription.AutoSize = True
        Me.lblDescription.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblDescription.Location = New System.Drawing.Point(13, 87)
        Me.lblDescription.Name = "lblDescription"
        Me.lblDescription.Size = New System.Drawing.Size(60, 13)
        Me.lblDescription.TabIndex = 14
        Me.lblDescription.Text = "Description"
        '
        'lblWebsite
        '
        Me.lblWebsite.AutoSize = True
        Me.lblWebsite.ForeColor = System.Drawing.Color.Blue
        Me.lblWebsite.Location = New System.Drawing.Point(14, 113)
        Me.lblWebsite.Name = "lblWebsite"
        Me.lblWebsite.Size = New System.Drawing.Size(46, 13)
        Me.lblWebsite.TabIndex = 15
        Me.lblWebsite.Text = "Website"
        '
        'cmdSelect
        '
        Me.cmdSelect.Location = New System.Drawing.Point(289, 45)
        Me.cmdSelect.Name = "cmdSelect"
        Me.cmdSelect.Size = New System.Drawing.Size(93, 23)
        Me.cmdSelect.TabIndex = 16
        Me.cmdSelect.Text = "Select on Map"
        Me.cmdSelect.UseVisualStyleBackColor = True
        '
        'cmdFlash
        '
        Me.cmdFlash.Location = New System.Drawing.Point(388, 45)
        Me.cmdFlash.Name = "cmdFlash"
        Me.cmdFlash.Size = New System.Drawing.Size(75, 23)
        Me.cmdFlash.TabIndex = 17
        Me.cmdFlash.Text = "Flash"
        Me.cmdFlash.UseVisualStyleBackColor = True
        '
        'txtSearch
        '
        Me.txtSearch.Location = New System.Drawing.Point(344, 12)
        Me.txtSearch.Name = "txtSearch"
        Me.txtSearch.Size = New System.Drawing.Size(141, 20)
        Me.txtSearch.TabIndex = 18
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(297, 15)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(41, 13)
        Me.Label3.TabIndex = 19
        Me.Label3.Text = "Search"
        '
        'frmRestaurantsViewer
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(497, 150)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.txtSearch)
        Me.Controls.Add(Me.cmdFlash)
        Me.Controls.Add(Me.cmdSelect)
        Me.Controls.Add(Me.lblWebsite)
        Me.Controls.Add(Me.lblDescription)
        Me.Controls.Add(Me.Category)
        Me.Controls.Add(Me.cmbCategories)
        Me.Controls.Add(Me.GroupBox1)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.cmbVenues)
        Me.Controls.Add(Me.cmdHide)
        Me.Controls.Add(Me.cmdShow)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.cmbLayers)
        Me.Name = "frmRestaurantsViewer"
        Me.Text = "frmRestaurantsViewer"
        Me.GroupBox1.ResumeLayout(False)
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents cmbLayers As System.Windows.Forms.ComboBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents cmdShow As System.Windows.Forms.Button
    Friend WithEvents cmdHide As System.Windows.Forms.Button
    Friend WithEvents cmdRestaurants As System.Windows.Forms.Button
    Friend WithEvents cmdBars As System.Windows.Forms.Button
    Friend WithEvents cmdLounges As System.Windows.Forms.Button
    Friend WithEvents cmdDiners As System.Windows.Forms.Button
    Friend WithEvents cmdCafes As System.Windows.Forms.Button
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents cmbVenues As System.Windows.Forms.ComboBox
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents cmbCategories As System.Windows.Forms.ComboBox
    Friend WithEvents Category As System.Windows.Forms.Label
    Friend WithEvents lblDescription As System.Windows.Forms.Label
    Friend WithEvents lblWebsite As System.Windows.Forms.Label
    Friend WithEvents cmdSelect As System.Windows.Forms.Button
    Friend WithEvents cmdFlash As System.Windows.Forms.Button
    Friend WithEvents txtSearch As System.Windows.Forms.TextBox
    Friend WithEvents Label3 As System.Windows.Forms.Label
End Class
