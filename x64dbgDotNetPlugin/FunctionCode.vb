Imports Microsoft.VisualBasic
Imports System.Runtime.InteropServices
Imports System.Windows.Forms
Imports RGiesecke.DllExport
Imports x64dbgDotNetPlugin.RegisteredCommands

Module FunctionCode
    Const about = 0
    Const MENU_DUMP = 1
    Const MENU_TEST = 2
    Const submenuentry = 3

    ' Public Sub _plugin_registercallback(ByVal pluginHandle As Integer, ByVal cbType As CBTYPE, ByVal cbPlugin As CBPLUGIN)
    Public Sub cbInitDebug(ByVal cbType As CBTYPE, ByRef callbackInfo As Object)
        Dim info As PLUG_CB_INITDEBUG = DirectCast(callbackInfo, PLUG_CB_INITDEBUG)
        _plugin_logprintf("DotNet test debugging of file %s started!" & ControlChars.Lf, CSByte(info.szFileName))
    End Sub

    Public Sub cbStopDebug(ByVal cbType As CBTYPE, ByRef callbackInfo As Object)
        _plugin_logputs("DotNet test debugging stopped!")
    End Sub

    Public Sub PlugIn_Init(<MarshalAs(UnmanagedType.LPStruct)> ByRef initStruct As PLUG_INITSTRUCT)
        _plugin_logprintf("[DotNet TEST] pluginHandle: %d" & ControlChars.Lf, pluginHandle)
        If (_plugin_registercommand(pluginHandle, "DotNetpluginTestCommand", AddressOf cbNetTestCommand, False) = False) Then
            _plugin_logputs("[DotNet TEST] error registering the \DotNetpluginTestCommand\ command!")
        End If
        If (_plugin_registercommand(pluginHandle, "DotNetDumpProcess", AddressOf cbDumpProcessCommand, True) = False) Then
            _plugin_logputs("[DotNet TEST] error registering the \DotNetDumpProcess\ command!")
        End If
        If (_plugin_registercommand(pluginHandle, "DotNetModuleEnum", AddressOf cbModuleEnum, True) = False) Then
            _plugin_logputs("[DotNet TEST] error registering the \DotNetModuleEnum\ command!")
        End If
        If (_plugin_registercommand(pluginHandle, "Loader", AddressOf cbLoader, True) = False) Then
            _plugin_logputs("[DotNet TEST] error registering the \Loader\ command!")
        End If

        '_plugin_registercallback(pluginHandle, CBTYPE.CB_INITDEBUG, AddressOf cbInitDebug)
        '_plugin_registercallback(pluginHandle, CBTYPE.CB_STOPDEBUG, AddressOf cbStopDebug)
        '_plugin_registercallback(pluginHandle, CBTYPE.CB_MENUENTRY, AddressOf cbStrongMenuEntry)
        '_plugin_registercallback(pluginHandle, CBTYPE.CB_LOADDLL, AddressOf CBLOADDLL)
    End Sub

    Public Sub PlugIn_Stop()
        _plugin_unregistercallback(pluginHandle, CBTYPE.CB_INITDEBUG)
        _plugin_unregistercallback(pluginHandle, CBTYPE.CB_STOPDEBUG)
    End Sub

    Public Sub PlugIn_SetUp()
        _plugin_menuaddentry(hMenu, 0, "&About...")
        _plugin_menuaddentry(hMenu, 1, "&DotNetDumpProcess")
        _plugin_menuaddentry(hMenu, 2, "&Hex Editor")
        Dim mysubmenu As Int32 = _plugin_menuadd(hMenu, "sub menu") ' //this only adds a 'fake' new menu
        _plugin_menuaddentry(mysubmenu, 3, "sub menu entry") ' //this is the new entry, it will be placed inside the submenu
        '45 will be the number of the entry presses
        'hMenu = also a submenu, but it is the submenu of the plugin
    End Sub

    <DllExport("CBLOADDLL")> _
    Public Sub CBLOADDLL(ByVal cbType As CBTYPE, ByVal info As PLUG_CB_LOADDLL)  ' For Call back if u not use IntPtr then u have to use ByVal or u will get Error in x64dbg
        'Dim ModuleInfo_Strc As New List(Of ModuleInfo)
        'Dim temp As New ModuleInfo

        'Dim lddi As New LOAD_DLL_DEBUG_INFO
        'lddi = DirectCast(Marshal.PtrToStructure(info.LoadDll, GetType(LOAD_DLL_DEBUG_INFO)), LOAD_DLL_DEBUG_INFO)
        'Dim FileHandle As IntPtr = lddi.hFile

        'Dim lddix As New IMAGEHLP_MODULE64
        'lddix = DirectCast(Marshal.PtrToStructure(info.modInfo, GetType(IMAGEHLP_MODULE64)), IMAGEHLP_MODULE64)
        ''_plugin_logputs("test")
        ''_plugin_logputs("DotNet Log value :" & lddix.ImageName.ToString)
        ''Dim s As String = info.modname
        'temp.base = lddix.BaseOfImage
        'temp.size = lddix.ImageSize
        'temp.entry = lddix.BaseOfImage

        ' '''''test
        'Dim infox As New MODINFO
        'infox.base = temp.base
        'infox.size = temp.size
        'infox.fileHandle = vbNull
        'infox.loadedSize = 0
        'infox.fileMap = vbNull
        'infox.fileMapVA = 0
        'infox.name = lddix.ModuleName


        'If StaticFileLoadW(lddix.ImageName, UE_ACCESS_READ, False, infox.fileHandle, infox.loadedSize, infox.fileMap, infox.fileMapVA) Then
        '    GetModuleInfo(info, info.fileMapVA)
        'Else
        '    info.fileHandle = Nothing
        '    info.loadedSize = 0
        '    info.fileMap = Nothing
        '    info.fileMapVA = 0
        'End If
        'ModuleInfo_Strc.Add(temp)


    End Sub
    <DllExport("CBMENUENTRY")> _
    Public Sub CBMENUENTRY(ByVal cbType As CBTYPE, ByRef info As PLUG_CB_MENUENTRY)
        'Dim info As PLUG_CB_MENUENTRY = DirectCast(callbackInfo, PLUG_CB_MENUENTRY)
        Dim temp As UInt32
        Select Case info.hEntry
            Case submenuentry
                'this will be called when submenu entry is pressed

            Case about
                MsgBox("Test DotNet Plugins For x64dbg " & Environment.NewLine & "Coded By Ahmadmansoor/exetools", MsgBoxStyle.OkOnly, "Info")
            Case MENU_DUMP
                If (DbgIsDebugging() = False) Then
                    _plugin_logputs("You need to be debugging to use this Command")
                    Exit Select
                End If
                DbgCmdExec("DotNetDumpProcess")
                'Case HexEditor_Menu
                'DbgCmdExec("HexEditor")
                '		if (!DbgIsDebugging())
                '		{break;}
                '		char argv_1[17];
                '		char argv_2[17];
                '
                '		SELECTIONDATA selection;
                '		if(GuiSelectionGet(GUI_DUMP, &selection))
                '		{
                '		_plugin_logprintf("[STRONG] %p-%p\n", selection.start, selection.end);
                '		}
                '		if (selection.start < selection.end)
                '		{
                '		temp=selection.end - selection.start + 1;
                '		}
                '		else
                '		{
                '		temp=selection.start - selection.end + 1;
                '		}		
                '		_plugin_logprintf("[STRONG] selection start: %p\n", selection.start);		
                '		_plugin_logprintf("[STRONG] selection end: %p\n", selection.end);
                '
                '		sprintf(argv_1,"%p",selection.start);
                '		sprintf(argv_2,"%p",temp);
                '		HexEditGetAddress(argv_1,argv_2);
                'case MENU_SELECTION:
                '    {
                '        SELECTIONDATA sel;
                '        char msg[256]="";
                '        GuiSelectionGet(GUI_DISASSEMBLY, &sel);
                '        sprintf(msg, "%p - %p", sel.start, sel.end);
                '        MessageBoxA(hwndDlg, msg, "Disassembly", MB_ICONINFORMATION);
                '        sel.start+=4; //expand selection
                '        GuiSelectionSet(GUI_DISASSEMBLY, &sel);

                '        GuiSelectionGet(GUI_DUMP, &sel);
                '        sprintf(msg, "%p - %p", sel.start, sel.end);
                '        MessageBoxA(hwndDlg, msg, "Dump", MB_ICONINFORMATION);
                '        sel.start+=4; //expand selection
                '        GuiSelectionSet(GUI_DUMP, &sel);

                '        GuiSelectionGet(GUI_STACK, &sel);
                '        sprintf(msg, "%p - %p", sel.start, sel.end);
                '        MessageBoxA(hwndDlg, msg, "Stack", MB_ICONINFORMATION);
                '        sel.start+=4; //expand selection
                '        GuiSelectionSet(GUI_STACK, &sel);
                '    }
                '    break;
        End Select
    End Sub

End Module
