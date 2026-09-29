<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class Form1
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()>
    Protected Overrides Sub Dispose(disposing As Boolean)
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
    <System.Diagnostics.DebuggerStepThrough()>
    Private Sub InitializeComponent()
        label1 = New Label()
        txtStudentID = New TextBox()
        label2 = New Label()
        txtName = New TextBox()
        label3 = New Label()
        txtEmail = New TextBox()
        label4 = New Label()
        label5 = New Label()
        txtPhoneNumber = New TextBox()
        txtCourse = New TextBox()
        BtnSave = New Button()
        BtnUpdate = New Button()
        BtnDelete = New Button()
        BtnClear = New Button()
        DataGridView1 = New DataGridView()
        txtSearch = New TextBox()
        Label6 = New Label()
        CType(DataGridView1, ComponentModel.ISupportInitialize).BeginInit()
        SuspendLayout()
        ' 
        ' label1
        ' 
        label1.AutoSize = True
        label1.Location = New Point(30, 19)
        label1.Name = "label1"
        label1.Size = New Size(96, 25)
        label1.TabIndex = 0
        label1.Text = "Student ID"
        ' 
        ' txtStudentID
        ' 
        txtStudentID.Location = New Point(171, 19)
        txtStudentID.Name = "txtStudentID"
        txtStudentID.Size = New Size(262, 31)
        txtStudentID.TabIndex = 1
        txtStudentID.Text = " "
        ' 
        ' label2
        ' 
        label2.AutoSize = True
        label2.Location = New Point(30, 72)
        label2.Name = "label2"
        label2.Size = New Size(59, 25)
        label2.TabIndex = 2
        label2.Text = "Name"
        ' 
        ' txtName
        ' 
        txtName.Location = New Point(171, 72)
        txtName.Name = "txtName"
        txtName.Size = New Size(262, 31)
        txtName.TabIndex = 3
        ' 
        ' label3
        ' 
        label3.AutoSize = True
        label3.Location = New Point(30, 125)
        label3.Name = "label3"
        label3.Size = New Size(54, 25)
        label3.TabIndex = 4
        label3.Text = "Email"
        ' 
        ' txtEmail
        ' 
        txtEmail.Location = New Point(171, 122)
        txtEmail.Name = "txtEmail"
        txtEmail.Size = New Size(262, 31)
        txtEmail.TabIndex = 5
        ' 
        ' label4
        ' 
        label4.AutoSize = True
        label4.Location = New Point(30, 184)
        label4.Name = "label4"
        label4.Size = New Size(132, 25)
        label4.TabIndex = 6
        label4.Text = "Phone Number"
        ' 
        ' label5
        ' 
        label5.AutoSize = True
        label5.Location = New Point(30, 241)
        label5.Name = "label5"
        label5.Size = New Size(67, 25)
        label5.TabIndex = 7
        label5.Text = "Course"
        ' 
        ' txtPhoneNumber
        ' 
        txtPhoneNumber.Location = New Point(171, 178)
        txtPhoneNumber.Name = "txtPhoneNumber"
        txtPhoneNumber.Size = New Size(262, 31)
        txtPhoneNumber.TabIndex = 8
        ' 
        ' txtCourse
        ' 
        txtCourse.Location = New Point(171, 241)
        txtCourse.Name = "txtCourse"
        txtCourse.Size = New Size(262, 31)
        txtCourse.TabIndex = 9
        ' 
        ' BtnSave
        ' 
        BtnSave.Location = New Point(321, 319)
        BtnSave.Name = "BtnSave"
        BtnSave.Size = New Size(112, 34)
        BtnSave.TabIndex = 10
        BtnSave.Text = "Save"
        BtnSave.UseVisualStyleBackColor = True
        ' 
        ' BtnUpdate
        ' 
        BtnUpdate.Location = New Point(171, 319)
        BtnUpdate.Name = "BtnUpdate"
        BtnUpdate.Size = New Size(112, 34)
        BtnUpdate.TabIndex = 11
        BtnUpdate.Text = "Update"
        BtnUpdate.UseVisualStyleBackColor = True
        ' 
        ' BtnDelete
        ' 
        BtnDelete.Location = New Point(30, 319)
        BtnDelete.Name = "BtnDelete"
        BtnDelete.Size = New Size(112, 34)
        BtnDelete.TabIndex = 12
        BtnDelete.Text = "Delete"
        BtnDelete.UseVisualStyleBackColor = True
        ' 
        ' BtnClear
        ' 
        BtnClear.Location = New Point(30, 386)
        BtnClear.Name = "BtnClear"
        BtnClear.Size = New Size(112, 34)
        BtnClear.TabIndex = 13
        BtnClear.Text = "Clear"
        BtnClear.UseVisualStyleBackColor = True
        ' 
        ' DataGridView1
        ' 
        DataGridView1.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize
        DataGridView1.Dock = DockStyle.Bottom
        DataGridView1.Location = New Point(0, 438)
        DataGridView1.Name = "DataGridView1"
        DataGridView1.RowHeadersWidth = 62
        DataGridView1.Size = New Size(1329, 220)
        DataGridView1.TabIndex = 14
        ' 
        ' txtSearch
        ' 
        txtSearch.Location = New Point(689, 13)
        txtSearch.Name = "txtSearch"
        txtSearch.Size = New Size(298, 31)
        txtSearch.TabIndex = 15
        ' 
        ' Label6
        ' 
        Label6.AutoSize = True
        Label6.Location = New Point(512, 16)
        Label6.Name = "Label6"
        Label6.Size = New Size(116, 25)
        Label6.TabIndex = 16
        Label6.Text = "Search Name"
        ' 
        ' Form1
        ' 
        AutoScaleDimensions = New SizeF(10F, 25F)
        AutoScaleMode = AutoScaleMode.Font
        ClientSize = New Size(1329, 658)
        Controls.Add(Label6)
        Controls.Add(txtSearch)
        Controls.Add(DataGridView1)
        Controls.Add(BtnClear)
        Controls.Add(BtnDelete)
        Controls.Add(BtnUpdate)
        Controls.Add(BtnSave)
        Controls.Add(txtCourse)
        Controls.Add(txtPhoneNumber)
        Controls.Add(label5)
        Controls.Add(label4)
        Controls.Add(txtEmail)
        Controls.Add(label3)
        Controls.Add(txtName)
        Controls.Add(label2)
        Controls.Add(txtStudentID)
        Controls.Add(label1)
        Name = "Form1"
        ShowIcon = False
        ShowInTaskbar = False
        Text = "Form1"
        CType(DataGridView1, ComponentModel.ISupportInitialize).EndInit()
        ResumeLayout(False)
        PerformLayout()
    End Sub

    Friend WithEvents label1 As Label
    Friend WithEvents txtStudentID As TextBox
    Friend WithEvents label2 As Label
    Friend WithEvents txtName As TextBox
    Friend WithEvents label3 As Label
    Friend WithEvents txtEmail As TextBox
    Friend WithEvents label4 As Label
    Friend WithEvents label5 As Label
    Friend WithEvents txtPhoneNumber As TextBox
    Friend WithEvents txtCourse As TextBox
    Friend WithEvents BtnSave As Button
    Friend WithEvents BtnUpdate As Button
    Friend WithEvents BtnDelete As Button
    Friend WithEvents BtnClear As Button
    Friend WithEvents DataGridView1 As DataGridView
    Friend WithEvents txtSearch As TextBox
    Friend WithEvents Label6 As Label

End Class
