Imports System.Runtime.CompilerServices
Imports System.Runtime.InteropServices

Module Extensions
    <System.Runtime.CompilerServices.Extension()> _
    Public Function ToHexString(ByVal intPtr As IntPtr) As String
        Return intPtr.ToString("X")
    End Function

    <System.Runtime.CompilerServices.Extension()> _
    Public Function ToPtrString(ByVal intPtr As IntPtr) As String
        Return If(System.IntPtr.Size = 4, intPtr.ToString("X8"), intPtr.ToString("X16"))
    End Function

    <System.Runtime.CompilerServices.Extension()> _
    Public Function MarshalToString(ByVal intPtr As IntPtr) As String
        If intPtr = System.IntPtr.Zero Then
            Return ""
        End If
        Return Marshal.PtrToStringAnsi(intPtr)
    End Function

    <System.Runtime.CompilerServices.Extension()> _
    Public Function ToStruct(Of T As New)(ByVal intPtr As IntPtr) As T
        If intPtr = System.IntPtr.Zero Then
            Return New T()
        End If
        Return CType(Marshal.PtrToStructure(intPtr, GetType(T)), T)
    End Function
End Module
