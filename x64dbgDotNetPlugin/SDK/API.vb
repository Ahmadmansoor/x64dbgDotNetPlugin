Imports System.Runtime.InteropServices
Imports System.Text

Module API
    <DllImport("psapi.dll")> _
    Public Function GetModuleBaseNameA(ByVal hProcess As IntPtr, ByVal hModule As IntPtr, ByVal lpBaseName As StringBuilder, ByVal nSize As UInteger) As UInteger
    End Function
    <DllImport("kernel32.dll", EntryPoint:="RtlZeroMemory")>
    Public Sub ZeroMemory(ByVal dst As IntPtr, length As Integer)
    End Sub
End Module
