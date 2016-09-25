Imports System.Runtime.InteropServices

Module moduleX
    Public Structure MODINFO
        Public base As Int64 ' Module base
        Public size As Int64 ' Module size
        Public hash As Int64 ' Full module name hash
        Public entry As Int64 ' Entry point
        <MarshalAs(UnmanagedType.ByValTStr, SizeConst:=MAX_MODULE_SIZE - 1)> Public name As String ' Module name (without extension)
        <MarshalAs(UnmanagedType.ByValTStr, SizeConst:=MAX_MODULE_SIZE - 1)> Public extension As String  ' File extension
        <MarshalAs(UnmanagedType.ByValTStr, SizeConst:=MAX_PATH - 1)> Public path As String ' File path (in UTF8)
        '<MarshalAs(UnmanagedType.ByValArray)> Public sections() As MODSECTIONINFO
        '<MarshalAs(UnmanagedType.ByValArray)> Public _imports As MODIMPORTINFO
        'Public name As IntPtr ' Module name (without extension)
        'Public extension As IntPtr  ' File extension
        'Public path As IntPtr ' File path (in UTF8)
        Public sections() As IntPtr
        Public _imports As IntPtr
        Public fileHandle As System.IntPtr
        Public loadedSize As UInteger
        Public fileMap As System.IntPtr
        Public fileMapVA As System.IntPtr
        Public party As Integer ' Party. Currently used value: 0: User, 1: System
    End Structure

    Public Structure MODSECTIONINFO
        Public addr As Int64 ' Virtual address
        Public size As Int64 ' Virtual size
        <MarshalAs(UnmanagedType.ByValTStr, SizeConst:=(MAX_SECTION_SIZE * 5) - 1)> Public name As String  ' Escaped section name
    End Structure
    Public Structure MODIMPORTINFO
        Public addr As Int64 ' Virtual address
        <MarshalAs(UnmanagedType.ByValTStr, SizeConst:=MAX_IMPORT_SIZE - 1)> Public name As String  '(har(MAX_IMPORT_SIZE - 1) {})
        <MarshalAs(UnmanagedType.ByValTStr, SizeConst:=MAX_MODULE_SIZE - 1)> Public moduleName As String    '(New Char(MAX_MODULE_SIZE - 1) {})
    End Structure



End Module


