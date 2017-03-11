Public Class Category

    Private _categoryname As String
    Public Property CategoryName() As String
        Get
            Return _categoryname
        End Get
        Set(ByVal value As String)
            _categoryname = value
        End Set
    End Property


    Private _categorycode As String
    Public Property CategoryCode() As String
        Get
            Return _categorycode
        End Get
        Set(ByVal value As String)
            _categorycode = value
        End Set
    End Property

    Public Overrides Function ToString() As String
        Return _categoryname
    End Function



End Class
