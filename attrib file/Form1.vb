Public Class Form1



    ' hello all 
    'اليوم سنعمل علي برمجة برنامج لإضع=هر الملفات التي تخفيها الفيروسات 
    'وخاصة فيروس الديودة 
    Dim path As String = New System.IO.FileInfo(Application.ExecutablePath).DirectoryName 'هذا الخاصية لتحديدالمسار وجود البرنامج "مثلا لو كان المسار c 
    Private Sub Form1_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Dim di As New IO.DirectoryInfo(Path)
        Dim diar1 As IO.FileInfo() = di.GetFiles()
        Dim dra As IO.FileInfo


        For Each dra In diar1

            Dim search, where
            search = "." ' هنا مثلا انت تحدد نوع من الملافات مثلا صورة تكتب jpg gif png وادا كنت تريد جميع الملافات فتكتب نقطة فقط 
            where = InStr(dra.Name, search)

            If where Then
                ListBox1.Items.Add(dra)
            End If
            TextBox1.Text = path
            T3.Text = ListBox1.Items.Count 'لمعرفة كم سطر في اللست اي كم ملف وجد البرنامج 
        Next

        ProgressBar1.Minimum = "0"
        ProgressBar1.Maximum = T3.Text - 1
        '  MsgBox(path) ' هنا سنلاحض ان الملف يحدد مسار المجل تلقائا 
        'هكذا نكون انتهينا من تحديد كل الملفات حتي وان كانت مخفية 
        'ملاحظة يوجد الكثير من الطرق لبحث 
        ' ولاكن هذه الطريقة الاسهر والاسرع 
        ComboBox1.Items.Add("Normal")
        ComboBox1.Items.Add("Hidden")
        ComboBox1.Items.Add("system + Hide")
        ComboBox1.Items.Add("Archive")
        ComboBox1.Items.Add("Directory")
        ComboBox1.Items.Add("ReadOnly")
        ComboBox1.Items.Add("System")
        ComboBox1.Items.Add("Volume")
        ComboBox1.SelectedIndex = 0

    End Sub

    Private Sub Timer1_Tick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Timer1.Tick
        On Error Resume Next 'هده لتخطي اي خطا بدون اي رسالة 
        Dim a As String = ListBox1.Items.Count
        a = a - 1
        T2.Text = ListBox1.SelectedIndex ' هدا لمعرفة item  المحدد في اليست لمعرفة الملف المحدد لعمل عليه 
        ListBox1.SelectedIndex += 1 ' طر المحدد الي الاخير هذا الكوذ لقرائة كل سطور الليست من الس
        If T2.Text = a Then

            Timer1.Enabled = False
            MsgBox(" Set And Get Attrib")
        End If
    End Sub

    Private Sub CheckBox1_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CheckBox1.CheckedChanged

        Timer1.Enabled = True

    End Sub

    Private Sub T2_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles T2.TextChanged
        TextBox2.Text = ListBox1.Text
    End Sub

    Private Sub TextBox2_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TextBox2.TextChanged
        Dim a = TextBox3.Text
        TextBox3.Text = a & vbCrLf & TextBox1.Text & "/" & TextBox2.Text & " :" & ComboBox1.Text & "  :" & vattr.Text & " ... OK "

        ProgressBar1.Value = T2.Text
        SetAttr(TextBox1.Text & "\" & TextBox2.Text, vattr.Text)
        l1.Text = TextBox1.Text & "/" & TextBox2.Text & " :" & ComboBox1.Text & "  :" & vattr.Text & " ... OK "
    End Sub

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        ListBox1.SelectedIndex = 0 'لبداية القراءة من الاول 
        Timer1.Enabled = True

    End Sub

    Private Sub ComboBox1_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ComboBox1.SelectedIndexChanged
        If ComboBox1.Text = "Normal" Then
            vattr.Text = "0"

        ElseIf ComboBox1.Text = "Hidden" Then
            vattr.Text = "2"

        ElseIf ComboBox1.Text = "system + Hide" Then
            vattr.Text = "39"

        ElseIf ComboBox1.Text = "Archive" Then
            vattr.Text = "32"

        ElseIf ComboBox1.Text = "Directory" Then
            vattr.Text = "16"

        ElseIf ComboBox1.Text = "ReadOnly" Then
            vattr.Text = "1"

        ElseIf ComboBox1.Text = "System" Then
            vattr.Text = "4"

        ElseIf ComboBox1.Text = "Volume" Then
            vattr.Text = "8"

            '    ElseIf 
        End If
    End Sub
End Class
