Imports Microsoft.VisualBasic
Imports System
Imports System.ComponentModel
Imports System.Collections.Generic
Imports System.Diagnostics
Imports System.Text

Imports DevExpress.ExpressApp
Imports DevExpress.ExpressApp.Actions
Imports DevExpress.Persistent.Base

Namespace TempCollection.Module.Win
	Partial Public Class ViewController1
		Inherits ViewController
		Public Sub New()
			InitializeComponent()
			RegisterActions(components)
			TargetViewId = "Order_DetailView"
		End Sub
		Protected Overrides Sub OnActivated()
			MyBase.OnActivated()
			AddHandler ObjectSpace.Committing, AddressOf ObjectSpace_Committing
		End Sub
		Protected Overrides Sub OnDeactivating()
			MyBase.OnDeactivating()
			RemoveHandler ObjectSpace.Committing, AddressOf ObjectSpace_Committing
		End Sub
		Private Sub ObjectSpace_Committing(ByVal sender As Object, ByVal e As CancelEventArgs)
			Dim obj As Order = CType(View.CurrentObject, Order)
			obj.UpdateGrouping()
		End Sub
	End Class
End Namespace
