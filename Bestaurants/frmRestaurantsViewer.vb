Imports ESRI.ArcGIS.Framework
Imports ESRI.ArcGIS.Carto
Imports ESRI.ArcGIS.ArcMapUI
Imports ESRI.ArcGIS.Geodatabase
Imports ESRI.ArcGIS.Display
Imports ESRI.ArcGIS.Geometry

Public Class frmRestaurantsViewer
    Private Const FOOD_AND_DRINKS As String = "Food_And_Drinks"


    Private _application As IApplication
    Public Property ArcMapApplication() As IApplication
        Get
            Return _application
        End Get
        Set(ByVal value As IApplication)
            _application = value
        End Set
    End Property


    Private Sub cmdShow_Click(sender As Object, e As EventArgs) Handles cmdShow.Click


        Dim pSelectedLayer As ILayer = getLayerByName(FOOD_AND_DRINKS)
        pSelectedLayer.Visible = True

        Dim pMxdoc As IMxDocument = _application.Document
        pMxdoc.UpdateContents()
        pMxdoc.ActiveView.Refresh()

    End Sub

    Private Sub cmdHide_Click(sender As Object, e As EventArgs) Handles cmdHide.Click

        Dim pSelectedLayer As ILayer = getLayerByName(FOOD_AND_DRINKS)
        pSelectedLayer.Visible = False

        Dim pMxdoc As IMxDocument = _application.Document
        pMxdoc.UpdateContents()
        pMxdoc.ActiveView.Refresh()


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


    Private Sub setDefinitionQuery(categorycode As Integer)

        setDefinitionQuery("CATEGORY =" & categorycode)

    End Sub

    Private Sub setDefinitionQuery(whereclause As String)

        Dim pSelectedLayer As ILayer = getLayerByName(FOOD_AND_DRINKS)
        'this can give an error if pSelectLayer is NOT a feature layer...
        Dim pFLayerDef As IFeatureLayerDefinition = pSelectedLayer
        pFLayerDef.DefinitionExpression = whereclause

        Dim pMxdoc As IMxDocument = _application.Document
        pMxdoc.UpdateContents()
        pMxdoc.ActiveView.Refresh()
    End Sub

    Private Sub FilterCategory(sender As Object, e As EventArgs) Handles cmdRestaurants.Click, cmdBars.Click, cmdCafes.Click, cmdLounges.Click, cmdDiners.Click
        Dim pButton As Windows.Forms.Button = sender

        setDefinitionQuery(pButton.Tag)

        'populate the drop down list with the venues for the particular cateogyr (tag) 

        'we need to get the selected layer 
        Dim pSelectedLayer As ILayer = getLayerByName(FOOD_AND_DRINKS)

        'assuming this layer is a feature layer 
        Dim pFeatureLayer As IFeatureLayer = pSelectedLayer

        'get the source data, the feature class
        Dim pFeatureClass As IFeatureClass = pFeatureLayer.FeatureClass

        Dim pQFilter As IQueryFilter = New QueryFilter

        pQFilter.WhereClause = "CATEGORY =" & pButton.Tag

        'Get the feature cursor to iteriate through the features 
        Dim pFeatureCursor As IFeatureCursor = pFeatureClass.Search(pQFilter, False)

        'populate the venues 
        PopulateVenues(pFeatureCursor)

    End Sub

    ''' <summary>
    ''' Populate the venues drop down list with the venues from a cursor 
    ''' </summary>
    ''' <param name="pFCursor"></param>
    ''' <remarks></remarks>
    Private Sub PopulateVenues(pFCursor As IFeatureCursor)

        Dim pFeature As IFeature

        pFeature = pFCursor.NextFeature

        'clear the combo box before populating it again...
        cmbVenues.Items.Clear()

        Do Until pFeature Is Nothing

            Dim index As Integer = pFeature.Fields.FindField("NAME") 'O(n) 
            Dim sName As String = pFeature.Value(index)

            'create a restaurant object

            Dim pRestaurant As Restaurant = New Restaurant()
            pRestaurant.Name = sName
            pRestaurant.ObjectID = pFeature.OID
            pRestaurant.Description = pFeature.Value(pFeature.Fields.FindField("DESCRIPTION"))
            pRestaurant.WebSite = pFeature.Value(pFeature.Fields.FindField("WEBSITE"))

            'DO SOMETHING
            cmbVenues.Items.Add(pRestaurant)
            pFeature = pFCursor.NextFeature
        Loop
    End Sub

    Private Sub cmbLayers_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cmbLayers.SelectedIndexChanged

        'we need to get the selected layer 
        Dim pSelectedLayer As ILayer = getLayerByName(FOOD_AND_DRINKS)

        'assuming this layer is a feature layer 
        Dim pFeatureLayer As IFeatureLayer = pSelectedLayer

        'get the source data, the feature class
        Dim pFeatureClass As IFeatureClass = pFeatureLayer.FeatureClass

        'Get the feature cursor to iteriate through the features 
        Dim pFeatureCursor As IFeatureCursor = pFeatureClass.Search(Nothing, False)

        PopulateVenues(pFeatureCursor)

        'BEGIN
        '=>First
        'Second
        'Third


        'this will give me the next feature 
        'BEGIN
        '=>First
        'Second
        'Third
        '  pFeature = pFeatureCursor.NextFeature
        'BEGIN
        'First
        '=>Second
        'Third
        ' pFeature = pFeatureCursor.NextFeature


        'BEGIN
        'First
        'Second
        '=>Third
        'pFeature = pFeatureCursor.NextFeature


        'BEGIN
        'First
        'Second
        'Third
        '=>NULL
        'pFeature = pFeatureCursor.NextFeature









    End Sub


    Private Sub Label1_Click(sender As Object, e As EventArgs) Handles Label1.Click

    End Sub

    Private Sub frmRestaurantsViewer_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        '_application should be populated...
        PopulateCategories()

    End Sub


    Private Sub PopulateCategories()
        Dim pLayer As IFeatureLayer = getLayerByName(FOOD_AND_DRINKS)

        Dim pFeatureClass As IFeatureClass = pLayer.FeatureClass

        'IFeaturelayer =>IFeatureClass
        'FeatureClass implements IFeatureClass.. ISubtypes 
        'this will only work if your feature class HAS subtypes 
        Dim pSubtypes As ISubtypes = pFeatureClass

        Dim eSubtypes As IEnumSubtype = pSubtypes.Subtypes
        'BAR 0 
        'RESTAURANT 1 
        'CAFES 2 ...
        eSubtypes.Reset()
        Dim code As Integer
        Dim sSubtypeText As String

        sSubtypeText = eSubtypes.Next(code)

        cmbCategories.Items.Clear()
        Do While sSubtypeText <> ""
            Dim pCategory As Category = New Category
            pCategory.CategoryCode = code
            pCategory.CategoryName = sSubtypeText
            cmbCategories.Items.Add(pCategory)
            sSubtypeText = eSubtypes.Next(code)
        Loop


    End Sub

    Private Sub cmbCategories_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cmbCategories.SelectedIndexChanged

        cmbVenues.Items.Clear()
        'category class...
        Dim pSelectedCategory As Category = cmbCategories.SelectedItem

        'set the definition ...
        setDefinitionQuery(pSelectedCategory.CategoryCode)

        'populate the drop down list with the venues for the particular cateogyr (tag) 

        'we need to get the selected layer 
        Dim pSelectedLayer As ILayer = getLayerByName(FOOD_AND_DRINKS)

        'assuming this layer is a feature layer 
        Dim pFeatureLayer As IFeatureLayer = pSelectedLayer

        'get the source data, the feature class
        Dim pFeatureClass As IFeatureClass = pFeatureLayer.FeatureClass

        Dim pQFilter As IQueryFilter = New QueryFilter

        pQFilter.WhereClause = "CATEGORY =" & pSelectedCategory.CategoryCode

        'Get the feature cursor to iteriate through the features 
        Dim pFeatureCursor As IFeatureCursor = pFeatureClass.Search(pQFilter, False)

        'populate the venues 
        PopulateVenues(pFeatureCursor)

    End Sub

    Private Sub cmbVenues_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cmbVenues.SelectedIndexChanged

        Dim pRestaurant As Restaurant = cmbVenues.SelectedItem

        lblDescription.Text = pRestaurant.Description
        lblWebsite.Text = pRestaurant.WebSite

    End Sub

    Private Sub cmdSelect_Click(sender As Object, e As EventArgs) Handles cmdSelect.Click
        'get the restaurant feature, object 

        Dim pRestaurant As Restaurant = cmbVenues.SelectedItem

        If pRestaurant Is Nothing Then Return

        Dim pFlayer As IFeatureLayer = getLayerByName(FOOD_AND_DRINKS)
        'get the feature class 
        Dim pFeatureClass As IFeatureClass = pFlayer.FeatureClass

        Dim pFeature As IFeature = pFeatureClass.GetFeature(pRestaurant.ObjectID)

        Dim pMxdoc As IMxDocument = _application.Document

        Dim pMap As IMap = pMxdoc.FocusMap

        'clear features before selection

        pMap.ClearSelection()
        'select your feature 

        pMap.SelectFeature(pFlayer, pFeature)
        'refresh to see your changes 

        pMxdoc.ActiveView.Refresh()



    End Sub

    Private Sub cmdFlash_Click(sender As Object, e As EventArgs) Handles cmdFlash.Click

        'draw, hide, draw , hide
        'get the restaurant feature, object 
        Dim pRestaurant As Restaurant = cmbVenues.SelectedItem

        'check if null
        If pRestaurant Is Nothing Then Return

        Dim pFlayer As IFeatureLayer = getLayerByName(FOOD_AND_DRINKS)
        'get the feature class 
        Dim pFeatureClass As IFeatureClass = pFlayer.FeatureClass

        Dim pFeature As IFeature = pFeatureClass.GetFeature(pRestaurant.ObjectID)


        Dim pMxdoc As IMxDocument = _application.Document
        'get the screen display so we can start drawing 
        Dim pScreenDisplay As IScreenDisplay = pMxdoc.ActiveView.ScreenDisplay

        pScreenDisplay.StartDrawing(pScreenDisplay.hDC, ESRI.ArcGIS.Display.esriScreenCache.esriNoScreenCache)

        'get the point geometry 
        Dim pPoint As IGeometry = pFeature.Shape

        Dim pMarkerSymbol As IMarkerSymbol = New SimpleMarkerSymbol() 'implements iSybmol 
        pMarkerSymbol.Size = 15

        Dim pColor As IRgbColor = New RgbColor
        pColor.RGB = RGB(255, 0, 0)
        pMarkerSymbol.Color = pColor

        'pen 
        Dim pSymbol As ISymbol = pMarkerSymbol
        pSymbol.ROP2 = esriRasterOpCode.esriROPNotXOrPen

        'Symbol 
        pScreenDisplay.SetSymbol(pMarkerSymbol)

        'draw something
        pScreenDisplay.DrawPoint(pPoint)

        'wait
        Threading.Thread.Sleep(200)

        'draw again
        pScreenDisplay.DrawPoint(pPoint)

        'wait
        Threading.Thread.Sleep(200)

        'draw
        pScreenDisplay.DrawPoint(pPoint)

        'wait 
        Threading.Thread.Sleep(200)

        'draw 
        pScreenDisplay.DrawPoint(pPoint)


        pScreenDisplay.FinishDrawing()


    End Sub

    Private Sub cmdSearch_Click(sender As Object, e As EventArgs)




    End Sub

    Private Sub txtSearch_TextChanged(sender As Object, e As EventArgs) Handles txtSearch.TextChanged
        'search restaurant by name
        'we need to get the selected layer 
        Dim pSelectedLayer As ILayer = getLayerByName(FOOD_AND_DRINKS)

        'assuming this layer is a feature layer 
        Dim pFeatureLayer As IFeatureLayer = pSelectedLayer

        'get the source data, the feature class
        Dim pFeatureClass As IFeatureClass = pFeatureLayer.FeatureClass

        Dim pQFilter As IQueryFilter = New QueryFilter

        Dim sName As String = txtSearch.Text
        'refer to sql syntex 
        'Mercy's 
        'NAME LIKE '%Mercy''s%'

        sName = sName.Replace("'", "''")
        sName = sName.ToUpper
        pQFilter.WhereClause = "UPPER(NAME) LIKE '%" & sName & "%'"


        'NAME LIKE '%F%'  'MACDOLANDS, HARDEEZ, KFC 
        'Get the feature cursor to iteriate through the features 
        Dim pFeatureCursor As IFeatureCursor = pFeatureClass.Search(pQFilter, False)

        'populate the venues 
        PopulateVenues(pFeatureCursor)

        'set the definition query 
        setDefinitionQuery(pQFilter.WhereClause)


    End Sub
End Class