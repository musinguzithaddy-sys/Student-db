Imports MySqlConnector

Public Class Form1
    Dim connStr As String = "Server=mysql-3c0dd1f3-students-db.k.aivencloud.com;" &
                        "Port=12997;" &
                        "User ID=avnadmin;" &
                        "Password=Hidden;" &
                        "Database=defaultdb;" &
                        "SslMode=Required;"


    Dim conn As New MySqlConnection(connStr)
    Private Sub Label1_Click(sender As Object, e As EventArgs) Handles label1.Click

    End Sub

    Private Sub Form1_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Try
            ' 1. Open the bridge to your Aiven cloud database
            conn.Open()

            ' 2. The SQL instruction to build your students table if it doesn't exist yet
            Dim tableQuery As String = "CREATE TABLE If Not EXISTS students (student_id VARCHAR(50) PRIMARY KEY, full_name VARCHAR(100) Not NULL, course VARCHAR(100), phone_number VARCHAR(20), email VARCHAR(100));"
            Dim setupCmd As New MySqlCommand(tableQuery, conn)

            ' 3. Execute the instruction and safely close the connection
            setupCmd.ExecuteNonQuery()
            conn.Close()
        Catch ex As Exception
            conn.Close()
            MessageBox.Show("Initial cloud table setup failed: " & ex.Message, "Setup Error", MessageBoxButtons.OK, MessageBoxIcon.Warning)
        End Try

        ' Load live records onto the form layout
        LoadDataGrid()
    End Sub


    Private Sub BtnSave_Click(sender As Object, e As EventArgs) Handles BtnSave.Click
        ' Make sure the user didn't leave critical fields blank
        If txtStudentID.Text.Trim() = "" Or txtName.Text.Trim() = "" Then
            MessageBox.Show("Please enter a Student ID and Full Name!", "Input Error", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            Exit Sub
        End If

        Try
            ' SQL query matching the exact column names from your database image
            Dim query As String = "INSERT INTO students (student_id, full_name, course, phone_number, email) VALUES (@sid, @name, @course, @phone, @email)"
            Dim cmd As New MySqlCommand(query, conn)

            ' Link your form fields to the query keys safely
            cmd.Parameters.AddWithValue("@sid", txtStudentID.Text)
            cmd.Parameters.AddWithValue("@name", txtName.Text)
            cmd.Parameters.AddWithValue("@course", txtCourse.Text)
            cmd.Parameters.AddWithValue("@phone", txtPhoneNumber.Text)
            cmd.Parameters.AddWithValue("@email", txtEmail.Text)

            ' Open database connection, save data, and close connection
            conn.Open()
            cmd.ExecuteNonQuery()
            conn.Close()

            MessageBox.Show("Student Record Saved Successfully to MySQL!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information)

        Catch ex As Exception
            conn.Close()
            MessageBox.Show("Failed to save data: " & ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
        LoadDataGrid()
    End Sub

    Private Sub BtnClear_Click(sender As Object, e As EventArgs) Handles BtnClear.Click
        ' Clear out text contents inside all entry textboxes
        txtName.Clear()
        txtEmail.Clear()
        txtPhoneNumber.Clear()
        txtStudentID.Clear()
        txtCourse.Clear()

        ' Place the active typing focus cursor back to the first field automatically
        txtStudentID.Focus()

    End Sub

    Private Sub BtnUpdate_Click(sender As Object, e As EventArgs) Handles BtnUpdate.Click
        ' Validation check
        If txtStudentID.Text = "" Then
            MessageBox.Show("Please enter the Student ID you want to update!", "Input Error", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            Exit Sub
        End If

        Try
            ' SQL statement to modify columns based on a specific student_id key
            Dim query As String = "UPDATE students SET full_name=@name, course=@course, phone_number=@phone, email=@email WHERE student_id=@sid"
            Dim cmd As New MySqlCommand(query, conn)

            ' Link your custom form fields
            cmd.Parameters.AddWithValue("@sid", txtStudentID.Text)
            cmd.Parameters.AddWithValue("@name", txtName.Text)
            cmd.Parameters.AddWithValue("@course", txtCourse.Text)
            cmd.Parameters.AddWithValue("@phone", txtPhoneNumber.Text)
            cmd.Parameters.AddWithValue("@email", txtEmail.Text)

            conn.Open()
            Dim rowsAffected As Integer = cmd.ExecuteNonQuery()
            conn.Close()

            ' Check if the Student ID actually existed in the database table
            If rowsAffected > 0 Then
                MessageBox.Show("Student Record Updated Successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information)
            Else
                MessageBox.Show("No student found with that ID.", "Not Found", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            End If

        Catch ex As Exception
            conn.Close()
            MessageBox.Show("Failed to update data: " & ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
        LoadDataGrid()

    End Sub

    Private Sub BtnDelete_Click(sender As Object, e As EventArgs) Handles BtnDelete.Click
        ' Validation check
        If txtStudentID.Text = "" Then
            MessageBox.Show("Please enter the Student ID you wish to delete!", "Input Error", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            Exit Sub
        End If

        ' Ask the user for confirmation so records aren't erased by accident
        Dim confirm As DialogResult = MessageBox.Show("Are you sure you want to permanently delete this student record?", "Confirm Delete", MessageBoxButtons.YesNo, MessageBoxIcon.Question)

        If confirm = DialogResult.Yes Then
            Try
                ' SQL command to delete a matching row
                Dim query As String = "DELETE FROM students WHERE student_id=@sid"
                Dim cmd As New MySqlCommand(query, conn)

                cmd.Parameters.AddWithValue("@sid", txtStudentID.Text)

                conn.Open()
                Dim rowsAffected As Integer = cmd.ExecuteNonQuery()
                conn.Close()

                If rowsAffected > 0 Then
                    MessageBox.Show("Student Record Deleted Successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information)
                    ' Clear the form textboxes immediately since the record is gone
                    BtnClear_Click(Nothing, Nothing)
                Else
                    MessageBox.Show("No student found with that ID.", "Not Found", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
                End If

            Catch ex As Exception
                conn.Close()
                MessageBox.Show("Failed to delete data: " & ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            End Try
        End If
        LoadDataGrid()
    End Sub
    ' Reusable function to fetch live table entries from MySQL
    Public Sub LoadDataGrid()
        Try
            Dim query As String = "SELECT student_id As 'Student ID', full_name As 'Full Name', email As 'Email Address', phone_number As 'Phone Number', course As 'Course Module' FROM students"
            Dim cmd As New MySqlCommand(query, conn)
            Dim da As New MySqlDataAdapter(cmd)
            Dim dt As New DataTable()

            ' Fill up our temporary data table container
            da.Fill(dt)

            ' Bind the live records straight into your Guna Grid View control layout
            DataGridView1.DataSource = dt

        Catch ex As Exception
            MessageBox.Show("Error displaying live data grid rows: " & ex.Message, "Grid Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub DataGridView1_CellContentClick(sender As Object, e As DataGridViewCellEventArgs) Handles DataGridView1.CellContentClick

    End Sub


    Private Sub txtSearch_TextChanged(sender As Object, e As EventArgs) Handles txtSearch.TextChanged
        Try
            Dim query As String = "SELECT student_id As 'Student ID', full_name As 'Full Name', email As 'Email Address', phone_number As 'Phone Number', course As 'Course Module' FROM students WHERE full_name LIKE @search"
            Dim cmd As New MySqlCommand(query, conn)

            cmd.Parameters.AddWithValue("@search", "%" & txtSearch.Text.Trim() & "%")

            Dim da As New MySqlDataAdapter(cmd)
            Dim dt As New DataTable()

            da.Fill(dt)
            DataGridView1.DataSource = dt

        Catch ex As Exception
            MessageBox.Show("Error searching for records: " & ex.Message, "Search Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub
End Class
