Public Class Restaurant


    Private _name As String
    Public Property Name() As String
        Get
            Return _name
        End Get
        Set(ByVal value As String)
            _name = value
        End Set
    End Property



    Private _website As String
    Public Property WebSite() As String
        Get
            Return _website
        End Get
        Set(ByVal value As String)
            _website = value
        End Set
    End Property

    Private _description As String
    Public Property Description() As String
        Get
            Return _description
        End Get
        Set(ByVal value As String)
            _description = value
        End Set
    End Property


    Private _objectid As String
    Public Property ObjectID() As String
        Get
            Return _objectid
        End Get
        Set(ByVal value As String)
            _objectid = value
        End Set
    End Property


    Public Overrides Function ToString() As String
        Return _name
    End Function



End Class
