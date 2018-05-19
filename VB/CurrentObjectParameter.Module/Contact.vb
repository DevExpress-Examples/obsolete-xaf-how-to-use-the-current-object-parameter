Imports Microsoft.VisualBasic
Imports System
Imports System.ComponentModel

Imports DevExpress.Xpo

Imports DevExpress.ExpressApp
Imports DevExpress.Persistent.Base
Imports DevExpress.Persistent.BaseImpl
Imports DevExpress.Persistent.Validation

Namespace CurrentObjectParameter.Module
	<DefaultClassOptions> _
	Public Class Contact
		Inherits BaseObject
		Public Sub New(ByVal session As Session)
			MyBase.New(session)
		End Sub

		Public Property Name() As String
			Get
				Return GetPropertyValue(Of String)("Name")
			End Get
			Set(ByVal value As String)
				SetPropertyValue(Of String)("Name", value)
			End Set
		End Property

		<Association("Contact-Department")> _
		Public Property Department() As Department
			Get
				Return GetPropertyValue(Of Department)("Department")
			End Get
			Set(ByVal value As Department)
				SetPropertyValue(Of Department)("Department", value)
			End Set
		End Property

		<DataSourceCriteria("Department = '@This.Department'")> _
		Public Property Position() As Position
			Get
				Return GetPropertyValue(Of Position)("Position")
			End Get
			Set(ByVal value As Position)
				SetPropertyValue(Of Position)("Position", value)
			End Set
		End Property
	End Class

	<DefaultClassOptions, FriendlyKeyPropertyAttribute("Title")> _
	Public Class Position
		Inherits BaseObject
		Public Sub New(ByVal session As Session)
			MyBase.New(session)
		End Sub

		Public Property Title() As String
			Get
				Return GetPropertyValue(Of String)("Title")
			End Get
			Set(ByVal value As String)
				SetPropertyValue(Of String)("Title", value)
			End Set
		End Property

		<Association("Department-Position", GetType(Department))> _
		Public Property Department() As Department
			Get
				Return GetPropertyValue(Of Department)("Department")
			End Get
			Set(ByVal value As Department)
				SetPropertyValue(Of Department)("Department", value)
			End Set
		End Property
	End Class

	<DefaultClassOptions, FriendlyKeyPropertyAttribute("Title")> _
	Public Class Department
		Inherits BaseObject
		Public Sub New(ByVal session As Session)
			MyBase.New(session)
		End Sub

		Public Property Title() As String
			Get
				Return GetPropertyValue(Of String)("Title")
			End Get
			Set(ByVal value As String)
				SetPropertyValue(Of String)("Title", value)
			End Set
		End Property

		<Association("Contact-Department", GetType(Contact))> _
		Public ReadOnly Property Contacts() As XPCollection
			Get
				Return GetCollection("Contacts")
			End Get
		End Property

		<Association("Department-Position", GetType(Position))> _
		Public ReadOnly Property Positions() As XPCollection
			Get
				Return GetCollection("Positions")
			End Get
		End Property
	End Class

End Namespace
