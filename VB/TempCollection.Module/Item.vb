Imports Microsoft.VisualBasic
Imports DevExpress.Persistent.Base
Imports DevExpress.Persistent.BaseImpl
Imports DevExpress.Xpo
Imports System.ComponentModel

Namespace TempCollection.Module
	<DefaultClassOptions, DefaultProperty("Id")> _
	Public Class Item
		Inherits BaseObject
		Private _id As String
		Private _quantity As Integer
		Private _Order As Order
		Public Sub New(ByVal session As Session)
			MyBase.New(session)
		End Sub
		Public Property Id() As String
			Get
				Return _id
			End Get
			Set(ByVal value As String)
				SetPropertyValue("Id", _id, value)
			End Set
		End Property
		Public Property Quantity() As Integer
			Get
				Return _quantity
			End Get
			Set(ByVal value As Integer)
				SetPropertyValue("Quantity", _quantity, value)
			End Set
		End Property
		<Association("RealAssociation")> _
		Public Property Order() As Order
			Get
				Return _Order
			End Get
			Set(ByVal value As Order)
				SetPropertyValue("Order", _Order, value)
			End Set
		End Property
	End Class
End Namespace