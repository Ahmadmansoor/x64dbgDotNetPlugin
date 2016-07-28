Imports System.Runtime.InteropServices

Module bridgemain
    <DllImport("x64_bridge.dll")> _
    Public Function GuiGetLineWindow(ByVal title As String, ByVal text As String) As Boolean
    End Function
    <DllImport("x64_bridge.dll")> _
    Public Function DbgValFromString(ByVal Sstring As String) As Int64
    End Function
    <DllImport("x64_bridge.dll")> _
    Public Function DbgGetModuleAt(ByVal addr As Int64, ByVal text As String) As Boolean
    End Function
    <DllImport("x64_bridge.dll")> _
    Public Function DbgModBaseFromName(ByVal name As String) As Int64
    End Function
End Module
