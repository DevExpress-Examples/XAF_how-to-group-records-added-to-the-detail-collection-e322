Imports Microsoft.VisualBasic
Imports DevExpress.Persistent.Base
Imports DevExpress.Persistent.BaseImpl
Imports DevExpress.Xpo
Imports DevExpress.Xpo.DB
Imports System.Collections.Generic
Imports System.ComponentModel

Namespace TempCollection.Module
	<DefaultClassOptions, DefaultProperty("Description")> _
	Public Class Order
		Inherits BaseObject
		Private _description As String
		Public Sub New(ByVal session As Session)
			MyBase.New(session)
		End Sub
		Private dictionaryCore As Dictionary(Of String, Integer) = Nothing
		Public Sub CollectGroupingInfo()
			Items.Sorting.Clear()
			Items.Sorting.Add(New SortProperty("Id", SortingDirection.Ascending))
			dictionaryCore = New Dictionary(Of String, Integer)()
			For Each item As Item In Items
				If dictionaryCore.ContainsKey(item.Id) Then
					dictionaryCore(item.Id) += item.Quantity
				Else
					dictionaryCore.Add(item.Id, item.Quantity)
				End If
			Next item
		End Sub
		Public Sub UpdateGrouping()
			CollectGroupingInfo()
			Session.Delete(Items)
			For Each pair As KeyValuePair(Of String, Integer) In dictionaryCore
				Dim newItem As New Item(Session)
				newItem.Id=pair.Key
				newItem.Quantity = pair.Value
				Items.Add(newItem)
			Next pair
		End Sub
		Public Property Description() As String
			Get
				Return _description
			End Get
			Set(ByVal value As String)
				SetPropertyValue("Description", _description, value)
			End Set
		End Property
		<Association("RealAssociation", GetType(Item)), Aggregated> _
		Public ReadOnly Property Items() As XPCollection(Of Item)
			Get
				Return GetCollection(Of Item)("Items")
			End Get
		End Property
	End Class
End Namespace