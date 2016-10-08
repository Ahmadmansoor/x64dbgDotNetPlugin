Imports x64dbgDotNetPlugin._plugins
Module Plog
    Public Sub WriteLine(ByVal format As String, ByVal ParamArray args() As Object)
        Write(String.Format(format.Replace("%", "%%") & ControlChars.Lf, args))
    End Sub

    Public Sub Write(ByVal format As String, ByVal ParamArray args() As Object)
        _plugin_logprintf(String.Format(format.Replace("%", "%%"), args))
    End Sub

End Module
