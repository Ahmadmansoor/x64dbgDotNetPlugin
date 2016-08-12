Imports System.Runtime.InteropServices
Imports System.Text

Module API
    <StructLayout(LayoutKind.Sequential)> _
    Public Structure LOAD_DLL_DEBUG_INFO
        Public hFile As Int32
        Public lpBaseOfDll As Int64
        Public dwDebugInfoFileOffset As UInteger
        Public nDebugInfoSize As UInteger
        Public lpImageName As IntPtr
        Public fUnicode As UShort
    End Structure

    <DllImport("psapi.dll")> _
    Public Function GetModuleBaseNameA(ByVal hProcess As IntPtr, ByVal hModule As IntPtr, ByVal lpBaseName As StringBuilder, ByVal nSize As UInteger) As UInteger
    End Function
    <DllImport("kernel32.dll", EntryPoint:="RtlZeroMemory")>
    Public Sub ZeroMemory(ByVal dst As IntPtr, length As Integer)
    End Sub
End Module
