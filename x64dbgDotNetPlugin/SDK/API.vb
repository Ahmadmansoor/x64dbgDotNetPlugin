Imports System.Runtime.InteropServices
Imports System.Text

Module API
    <DllImport("psapi.dll")> _
    Public Function GetModuleBaseNameA(ByVal hProcess As IntPtr, ByVal hModule As IntPtr, ByVal lpBaseName As StringBuilder, ByVal nSize As UInteger) As UInteger
    End Function
End Module
