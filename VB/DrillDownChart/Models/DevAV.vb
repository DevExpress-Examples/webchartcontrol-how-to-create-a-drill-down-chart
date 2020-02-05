Imports System
Imports System.Collections.Generic

Namespace DrillDownChart.Models
	Public Class DevAVDataItem
		Public Shared Function CreateByNameProductCategoryRegionSales(ByVal [date] As Date, ByVal productName As String, ByVal productCategory As String, ByVal region As String, ByVal sales As Decimal) As DevAVDataItem
			Dim item As New DevAVDataItem()
			item.SaleDate = [date]
			item.ProductName = productName
			item.ProductCategory = productCategory
			item.Region = region
			item.Sales = sales
			Return item
		End Function
		Private privateRegion As String
		Public Property Region() As String
			Get
				Return privateRegion
			End Get
			Private Set(ByVal value As String)
				privateRegion = value
			End Set
		End Property
		Private privateSales As Decimal
		Public Property Sales() As Decimal
			Get
				Return privateSales
			End Get
			Private Set(ByVal value As Decimal)
				privateSales = value
			End Set
		End Property
		Private privateProductCategory As String
		Public Property ProductCategory() As String
			Get
				Return privateProductCategory
			End Get
			Private Set(ByVal value As String)
				privateProductCategory = value
			End Set
		End Property
		Private privateProductName As String
		Public Property ProductName() As String
			Get
				Return privateProductName
			End Get
			Private Set(ByVal value As String)
				privateProductName = value
			End Set
		End Property
		Private privateSaleDate As Date
		Public Property SaleDate() As Date
			Get
				Return privateSaleDate
			End Get
			Private Set(ByVal value As Date)
				privateSaleDate = value
			End Set
		End Property
		Public Sub New()
		End Sub
	End Class

	Public Class DevAV
		Private ReadOnly Shared regions() As String = { "DevAV North", "DevAV South", "DevAV West", "DevAV East", "DevAV Central" }
'INSTANT VB NOTE: The field categorizedProducts was renamed since Visual Basic does not allow fields to have the same name as other class members:
		Private Shared categorizedProducts_Renamed As Dictionary(Of String, List(Of String))

		Public Shared ReadOnly Property CategorizedProducts() As Dictionary(Of String, List(Of String))
			Get
				If categorizedProducts_Renamed Is Nothing Then
					categorizedProducts_Renamed = New Dictionary(Of String, List(Of String))()
					categorizedProducts_Renamed("Cameras") = New List(Of String)() From {"Camera", "Camcorder", "Binoculars", "Flash", "Tripod"}
					categorizedProducts_Renamed("Cell Phones") = New List(Of String)() From {"Smartphone", "Mobile Phone", "Smart Watch", "Sim Card"}
					categorizedProducts_Renamed("Computers") = New List(Of String)() From {"Desktop", "Laptop", "Tablet", "Printer"}
					categorizedProducts_Renamed("TV, Audio") = New List(Of String)() From {"Television", "Home Audio", "Headphone", "DVD Player"}
					categorizedProducts_Renamed("Vehicle Electronics") = New List(Of String)() From {"GPS Unit", "Radar", "Car Alarm", "Car Accessories"}
					categorizedProducts_Renamed("Multipurpose Batteries") = New List(Of String)() From {"Battery", "Charger", "Converter", "Tester", "AC/DC Adapter"}
				End If
				Return categorizedProducts_Renamed
			End Get
		End Property

		Private Shared totalSales As List(Of DevAVDataItem)
		Public Shared Function GetTotalSales() As List(Of DevAVDataItem)
			If totalSales Is Nothing Then
				Dim rnd As New Random(Date.Now.Millisecond)
				Dim now As Date = Date.Now
				Dim endDate As New Date(now.Year, now.Month, 1)
				Dim items As New List(Of DevAVDataItem)()
				For Each region As String In regions
					Dim companyFactor As Double = rnd.NextDouble() * 0.6 + 1
					For Each productCategory As String In CategorizedProducts.Keys
						Dim categoryFactor As Double = rnd.NextDouble() * 0.6 + 1
						For Each productName As String In CategorizedProducts(productCategory)
							Dim maxSales As Integer = rnd.Next(60, 140)
							For i As Integer = 0 To 999
								If i Mod 100 = 0 Then
									maxSales = Math.Max(40, rnd.Next(maxSales - 20, maxSales + 20))
								End If
								Dim [date] As Date = endDate.AddDays(-i - 1)
								Dim sales As Decimal = Convert.ToDecimal(rnd.Next(20, maxSales) * companyFactor * categoryFactor)
								items.Add(DevAVDataItem.CreateByNameProductCategoryRegionSales([date], productName, productCategory, region, sales))
							Next i
						Next productName
					Next productCategory
				Next region
				totalSales = items
			End If
			Return totalSales
		End Function
	End Class
End Namespace