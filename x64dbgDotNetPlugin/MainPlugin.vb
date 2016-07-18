Imports System
Imports System.Linq
Imports System.Runtime.InteropServices
Imports RGiesecke.DllExport
Imports x64dbgDotNetPlugin._plugins
Imports x64dbgDotNetPlugin.FunctionCode
Module MainPlugin
    Const plugin_name = ".net Test"
    Const plugin_version = 1
    Public hwndDlg As IntPtr
    Public hMenu As Int64
    <DllExport("pluginit")> _
    Public Function pluginit(ByRef initStruct As PLUG_INITSTRUCT) As Boolean
        pluginHandle = Marshal.GetHINSTANCE(System.Reflection.Assembly.GetExecutingAssembly.GetModules()(0)).ToInt32()
        initStruct.sdkVersion = 1
        initStruct.pluginVersion = 1
        initStruct.pluginName = plugin_name
        'pluginHandle = initStruct.pluginHandle
        PlugIn_Init(initStruct)
        Return True
    End Function
    <DllExport("plugstop")> _
    Private Function plugstop() As Boolean
        PlugIn_Stop()
        Return True
    End Function
    <DllExport("plugsetup")> _
    Private Sub plugsetup(ByRef setupStruct As PLUG_SETUPSTRUCT)
        hwndDlg = setupStruct.hwndDlg
        hMenu = setupStruct.hMenu
        PlugIn_SetUp()
    End Sub



    '<DllExport("TEST")> _
    'Private Function TEST(ByVal s As Integer) As Boolean
    '    MsgBox(s.ToString, MsgBoxStyle.OkOnly, "OK")
    '    Return True
    'End Function

End Module
