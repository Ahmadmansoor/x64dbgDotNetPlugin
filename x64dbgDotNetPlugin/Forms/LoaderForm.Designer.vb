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
        Me.TabPage2 = New System.Windows.Forms.TabPage()
        Me.DialogLoadTarget = New System.Windows.Forms.OpenFileDialog()
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.Bu_LoadPatchFile = New System.Windows.Forms.Button()
        Me.Bu_LoadTarget = New System.Windows.Forms.Button()
        Me.TB_TargetPath = New System.Windows.Forms.TextBox()
        Me.TabControl1.SuspendLayout()
        Me.GroupBox1.SuspendLayout()
        Me.SuspendLayout()
        '
        'TabControl1
        '
        Me.TabControl1.Controls.Add(Me.TabPage1)
        Me.TabControl1.Controls.Add(Me.TabPage2)
        Me.TabControl1.Location = New System.Drawing.Point(91, 482)
        Me.TabControl1.Name = "TabControl1"
        Me.TabControl1.SelectedIndex = 0
        Me.TabControl1.Size = New System.Drawing.Size(165, 152)
        Me.TabControl1.TabIndex = 0
        '
        'TabPage1
        '
        Me.TabPage1.BackColor = System.Drawing.Color.Gainsboro
        Me.TabPage1.Location = New System.Drawing.Point(4, 22)
        Me.TabPage1.Name = "TabPage1"
        Me.TabPage1.Padding = New System.Windows.Forms.Padding(3)
        Me.TabPage1.Size = New System.Drawing.Size(157, 126)
        Me.TabPage1.TabIndex = 0
        Me.TabPage1.Text = "Loader"
        '
        'TabPage2
        '
        Me.TabPage2.Location = New System.Drawing.Point(4, 22)
        Me.TabPage2.Name = "TabPage2"
        Me.TabPage2.Padding = New System.Windows.Forms.Padding(3)
        Me.TabPage2.Size = New System.Drawing.Size(294, 247)
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
        Me.GroupBox1.Controls.Add(Me.Bu_LoadPatchFile)
        Me.GroupBox1.Controls.Add(Me.TabControl1)
        Me.GroupBox1.Controls.Add(Me.Bu_LoadTarget)
        Me.GroupBox1.Controls.Add(Me.TB_TargetPath)
        Me.GroupBox1.Location = New System.Drawing.Point(12, 12)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(483, 656)
        Me.GroupBox1.TabIndex = 0
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "Target"
        '
        'Bu_LoadPatchFile
        '
        Me.Bu_LoadPatchFile.Location = New System.Drawing.Point(6, 53)
        Me.Bu_LoadPatchFile.Name = "Bu_LoadPatchFile"
        Me.Bu_LoadPatchFile.Size = New System.Drawing.Size(108, 21)
        Me.Bu_LoadPatchFile.TabIndex = 0
        Me.Bu_LoadPatchFile.Text = "Load Patch File"
        Me.Bu_LoadPatchFile.UseVisualStyleBackColor = True
        '
        'Bu_LoadTarget
        '
        Me.Bu_LoadTarget.Location = New System.Drawing.Point(6, 26)
        Me.Bu_LoadTarget.Name = "Bu_LoadTarget"
        Me.Bu_LoadTarget.Size = New System.Drawing.Size(108, 21)
        Me.Bu_LoadTarget.TabIndex = 1
        Me.Bu_LoadTarget.Text = "Load Target"
        Me.Bu_LoadTarget.UseVisualStyleBackColor = True
        '
        'TB_TargetPath
        '
        Me.TB_TargetPath.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(178, Byte))
        Me.TB_TargetPath.Location = New System.Drawing.Point(120, 26)
        Me.TB_TargetPath.Name = "TB_TargetPath"
        Me.TB_TargetPath.Size = New System.Drawing.Size(285, 21)
        Me.TB_TargetPath.TabIndex = 3
        '
        'LoaderForm
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.SystemColors.ActiveCaption
        Me.ClientSize = New System.Drawing.Size(534, 741)
        Me.Controls.Add(Me.GroupBox1)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D
        Me.MaximizeBox = False
        Me.Name = "LoaderForm"
        Me.Text = "LoaderForm"
        Me.TabControl1.ResumeLayout(False)
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
End Class
