Imports System.Runtime.InteropServices
Imports System.Text

Module bridgemain
    <DllImport("x64_bridge.dll")> _
    Public Function GuiGetLineWindow(ByVal title As String, ByVal text As String) As Boolean
    End Function
    <DllImport("x64_bridge.dll")> _
    Public Function DbgValFromString(ByVal Sstring As String) As Int64
    End Function
    <DllImport("x64_bridge.dll", EntryPoint:="DbgGetModuleAt", CharSet:=CharSet.Ansi, CallingConvention:=CallingConvention.Cdecl)> _
    Public Function DbgGetModuleAt(ByVal addr As Int64, ByVal text As IntPtr) As Boolean
        'Public Function DbgGetModuleAt(ByVal addr As Int64, <MarshalAs(UnmanagedType.VBByRefStr)> ByRef text As String) As Boolean
    End Function
    <DllImport("x64_bridge.dll")> _
    Public Function DbgModBaseFromName(ByVal name As String) As Int64
    End Function
End Module

