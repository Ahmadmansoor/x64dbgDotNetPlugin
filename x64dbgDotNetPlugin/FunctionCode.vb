Imports Microsoft.VisualBasic
Imports System.Runtime.InteropServices
Imports System.Windows.Forms
Imports RGiesecke.DllExport
Imports x64dbgDotNetPlugin.RegisteredCommands

Module FunctionCode
    Const about = 0
    Const GotoAPI = 1
    Const HexEditor_Menu = 2
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
        If (_plugin_registercommand(pluginHandle, "DotNetplugin", AddressOf cbNetTestCommand, False) = False) Then
            _plugin_logputs("[DotNet TEST] error registering the \plugin1\ command!")
        End If

        If (_plugin_registercommand(pluginHandle, "DotNetDumpProcess", AddressOf cbDumpProcessCommand, True) = False) Then
            _plugin_logputs("[DotNet TEST] error registering the \DumpProcess\ command!")
        End If



        '_plugin_registercallback(pluginHandle, CBTYPE.CB_INITDEBUG, AddressOf cbInitDebug)
        '_plugin_registercallback(pluginHandle, CBTYPE.CB_STOPDEBUG, AddressOf cbStopDebug)
        '_plugin_registercallback(pluginHandle, CBTYPE.CB_MENUENTRY, AddressOf cbStrongMenuEntry)
        '_plugin_registercallback(pluginHandle, CB_LOADDLL, CBLOADDLL)
    End Sub

    Public Sub PlugIn_Stop()
        _plugin_unregistercallback(pluginHandle, CBTYPE.CB_INITDEBUG)
        _plugin_unregistercallback(pluginHandle, CBTYPE.CB_STOPDEBUG)
    End Sub

    Public Sub PlugIn_SetUp()
        _plugin_menuaddentry(hMenu, 0, "&About...")
        _plugin_menuaddentry(hMenu, 1, "&Go To APi")
        _plugin_menuaddentry(hMenu, 2, "&Hex Editor")
        Dim mysubmenu As Int32 = _plugin_menuadd(hMenu, "sub menu") ' //this only adds a 'fake' new menu
        _plugin_menuaddentry(mysubmenu, 3, "sub menu entry") ' //this is the new entry, it will be placed inside the submenu
        '45 will be the number of the entry presses
        'hMenu = also a submenu, but it is the submenu of the plugin
    End Sub

    <DllExport("CBMENUENTRY")> _
    Public Sub CBMENUENTRY(ByVal cbType As CBTYPE, ByRef info As PLUG_CB_MENUENTRY)
        'Dim info As PLUG_CB_MENUENTRY = DirectCast(callbackInfo, PLUG_CB_MENUENTRY)
        Dim temp As UInt32
        Select Case info.hEntry
            Case submenuentry
                'this will be called when submenu entry is pressed

            Case about
                'DbgCmdExec("DumpProcess");
                'C++ TO VB CONVERTER TODO TASK: The HWND argument in the MessageBox call is ignored:
                'ORIGINAL LINE: MessageBoxA(GuiGetWindowHandle(),"Strong x64_dbg Plugins ,Coded By Ahmadmansoor&mrexodia /exetools","Info",0);
                MsgBox("Strong x64_dbg Plugins ,Coded By Ahmadmansoor&mrexodia /exetools", MsgBoxStyle.OkOnly, "Info")
            Case GotoAPI
                '		if (!DbgIsDebugging())
                '		{break;}	
                '		_plugin_logputs("[GoTODialog] Show GoTO Dialog!");
                'GoToDialogInNewThread();		
                'DbgCmdExec("GTD")
            Case HexEditor_Menu
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
