Imports System.Windows.Forms
Imports System.Runtime.InteropServices
Public Class LoaderForm
    Private Structure PATCHINFO_
        Dim modulname As String
        Dim addr() As String
        Dim oldbyte() As String
        Dim newbyte() As String
    End Structure
    Dim tempPATCHINFO() As PATCHINFO_
    Dim res_arr As Byte() = My.Resources.rcdata1

    Private Sub LoaderForm_Load(sender As System.Object, e As System.EventArgs) Handles MyBase.Load
        'Create the ToolTip and associate with the Form container.
        Dim toolTip1 As New ToolTip()
        ' Set up the delays for the ToolTip.
        toolTip1.AutoPopDelay = 5000
        toolTip1.InitialDelay = 1000
        toolTip1.ReshowDelay = 500
        ' Force the ToolTip text to be displayed whether or not the form is active.
        toolTip1.ShowAlways = True
        ' Set up the ToolTip text for the Button and Checkbox.
        toolTip1.SetToolTip(Me.TV_modpatch, "click enter on the address to go to at CPU")
        CB_LoadMod.Items.Clear()
        For Each _mod In GetList()
            If _mod.name.Contains(".exe") Then
                TB_TargetPath.Text = _mod.path
            End If
            CB_LoadMod.Items.Add(_mod.name)
        Next _mod

    End Sub
    Private Sub Bu_LoadPatchFile_Click(sender As System.Object, e As System.EventArgs) Handles Bu_LoadPatchFile.Click
        'DialogLoadTarget.InitialDirectory = "c:\"
        DialogLoadTarget.Filter = "patch files (*.1337)|*.1337|dll files (*.dll)|*.dll|All files (*.*)|*.*"
        DialogLoadTarget.FilterIndex = 1
        DialogLoadTarget.RestoreDirectory = True

        Dim i, j As Integer
        'Dim tempPATCHINFO() As PATCHINFO_
        ReDim tempPATCHINFO(0)  'clear arry for new update 
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
        Else
            Exit Sub
        End If

        TV_modpatch.Nodes.Clear()
        For n = 0 To tempPATCHINFO.Length - 1
            Dim G_node = TV_modpatch.Nodes.Add(tempPATCHINFO(n).modulname)
            For s = 0 To tempPATCHINFO(n).addr.Length - 1
                'TV_modpatch.Nodes.Add(n, tempPATCHINFO(s).addr(s))
                Dim F_node = G_node.Nodes.Add(tempPATCHINFO(n).addr(s))
                F_node.Nodes.Add("Old Byte: " & tempPATCHINFO(n).oldbyte(s))
                F_node.Nodes.Add("New Byte: " & tempPATCHINFO(n).newbyte(s))
            Next
        Next



        ''get resource as byte arry the loader and resource inside the Loader
        'Dim loader_byte As Byte() = My.Resources.Loader
        'Dim res_arr As Byte() = My.Resources.rcdata1
        'Dim l As Byte = CByte(AscW("a"))
        'res_arr(1) = &HFE
        'res_arr(0) = l
        'ReDim Preserve res_arr(3)
        'My.Computer.FileSystem.WriteAllBytes(Application.StartupPath + "\loader.exe", loader_byte, False)
        ''edit resource of the loader
        'Dim hUpdateRes As System.IntPtr ' update resource handle
        'Dim result As Integer
        'If (FileIO.FileSystem.FileExists(Application.StartupPath + "\loader.exe")) Then
        '    hUpdateRes = BeginUpdateResource(Application.StartupPath + "\loader.exe", False)
        '    If (hUpdateRes = 0) Then MsgBox("Couldn't load the Loader", MsgBoxStyle.OkOnly, "Error") : Exit Sub
        '    'https://msdn.microsoft.com/en-us/library/windows/desktop/dd318693(v=vs.85).aspx  Language Identifier Constants and Strings &H409=United state Amirca
        '    Try
        '        result = UpdateResource(hUpdateRes, 10, 106, &H409, res_arr, res_arr.Length)       ' size of resource info
        '        Dim isFinish As Boolean = EndUpdateResource(hUpdateRes, False)
        '        If Not isFinish Then MsgBox("Couldn't load the Loader", MsgBoxStyle.OkOnly, "Error") : Exit Sub
        '    Catch ex As Exception
        '        MsgBox(ex.Message.ToString)
        '    End Try

        'Else
        '    MsgBox("Couldn't create loader", MsgBoxStyle.OkOnly, "Error")
        'End If
        'MsgBox("Done")
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


    Private Sub TV_modpatch_KeyUp(sender As Object, e As System.Windows.Forms.KeyEventArgs) Handles TV_modpatch.KeyUp
        If (e.KeyCode = Keys.Enter) Then
            Try
                Dim P_node As String = TV_modpatch.SelectedNode.Parent.Text
                Dim modbase = (From s In GetList() Where s.name = P_node Select s.base).First.ToPtrString
                Dim modbaseX = TV_modpatch.SelectedNode.Text
                Dim Addr As String = Hex(Convert.ToInt64(modbase, 16) + Convert.ToInt64(modbaseX, 16))
                DbgCmdExec("disasm " & Addr)
            Catch ex As Exception
                MsgBox("as this patch file not for this Target pls check it again ", MsgBoxStyle.OkOnly, "Error")
            End Try
        End If
    End Sub

    Private Sub CB_ShowWindow_CheckedChanged(sender As System.Object, e As System.EventArgs) Handles CB_ShowWindow.CheckedChanged
        If CB_ShowWindow.Checked Then
            TB_Title.Enabled = True
        Else
            TB_Title.Enabled = False
        End If
    End Sub

    
    Private Sub CB_Hook_CheckedChanged(sender As System.Object, e As System.EventArgs) Handles CB_Hook.CheckedChanged
        If CB_Hook.Checked Then
            CB_LoadMod.Enabled = True
            TB_Addr.Enabled = True
            TB_count.Enabled = True
            CB_LoadMod.Items.Clear()
            For Each _mod In GetList()
                If _mod.name.Contains(".exe") Then
                    TB_TargetPath.Text = _mod.path
                End If
                CB_LoadMod.Items.Add(_mod.name)
            Next _mod
        Else
            CB_LoadMod.Enabled = False
            TB_Addr.Enabled = False
            TB_count.Enabled = False
        End If
    End Sub

    Private Sub Bu_Create_Click(sender As System.Object, e As System.EventArgs) Handles Bu_Create.Click

        'get resource as byte arry the loader and resource inside the Loader
        Dim loader_byte As Byte() = My.Resources.Loader
        'Dim res_arr As Byte() = My.Resources.rcdata1
        'Dim l As Byte = CByte(AscW("a"))
        'res_arr(1) = &HFE
        'res_arr(0) = l

        filldata("Loader")
        'Dim s = TB_TargetPath.Text.Substring(0, TB_TargetPath.Text.LastIndexOf("\"))
        'ReDim Preserve res_arr(3)
        'My.Computer.FileSystem.WriteAllBytes(Application.StartupPath + "\loader.exe", loader_byte, False)
        Dim TargetPath As String = TB_TargetPath.Text.Substring(0, TB_TargetPath.Text.LastIndexOf("\")) + "\loader.exe"
        Try
            My.Computer.FileSystem.WriteAllBytes(TargetPath, loader_byte, False)
        Catch ex As Exception
            MsgBox(ex.Message.ToString)
            Dim savefile As New SaveFileDialog
            savefile.Filter = "txt files (*.exe)|*.exe"
            savefile.FileName = "loader.exe"
            savefile.RestoreDirectory = True
            'If (savefile.ShowDialog = Windows.Forms.DialogResult.OK) Then
            '    TargetPath = savefile.FileName
            '    My.Computer.FileSystem.WriteAllBytes(TargetPath, loader_byte, False)
            'Else
            '    Exit Sub
            'End If
        End Try

        'edit resource of the loader
        Dim hUpdateRes As System.IntPtr ' update resource handle
        Dim result As Integer
        'If (FileIO.FileSystem.FileExists(Application.StartupPath + "\loader.exe")) Then
        If (FileIO.FileSystem.FileExists(TargetPath)) Then
            hUpdateRes = BeginUpdateResource(TargetPath, False)
            If (hUpdateRes = 0) Then MsgBox("Couldn't load the Loader", MsgBoxStyle.OkOnly, "Error") : Exit Sub
            'https://msdn.microsoft.com/en-us/library/windows/desktop/dd318693(v=vs.85).aspx  Language Identifier Constants and Strings &H409=United state Amirca
            Try
                result = UpdateResource(hUpdateRes, 10, 106, &H409, res_arr, res_arr.Length)       ' size of resource info
                Dim isFinish As Boolean = EndUpdateResource(hUpdateRes, False)
                If Not isFinish Then MsgBox("Couldn't load the Loader", MsgBoxStyle.OkOnly, "Error") : Exit Sub
            Catch ex As Exception
                MsgBox(ex.Message.ToString)
                Exit Sub
            End Try

        Else
            MsgBox("Couldn't create loader", MsgBoxStyle.OkOnly, "Error")
            Exit Sub
        End If
        MsgBox("Done")
    End Sub
    'Function Addprac(ByVal str As String, ByVal place_ As Integer) As String
    '    Select Case place_
    '        Case 0
    '            str = "<" & str
    '        Case 1
    '            str = str & ">"
    '        Case 2
    '            str = "<" & str & ">"
    '        Case Else
    '            Return ""
    '    End Select
    '    Return str
    'End Function
    Function Addprac(ByVal str As String) As String
        str = "<" & str & ">"
        Return str
    End Function
    Function AddpracLeft(ByVal str As String) As String
        str = "<" & str
        Return str
    End Function
    Function AddpracRight(ByVal str As String) As String
        str = str & ">"
        Return str
    End Function

    Private Sub filldata(ByVal kind As String)
        Dim resStr As String = String.Empty
        Dim dpoint As String = ":"
        If kind = "Loader" Then
            resStr = Addprac("Loader")
            If CB_ShowWindow.Checked Then resStr = resStr + Addprac("ShowWindow" + dpoint + TB_Title.Text) '<ShowWindow:the title u enter>
            If CB_Hook.Checked Then resStr = resStr + Addprac("Hook" + dpoint + CB_LoadMod.Text + dpoint + TB_Addr.Text + dpoint + TB_count.Text)
            ReDim Preserve res_arr(resStr.Length)
            For i = 0 To resStr.Length - 1
                res_arr(i) = CByte(AscW(resStr.Substring(i, 1)))
            Next
        ElseIf kind = "Patch" Then
            resStr = Addprac("Patch")
        End If
    End Sub

    
End Class