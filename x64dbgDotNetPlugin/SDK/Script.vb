Imports System.Runtime.InteropServices
Imports x64dbgDotNetPlugin.bridgemain
Module Script

    '<StructLayout(LayoutKind.Sequential)> Structure ModuleInfo
    '    Public base As Int64
    '    Public size As Int64
    '    Public entry As Int64
    '    Public sectionCount As Integer
    '    <MarshalAs(UnmanagedType.ByValTStr, SizeConst:=MAX_MODULE_SIZE)> Public name As String
    '    <MarshalAs(UnmanagedType.ByValTStr, SizeConst:=MAX_PATH)> Public path As String
    'End Structure
    '<StructLayout(LayoutKind.Sequential)> Structure ModuleSectionInfo
    '    Public addr As Int64
    '    Public size As Int64
    '    Public name As String
    'End Structure

    <DllImport("x64dbg.dll")> _
    Public Function InfoFromAddr(ByVal addr As Int64, ByRef info As IntPtr) As Boolean 'IntPtr=ModuleInfo
    End Function
    <DllImport("x64dbg.dll")>
    Public Function InfoFromName(ByVal name As String, ByRef info As IntPtr) As Boolean
    End Function
    <DllImport("x64dbg.dll")>
    Public Function BaseFromAddr(ByVal addr As Int64) As Int64
    End Function
    <DllImport("x64dbg.dll")>
    Public Function BaseFromName(ByVal name As String) As Int64
    End Function
    <DllImport("x64dbg.dll")>
    Public Function SizeFromAddr(ByVal addr As Int64) As Int64
    End Function
    <DllImport("x64dbg.dll")>
    Public Function SizeFromName(ByVal name As String) As Int64
    End Function
    <DllImport("x64dbg.dll")>
    Public Function NameFromAddr(ByVal addr As Int64, ByRef name As IntPtr) As Boolean 'name as string
    End Function
    <DllImport("x64dbg.dll")>
    Public Function PathFromAddr(ByVal addr As Int64, ByRef path As IntPtr) As Boolean 'path as string
    End Function
    <DllImport("x64dbg.dll")>
    Public Function PathFromName(ByVal name As String, ByRef path As IntPtr) As Boolean 'path as string
    End Function
    <DllImport("x64dbg.dll")>
    Public Function EntryFromAddr(ByVal addr As Int64) As Int64
    End Function
    <DllImport("x64dbg.dll")>
    Public Function EntryFromName(ByVal name As String) As Int64
    End Function
    <DllImport("x64dbg.dll")>
    Public Function SectionCountFromAddr(ByVal addr As Int64) As Integer
    End Function
    <DllImport("x64dbg.dll")>
    Public Function SectionCountFromName(ByVal name As String) As Integer
    End Function
    <DllImport("x64dbg.dll")>
    Public Function SectionFromAddr(ByVal addr As Int64, ByVal number As Integer, ByRef section As IntPtr) As Boolean 'section as ModuleSectionInfo
    End Function
    <DllImport("x64dbg.dll")>
    Public Function SectionFromName(ByVal name As String, ByVal number As Integer, ByRef section As IntPtr) As Boolean 'section as ModuleSectionInfo
    End Function
    <DllImport("x64dbg.dll")>
    Public Function SectionListFromAddr(ByVal addr As Int64, ByVal list As List(Of ModuleSectionInfo)) As Boolean
    End Function
    '<DllImport("x64dbg.dll")>
    'Public Function SectionListFromName(ByVal name As String, ByVal list As List(Of ModuleSectionInfo)) As Boolean
    'End Function
    <DllImport("x64dbg.dll")>
    Public Function GetMainModuleInfo(ByVal info As IntPtr) As Boolean 'info as ModuleInfo
    End Function
    <DllImport("x64dbg.dll")>
    Public Function GetMainModuleBase() As Int64
    End Function
    <DllImport("x64dbg.dll")>
    Public Function GetMainModuleSize() As Int64
    End Function
    <DllImport("x64dbg.dll")>
    Public Function GetMainModuleEntry() As Int64
    End Function
    <DllImport("x64dbg.dll")>
    Public Function GetMainModuleSectionCount() As Integer
    End Function
    <DllImport("x64dbg.dll")>
    Public Function GetMainModuleName(ByRef name As String) As Boolean 'name[MAX_MODULE_SIZE]
    End Function
    <DllImport("x64dbg.dll")>
    Public Function GetMainModulePath(ByRef path As String) As Boolean 'path[MAX_PATH]
    End Function
    <DllImport("x64dbg.dll")>
    Public Function GetMainModuleSectionList(ByVal list As List(Of ModuleSectionInfo)) As Boolean 'caller has the responsibility to free the list
    End Function
    <DllImport("x64dbg.dll")>
    Function ModInfoFromAddr(ByVal Address As Int64) As MODINFO
    End Function

    'Declare Function GetList Lib "x64dbg.dll" Alias "GetList" (ByRef list As IntPtr) As Boolean
    '<DllImport("x64dbg.dll", EntryPoint:="GetList", CharSet:=CharSet.Ansi, CallingConvention:=CallingConvention.Cdecl)>
    'Public Function GetList(ByRef list As IntPtr) As Boolean 'List(Of ModuleInfo) 'caller has the responsibility to free the list
    'End Function
    'Public Function GetList(ByRef list As ModuleInfo) As Boolean 'List(Of ModuleInfo) 'caller has the responsibility to free the list
    '    Dim modList As New List(Of ModuleInfo)
    'End Function

    <DllImport("x64dbg.dll", CallingConvention:=CallingConvention.Cdecl, EntryPoint:="?GetList@Module@Script@@YA_NPEAUListInfo@@@Z")>
    Function GetList(ByRef listInfo As List(Of ModuleInfo)) As Boolean
    End Function

    'Public Function SectionListFromAddrX(ByVal addr As Int64, ByVal list As List(Of ModuleSectionInfo)) As Boolean
    '    'Dim modInfo As ModuleInfo = ModInfoFr
    'End Function
    'Function GetList(ByRef listInfo As IntPtr) As Boolean


    Public Structure ModuleInfo
        Public base As IntPtr
        Public size As IntPtr
        Public entry As IntPtr
        Public sectionCount As Integer
        <MarshalAs(UnmanagedType.ByValTStr, SizeConst:=MAX_MODULE_SIZE)>
        Public name As String
        <MarshalAs(UnmanagedType.ByValTStr, SizeConst:=MAX_PATH)>
        Public path As String
    End Structure

    Public Structure ModuleSectionInfo
        Public addr As IntPtr
        Public size As IntPtr
        <MarshalAs(UnmanagedType.ByValTStr, SizeConst:=MAX_SECTION_SIZE * 5)>
        Public name As String
    End Structure

    <DllImport("x64dbg.dll", CallingConvention:=CallingConvention.Cdecl, EntryPoint:="?GetList@Module@Script@@YA_NPEAUListInfo@@@Z")>
    Private Function ScriptModuleGetList(ByRef listInfo As ListInfo) As Boolean
    End Function

    Public Function GetList() As ModuleInfo()
        Dim listInfo = New ListInfo()
        Return listInfo.ToArray(Of ModuleInfo)(ScriptModuleGetList(listInfo))
    End Function

    <DllImport("x64dbg.dll", CallingConvention:=CallingConvention.Cdecl, EntryPoint:="?SectionListFromAddr@Module@Script@@YA_N_KPEAUListInfo@@@Z")>
    Private Function ScriptModuleSectionListFromAddr(ByVal addr As IntPtr, ByRef listInfo As ListInfo) As Boolean
    End Function

    Public Function SectionListFromAddr(ByVal addr As IntPtr) As ModuleSectionInfo()
        Dim listInfo = New ListInfo()
        Return listInfo.ToArray(Of ModuleSectionInfo)(ScriptModuleSectionListFromAddr(addr, listInfo))
    End Function


End Module
