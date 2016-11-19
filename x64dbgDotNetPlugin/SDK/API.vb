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

    <DllImport("kernel32.dll", SetLastError:=True, CharSet:=CharSet.Ansi)> _
    Public Function LoadLibrary(ByVal lpFileName As String) As IntPtr
    End Function
    <DllImport("kernel32.dll", SetLastError:=True, EntryPoint:="FreeLibrary")> _
    Public Function FreeLibrary(ByVal hModule As IntPtr) As Boolean
    End Function
    <DllImport("kernel32.dll")> _
    Public Function FindResourceEx(ByVal hModule As IntPtr, ByVal lpType As IntPtr, ByVal lpName As IntPtr, ByVal wLanguage As UShort) As IntPtr
    End Function
    <DllImport("kernel32.dll", SetLastError:=True)> _
    Public Function FindResource(hModule As IntPtr, lpName As Integer, lpType As Integer) As IntPtr
    End Function
    <DllImport("kernel32.dll")> _
    Public Function LockResource(hResData As IntPtr) As IntPtr
    End Function
    <DllImport("kernel32.dll", SetLastError:=False)> _
    Public Function BeginUpdateResource(ByVal pFileName As String, _
    <MarshalAs(UnmanagedType.Bool)> ByVal bDeleteExistingResources As Boolean) As IntPtr
    End Function
    <DllImport("kernel32.dll", EntryPoint:="UpdateResource", SetLastError:=True)> _
    Public Function UpdateResource(hUpdate As IntPtr, lpType As IntPtr, lpName As IntPtr, wLanguage As UShort, <MarshalAs(UnmanagedType.LPArray, SizeParamIndex:=5)> lpData As Byte(), cbData As UInteger) As <MarshalAs(UnmanagedType.Bool)> Boolean
    End Function
    '<DllImport("kernel32.dll", EntryPoint:="UpdateResource", SetLastError:=True)> _
    'Public Function UpdateResource(hUpdate As IntPtr, lpType As IntPtr, lpName As IntPtr, wLanguage As UShort, lpData As IntPtr, cbData As UInteger) As <MarshalAs(UnmanagedType.Bool)> Boolean
    'End Function
    <DllImport("kernel32.dll", SetLastError:=True)> _
    Public Function SizeofResource(hModule As IntPtr, hResInfo As IntPtr) As UInteger
    End Function
    <DllImport("kernel32.dll", SetLastError:=True, EntryPoint:="CopyMemory")>
    Public Sub CopyMemory(destination As IntPtr, source As IntPtr, length As UInteger)
    End Sub
    <DllImport("kernel32.dll", SetLastError:=True)> _
    Public Function LoadResource(hModule As IntPtr, hResInfo As IntPtr) As IntPtr
    End Function
    <DllImport("kernel32.dll", setlasterror:=True)> _
    Public Function EndUpdateResource(ByVal hUpdate As IntPtr, ByVal fDiscard As Boolean) As Boolean
    End Function
    <DllImport("kernel32.dll", SetLastError:=True)> _
    Public Function ReadProcessMemory( _
    ByVal hProcess As IntPtr, _
    ByVal lpBaseAddress As IntPtr, _
    <Out()> ByVal lpBuffer As Byte(), _
    ByVal dwSize As Integer, _
    ByRef lpNumberOfBytesRead As Integer) As Boolean
    End Function

    '<DllImport("kernel32.dll", SetLastError:=True)> _
    'Public Shared Function ReadProcessMemory( _
    'ByVal hProcess As IntPtr, _
    'ByVal lpBaseAddress As IntPtr, _
    '<Out(), MarshalAs(UnmanagedType.AsAny)> ByVal lpBuffer As Object, _
    'ByVal dwSize As Integer, _
    'ByRef lpNumberOfBytesRead As Integer) As Boolean
    'End Function

    '<DllImport("kernel32.dll", SetLastError:=True)> _
    'Public Shared Function ReadProcessMemory( _
    'ByVal hProcess As IntPtr, _
    'ByVal lpBaseAddress As IntPtr, _
    'ByVal lpBuffer As IntPtr, _
    'ByVal iSize As Integer, _
    'ByRef lpNumberOfBytesRead As Integer) As Boolean
    'End Function
End Module
