Imports System.IO
Imports System.Text
Imports System.Windows.Forms.DataVisualization.Charting

Public Class Form1
    Private filePathCSV As String

    Private Sub btnOpen_Click(sender As Object, e As EventArgs) Handles btnOpen.Click
        Dim openFileDialog As New OpenFileDialog()
        openFileDialog.Filter = "CSV Files (*.csv)|*.csv|All Files (*.*)|*.*"

        If openFileDialog.ShowDialog() = DialogResult.Cancel Then
            Return
        End If

        filePathCSV = openFileDialog.FileName
        ShowCSV_InDGV()

    End Sub

    Public Sub ShowCSV_InDGV()
        dgvTableCSV.Rows.Clear()
        dgvTableCSV.Columns.Clear()

        ' Leer líneas del archivo CSV
        Dim lines As String() = File.ReadAllLines(filePathCSV)

        ' Si hay líneas en el archivo
        If lines.Length > 0 Then
            ' Obtener los nombres de las columnas del primer registro
            Dim columnNames As String() = lines(0).Split(","c)

            ' Agregar columnas al DataGridView usando los nombres de las columnas del CSV
            For Each columnName As String In columnNames
                dgvTableCSV.Columns.Add(columnName, columnName)
            Next

            ' Agregar filas al DataGridView con el contenido del CSV (excluyendo la primera línea)
            For i As Integer = 1 To lines.Length - 1
                Dim fields As String() = lines(i).Split(","c)
                dgvTableCSV.Rows.Add(fields)
            Next
        End If
    End Sub

    Private Sub btnSearch_Click(sender As Object, e As EventArgs) Handles btnSearch.Click
        If String.IsNullOrEmpty(filePathCSV) OrElse Not File.Exists(filePathCSV) Then
            MessageBox.Show("Select a file to work with.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            Return
        End If

        If txtSearchCSV.Text = "" Then
            MessageBox.Show("To search, you must use a NAME.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            Return
        End If

        Try
            ' Leer el archivo CSV línea por línea
            Using reader As New StreamReader(filePathCSV)
                While Not reader.EndOfStream
                    Dim line As String = reader.ReadLine()
                    Dim fields As String() = line.Split(","c)

                    ' Comparar el término de búsqueda con el primer campo (en este caso, el nombre)
                    If fields.Length > 0 AndAlso fields(0) = txtSearchCSV.Text Then
                        MessageBox.Show("Found: " & String.Join(", ", fields), "Warning", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
                        Return
                    End If
                End While
            End Using
        Catch ex As Exception
            Console.WriteLine("Error searching in the CSV file: " & ex.Message)
        End Try

        MessageBox.Show("No matching name found in the file", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
    End Sub

    Private Sub btnSave_Click(sender As Object, e As EventArgs) Handles btnSave.Click
        ' Verificar si hay datos en el DataGridView
        If dgvTableCSV.Rows.Count = 0 Then
            MessageBox.Show("No hay datos para guardar.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Return
        End If

        Try
            ' Obtener la ruta del archivo CSV
            Dim filePath As String = filePathCSV

            ' Crear un StringBuilder para construir el contenido del archivo CSV
            Dim csvContent As New StringBuilder()

            ' Agregar los encabezados de columna al archivo CSV
            For i As Integer = 0 To dgvTableCSV.Columns.Count - 1
                csvContent.Append(dgvTableCSV.Columns(i).HeaderText)
                If i < dgvTableCSV.Columns.Count - 1 Then
                    csvContent.Append(",")
                End If
            Next
            csvContent.AppendLine() ' Agregar nueva línea después de los encabezados

            ' Obtener los datos y los índices de las filas que tienen valores en la columna "Revenue"
            Dim revenueData = dgvTableCSV.Rows.Cast(Of DataGridViewRow)() _
                        .Where(Function(row) row.Cells("Revenue").Value IsNot Nothing) _
                        .Select(Function(row) New With {.Value = Convert.ToDecimal(row.Cells("Revenue").Value), .Index = row.Index}) _
                        .OrderByDescending(Function(row) row.Value) _
                        .ToList()

            ' Agregar datos de cada fila al archivo CSV en el orden ordenado
            For Each rowData In revenueData
                Dim row As DataGridViewRow = dgvTableCSV.Rows(rowData.Index)
                Dim hasData As Boolean = False ' Bandera para verificar si la fila tiene celdas no vacías
                Dim rowDataStr As New StringBuilder()

                For i As Integer = 0 To dgvTableCSV.Columns.Count - 1
                    ' Verificar si el valor de la celda no es nulo ni está vacío
                    If row.Cells(i).Value IsNot Nothing AndAlso Not String.IsNullOrWhiteSpace(row.Cells(i).Value.ToString()) Then
                        rowDataStr.Append(row.Cells(i).Value.ToString())
                        hasData = True ' Establecer la bandera en true si la celda tiene un valor no vacío
                    End If

                    If i < dgvTableCSV.Columns.Count - 1 Then
                        rowDataStr.Append(",")
                    End If
                Next

                ' Agregar los datos de la fila al contenido del CSV si la fila tiene celdas no vacías
                If hasData Then
                    csvContent.AppendLine(rowDataStr.ToString())
                End If
            Next

            ' Escribir el contenido en el archivo CSV
            File.WriteAllText(filePath, csvContent.ToString())

            MessageBox.Show("Los datos se guardaron correctamente en el archivo CSV.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information)
        Catch ex As Exception
            MessageBox.Show("Error al guardar datos en el archivo CSV: " & ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try

        ShowCSV_InDGV()
    End Sub

    Private Sub btnDelete_Click(sender As Object, e As EventArgs) Handles btnDelete.Click
        ' Check if a file is selected
        If String.IsNullOrWhiteSpace(filePathCSV) OrElse Not File.Exists(filePathCSV) Then
            MessageBox.Show("Select a valid file to work with.", "Attention", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            Return
        End If

        ' Check if a name to search for is entered
        If String.IsNullOrWhiteSpace(txtSearchCSV.Text) Then
            MessageBox.Show("Please enter a name to search for.", "Attention", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            Return
        End If

        Try
            ' Read the CSV file line by line and write the non-deleted lines to a new temporary file
            Dim tempFilePath As String = Path.GetTempFileName()
            Using reader As New StreamReader(filePathCSV)
                Using writer As New StreamWriter(tempFilePath)
                    Dim line As String = reader.ReadLine()
                    While line IsNot Nothing
                        ' Check if the current line contains the name to delete
                        If Not line.Contains(txtSearchCSV.Text) Then
                            writer.WriteLine(line)
                        End If
                        line = reader.ReadLine()
                    End While
                End Using
            End Using

            ' Replace the original file with the temporary file
            File.Delete(filePathCSV)
            File.Move(tempFilePath, filePathCSV)
            ShowCSV_InDGV()
        Catch ex As Exception
            MessageBox.Show("Error deleting line from the CSV file: " & ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try

    End Sub

    Private Sub btnSaveNewFile_Click(sender As Object, e As EventArgs) Handles btnSaveNewFile.Click
        ' Check if there is data in the DataGridView
        If dgvTableCSV.Rows.Count = 0 Then
            MessageBox.Show("There is no data to save.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Return
        End If

        ' Get the index of the "Revenue" column
        Dim revenueColumnIndex As Integer = dgvTableCSV.Columns("Revenue").Index

        ' Obtain data and row indices of the "Revenue" column, excluding the last row
        Dim revenueData = dgvTableCSV.Rows.Cast(Of DataGridViewRow)() _
    .Where(Function(row) row.Index <> dgvTableCSV.Rows.Count - 1 AndAlso row.Cells(revenueColumnIndex).Value IsNot Nothing) _
    .Select(Function(row) Convert.ToDecimal(row.Cells(revenueColumnIndex).Value)) _
    .ToList()

        Dim rowIndices = dgvTableCSV.Rows.Cast(Of DataGridViewRow)() _
    .Where(Function(row) row.Index <> dgvTableCSV.Rows.Count - 1 AndAlso row.Cells(revenueColumnIndex).Value IsNot Nothing) _
    .Select(Function(row) row.Index) _
    .ToList()

        ' Sort the revenue data and row indices in descending order
        Dim sortedData = revenueData.OrderByDescending(Function(x) x).ToList()
        Dim sortedIndices = rowIndices.OrderByDescending(Function(x) revenueData(rowIndices.IndexOf(x))).ToList()

        ' Create a SaveFileDialog instance
        Dim saveFileDialog As New SaveFileDialog()
        saveFileDialog.Filter = "CSV Files (*.csv)|*.csv"
        saveFileDialog.Title = "Save as CSV File"

        ' Set initial directory and default file name
        saveFileDialog.InitialDirectory = Path.GetDirectoryName(filePathCSV)
        saveFileDialog.FileName = Path.GetFileNameWithoutExtension(filePathCSV) & "_new.csv"

        If saveFileDialog.ShowDialog() = DialogResult.Cancel Then
            Return
        End If

        filePathCSV = saveFileDialog.FileName

        Try
            ' Create a StringBuilder to build the content of the CSV file
            Dim csvContent As New StringBuilder()

            ' Add column headers to the CSV file
            For i As Integer = 0 To dgvTableCSV.Columns.Count - 1
                csvContent.Append(dgvTableCSV.Columns(i).HeaderText)
                If i < dgvTableCSV.Columns.Count - 1 Then
                    csvContent.Append(",")
                End If
            Next
            csvContent.AppendLine() ' Add new line after headers

            ' Add data from each row to the CSV file
            For Each rowIndex As Integer In sortedIndices
                Dim row As DataGridViewRow = dgvTableCSV.Rows(rowIndex)
                Dim hasData As Boolean = False ' Flag to check if the row has any non-empty cells
                Dim rowData As New StringBuilder()

                For i As Integer = 0 To dgvTableCSV.Columns.Count - 1
                    ' Check if the cell value is not null or empty
                    If row.Cells(i).Value IsNot Nothing AndAlso Not String.IsNullOrWhiteSpace(row.Cells(i).Value.ToString()) Then
                        rowData.Append(row.Cells(i).Value.ToString())
                        hasData = True ' Set flag to true if the cell has non-empty value
                    End If

                    If i < dgvTableCSV.Columns.Count - 1 Then
                        rowData.Append(",")
                    End If
                Next

                ' Add row data to the CSV content if the row has any non-empty cells
                If hasData Then
                    csvContent.AppendLine(rowData.ToString())
                End If
            Next

            ' Write the content to the CSV file
            File.WriteAllText(filePathCSV, csvContent.ToString())

            MessageBox.Show("Data saved successfully to the CSV file.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information)
        Catch ex As Exception
            MessageBox.Show("Error saving data to the CSV file: " & ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try

        ShowCSV_InDGV()

    End Sub

    Private Sub btnUpdate_Click(sender As Object, e As EventArgs) Handles btnUpdate.Click
        ' Obtener los datos del DataGridView
        Dim data As New Dictionary(Of String, Decimal)()
        For Each row As DataGridViewRow In dgvTableCSV.Rows
            ' Verificar si la celda "Product" no es nula
            If row.Cells("Product").Value IsNot Nothing Then
                Dim product As String = row.Cells("Product").Value.ToString()
                Dim revenue As Decimal = 0

                ' Verificar si la celda "Revenue" no es nula
                If row.Cells("Revenue").Value IsNot Nothing AndAlso Decimal.TryParse(row.Cells("Revenue").Value.ToString(), revenue) Then
                    If Not data.ContainsKey(product) Then
                        data.Add(product, revenue)
                    End If
                End If
            End If
        Next

        ' Limpiar el Chart antes de agregar nuevos datos
        Chart1.Series.Clear()
        Chart1.ChartAreas(0).AxisX.Title = "Productos"
        Chart1.ChartAreas(0).AxisY.Title = "Revenue"

        ' Definir una lista de colores diferentes para cada serie
        Dim colors As Color() = {Color.Red, Color.Blue, Color.Green, Color.Orange, Color.Purple, Color.Yellow}

        ' Contador para iterar sobre la lista de colores
        Dim colorIndex As Integer = 0

        ' Agregar datos al Chart
        For Each entry In data
            Dim product As String = entry.Key
            Dim revenue As Decimal = entry.Value

            ' Agregar una nueva serie al gráfico con el nombre del producto
            Chart1.Series.Add(product)

            ' Asignar un color diferente a la serie actual
            Chart1.Series(product).Color = colors(colorIndex)

            ' Agregar el punto (valor de revenue) a la serie actual
            Chart1.Series(product).Points.AddY(revenue)

            ' Incrementar el índice del color
            colorIndex += 1

            ' Reiniciar el índice del color si se excede el número de colores definidos
            If colorIndex >= colors.Length Then
                colorIndex = 0
            End If
        Next

        ' Personalizar el gráfico (opcional)
        Chart1.ChartAreas(0).AxisX.Interval = 1 ' Mostrar una etiqueta por cada producto
        Chart1.Series(0).ChartType = SeriesChartType.Column ' Tipo de gráfico de barras
    End Sub
End Class

