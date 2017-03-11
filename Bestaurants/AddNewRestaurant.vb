Imports System.Runtime.InteropServices
Imports System.Drawing
Imports ESRI.ArcGIS.ADF.BaseClasses
Imports ESRI.ArcGIS.ADF.CATIDs
Imports ESRI.ArcGIS.Framework
Imports ESRI.ArcGIS.ArcMapUI
Imports System.Windows.Forms
Imports ESRI.ArcGIS.Geometry
Imports ESRI.ArcGIS.Carto
Imports ESRI.ArcGIS.Geodatabase

<ComClass(AddNewRestaurant.ClassId, AddNewRestaurant.InterfaceId, AddNewRestaurant.EventsId), _
 ProgId("Bestaurants.AddNewRestaurant")> _
Public NotInheritable Class AddNewRestaurant
    Inherits BaseTool
    Private Const FOOD_AND_DRINKS As String = "Food_And_Drinks"


#Region "COM GUIDs"
    ' These  GUIDs provide the COM identity for this class 
    ' and its COM interfaces. If you change them, existing 
    ' clients will no longer be able to access the class.
    Public Const ClassId As String = "6c688800-85fc-43bd-8ca7-4697883ac080"
    Public Const InterfaceId As String = "5e141048-7343-44f9-8948-8c4e8c786815"
    Public Const EventsId As String = "d17cff34-2f85-4abd-bee3-08be1058cd83"
#End Region

#Region "COM Registration Function(s)"
    <ComRegisterFunction(), ComVisibleAttribute(False)> _
    Public Shared Sub RegisterFunction(ByVal registerType As Type)
        ' Required for ArcGIS Component Category Registrar support
        ArcGISCategoryRegistration(registerType)

        'Add any COM registration code after the ArcGISCategoryRegistration() call

    End Sub

    <ComUnregisterFunction(), ComVisibleAttribute(False)> _
    Public Shared Sub UnregisterFunction(ByVal registerType As Type)
        ' Required for ArcGIS Component Category Registrar support
        ArcGISCategoryUnregistration(registerType)

        'Add any COM unregistration code after the ArcGISCategoryUnregistration() call

    End Sub

#Region "ArcGIS Component Category Registrar generated code"
    Private Shared Sub ArcGISCategoryRegistration(ByVal registerType As Type)
        Dim regKey As String = String.Format("HKEY_CLASSES_ROOT\CLSID\{{{0}}}", registerType.GUID)
        MxCommands.Register(regKey)

    End Sub
    Private Shared Sub ArcGISCategoryUnregistration(ByVal registerType As Type)
        Dim regKey As String = String.Format("HKEY_CLASSES_ROOT\CLSID\{{{0}}}", registerType.GUID)
        MxCommands.Unregister(regKey)

    End Sub

#End Region
#End Region


    Private _application As IApplication

    ' A creatable COM class must have a Public Sub New() 
    ' with no parameters, otherwise, the class will not be 
    ' registered in the COM registry and cannot be created 
    ' via CreateObject.
    Public Sub New()
        MyBase.New()

        ' TODO: Define values for the public properties
        MyBase.m_category = "Bestaurants_Tools"  'localizable text 
        MyBase.m_caption = "Add a new restaurant"   'localizable text 
        MyBase.m_message = "Click on the map to add a new restaurant and populate its information"   'localizable text 
        MyBase.m_toolTip = "Add a new restaurant" 'localizable text 
        MyBase.m_name = "Bestaurants_Tools_AddNewRestaurant"  'unique id, non-localizable (e.g. "MyCategory_ArcMapCommand")

        Try
            'TODO: change resource name if necessary
            Dim bitmapResourceName As String = Me.GetType().Name + ".bmp"
            MyBase.m_bitmap = New Bitmap(Me.GetType(), bitmapResourceName)
            MyBase.m_cursor = New System.Windows.Forms.Cursor(Me.GetType(), Me.GetType().Name + ".cur")
        Catch ex As Exception
            System.Diagnostics.Trace.WriteLine(ex.Message, "Invalid Bitmap")
        End Try
    End Sub


    Public Overrides Sub OnCreate(ByVal hook As Object)
        If Not hook Is Nothing Then
            _application = CType(hook, IApplication)

            'Disable if it is not ArcMap
            If TypeOf hook Is IMxApplication Then
                MyBase.m_enabled = True
            Else
                MyBase.m_enabled = False
            End If
        End If

        ' TODO:  Add other initialization code
    End Sub

    Public Overrides Sub OnClick()
        'TODO: Add AddNewRestaurant.OnClick implementation
    End Sub

    Public Overrides Sub OnMouseDown(ByVal Button As Integer, ByVal Shift As Integer, ByVal X As Integer, ByVal Y As Integer)
        'TODO: Add AddNewRestaurant.OnMouseDown implementation

    End Sub

    Public Overrides Sub OnMouseMove(ByVal Button As Integer, ByVal Shift As Integer, ByVal X As Integer, ByVal Y As Integer)
        'TODO: Add AddNewRestaurant.OnMouseMove implementation
    End Sub

    Public Overrides Sub OnMouseUp(ByVal Button As Integer, ByVal Shift As Integer, ByVal X As Integer, ByVal Y As Integer)
        'TODO: Add AddNewRestaurant.OnMouseUp implementation

        'what do you want to do when the user clicks on the MAP (LOCATION)
        'MsgBox("X: " & X & vbCrLf & "Y:" & Y)

        Try

            'convert the mouse x and y into map coordinates
            Dim pmXdoc As IMxDocument = _application.Document

            Dim pRestaurantLocation As IPoint = pmXdoc.ActiveView.ScreenDisplay.DisplayTransformation.ToMapPoint(X, Y)

            Dim pEditRestaurant As New frmEditRestaurant

            'create the parent wrapper
            Dim pArcMapApplication As New ArcMapWrapper
            pArcMapApplication.ArcMapApplication = _application

            pEditRestaurant.ArcMapApplication = _application
            pEditRestaurant.RestaurantLocation = pRestaurantLocation

            pEditRestaurant.Show(pArcMapApplication)

        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try
    End Sub


    ''' <summary>
    ''' Get the layer by name 
    ''' </summary>
    ''' <param name="sLayerName"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Private Function getLayerByName(sLayerName As String) As ILayer
        Try

            Dim pMxDoc As IMxDocument = _application.Document
            Dim pMap As IMap = pMxDoc.FocusMap

            For i As Integer = 0 To pMap.LayerCount - 1
                Dim pLayer As ILayer = pMap.Layer(i)

                If pLayer.Name = sLayerName Then
                    Return pLayer
                End If

            Next

            'if you are here then you didn't find the layer... return nothing
            Return Nothing


        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try


    End Function


End Class

