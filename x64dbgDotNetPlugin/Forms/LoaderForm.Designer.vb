<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class LoaderForm
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()> _
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        Try
            If disposing AndAlso components IsNot Nothing Then
                components.Dispose()
            End If
        Finally
            MyBase.Dispose(disposing)
        End Try
    End Sub

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Me.TabControl1 = New System.Windows.Forms.TabControl()
        Me.TabPage1 = New System.Windows.Forms.TabPage()
        Me.CB_LoadMod = New System.Windows.Forms.ComboBox()
        Me.TB_count = New System.Windows.Forms.TextBox()
        Me.TB_Addr = New System.Windows.Forms.TextBox()
        Me.Bu_Create = New System.Windows.Forms.Button()
        Me.CB_Hook = New System.Windows.Forms.CheckBox()
        Me.TB_Title = New System.Windows.Forms.TextBox()
        Me.CB_ShowWindow = New System.Windows.Forms.CheckBox()
        Me.TabPage2 = New System.Windows.Forms.TabPage()
        Me.DialogLoadTarget = New System.Windows.Forms.OpenFileDialog()
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.TV_modpatch = New System.Windows.Forms.TreeView()
        Me.Bu_LoadPatchFile = New System.Windows.Forms.Button()
        Me.Bu_LoadTarget = New System.Windows.Forms.Button()
        Me.TB_TargetPath = New System.Windows.Forms.TextBox()
        Me.TabControl1.SuspendLayout()
        Me.TabPage1.SuspendLayout()
        Me.GroupBox1.SuspendLayout()
        Me.SuspendLayout()
        '
        'TabControl1
        '
        Me.TabControl1.Controls.Add(Me.TabPage1)
        Me.TabControl1.Controls.Add(Me.TabPage2)
        Me.TabControl1.Location = New System.Drawing.Point(6, 249)
        Me.TabControl1.Name = "TabControl1"
        Me.TabControl1.SelectedIndex = 0
        Me.TabControl1.Size = New System.Drawing.Size(233, 237)
        Me.TabControl1.TabIndex = 0
        '
        'TabPage1
        '
        Me.TabPage1.BackColor = System.Drawing.Color.Gainsboro
        Me.TabPage1.Controls.Add(Me.CB_LoadMod)
        Me.TabPage1.Controls.Add(Me.TB_count)
        Me.TabPage1.Controls.Add(Me.TB_Addr)
        Me.TabPage1.Controls.Add(Me.Bu_Create)
        Me.TabPage1.Controls.Add(Me.CB_Hook)
        Me.TabPage1.Controls.Add(Me.TB_Title)
        Me.TabPage1.Controls.Add(Me.CB_ShowWindow)
        Me.TabPage1.Location = New System.Drawing.Point(4, 22)
        Me.TabPage1.Name = "TabPage1"
        Me.TabPage1.Padding = New System.Windows.Forms.Padding(3)
        Me.TabPage1.Size = New System.Drawing.Size(225, 211)
        Me.TabPage1.TabIndex = 0
        Me.TabPage1.Text = "Loader"
        '
        'CB_LoadMod
        '
        Me.CB_LoadMod.Enabled = False
        Me.CB_LoadMod.FormattingEnabled = True
        Me.CB_LoadMod.Location = New System.Drawing.Point(6, 77)
        Me.CB_LoadMod.Name = "CB_LoadMod"
        Me.CB_LoadMod.Size = New System.Drawing.Size(66, 21)
        Me.CB_LoadMod.TabIndex = 7
        '
        'TB_count
        '
        Me.TB_count.Enabled = False
        Me.TB_count.Location = New System.Drawing.Point(186, 78)
        Me.TB_count.Name = "TB_count"
        Me.TB_count.Size = New System.Drawing.Size(33, 20)
        Me.TB_count.TabIndex = 6
        Me.TB_count.Text = "1"
        Me.TB_count.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'TB_Addr
        '
        Me.TB_Addr.Enabled = False
        Me.TB_Addr.Location = New System.Drawing.Point(78, 78)
        Me.TB_Addr.Name = "TB_Addr"
        Me.TB_Addr.Size = New System.Drawing.Size(102, 20)
        Me.TB_Addr.TabIndex = 5
        Me.TB_Addr.Text = "FFFFFFFFFFFFFFFF"
        Me.TB_Addr.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'Bu_Create
        '
        Me.Bu_Create.Location = New System.Drawing.Point(54, 182)
        Me.Bu_Create.Name = "Bu_Create"
        Me.Bu_Create.Size = New System.Drawing.Size(106, 23)
        Me.Bu_Create.TabIndex = 3
        Me.Bu_Create.Text = "Create"
        Me.Bu_Create.UseVisualStyleBackColor = True
        '
        'CB_Hook
        '
        Me.CB_Hook.AutoSize = True
        Me.CB_Hook.Location = New System.Drawing.Point(6, 55)
        Me.CB_Hook.Name = "CB_Hook"
        Me.CB_Hook.Size = New System.Drawing.Size(210, 17)
        Me.CB_Hook.TabIndex = 2
        Me.CB_Hook.Text = "Hook Address ( will update module list)"
        Me.CB_Hook.UseVisualStyleBackColor = True
        '
        'TB_Title
        '
        Me.TB_Title.Enabled = False
        Me.TB_Title.Location = New System.Drawing.Point(6, 29)
        Me.TB_Title.Name = "TB_Title"
        Me.TB_Title.Size = New System.Drawing.Size(210, 20)
        Me.TB_Title.TabIndex = 1
        Me.TB_Title.Text = "write the lable u want to show on form "
        '
        'CB_ShowWindow
        '
        Me.CB_ShowWindow.AutoSize = True
        Me.CB_ShowWindow.Location = New System.Drawing.Point(6, 6)
        Me.CB_ShowWindow.Name = "CB_ShowWindow"
        Me.CB_ShowWindow.Size = New System.Drawing.Size(93, 17)
        Me.CB_ShowWindow.TabIndex = 0
        Me.CB_ShowWindow.Text = "Show Window"
        Me.CB_ShowWindow.UseVisualStyleBackColor = True
        '
        'TabPage2
        '
        Me.TabPage2.Location = New System.Drawing.Point(4, 22)
        Me.TabPage2.Name = "TabPage2"
        Me.TabPage2.Padding = New System.Windows.Forms.Padding(3)
        Me.TabPage2.Size = New System.Drawing.Size(225, 135)
        Me.TabPage2.TabIndex = 1
        Me.TabPage2.Text = "Patch"
        Me.TabPage2.UseVisualStyleBackColor = True
        '
        'DialogLoadTarget
        '
        Me.DialogLoadTarget.RestoreDirectory = True
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.TV_modpatch)
        Me.GroupBox1.Controls.Add(Me.Bu_LoadPatchFile)
        Me.GroupBox1.Controls.Add(Me.TabControl1)
        Me.GroupBox1.Controls.Add(Me.Bu_LoadTarget)
        Me.GroupBox1.Controls.Add(Me.TB_TargetPath)
        Me.GroupBox1.Location = New System.Drawing.Point(12, 9)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(245, 492)
        Me.GroupBox1.TabIndex = 0
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "Target"
        '
        'TV_modpatch
        '
        Me.TV_modpatch.Location = New System.Drawing.Point(10, 100)
        Me.TV_modpatch.Name = "TV_modpatch"
        Me.TV_modpatch.Size = New System.Drawing.Size(229, 143)
        Me.TV_modpatch.TabIndex = 4
        '
        'Bu_LoadPatchFile
        '
        Me.Bu_LoadPatchFile.Location = New System.Drawing.Point(10, 73)
        Me.Bu_LoadPatchFile.Name = "Bu_LoadPatchFile"
        Me.Bu_LoadPatchFile.Size = New System.Drawing.Size(108, 21)
        Me.Bu_LoadPatchFile.TabIndex = 0
        Me.Bu_LoadPatchFile.Text = "Load Patch File"
        Me.Bu_LoadPatchFile.UseVisualStyleBackColor = True
        '
        'Bu_LoadTarget
        '
        Me.Bu_LoadTarget.Location = New System.Drawing.Point(10, 19)
        Me.Bu_LoadTarget.Name = "Bu_LoadTarget"
        Me.Bu_LoadTarget.Size = New System.Drawing.Size(108, 21)
        Me.Bu_LoadTarget.TabIndex = 1
        Me.Bu_LoadTarget.Text = "Load Target"
        Me.Bu_LoadTarget.UseVisualStyleBackColor = True
        '
        'TB_TargetPath
        '
        Me.TB_TargetPath.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(178, Byte))
        Me.TB_TargetPath.Location = New System.Drawing.Point(10, 46)
        Me.TB_TargetPath.Name = "TB_TargetPath"
        Me.TB_TargetPath.Size = New System.Drawing.Size(229, 21)
        Me.TB_TargetPath.TabIndex = 3
        '
        'LoaderForm
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.SystemColors.ActiveCaption
        Me.ClientSize = New System.Drawing.Size(270, 513)
        Me.Controls.Add(Me.GroupBox1)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D
        Me.MaximizeBox = False
        Me.Name = "LoaderForm"
        Me.Text = "LoaderForm"
        Me.TabControl1.ResumeLayout(False)
        Me.TabPage1.ResumeLayout(False)
        Me.TabPage1.PerformLayout()
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents TabControl1 As System.Windows.Forms.TabControl
    Friend WithEvents TabPage1 As System.Windows.Forms.TabPage
    Friend WithEvents TabPage2 As System.Windows.Forms.TabPage
    Friend WithEvents DialogLoadTarget As System.Windows.Forms.OpenFileDialog
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents Bu_LoadPatchFile As System.Windows.Forms.Button
    Friend WithEvents Bu_LoadTarget As System.Windows.Forms.Button
    Friend WithEvents TB_TargetPath As System.Windows.Forms.TextBox
    Friend WithEvents TV_modpatch As System.Windows.Forms.TreeView
    Friend WithEvents TB_Title As System.Windows.Forms.TextBox
    Friend WithEvents CB_ShowWindow As System.Windows.Forms.CheckBox
    Friend WithEvents TB_count As System.Windows.Forms.TextBox
    Friend WithEvents TB_Addr As System.Windows.Forms.TextBox
    Friend WithEvents Bu_Create As System.Windows.Forms.Button
    Friend WithEvents CB_Hook As System.Windows.Forms.CheckBox
    Friend WithEvents CB_LoadMod As System.Windows.Forms.ComboBox
End Class
