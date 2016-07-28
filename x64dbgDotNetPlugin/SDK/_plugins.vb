Imports System.Reflection
Imports System.Runtime.InteropServices

Module _plugins
    Const PLUG_SDKVERSION = 1
    Public pluginHandle As Integer

    Public Delegate Sub CBPLUGIN(ByVal cbType As CBTYPE, ByRef callbackInfo As Object)
    Public Delegate Function CBPLUGINCOMMAND(ByVal argc As Integer, ByVal argv() As String) As Boolean
    <DllImport("x64_dbg.dll")> _
    Public Function _plugin_menuclear(ByVal hMenu As Integer) As Boolean
    End Function
    <DllImport("x64_dbg.dll")> _
    Public Sub _plugin_logprintf(ByVal format As String, ByVal ParamArray LegacyParamArray() As Object)
    End Sub
    <DllImport("x64_dbg.dll")> _
    Public Sub _plugin_logputs(ByVal text As String)
    End Sub
    <DllImport("x64_dbg.dll")> _
    Public Sub _plugin_registercallback(ByVal pluginHandle As Integer, ByVal cbType As CBTYPE, ByVal cbPlugin As CBPLUGIN)
    End Sub
    <DllImport("x64_dbg.dll")> _
    Public Function _plugin_unregistercallback(ByVal pluginHandle As Integer, ByVal cbType As CBTYPE) As Boolean
    End Function
    <DllImport("x64_dbg.dll")> _
    Public Function _plugin_menuaddentry(ByVal hMenu As Integer, ByVal hEntry As Integer, ByVal title As String) As Boolean
    End Function
    <DllImport("x64_dbg.dll")> _
    Public Function _plugin_menuadd(ByVal hMenu As Integer, ByVal title As String) As Int32
    End Function
    <DllImport("x64_dbg.dll")> _
    Public Function _plugin_registercommand(ByVal pluginHandle As Integer, ByVal command As String, ByVal cbCommand As CBPLUGINCOMMAND, ByVal debugonly As Boolean) As Boolean
    End Function


    Public Enum CBTYPE
        CB_INITDEBUG 'PLUG_CB_INITDEBUG
        CB_STOPDEBUG 'PLUG_CB_STOPDEBUG
        CB_CREATEPROCESS 'PLUG_CB_CREATEPROCESS
        CB_EXITPROCESS 'PLUG_CB_EXITPROCESS
        CB_CREATETHREAD 'PLUG_CB_CREATETHREAD
        CB_EXITTHREAD 'PLUG_CB_EXITTHREAD
        CB_SYSTEMBREAKPOINT 'PLUG_CB_SYSTEMBREAKPOINT
        CB_LOADDLL 'PLUG_CB_LOADDLL
        CB_UNLOADDLL 'PLUG_CB_UNLOADDLL
        CB_OUTPUTDEBUGSTRING 'PLUG_CB_OUTPUTDEBUGSTRING
        CB_EXCEPTION 'PLUG_CB_EXCEPTION
        CB_BREAKPOINT 'PLUG_CB_BREAKPOINT
        CB_PAUSEDEBUG 'PLUG_CB_PAUSEDEBUG
        CB_RESUMEDEBUG 'PLUG_CB_RESUMEDEBUG
        CB_STEPPED 'PLUG_CB_STEPPED
        CB_ATTACH 'PLUG_CB_ATTACHED (before attaching, after CB_INITDEBUG)
        CB_DETACH 'PLUG_CB_DETACH (before detaching, before CB_STOPDEBUG)
        CB_DEBUGEVENT 'PLUG_CB_DEBUGEVENT (called on any debug event)
        CB_MENUENTRY 'PLUG_CB_MENUENTRY
        CB_WINEVENT 'PLUG_CB_WINEVENT
        CB_WINEVENTGLOBAL 'PLUG_CB_WINEVENTGLOBAL
    End Enum
    <StructLayout(LayoutKind.Sequential)> Public Structure PLUG_CB_MENUENTRY
        Dim hEntry As Int32
    End Structure

    <StructLayout(LayoutKind.Sequential)> Public Structure PLUG_INITSTRUCT
        '//provided by the debugger
        'int pluginHandle;
        Dim pluginHandle As Int32
        '//provided by the pluginit function
        'int sdkVersion;
        Dim sdkVersion As Int32
        'int pluginVersion;
        Dim pluginVersion As Int32
        'char pluginName[256];
        <MarshalAsAttribute(UnmanagedType.ByValTStr, SizeConst:=256)>
        Dim pluginName As String
    End Structure

    <StructLayout(LayoutKind.Sequential)> Public Structure PLUG_SETUPSTRUCT
        '//provided by the debugger
        'HWND hwndDlg; //gui window handle
        Dim hwndDlg As IntPtr
        'int hMenu; //plugin menu handle
        Dim hMenu As Int32
        'int hMenuDisasm; //plugin disasm menu handle
        Dim hMenuDisasm As Int32
        'int hMenuDump; //plugin dump menu handle
        Dim hMenuDump As Int32
        'int hMenuStack; //plugin stack menu handle
        Dim hMenuStack As Int32
    End Structure
    'callback structures
    <StructLayout(LayoutKind.Sequential)> Public Structure PLUG_CB_INITDEBUG
        Dim szFileName As String
    End Structure
    Public Delegate Function PLUGINIT(ByVal initStruct As PLUG_INITSTRUCT) As Boolean
    Public Delegate Function PLUGSTOP() As Boolean
    Public Delegate Sub PLUGSETUP(ByVal setupStruct As PLUG_SETUPSTRUCT)

    'callback structures
    <StructLayout(LayoutKind.Sequential)> Public Structure PLUG_DATA
        'HINSTANCE hPlugin;
        Dim hPlugin As IntPtr

        'PLUGINIT pluginit;
        Dim pluginit As PLUGINIT

        'PLUGSTOP plugstop;
        Dim plugstop As PLUGSTOP

        'PLUGSETUP plugsetup;
        Dim plugsetup As PLUGSETUP

        'int hMenu;
        Dim hMenu As Int64

        'PLUG_INITSTRUCT initStruct;
        Dim initStruct As PLUG_INITSTRUCT

    End Structure

    <StructLayout(LayoutKind.Sequential)> Public Structure PLUG_CB_STOPDEBUG
        Dim reserved As UIntPtr
    End Structure
    Public Delegate Function PTHREAD_START_ROUTINE(lpThreadParameter As IntPtr) As UInteger
    <StructLayout(LayoutKind.Sequential)> Public Structure CREATE_PROCESS_DEBUG_INFO
        Public hFile As IntPtr
        Public hProcess As IntPtr
        Public hThread As IntPtr
        Public lpBaseOfImage As IntPtr
        Public dwDebugInfoFileOffset As UInteger
        Public nDebugInfoSize As UInteger
        Public lpThreadLocalBase As IntPtr
        Public lpStartAddress As PTHREAD_START_ROUTINE
        Public lpImageName As IntPtr
        Public fUnicode As UShort
    End Structure
    ' symbol type enumeration
    Public Enum SYM_TYPE
        SymNone = 0
        SymCoff
        SymCv
        SymPdb
        SymExport
        SymDeferred
        SymSym ' .sym file
        SymDia
        SymVirtual
        NumSymTypes
    End Enum

    <StructLayout(LayoutKind.Sequential)> Public Structure IMAGEHLP_MODULE64
        Public SizeOfStruct As UInteger ' set to sizeof(IMAGEHLP_MODULE64)
        Public BaseOfImage As ULong ' base load address of module
        Public ImageSize As UInteger ' virtual size of the loaded module
        Public TimeDateStamp As UInteger ' date/time stamp from pe header
        Public CheckSum As UInteger ' checksum from the pe header
        Public NumSyms As UInteger ' number of symbols in the symbol table
        Public SymType As SYM_TYPE() ' type of symbols loaded
        Public ModuleName As String ' module name
        Public ImageName As String ' image name
        Public LoadedImageName As String ' symbol file name
        ' new elements: 07-Jun-2002
        Public LoadedPdbName As String ' pdb file name
        Public CVSig As UInteger ' Signature of the CV record in the debug directories
        Public CVData As String ' Contents of the CV record
        Public PdbSig As UInteger ' Signature of PDB
        Public PdbSig70 As Guid() ' Signature of PDB (VC 7 and up)
        Public PdbAge As UInteger ' DBI age of pdb
        Public PdbUnmatched As Integer ' loaded an unmatched pdb
        Public DbgUnmatched As Integer ' loaded an unmatched dbg
        Public LineNumbers As Integer ' we have line number information
        Public GlobalSymbols As Integer ' we have internal symbol information
        Public TypeInfo As Integer ' we have type information
        ' new elements: 17-Dec-2003
        Public SourceIndexed As Integer ' pdb supports source server
        Public Publics As Integer ' contains public symbols
        ' new element: 15-Jul-2009
        Public MachineType As UInteger ' IMAGE_FILE_MACHINE_XXX from ntimage.h and winnt.h
        Public Reserved As UInteger ' Padding - don't remove.
    End Structure
    Structure PROCESS_INFORMATION
        Public hProcess As IntPtr
        Public hThread As IntPtr
        Public dwProcessId As Integer
        Public dwThreadId As Integer
    End Structure
    <StructLayout(LayoutKind.Sequential)> Public Structure PLUG_CB_CREATEPROCESS
        '    CREATE_PROCESS_DEBUG_INFO* CreateProcessInfo;
        Dim CreateProcessInfo As CREATE_PROCESS_DEBUG_INFO
        'IMAGEHLP_MODULE64* modInfo;
        Dim modInfo As IMAGEHLP_MODULE64
        'Const Char* DebugFileName;
        Dim DebugFileName As String
        'PROCESS_INFORMATION* fdProcessInfo;
        Dim fdProcessInfo As PROCESS_INFORMATION
    End Structure

    <StructLayout(LayoutKind.Sequential)> Public Structure EXIT_PROCESS_DEBUG_INFO
        Public dwExitCode As UInteger
    End Structure
    <StructLayout(LayoutKind.Sequential)> Public Structure PLUG_CB_EXITPROCESS
        Public ExitProcess As EXIT_PROCESS_DEBUG_INFO
    End Structure




End Module
