Imports System.Windows.Forms
Imports System.Runtime.InteropServices
Public Class LoaderForm
    Structure Values
        Dim addr As Int64
        Dim oldbyte As Byte
        Dim newbyte As Byte
    End Structure
    Private Structure PATCHINFO_
        Dim modulname As String
        Dim addr() As String
        Dim oldbyte() As String
        Dim newbyte() As String
    End Structure

    Private Sub LoaderForm_Load(sender As System.Object, e As System.EventArgs) Handles MyBase.Load
        ' Create the ToolTip and associate with the Form container.
        'Dim toolTip1 As New ToolTip()
        '' Set up the delays for the ToolTip.
        'toolTip1.AutoPopDelay = 5000
        'toolTip1.InitialDelay = 1000
        'toolTip1.ReshowDelay = 500
        '' Force the ToolTip text to be displayed whether or not the form is active.
        'toolTip1.ShowAlways = True
        '' Set up the ToolTip text for the Button and Checkbox.
        'toolTip1.SetToolTip(Me.TB_TargetName, "depule click to brows folder")
        For Each _mod In GetList()
            If _mod.name.Contains(".exe") Then
                TB_TargetPath.Text = _mod.path
            End If
        Next _mod
    End Sub
    Private Sub Bu_LoadPatchFile_Click(sender As System.Object, e As System.EventArgs) Handles Bu_LoadPatchFile.Click
        'DialogLoadTarget.InitialDirectory = "c:\"
        DialogLoadTarget.Filter = "patch files (*.1337)|*.1337|dll files (*.dll)|*.dll|All files (*.*)|*.*"
        DialogLoadTarget.FilterIndex = 1
        DialogLoadTarget.RestoreDirectory = True

        Dim i, j As Integer
        Dim tempPATCHINFO() As PATCHINFO_
        If DialogLoadTarget.ShowDialog() = System.Windows.Forms.DialogResult.OK Then
            Dim Fileread As System.IO.StreamReader = My.Computer.FileSystem.OpenTextFileReader(DialogLoadTarget.FileName)
            Dim begin As Boolean = True
            Do Until Fileread.EndOfStream
                Dim stemp As String = Fileread.ReadLine
                If stemp.Length < 1 Then MsgBox("unspported file ", MsgBoxStyle.OkOnly, "Error") : Exit Sub
                Try
                    If stemp.Substring(0, 1) = ">" Then
                        ReDim Preserve tempPATCHINFO(i)
                        tempPATCHINFO(i).modulname = stemp.Substring(1, stemp.Length - 1)
                        i = i + 1
                        j = 0
                    Else
                        ReDim Preserve tempPATCHINFO(i - 1).addr(j)
                        ReDim Preserve tempPATCHINFO(i - 1).oldbyte(j)
                        ReDim Preserve tempPATCHINFO(i - 1).newbyte(j)
                        tempPATCHINFO(i - 1).addr(j) = stemp.Substring(0, 16)
                        tempPATCHINFO(i - 1).oldbyte(j) = stemp.Substring(17, 2)
                        tempPATCHINFO(i - 1).newbyte(j) = stemp.Substring(21, 2)
                        j = j + 1
                    End If
                Catch ex As Exception
                    Fileread.Close()
                    MsgBox(ex.Message.ToString)
                    Exit Sub
                End Try
            Loop
            Fileread.Close()
        End If

        'get resource as byte arry the loader and resource inside the Loader
        Dim loader_byte As Byte() = My.Resources.Loader
        Dim res_arr As Byte() = My.Resources.rcdata1
        'Dim l As Byte = CByte(AscW("a"))
        'res_arr(1) = &HFE
        'res_arr(0) = l
        My.Computer.FileSystem.WriteAllBytes(Application.StartupPath + "\loader.exe", loader_byte, False)
        'edit resource of the loader
        Dim hUpdateRes As System.IntPtr ' update resource handle
        Dim result As Integer
        If (FileIO.FileSystem.FileExists(Application.StartupPath + "\loader.exe")) Then
            hUpdateRes = BeginUpdateResource(Application.StartupPath + "\loader.exe", False)
            If (hUpdateRes = 0) Then MsgBox("Couldn't load the Loader", MsgBoxStyle.OkOnly, "Error") : Exit Sub
            'https://msdn.microsoft.com/en-us/library/windows/desktop/dd318693(v=vs.85).aspx  Language Identifier Constants and Strings &H409=United state Amirca
            Try
                result = UpdateResource(hUpdateRes, 10, 106, &H409, res_arr, res_arr.Length)       ' size of resource info
                Dim isFinish As Boolean = EndUpdateResource(hUpdateRes, False)
                If Not isFinish Then MsgBox("Couldn't load the Loader", MsgBoxStyle.OkOnly, "Error") : Exit Sub
            Catch ex As Exception
                MsgBox(ex.Message.ToString)
            End Try

        Else
            MsgBox("Couldn't create loader", MsgBoxStyle.OkOnly, "Error")
        End If
        MsgBox("Done")
    End Sub

    'old try ...has some usefull code

    'Private Sub Bu_LoadPatchFile_Click(sender As System.Object, e As System.EventArgs) Handles Bu_LoadPatchFile.Click
    '    DialogLoadTarget.InitialDirectory = "c:\"
    '    DialogLoadTarget.Filter = "patch files (*.1337)|*.1337|dll files (*.dll)|*.dll|All files (*.*)|*.*"
    '    DialogLoadTarget.FilterIndex = 1
    '    'DialogLoadTarget.RestoreDirectory = True
    '    Dim i, j As Integer
    '    Dim tempPATCHINFO() As PATCHINFO_
    '    If DialogLoadTarget.ShowDialog() = System.Windows.Forms.DialogResult.OK Then
    '        Dim Fileread As System.IO.StreamReader = My.Computer.FileSystem.OpenTextFileReader(DialogLoadTarget.FileName)
    '        Dim begin As Boolean = True
    '        Do Until Fileread.EndOfStream
    '            Dim stemp As String = Fileread.ReadLine
    '            If stemp.Length < 1 Then MsgBox("unspported file ", MsgBoxStyle.OkOnly, "Error") : Exit Sub
    '            Try
    '                If stemp.Substring(0, 1) = ">" Then
    '                    ReDim Preserve tempPATCHINFO(i)
    '                    tempPATCHINFO(i).modulname = stemp.Substring(1, stemp.Length - 1)
    '                    i = i + 1
    '                    'ReDim Preserve tempPATCHINFO(i).addr(1)
    '                    'ReDim Preserve tempPATCHINFO(i).oldbyte(1)
    '                    'ReDim Preserve tempPATCHINFO(i).newbyte(1)
    '                    j = 0
    '                Else
    '                    ReDim Preserve tempPATCHINFO(i - 1).addr(j)
    '                    ReDim Preserve tempPATCHINFO(i - 1).oldbyte(j)
    '                    ReDim Preserve tempPATCHINFO(i - 1).newbyte(j)
    '                    tempPATCHINFO(i - 1).addr(j) = stemp.Substring(0, 16)
    '                    tempPATCHINFO(i - 1).oldbyte(j) = stemp.Substring(17, 2)
    '                    tempPATCHINFO(i - 1).newbyte(j) = stemp.Substring(21, 2)
    '                    j = j + 1
    '                End If
    '            Catch ex As Exception
    '                Fileread.Close()
    '                MsgBox(ex.Message.ToString)
    '                Exit Sub
    '            End Try
    '        Loop
    '        Fileread.Close()
    '    End If

    '    'extract file
    '    Dim x As Byte() = My.Resources.Loader
    '    Dim res_arr As Byte() = My.Resources.rcdata1
    '    Dim l As Byte = CByte(AscW("a"))
    '    res_arr(1) = &HFE
    '    res_arr(0) = l
    '    'Dim Add_res As IntPtr
    '    My.Computer.FileSystem.WriteAllBytes(Application.StartupPath + "\loader.exe", x, False)
    '    'My.Computer.FileSystem.WriteAllBytes(Application.StartupPath + "\loader-.exe", x, False)
    '    'edit resource of the loader
    '    'Dim hResLoad As System.IntPtr ' handle to loaded resource
    '    Dim hExe As System.IntPtr ' handle to existing .EXE file
    '    Dim hRes As System.IntPtr ' handle/ptr. to res. info. in hExe
    '    Dim hUpdateRes As System.IntPtr ' update resource handle
    '    'Dim lpResLock As System.IntPtr ' pointer to resource data
    '    Dim result As Integer
    '    If (FileIO.FileSystem.FileExists(Application.StartupPath + "\loader.exe")) Then
    '        'hExe = LoadLibrary(Application.StartupPath + "\loader-.exe")
    '        hExe = LoadLibrary(Application.StartupPath + "\loader.exe")
    '        If (hExe = 0) Then MsgBox("Couldn't load the Loader", MsgBoxStyle.OkOnly, "Error") : Exit Sub
    '        hRes = FindResource(hExe, 106, 10) 'RT_RCDATA  MAKEINTRESOURCE(10)  =10  ,,,, 106 is the name of resource handle in loader
    '        'lpResLock = LockResource(hRes)
    '        'ReDim Preserve lpResLockx(SizeofResource(hExe, hRes))
    '        'Add_res = LoadResource(hExe, hRes)
    '        'Marshal.Copy(lpResLock, lpResLockx, 0, SizeofResource(hExe, hRes))
    '        'lpResLockx(0) = &H38
    '        'MsgBox("Loaded2")
    '        'If (lpResLock = 0) Then MsgBox("Couldn't load the Loader", MsgBoxStyle.OkOnly, "Error") : Exit Sub
    '        FreeLibrary(hExe)
    '        hUpdateRes = BeginUpdateResource(Application.StartupPath + "\loader.exe", False)
    '        If (hUpdateRes = 0) Then MsgBox("Couldn't load the Loader", MsgBoxStyle.OkOnly, "Error") : Exit Sub
    '        'https://msdn.microsoft.com/en-us/library/windows/desktop/dd318693(v=vs.85).aspx  Language Identifier Constants and Strings
    '        Try
    '            'result = UpdateResource(hUpdateRes, 10, 106, &H409, res_arr, SizeofResource(hExe, hRes))       ' size of resource info
    '            result = UpdateResource(hUpdateRes, 10, 106, &H409, res_arr, res_arr.Length)       ' size of resource info
    '            Dim isFinish As Boolean = EndUpdateResource(hUpdateRes, False)
    '            If Not isFinish Then MsgBox("Couldn't load the Loader", MsgBoxStyle.OkOnly, "Error") : Exit Sub
    '        Catch ex As Exception
    '            MsgBox(ex.Message.ToString)
    '        End Try

    '    Else
    '        MsgBox("Couldn't create loader", MsgBoxStyle.OkOnly, "Error")
    '    End If

    '    'FreeLibrary(hExe)

    '    MsgBox("Done")
    'End Sub
End Class