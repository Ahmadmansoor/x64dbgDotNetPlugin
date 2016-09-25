Imports System.Runtime.InteropServices
Imports System.Text

Module bridgemain

    Public Const GUI_MAX_LINE_SIZE = 65536

    'Debugger defines
    Public Const MAX_LABEL_SIZE = 256
    Public Const MAX_COMMENT_SIZE = 512
    Public Const MAX_MODULE_SIZE = 256
    Public Const MAX_PATH = 260
    Public Const MAX_IMPORT_SIZE = 65536
    Public Const MAX_BREAKPOINT_SIZE = 256
    Public Const MAX_CONDITIONAL_EXPR_SIZE = 256
    Public Const MAX_CONDITIONAL_TEXT_SIZE = 256
    Public Const MAX_SCRIPT_LINE_SIZE = 2048
    Public Const MAX_THREAD_NAME_SIZE = 256
    Public Const MAX_WATCH_NAME_SIZE = 256
    Public Const MAX_STRING_SIZE = 512
    Public Const MAX_ERROR_SIZE = 512
    'Public Const RIGHTS_STRING_SIZE(sizeof("ERWCG") + 1)
    Public Const MAX_SECTION_SIZE = 10
    Public Const MAX_COMMAND_LINE_SIZE = 256
    Public Const MAX_MNEMONIC_SIZE = 64
    Public Const PAGE_SIZE = &H1000



    <DllImport("x64_bridge.dll")> _
    Public Function GuiGetLineWindow(ByVal title As String, ByRef text As IntPtr) As Boolean
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
    <DllImport("x64_bridge.dll")> _
    Public Function DbgIsDebugging() As Boolean
    End Function
    <DllImport("x64_bridge.dll")> _
    Public Function DbgCmdExec(ByVal cmd As String) As Boolean
    End Function

    <StructLayout(LayoutKind.Sequential)> Public Structure ICONDATA
        Dim data As IntPtr
        Dim size As Int64
    End Structure
End Module

