Imports System.Text
Imports System.Runtime.InteropServices

Module RegisteredCommands
    Const MAX_MODULE_SIZE = 256
    Public Function cbNetTestCommand(ByVal argc As Integer, ByVal argv() As String) As Boolean
        _plugin_logputs("[.net TEST] .Net test command!")
        Dim line As String = ""
        If Not GuiGetLineWindow("test", line) Then
            _plugin_logputs("[TEST] cancel pressed!")
        Else
            _plugin_logprintf("[TEST] line: ""%s""" & ControlChars.Lf, line)
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
        Dim _modIntPtr As IntPtr = Marshal.AllocHGlobal(256)
        Dim _mod As String = String.Empty
        If Not DbgGetModuleAt(entry, _modIntPtr) Then
            _plugin_logprintf("[DotNet TEST] no module at %p..." & ControlChars.Lf, entry)
            Return False
        End If
        _mod = Marshal.PtrToStringAnsi(_modIntPtr)
        Dim base As Int64 = DbgModBaseFromName(_mod.ToString)
        If base = Nothing Then
            _plugin_logputs("[DotNet TEST] could not get module base...")
            Return False
        End If
        Dim hProcess As System.IntPtr = CType(TitanGetProcessInformation(), PROCESS_INFORMATION).hProcess
        Dim _mods As StringBuilder = New StringBuilder()
        _mods.Append(_mod)
        If Not GetModuleBaseNameA(hProcess, CType(base, System.IntPtr), _mods, MAX_MODULE_SIZE) Then
            _plugin_logputs("[DotNet TEST] could not get module base name...")
            Return False
        End If
        Dim szFileName As String = ""
        'Dim len As UInteger = [mod].Length
        'Do While [mod].Chars(len) <> "."c AndAlso len <> 0
        '    len -= 1
        'Loop
        'Dim ext As String = ""
        'If len <> 0 Then
        '    ext = [mod].Substring(len)
        '    [mod] = [mod].Substring(0, len)
        'End If
        'szFileName = String.Format("{0}_dump{1}", [mod], ext)
        'If Not SaveFileDialog(szFileName) Then
        '    Return True
        'End If
        'If Not DumpProcess(hProcess, DirectCast(base, Object), szFileName, entry) Then
        '    _plugin_logputs("[TEST] DumpProcess failed...")
        '    Return False
        'End If
        '_plugin_logputs("[TEST] Dumping done!")
        Return True
    End Function


End Module
