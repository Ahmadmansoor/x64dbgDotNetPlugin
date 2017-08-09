Imports System.Text
Imports System.Runtime.InteropServices
Imports System.Windows.Forms
Imports x64dbgDotNetPlugin.Script
Imports x64dbgDotNetPlugin._plugins
Imports x64dbgDotNetPlugin.Plog
Imports x64dbgDotNetPlugin.Extensions
Module RegisteredCommands
    Const MAX_MODULE_SIZE = 256
    Public Function cbNetTestCommand(ByVal argc As Integer, ByVal argv() As String) As Boolean
        _plugin_logputs("[.net TEST] .Net test command!")
        Dim line As String = String.Empty
        'Dim LinePtr As IntPtr
        'Dim retvalue As Boolean = GuiGetLineWindow("test", LinePtr)
        'line = Marshal.PtrToStringAnsi(LinePtr)
        line = InputBox("Enter value pls", "NetTest")
        If (line Is Nothing Or line = "") Then
            _plugin_logputs("[TEST] cancel pressed!")
        Else
            _plugin_logputs("[TEST] line: " & line)
        End If
        Return True
    End Function


    'DumpProcess [EntryPointVA]
    Public Function cbDumpProcessCommand(ByVal argc As Integer, ByVal argv() As String) As Boolean
        Dim entry As Int64
        If argc < 2 Then
            entry = GetContextData(UE_CIP)
        Else
            entry = DbgValFromString(argv(1))
        End If
        ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
        '' test to get the string from text in the Function DbgGetModuleAt(ByVal addr As Int64, ByVal text As IntPtr) As Boolean
        'Dim incoming As IntPtr = Marshal.AllocHGlobal(256)
        'Dim retVal As String = ""
        'Try
        '    'ZeroMemory(incoming, 256)  no need to use 
        '    DbgGetModuleAt(entry, incoming)
        '    retVal = Marshal.PtrToStringAnsi(incoming) ' here it must be used PtrToStringAnsi as we define this <DllImport("x64_bridge.dll", EntryPoint:="DbgGetModuleAt", CharSet:=CharSet.Ansi, CallingConvention:=CallingConvention.Cdecl)> _
        '    Marshal.FreeHGlobal(incoming)
        '    Return True
        '    Exit Function
        'Catch ex As Exception
        '    ' Add some exception handling here '
        '    MsgBox(ex.ToString, MsgBoxStyle.OkOnly, "Error")
        'End Try
        ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
        Dim _modIntPtr As IntPtr = Marshal.AllocHGlobal(256) 'Define a Pointer to the memoery which hold the string 
        Dim _mod As String = String.Empty ' Define the variable which will hold the string later 
        If Not DbgGetModuleAt(entry, _modIntPtr) Then
            _plugin_logprintf("[DotNet TEST] no module at %p..." & ControlChars.Lf, entry)
            Return False
        End If
        _mod = Marshal.PtrToStringAnsi(_modIntPtr)
        Dim base As Int64 = DbgModBaseFromName(_mod)
        If base = Nothing Then
            _plugin_logputs("[DotNet TEST] could not get module base...")
            Return False
        End If
        Dim _PROCESS_INFORMATION As PROCESS_INFORMATION = Marshal.PtrToStructure(TitanGetProcessInformation(), GetType(PROCESS_INFORMATION))
        Dim hProcess As System.IntPtr = _PROCESS_INFORMATION.hProcess
        Dim _mods As StringBuilder = New StringBuilder() ' we use StringBuilder because the size of string will changed to get more char like ntdll to ntdll.dll
        _mods.Append(_mod)
        'Dim x As Int64 = GetModuleBaseNameA(hProcess, base, _mods, MAX_MODULE_SIZE)
        If GetModuleBaseNameA(hProcess, base, _mods, MAX_MODULE_SIZE) = Nothing Then
            _plugin_logputs("[DotNet TEST] could not get module base name...")
            Return False
        End If
        _mod = _mods.ToString
        Dim szFileName As String = _mod.Substring(0, _mod.IndexOf(".")) & "_dump" & _mod.Substring(_mod.IndexOf("."), _mod.Length - _mod.IndexOf("."))
        Dim SaveFile As New SaveFileDialog()
        'SaveFile.Filter = "Dll files (*.dll)|*.dll|exe files(*.exe)|*.exe|All Files (*.*)|*.*"
        SaveFile.Filter = "Executables (*.dll,*.exe)|*.exe|All Files (*.*)|*.*"
        'SaveFile.FilterIndex = 2
        SaveFile.RestoreDirectory = True
        SaveFile.FileName = szFileName
        If SaveFile.ShowDialog = DialogResult.OK Then
            Dim Path As String = SaveFile.FileName
            If Not DumpProcess(hProcess, base, Path, entry) Then
                _plugin_logputs("[TEST] DumpProcess failed...")
                Return False
            End If
            _plugin_logputs("[TEST] Dumping done!")
        End If
        Return True
    End Function

    Public Function cbModuleEnum(ByVal argc As Integer, ByVal argv() As String) As Boolean
        ''MsgBox("Not Done Yet ", MsgBoxStyle.OkOnly, "next time")
        'Dim ModuleInfo_Strc As New List(Of ModuleInfo)
        'Dim temp As New ModuleInfo
        ''temp.base = info
        ''ModuleInfo_Strc.Add(
        ''Dim modlist As IntPtr = Marshal.AllocHGlobal(Marshal.SizeOf(ModuleInfo_Strc)) ' New List(Of ModuleInfo)
        'Dim s As Boolean = GetList(ModuleInfo_Strc)
        ''Marshal.PtrToStructure(modlist, ModuleInfo_Strc)
        'Return 1
        ' by MrExodia
        For Each _mod In GetList()
            WriteLine("[DotNet TEST]" + " " + _mod.base.ToPtrString + " " + _mod.name.ToString)
            For Each section In SectionListFromAddr(_mod.base)
                WriteLine("[DotNet TEST]" + " " + section.addr.ToPtrString + " " + section.name)
            Next section
            WriteLine("")
        Next _mod
        Return 1
    End Function

    Public Function cbLoader(ByVal argc As Integer, ByVal argv() As String) As Boolean
        Dim thread As New Threading.Thread(AddressOf GoToForm)
        thread.SetApartmentState(Threading.ApartmentState.STA)
        thread.Start()

        'Dim Loader_Form As New LoaderForm
        'Loader_Form.ShowDialog()
        'Return 1
    End Function
    Public Sub GoToForm()
        Dim Loader_Form As New LoaderForm
        Loader_Form.ShowDialog()
    End Sub
End Module
