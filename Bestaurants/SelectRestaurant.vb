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
Imports ESRI.ArcGIS.Display

<ComClass(SelectRestaurant.ClassId, SelectRestaurant.InterfaceId, SelectRestaurant.EventsId), _
 ProgId("Bestaurants.SelectRestaurant")> _
Public NotInheritable Class SelectRestaurant
    Inherits BaseTool



    Private Const FOOD_AND_DRINKS As String = "Food_And_Drinks"



#Region "COM GUIDs"
    ' These  GUIDs provide the COM identity for this class 
    ' and its COM interfaces. If you change them, existing 
    ' clients will no longer be able to access the class.
    Public Const ClassId As String = "74e6609f-fef0-462d-aa3f-0a305c0cede0"
    Public Const InterfaceId As String = "301bf6c6-4fb7-45de-a499-b0be0b502e2a"
    Public Const EventsId As String = "621881da-cce9-4363-99ba-c13b96786689"
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
        MyBase.m_caption = "Select a restaurant"   'localizable text 
        MyBase.m_message = "Click on the map to view the restaurant information"   'localizable text 
        MyBase.m_toolTip = "Select Restaurant" 'localizable text 
        MyBase.m_name = "Bestaurants_Tools_SelectRestaurant"  'unique id, non-localizable (e.g. "MyCategory_ArcMapCommand")

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
        'TODO: Add SelectRestaurant.OnClick implementation
    End Sub

    Public Overrides Sub OnMouseDown(ByVal Button As Integer, ByVal Shift As Integer, ByVal X As Integer, ByVal Y As Integer)
        'TODO: Add SelectRestaurant.OnMouseDown implementation
    End Sub

    Public Overrides Sub OnMouseMove(ByVal Button As Integer, ByVal Shift As Integer, ByVal X As Integer, ByVal Y As Integer)
        'TODO: Add SelectRestaurant.OnMouseMove implementation
    End Sub

    Public Overrides Sub OnMouseUp(ByVal Button As Integer, ByVal Shift As Integer, ByVal X As Integer, ByVal Y As Integer)
        'TODO: Add SelectRestaurant.OnMouseUp implementation

        'Spatial filter
        Dim pMxdoc As IMxDocument = _application.Document

        Dim pPoint As IPoint = pMxdoc.ActiveView.ScreenDisplay.DisplayTransformation.ToMapPoint(X, Y)
        'this interface impelments all geometry types 
        Dim pTopo As ITopologicalOperator = pPoint
        Dim pBufferGeometry As IGeometry = pTopo.Buffer(60)

        DrawBufferGeometry(pBufferGeometry)


        Dim pFlayer As IFeatureLayer = getLayerByName(FOOD_AND_DRINKS)

        Dim pFeatureClass As IFeatureClass = pFlayer.FeatureClass
        Dim pDataset As IDataset = pFeatureClass

        Dim pWorkspace As IWorkspace = pDataset.Workspace


        Dim pSFilter As ISpatialFilter = New SpatialFilter
        pSFilter.Geometry = pBufferGeometry
        pSFilter.SpatialRel = esriSpatialRelEnum.esriSpatialRelIntersects
        'spatial filter class implements IQueryFilter... 
        Dim pFCursor As IFeatureCursor = pFeatureClass.Search(pSFilter, False)


        Dim pFeature As IFeature = pFCursor.NextFeature

        Do Until pFeature Is Nothing

            'MsgBox(pFeature.OID)
            Dim pRestaurantForm As New frmEditRestaurant
            Dim pArcMapWrapper As New ArcMapWrapper
            pArcMapWrapper.ArcMapApplication = _application
            pRestaurantForm.ArcMapApplication = _application
            pRestaurantForm.cmdSave.Visible = False
            pRestaurantForm.cmdEdit.Visible = True
            pRestaurantForm.cmdDelete.Visible = True
            pRestaurantForm.Show(pArcMapWrapper)
            pRestaurantForm.ObjectID = pFeature.OID
            pRestaurantForm.txtName.Text = pFeature.Value(pFeature.Fields.FindField("NAME"))
            pRestaurantForm.txtWebSite.Text = pFeature.Value(pFeature.Fields.FindField("WEBSITE"))
            pRestaurantForm.txtDescription.Text = pFeature.Value(pFeature.Fields.FindField("DESCRIPTION"))

            Dim lCategoryCode As Integer = pFeature.Value(pFeature.Fields.FindField("CATEGORY"))

            For Each pCategory As Category In pRestaurantForm.cmbCategories.Items
                If pCategory.CategoryCode = lCategoryCode Then
                    pRestaurantForm.cmbCategories.SelectedItem = pCategory
                    Exit For
                End If
            Next


            '--calculate the rating for the selected restaurant 
            Dim pFeatureWorkspace As IFeatureWorkspace = pWorkspace
            Dim pReviewTable As ITable = pFeatureWorkspace.OpenTable("VENUES_REVIEW")

            'give me all reviews for the selected restaurant. 
            Dim pQfilter As IQueryFilter = New QueryFilter
            pQfilter.WhereClause = "VENUE_OBJECTID=" & pFeature.OID

            Dim pCursor As ICursor = pReviewTable.Search(pQfilter, True)

            Dim pRow As IRow = pCursor.NextRow
            Dim lSumRating As Double = 0
            Dim lTotalReviews As Integer = 0

            Do Until pRow Is Nothing
                lTotalReviews = lTotalReviews + 1
                lSumRating = lSumRating + pRow.Value(pRow.Fields.FindField("RATING")) '1 is poor, 2 is fair, 3 is average, 4 is good , 5 is excellent 

                pRow = pCursor.NextRow
            Loop

            Dim lAverageRating As Double

            If lTotalReviews > 0 Then
                lAverageRating = lSumRating / lTotalReviews
                pRestaurantForm.lblRating.Text = Math.Round(lAverageRating, 1)
                pRestaurantForm.lblNumReviews.Text = "Based on " & lTotalReviews & " review(s)"
                pRestaurantForm.StarRating1.SetRating(lAverageRating)
            Else
                pRestaurantForm.lblRating.Text = "No Reviews"
                pRestaurantForm.lblNumReviews.Text = ""
            End If

            Exit Sub

            pFeature = pFCursor.NextFeature
        Loop


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



    ''' <summary>
    ''' Draws the geometry on the map .. 
    ''' </summary>
    ''' <param name="pGeometry"></param>
    ''' <remarks></remarks>
    Public Sub DrawBufferGeometry(pGeometry As IGeometry)
        Dim pMxdoc As IMxDocument = _application.Document
        'get the screen display so we can start drawing 
        Dim pScreenDisplay As IScreenDisplay = pMxdoc.ActiveView.ScreenDisplay

        pScreenDisplay.StartDrawing(pScreenDisplay.hDC, ESRI.ArcGIS.Display.esriScreenCache.esriNoScreenCache)

        Dim pBufferSymbol As ISimpleFillSymbol = New SimpleFillSymbol

        pBufferSymbol.Style = esriSimpleFillStyle.esriSFSDiagonalCross

        pScreenDisplay.SetSymbol(pBufferSymbol)

        pScreenDisplay.DrawPolygon(pGeometry)

        pScreenDisplay.FinishDrawing()


    End Sub
End Class

