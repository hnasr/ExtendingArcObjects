Imports System.Runtime.InteropServices
Imports System.Drawing
Imports ESRI.ArcGIS.ADF.BaseClasses
Imports ESRI.ArcGIS.ADF.CATIDs
Imports ESRI.ArcGIS.Framework
Imports ESRI.ArcGIS.ArcMapUI
Imports ESRI.ArcGIS.Carto
Imports System.Windows.Forms

<ComClass(cmdRestaurantsViewer.ClassId, cmdRestaurantsViewer.InterfaceId, cmdRestaurantsViewer.EventsId), _
 ProgId("Bestaurants.cmdRestaurantsViewer")> _
Public NotInheritable Class cmdRestaurantsViewer
    Inherits BaseCommand

#Region "COM GUIDs"
    ' These  GUIDs provide the COM identity for this class 
    ' and its COM interfaces. If you change them, existing 
    ' clients will no longer be able to access the class.
    Public Const ClassId As String = "928c023f-08ed-428b-9e17-4c88e867cd90"
    Public Const InterfaceId As String = "6ca35a20-fed1-406b-9620-9150b670a298"
    Public Const EventsId As String = "e607fa4a-b233-4c81-a147-7b18bea96be6"
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
        MyBase.m_caption = "Restaurants Viewer"   'localizable text 
        MyBase.m_message = "View the restaurants in tabular format and interacts with the map."   'localizable text 
        MyBase.m_toolTip = "Restaurants viewer" 'localizable text 
        MyBase.m_name = "Bestaurants_Tools_RestaurantsViewer"  'unique id, non-localizable (e.g. "MyCategory_ArcMapCommand")


        Try
            'TODO: change bitmap name if necessary
            Dim bitmapResourceName As String = Me.GetType().Name + ".bmp"
            MyBase.m_bitmap = New Bitmap(Me.GetType(), bitmapResourceName)
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
        'TODO: Add cmdRestaurantsViewer.OnClick implementation

        Dim pRestaurantsViewer As New frmRestaurantsViewer

        'set the application object so we can work with it int he form
        pRestaurantsViewer.ArcMapApplication = _application

        'create the parent wrapper
        Dim pArcMapApplication As New ArcMapWrapper
        pArcMapApplication.ArcMapApplication = _application

        'show the form 
        pRestaurantsViewer.Show(pArcMapApplication)

        'Iapplication -> imxdocument -> Imap -> ILayer
        Dim pMxDoc As IMxDocument = _application.Document

        'get the map from the document 
        Dim pMap As IMap = pMxDoc.FocusMap

        'get the first layer in the map
        'Dim pLayer As ILayer = pMap.Layer(0)
        'add the layer to the drop down list 
        'pRestaurantsViewer.cmbLayers.Items.Add(pLayer.Name)

        'loop through all layers and add them to the list 
        For i As Integer = 0 To pMap.LayerCount - 1
            Dim pLayer As ILayer = pMap.Layer(i)
            pRestaurantsViewer.cmbLayers.Items.Add(pLayer.Name)

        Next




    End Sub
End Class


Public Class ArcMapWrapper
    Implements IWin32Window

    Private _application As IApplication
    Public Property ArcMapApplication() As IApplication
        Get
            Return _application
        End Get
        Set(ByVal value As IApplication)
            _application = value
        End Set
    End Property

    Public Sub New()

    End Sub

    Public ReadOnly Property Handle As IntPtr Implements IWin32Window.Handle
        Get
            Return New IntPtr(_application.hWnd)
        End Get
    End Property
End Class


