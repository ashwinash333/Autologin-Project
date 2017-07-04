Imports System.IO
Imports System.Web.Script.Serialization


Public Class Form1
    Dim maskproperty As Boolean = True
    Dim s As JavaScriptSerializer = New JavaScriptSerializer()
    Dim j As String = File.ReadAllText(My.Computer.FileSystem.SpecialDirectories.MyDocuments & "\json1.json")
    Dim l As login = New login()

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        ListBox3.Items.Clear()

        If maskproperty = True Then

            l = s.Deserialize(Of login)(j)
            Dim listcount As Integer = l.login.Count
            For i = 0 To listcount - 1
                ListBox3.Items.Add(l.login.Item(i).password.ToString)
            Next i
            maskproperty = False
            Return
        ElseIf maskproperty = False Then


            l = s.Deserialize(Of login)(j)
            Dim listcount As Integer = l.login.Count
            Dim i As Integer
            For i = 0 To listcount - 1
                Dim strC As String
                Dim setcount As Integer = l.login.Item(i).password.ToString.Count
                strC = StrDup(setcount, "*")
                ListBox3.Items.Add(strC)
            Next i
            maskproperty = True
            Return

        End If
    End Sub

    Private Sub Form1_Load(sender As Object, e As EventArgs) Handles MyBase.Load


        l = s.Deserialize(Of login)(j)
        Dim listcount As Integer = l.login.Count
        Dim i As Integer

        For i = 0 To listcount - 1
            Dim strC As String
            Dim setcount As Integer = l.login.Item(i).password.ToString.Count
            ListBox1.Items.Add(l.login.Item(i).website.ToString)
            ListBox2.Items.Add(l.login.Item(i).username.ToString)
            strC = StrDup(setcount, "*")
            ListBox3.Items.Add(strC)
        Next i

    End Sub



    Private Sub onlistitemclicked(sender As Object, e As EventArgs) Handles ListBox1.DoubleClick

        l = s.Deserialize(Of login)(j)
        Dim indf As Integer = ListBox1.SelectedIndex
        Dim username As String = l.login.Item(indf).username
        Dim password As String = l.login.Item(indf).password
        Dim url As String = l.login.Item(indf).url
        Dim wsh As Object = CreateObject("WScript.Shell")
        If url.Equals("https://accounts.google.com/signin") Then
            wsh.Run("chrome.exe", 3)
            Threading.Thread.Sleep(5000)
            wsh.SendKeys("^+n")
            Threading.Thread.Sleep(3000)
            wsh.SendKeys(url)
            Threading.Thread.Sleep(1000)
            wsh.SendKeys("{ENTER}")
            Threading.Thread.Sleep(8000)
            wsh.SendKeys(username)
            Threading.Thread.Sleep(1000)
            wsh.SendKeys("{ENTER}")
            Threading.Thread.Sleep(4000)
            wsh.SendKeys(password)
            Threading.Thread.Sleep(1000)
            wsh.SendKeys("{ENTER}")
            Threading.Thread.Sleep(4000)
            wsh.SendKeys("^l")
            Threading.Thread.Sleep(1000)
            wsh.SendKeys("{BKSP}")
            Threading.Thread.Sleep(1000)
            wsh.SendKeys("https://mail.google.com/mail/u/0/#inbox")
            Threading.Thread.Sleep(1000)
            wsh.SendKeys("{ENTER}")
            Threading.Thread.Sleep(4000)
        End If
        If url.Equals("https://www.facebook.com/?_rdr") Then
            wsh.Run("chrome.exe", 3)
            Threading.Thread.Sleep(5000)
            wsh.SendKeys("^+n")
            Threading.Thread.Sleep(3000)
            wsh.SendKeys(url)
            Threading.Thread.Sleep(1000)
            wsh.SendKeys("{ENTER}")
            Threading.Thread.Sleep(6000)
            wsh.sendkeys("+{TAB}")
            Threading.Thread.Sleep(600)
            wsh.sendkeys("+{TAB}")
            Threading.Thread.Sleep(600)
            wsh.sendkeys("+{TAB}")
            Threading.Thread.Sleep(600)
            wsh.sendkeys("+{TAB}")
            Threading.Thread.Sleep(600)
            wsh.sendkeys("+{TAB}")
            Threading.Thread.Sleep(600)
            wsh.sendkeys(username)
            Threading.Thread.Sleep(1000)
            wsh.sendkeys("{TAB}")
            Threading.Thread.Sleep(600)
            wsh.sendkeys(password)
            Threading.Thread.Sleep(600)
            wsh.sendkeys("{TAB}")
            Threading.Thread.Sleep(600)
            wsh.sendkeys("{ENTER}")
            Threading.Thread.Sleep(4000)
        End If

    End Sub



    Private Sub onlist3click(sender As Object, e As EventArgs) Handles ListBox3.DoubleClick
        Dim setthis As Integer = ListBox3.SelectedIndex

        l = s.Deserialize(Of login)(j)
        My.Computer.Clipboard.SetText(l.login.Item(setthis).password.ToString)

        clipcop.Text = ListBox3.SelectedItem.ToString()
    End Sub

    Private Sub onlist2click(sender As Object, e As EventArgs) Handles ListBox2.DoubleClick
        My.Computer.Clipboard.SetText(ListBox2.SelectedItem.ToString())
        clipcop.Text = ListBox2.SelectedItem.ToString()
    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click

        l = s.Deserialize(Of login)(j)
        Dim indf As Integer = ListBox1.SelectedIndex
        Dim username As String = l.login.Item(indf).username
        Dim password As String = l.login.Item(indf).password
        Dim url As String = l.login.Item(indf).url
        Dim wsh As Object = CreateObject("WScript.Shell")
        If url.Equals("https://accounts.google.com/signin") Then
            wsh.Run("firefox.exe", 3)
            Threading.Thread.Sleep(5000)
            wsh.SendKeys("^+p")
            Threading.Thread.Sleep(3000)
            wsh.SendKeys(url)
            Threading.Thread.Sleep(1000)
            wsh.SendKeys("{ENTER}")
            Threading.Thread.Sleep(8000)
            wsh.SendKeys(username)
            Threading.Thread.Sleep(1000)
            wsh.SendKeys("{ENTER}")
            Threading.Thread.Sleep(4000)
            wsh.SendKeys(password)
            Threading.Thread.Sleep(1000)
            wsh.SendKeys("{ENTER}")
            Threading.Thread.Sleep(4000)
            wsh.SendKeys("^l")
            Threading.Thread.Sleep(1000)
            wsh.SendKeys("{BKSP}")
            Threading.Thread.Sleep(1000)
            wsh.SendKeys("https://mail.google.com/mail/u/0/#inbox")
            Threading.Thread.Sleep(1000)
            wsh.SendKeys("{ENTER}")
            Threading.Thread.Sleep(4000)
        End If
        If url.Equals("https://www.facebook.com/?_rdr") Then
            wsh.Run("firefox.exe", 3)
            Threading.Thread.Sleep(5000)
            wsh.SendKeys("^+p")
            Threading.Thread.Sleep(3000)
            wsh.SendKeys(url)
            Threading.Thread.Sleep(1000)
            wsh.SendKeys("{ENTER}")
            Threading.Thread.Sleep(6000)
            wsh.sendkeys("+{TAB}")
            Threading.Thread.Sleep(600)
            wsh.sendkeys("+{TAB}")
            Threading.Thread.Sleep(600)
            wsh.sendkeys("+{TAB}")
            Threading.Thread.Sleep(600)
            wsh.sendkeys("+{TAB}")
            Threading.Thread.Sleep(600)
            wsh.sendkeys("+{TAB}")
            Threading.Thread.Sleep(600)
            wsh.sendkeys(username)
            Threading.Thread.Sleep(1000)
            wsh.sendkeys("{TAB}")
            Threading.Thread.Sleep(600)
            wsh.sendkeys(password)
            Threading.Thread.Sleep(600)
            wsh.sendkeys("{TAB}")
            Threading.Thread.Sleep(600)
            wsh.sendkeys("{ENTER}")
            Threading.Thread.Sleep(4000)
        End If

    End Sub

    Private Sub Button3_Click(sender As Object, e As EventArgs) Handles Button3.Click
        OpenFileDialog1.Filter = "(*json)|*.json"
        If Directory.Exists(My.Computer.FileSystem.SpecialDirectories.MyDocuments) Then
            OpenFileDialog1.InitialDirectory = My.Computer.FileSystem.SpecialDirectories.MyDocuments
        End If
        OpenFileDialog1.ShowDialog()

        Shell("Notepad " + OpenFileDialog1.FileName, vbNormalFocus)

    End Sub

    Private Sub Button4_Click(sender As Object, e As EventArgs) Handles Button4.Click
        ListBox1.Items.Clear()
        ListBox2.Items.Clear()
        ListBox3.Items.Clear()
        Dim s As JavaScriptSerializer = New JavaScriptSerializer()
        Dim j As String = File.ReadAllText(My.Computer.FileSystem.SpecialDirectories.MyDocuments & "\json1.json")
        Dim l As login = New login()
        l = s.Deserialize(Of login)(j)
        Dim listcount As Integer = l.login.Count
        For i = 0 To listcount - 1
            Dim strC As String
            Dim setcount As Integer = l.login.Item(i).password.ToString.Count
            ListBox1.Items.Add(l.login.Item(i).website.ToString)
            ListBox2.Items.Add(l.login.Item(i).username.ToString)
            strC = StrDup(setcount, "*")
            ListBox3.Items.Add(strC)
        Next i
    End Sub
End Class

Class login
    Public Property login As List(Of loginDetails)
End Class

Class loginDetails

    Public Property website As String
    Public Property username As String
    Public Property password As String
    Public Property url As String
End Class

