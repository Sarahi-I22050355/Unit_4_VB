<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class Form1
    Inherits System.Windows.Forms.Form

    'Form reemplaza a Dispose para limpiar la lista de componentes.
    <System.Diagnostics.DebuggerNonUserCode()>
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        Try
            If disposing AndAlso components IsNot Nothing Then
                components.Dispose()
            End If
        Finally
            MyBase.Dispose(disposing)
        End Try
    End Sub

    'Requerido por el Diseñador de Windows Forms
    Private components As System.ComponentModel.IContainer

    'NOTA: el Diseñador de Windows Forms necesita el siguiente procedimiento
    'Se puede modificar usando el Diseñador de Windows Forms.  
    'No lo modifique con el editor de código.
    <System.Diagnostics.DebuggerStepThrough()>
    Private Sub InitializeComponent()
        Dim ChartArea7 As System.Windows.Forms.DataVisualization.Charting.ChartArea = New System.Windows.Forms.DataVisualization.Charting.ChartArea()
        Dim Legend7 As System.Windows.Forms.DataVisualization.Charting.Legend = New System.Windows.Forms.DataVisualization.Charting.Legend()
        Dim Series7 As System.Windows.Forms.DataVisualization.Charting.Series = New System.Windows.Forms.DataVisualization.Charting.Series()
        Me.btnUpdate = New System.Windows.Forms.Button()
        Me.btnSaveNewFile = New System.Windows.Forms.Button()
        Me.label2 = New System.Windows.Forms.Label()
        Me.label1 = New System.Windows.Forms.Label()
        Me.txtSearchCSV = New System.Windows.Forms.TextBox()
        Me.btnDelete = New System.Windows.Forms.Button()
        Me.btnSearch = New System.Windows.Forms.Button()
        Me.btnSave = New System.Windows.Forms.Button()
        Me.btnOpen = New System.Windows.Forms.Button()
        Me.dgvTableCSV = New System.Windows.Forms.DataGridView()
        Me.Product = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Column3 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Column4 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Revenue = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Chart1 = New System.Windows.Forms.DataVisualization.Charting.Chart()
        CType(Me.dgvTableCSV, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Chart1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'btnUpdate
        '
        Me.btnUpdate.FlatStyle = System.Windows.Forms.FlatStyle.System
        Me.btnUpdate.Font = New System.Drawing.Font("Arial Narrow", 10.8!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnUpdate.Location = New System.Drawing.Point(854, 362)
        Me.btnUpdate.Name = "btnUpdate"
        Me.btnUpdate.Size = New System.Drawing.Size(149, 43)
        Me.btnUpdate.TabIndex = 20
        Me.btnUpdate.Text = "Update"
        Me.btnUpdate.UseVisualStyleBackColor = True
        '
        'btnSaveNewFile
        '
        Me.btnSaveNewFile.FlatStyle = System.Windows.Forms.FlatStyle.System
        Me.btnSaveNewFile.Font = New System.Drawing.Font("Arial Narrow", 10.8!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnSaveNewFile.Location = New System.Drawing.Point(181, 356)
        Me.btnSaveNewFile.Name = "btnSaveNewFile"
        Me.btnSaveNewFile.Size = New System.Drawing.Size(149, 43)
        Me.btnSaveNewFile.TabIndex = 19
        Me.btnSaveNewFile.Text = "Save new file"
        Me.btnSaveNewFile.UseVisualStyleBackColor = True
        '
        'label2
        '
        Me.label2.AutoSize = True
        Me.label2.Font = New System.Drawing.Font("Arial Narrow", 10.8!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.label2.Location = New System.Drawing.Point(532, 151)
        Me.label2.Name = "label2"
        Me.label2.Size = New System.Drawing.Size(102, 22)
        Me.label2.TabIndex = 18
        Me.label2.Text = "Text to Search"
        '
        'label1
        '
        Me.label1.AutoSize = True
        Me.label1.Font = New System.Drawing.Font("Arial Narrow", 22.2!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.label1.Location = New System.Drawing.Point(18, 35)
        Me.label1.Name = "label1"
        Me.label1.Size = New System.Drawing.Size(271, 43)
        Me.label1.TabIndex = 17
        Me.label1.Text = "Inventory Manager"
        '
        'txtSearchCSV
        '
        Me.txtSearchCSV.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtSearchCSV.Font = New System.Drawing.Font("Arial Narrow", 10.8!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtSearchCSV.Location = New System.Drawing.Point(536, 176)
        Me.txtSearchCSV.Name = "txtSearchCSV"
        Me.txtSearchCSV.Size = New System.Drawing.Size(181, 28)
        Me.txtSearchCSV.TabIndex = 16
        '
        'btnDelete
        '
        Me.btnDelete.FlatStyle = System.Windows.Forms.FlatStyle.System
        Me.btnDelete.Font = New System.Drawing.Font("Arial Narrow", 10.8!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnDelete.Location = New System.Drawing.Point(536, 259)
        Me.btnDelete.Name = "btnDelete"
        Me.btnDelete.Size = New System.Drawing.Size(149, 43)
        Me.btnDelete.TabIndex = 15
        Me.btnDelete.Text = "Delete"
        Me.btnDelete.UseVisualStyleBackColor = True
        '
        'btnSearch
        '
        Me.btnSearch.FlatStyle = System.Windows.Forms.FlatStyle.System
        Me.btnSearch.Font = New System.Drawing.Font("Arial Narrow", 10.8!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnSearch.Location = New System.Drawing.Point(536, 210)
        Me.btnSearch.Name = "btnSearch"
        Me.btnSearch.Size = New System.Drawing.Size(149, 43)
        Me.btnSearch.TabIndex = 14
        Me.btnSearch.Text = "Search"
        Me.btnSearch.UseVisualStyleBackColor = True
        '
        'btnSave
        '
        Me.btnSave.FlatStyle = System.Windows.Forms.FlatStyle.System
        Me.btnSave.Font = New System.Drawing.Font("Arial Narrow", 10.8!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnSave.Location = New System.Drawing.Point(181, 307)
        Me.btnSave.Name = "btnSave"
        Me.btnSave.Size = New System.Drawing.Size(149, 43)
        Me.btnSave.TabIndex = 13
        Me.btnSave.Text = "Save"
        Me.btnSave.UseVisualStyleBackColor = True
        '
        'btnOpen
        '
        Me.btnOpen.FlatStyle = System.Windows.Forms.FlatStyle.System
        Me.btnOpen.Font = New System.Drawing.Font("Arial Narrow", 10.8!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnOpen.Location = New System.Drawing.Point(26, 307)
        Me.btnOpen.Name = "btnOpen"
        Me.btnOpen.Size = New System.Drawing.Size(149, 43)
        Me.btnOpen.TabIndex = 12
        Me.btnOpen.Text = "Open"
        Me.btnOpen.UseVisualStyleBackColor = True
        '
        'dgvTableCSV
        '
        Me.dgvTableCSV.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgvTableCSV.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.Product, Me.Column3, Me.Column4, Me.Revenue})
        Me.dgvTableCSV.Location = New System.Drawing.Point(26, 81)
        Me.dgvTableCSV.MultiSelect = False
        Me.dgvTableCSV.Name = "dgvTableCSV"
        Me.dgvTableCSV.RowHeadersVisible = False
        Me.dgvTableCSV.RowHeadersWidth = 51
        Me.dgvTableCSV.RowTemplate.Height = 24
        Me.dgvTableCSV.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.dgvTableCSV.Size = New System.Drawing.Size(504, 220)
        Me.dgvTableCSV.TabIndex = 11
        '
        'Product
        '
        Me.Product.HeaderText = "Product"
        Me.Product.MinimumWidth = 6
        Me.Product.Name = "Product"
        Me.Product.Width = 125
        '
        'Column3
        '
        Me.Column3.HeaderText = "Quantity"
        Me.Column3.MinimumWidth = 6
        Me.Column3.Name = "Column3"
        Me.Column3.Width = 125
        '
        'Column4
        '
        Me.Column4.HeaderText = "Price"
        Me.Column4.MinimumWidth = 6
        Me.Column4.Name = "Column4"
        Me.Column4.Width = 125
        '
        'Revenue
        '
        Me.Revenue.HeaderText = "Revenue"
        Me.Revenue.MinimumWidth = 6
        Me.Revenue.Name = "Revenue"
        Me.Revenue.Width = 125
        '
        'Chart1
        '
        ChartArea7.Name = "ChartArea1"
        Me.Chart1.ChartAreas.Add(ChartArea7)
        Legend7.Name = "Legend1"
        Me.Chart1.Legends.Add(Legend7)
        Me.Chart1.Location = New System.Drawing.Point(852, 33)
        Me.Chart1.Name = "Chart1"
        Series7.ChartArea = "ChartArea1"
        Series7.Legend = "Legend1"
        Series7.Name = "Series1"
        Me.Chart1.Series.Add(Series7)
        Me.Chart1.Size = New System.Drawing.Size(517, 316)
        Me.Chart1.TabIndex = 21
        Me.Chart1.Text = "Chart1"
        '
        'Form1
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(8.0!, 16.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.SystemColors.ControlDark
        Me.ClientSize = New System.Drawing.Size(1470, 440)
        Me.Controls.Add(Me.Chart1)
        Me.Controls.Add(Me.btnUpdate)
        Me.Controls.Add(Me.btnSaveNewFile)
        Me.Controls.Add(Me.label2)
        Me.Controls.Add(Me.label1)
        Me.Controls.Add(Me.txtSearchCSV)
        Me.Controls.Add(Me.btnDelete)
        Me.Controls.Add(Me.btnSearch)
        Me.Controls.Add(Me.btnSave)
        Me.Controls.Add(Me.btnOpen)
        Me.Controls.Add(Me.dgvTableCSV)
        Me.Name = "Form1"
        Me.Text = "Form1"
        CType(Me.dgvTableCSV, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Chart1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Private WithEvents btnUpdate As Button
    Private WithEvents btnSaveNewFile As Button
    Private WithEvents label2 As Label
    Private WithEvents label1 As Label
    Private WithEvents txtSearchCSV As TextBox
    Private WithEvents btnDelete As Button
    Private WithEvents btnSearch As Button
    Private WithEvents btnSave As Button
    Private WithEvents btnOpen As Button
    Private WithEvents dgvTableCSV As DataGridView
    Private WithEvents Product As DataGridViewTextBoxColumn
    Private WithEvents Column3 As DataGridViewTextBoxColumn
    Private WithEvents Column4 As DataGridViewTextBoxColumn
    Private WithEvents Revenue As DataGridViewTextBoxColumn
    Friend WithEvents Chart1 As DataVisualization.Charting.Chart
End Class