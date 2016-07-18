Imports Microsoft.VisualBasic
Imports System.Runtime.InteropServices

Module FunctionCode
    ' Public Sub _plugin_registercallback(ByVal pluginHandle As Integer, ByVal cbType As CBTYPE, ByVal cbPlugin As CBPLUGIN)
    Public Sub cbInitDebug(ByVal cbType As CBTYPE, ByRef callbackInfo As Object)
        Dim info As PLUG_CB_INITDEBUG = DirectCast(callbackInfo, PLUG_CB_INITDEBUG)
        _plugin_logprintf("test debugging of file %s started!" & ControlChars.Lf, CSByte(info.szFileName))
    End Sub

    Public Sub cbStopDebug(ByVal cbType As CBTYPE, ByRef callbackInfo As Object)
        _plugin_logputs("test debugging stopped!")
    End Sub

    Public Sub PlugIn_Init(<MarshalAs(UnmanagedType.LPStruct)> ByRef initStruct As PLUG_INITSTRUCT)
        _plugin_logprintf("[TEST] pluginHandle: %d" & ControlChars.Lf, pluginHandle)
        _plugin_registercallback(pluginHandle, CBTYPE.CB_INITDEBUG, AddressOf cbInitDebug)
        _plugin_registercallback(pluginHandle, CBTYPE.CB_STOPDEBUG, AddressOf cbStopDebug)
        '_plugin_registercallback(pluginHandle, CB_MENUENTRY, cbStrongMenuEntry)
        '_plugin_registercallback(pluginHandle, CB_LOADDLL, CBLOADDLL)
    End Sub

    Public Sub PlugIn_Stop()
        _plugin_unregistercallback(pluginHandle, CBTYPE.CB_INITDEBUG)
        _plugin_unregistercallback(pluginHandle, CBTYPE.CB_STOPDEBUG)
    End Sub

    Public Sub PlugIn_SetUp()
        _plugin_menuaddentry(hMenu, 0, "&About...")

    End Sub
End Module
