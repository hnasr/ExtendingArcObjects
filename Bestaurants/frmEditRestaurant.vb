Imports ESRI.ArcGIS.Carto
Imports ESRI.ArcGIS.Geodatabase
Imports ESRI.ArcGIS.ArcMapUI
Imports ESRI.ArcGIS.Framework
Imports ESRI.ArcGIS.Geometry

Public Class frmEditRestaurant

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

    Private _RestaurantLocation As IPoint
    Public Property RestaurantLocation() As IPoint
        Get
            Return _RestaurantLocation
        End Get
        Set(ByVal value As IPoint)
            _RestaurantLocation = value
        End Set
    End Property


    Private _objectID As Long
    Public Property ObjectID() As Long
        Get
            Return _objectID
        End Get
        Set(ByVal value As Long)
            _objectID = value
        End Set
    End Property





    Private Sub frmEditRestaurant_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        PopulateCategories()

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

    End Sub

    Private Sub cmdSave_Click(sender As Object, e As EventArgs) Handles cmdSave.Click


        'check the data ..
        If txtName.Text = "" Or txtWebSite.Text = "" Or cmbCategories.SelectedItem Is Nothing Then
            MsgBox("Some values are required to complete this operation.!!", MsgBoxStyle.Information)
            Return
        End If

        Dim pMxdoc As IMxDocument = _application.Document

        Dim pPoint As IPoint = RestaurantLocation  '

        ' MsgBox("Map X:" & pPoint.X & vbCrLf & "Map Y: " & pPoint.Y)

        'create feature , assign the geometry to the feature and save the feature 
        Dim pFlayer As IFeatureLayer = getLayerByName(FOOD_AND_DRINKS)

        Dim pFeatureclass As IFeatureClass = pFlayer.FeatureClass
        'featureclass implements IDataset
        Dim pDataset As IDataset = pFeatureclass

        'workspace, after so many hours of code..
        Dim pWorkspace As IWorkspace = pDataset.Workspace
        Dim pWorkspaceEdit As IWorkspaceEdit = pWorkspace
        pWorkspaceEdit.StartEditing(True)
        pWorkspaceEdit.StartEditOperation()
        'do your editing


        'ACCOUNT A, 2000000 (TRANSFER 1 M) 
        'ACCOUNT B, 0
        'TX 
        'A - 1000000
        'NETWORK PROBLEM , SERVER CRASH, ZOMBIE ..
        'B + 1000000
        'TX
        'TRANSACTION 
        'ACCOUNT A, 1000000
        'ACCOUNT B, 1000000
        'TRANSACTION 

        'create a new record in the feature class .. its empty 
        Dim pNewFeature As IFeature = pFeatureclass.CreateFeature()
        pNewFeature.Shape = pPoint
        pNewFeature.Value(pNewFeature.Fields.FindField("NAME")) = txtName.Text
        pNewFeature.Value(pNewFeature.Fields.FindField("WEBSITE")) = txtWebSite.Text
        pNewFeature.Value(pNewFeature.Fields.FindField("DESCRIPTION")) = txtDescription.Text

        Dim pCategory As Category = cmbCategories.SelectedItem
        pNewFeature.Value(pNewFeature.Fields.FindField("CATEGORY")) = pCategory.CategoryCode
        'SAVE THE FEATURE 
        pNewFeature.Store()

        'stop editing\
        pWorkspaceEdit.StopEditOperation()
        pWorkspaceEdit.StopEditing(True)


        pMxdoc.ActiveView.Refresh()
        'do not allow the user to make any more changes 

        Me.Close()

    End Sub

    Private Sub cmdEdit_Click(sender As Object, e As EventArgs) Handles cmdEdit.Click

        'get that feature 
        'create feature , assign the geometry to the feature and save the feature 
        Dim pFlayer As IFeatureLayer = getLayerByName(FOOD_AND_DRINKS)

        Dim pFeatureclass As IFeatureClass = pFlayer.FeatureClass

        Dim pFeature As IFeature = pFeatureclass.GetFeature(ObjectID)

        Dim pDataset As IDataset = pFeatureclass
        Dim pWorkspace As IWorkspace = pDataset.Workspace

        Dim pWorkspaceEdit As IWorkspaceEdit = pWorkspace
        pWorkspaceEdit.StartEditing(True)
        pWorkspaceEdit.StartEditOperation()

        Dim pCategory As Category = cmbCategories.SelectedItem

        pFeature.Value(pFeature.Fields.FindField("NAME")) = txtName.Text
        pFeature.Value(pFeature.Fields.FindField("DESCRIPTION")) = txtDescription.Text
        pFeature.Value(pFeature.Fields.FindField("WEBSITE")) = txtWebSite.Text
        pFeature.Value(pFeature.Fields.FindField("CATEGORY")) = pCategory.CategoryCode
        pFeature.Store()

        pWorkspaceEdit.StopEditOperation()
        pWorkspaceEdit.StopEditing(True)

        Dim pMxdoc As IMxDocument = _application.Document
        pMxdoc.ActiveView.Refresh()

        Me.Close()

    End Sub

    Private Sub cmdDelete_Click(sender As Object, e As EventArgs) Handles cmdDelete.Click

        'get that feature 
        'create feature , assign the geometry to the feature and save the feature 
        Dim pFlayer As IFeatureLayer = getLayerByName(FOOD_AND_DRINKS)

        Dim pFeatureclass As IFeatureClass = pFlayer.FeatureClass

        Dim pFeature As IFeature = pFeatureclass.GetFeature(ObjectID)

        Dim pDataset As IDataset = pFeatureclass
        Dim pWorkspace As IWorkspace = pDataset.Workspace

        Dim pWorkspaceEdit As IWorkspaceEdit = pWorkspace
        pWorkspaceEdit.StartEditing(True)
        pWorkspaceEdit.StartEditOperation()

        Dim pCategory As Category = cmbCategories.SelectedItem
        'delete 
        pFeature.Delete()
        pFeature.Store()

        pWorkspaceEdit.StopEditOperation()
        pWorkspaceEdit.StopEditing(True)

        Dim pMxdoc As IMxDocument = _application.Document
        pMxdoc.ActiveView.Refresh()

        Me.Close()



    End Sub

    Private Sub lblNumReviews_Click(sender As Object, e As EventArgs) Handles lblNumReviews.Click

        Dim pFlayer As IFeatureLayer = getLayerByName(FOOD_AND_DRINKS)

        Dim pDataset As IDataset = pFlayer.FeatureClass

        '--calculate the rating for the selected restaurant 
        Dim pFeatureWorkspace As IFeatureWorkspace = pDataset.Workspace
        Dim pReviewTable As ITable = pFeatureWorkspace.OpenTable("VENUES_REVIEW")

        'give me all reviews for the selected restaurant. 
        Dim pQfilter As IQueryFilter = New QueryFilter
        pQfilter.WhereClause = "VENUE_OBJECTID=" & ObjectID

        Dim pCursor As ICursor = pReviewTable.Search(pQfilter, True)

        Dim pRow As IRow = pCursor.NextRow
 

        Dim sAllReviews As String = ""

        Do Until pRow Is Nothing

            Dim dRating As Double = pRow.Value(pRow.Fields.FindField("RATING")) '1 is poor, 2 is fair, 3 is average, 4 is good , 5 is excellent 
            Dim sReview As String = pRow.Value(pRow.Fields.FindField("REVIEW"))
            Dim sUser As String = pRow.Value(pRow.Fields.FindField("USER"))
            Dim sDate As String = pRow.Value(pRow.Fields.FindField("REVIEW_DATE"))

            sAllReviews = sAllReviews & vbCrLf & "Reviewed by " & sUser & " (" & dRating & ") on " & sDate & vbCrLf & sReview & vbCrLf & vbCrLf & "--------------------" & vbCrLf

            pRow = pCursor.NextRow
        Loop

        MsgBox(sAllReviews, MsgBoxStyle.Information)

    End Sub

    Private Sub cmdAddReview_Click(sender As Object, e As EventArgs) Handles cmdAddReview.Click


        'addd a new review to the reviews table
        Dim pFlayer As IFeatureLayer = getLayerByName(FOOD_AND_DRINKS)

        Dim pDataset As IDataset = pFlayer.FeatureClass

        '--calculate the rating for the selected restaurant 
        Dim pFeatureWorkspace As IFeatureWorkspace = pDataset.Workspace
        Dim pReviewTable As ITable = pFeatureWorkspace.OpenTable("VENUES_REVIEW")

        Dim pWorkspaceEdit As IWorkspaceEdit = pFeatureWorkspace
        pWorkspaceEdit.StartEditing(True)
        pWorkspaceEdit.StartEditOperation()

        'our editing
        Dim pNewRow As IRow = pReviewTable.CreateRow()
        pNewRow.Value(pNewRow.Fields.FindField("VENUE_OBJECTID")) = ObjectID
        pNewRow.Value(pNewRow.Fields.FindField("USER")) = txtUser.Text
        pNewRow.Value(pNewRow.Fields.FindField("RATING")) = cmbRating.Text
        pNewRow.Value(pNewRow.Fields.FindField("REVIEW")) = txtReview.Text
        pNewRow.Value(pNewRow.Fields.FindField("REVIEW_DATE")) = Now
        pNewRow.Store()

        pWorkspaceEdit.StopEditOperation()
        pWorkspaceEdit.StopEditing(True)



    End Sub
End Class