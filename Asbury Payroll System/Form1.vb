Imports System.Threading.Tasks
Imports System.Windows.Forms
Imports System.Runtime.InteropServices
Imports System.Text
Imports System.Drawing
Imports System.IO
Imports System.Drawing.Graphics
Imports System.Drawing.Design
Public Class Form1
    '##################################################33
    ' Const And dll functions For moving form

    Public Const WM_NCLBUTTONDOWN As Integer = &HA1
    Public Const HT_CAPTION As Integer = &H2

    <DllImport("user32.dll", SetLastError:=True, CharSet:=CharSet.Auto)>
    Private Shared Function SendMessage(ByVal hWnd As IntPtr,
            ByVal Msg As UInteger,
            ByVal wParam As IntPtr,
            ByVal lParam As IntPtr) As IntPtr
    End Function

    <DllImportAttribute("user32.dll")>
    Public Shared Function ReleaseCapture() As Boolean
    End Function
    Private Sub TopPanel_botton_MouseDown(sender As Object, e As MouseEventArgs) Handles TopPanel_botton.MouseDown
        Top_Panel1_MouseDown_1(sender, e)
    End Sub
    Private Sub Top_Panel1_MouseDown_1(sender As Object, e As MouseEventArgs) Handles Top_Panel1.MouseDown
        If e.Button = MouseButtons.Left Then
            ReleaseCapture()
            SendMessage(Handle, WM_NCLBUTTONDOWN, HT_CAPTION, 0)
        End If
    End Sub
    '###############################################################33

    Private Sub Form1_Load(sender As Object, e As EventArgs) Handles MyBase.Load


        'open the home page first
        BTN_HomePage_Click(sender, e)
    End Sub
    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Btn_Employee.Click
        If LeftSideBarSubMenu_employee.Visible = False Then

            LeftSideBarSubMenu_hr.Visible = False     'hide HR submenu
            LeftSideBarSubMenu_sign.Visible = False    'hide signingsheet submenu
            LeftSideBarSubMenu_Setting.Visible = False    'hide setting submenu
            LeftSideBarSubMenu_employee.Visible = True     'show employee submenu
        Else
            LeftSideBarSubMenu_employee.Visible = False

        End If
    End Sub

    Private Sub Btn_HR_Click(sender As Object, e As EventArgs) Handles Btn_HR.Click
        If LeftSideBarSubMenu_hr.Visible = False Then

            LeftSideBarSubMenu_employee.Visible = False 'hide HR submenu
            LeftSideBarSubMenu_sign.Visible = False    'hide signingsheet submenu
            LeftSideBarSubMenu_Setting.Visible = False    'hide setting submenu
            LeftSideBarSubMenu_hr.Visible = True     'show employee submenu
        Else
            LeftSideBarSubMenu_hr.Visible = False

        End If
    End Sub

    Private Sub Btn_signSheet_Click(sender As Object, e As EventArgs) Handles Btn_signSheet.Click
        If LeftSideBarSubMenu_sign.Visible = False Then

            LeftSideBarSubMenu_employee.Visible = False 'hide HR submenu
            LeftSideBarSubMenu_Setting.Visible = False    'hide signingsheet submenu
            LeftSideBarSubMenu_hr.Visible = False    'hide setting submenu
            LeftSideBarSubMenu_sign.Visible = True     'show employee submenu
        Else
            LeftSideBarSubMenu_sign.Visible = False

        End If
    End Sub

    Private Sub Btn_Setting_Click(sender As Object, e As EventArgs) Handles Btn_Setting.Click
        If LeftSideBarSubMenu_Setting.Visible = False Then

            LeftSideBarSubMenu_employee.Visible = False 'hide HR submenu
            LeftSideBarSubMenu_sign.Visible = False    'hide signingsheet submenu
            LeftSideBarSubMenu_hr.Visible = False    'hide setting submenu
            LeftSideBarSubMenu_Setting.Visible = True     'show employee submenu
        Else
            LeftSideBarSubMenu_Setting.Visible = False

        End If
    End Sub

    Private Sub Btn_minimise_Click(sender As Object, e As EventArgs) Handles Btn_minimise.Click
        Try

            'MsgBox("no code in here yet")
            'Me.WindowState = FormWindowState.Minimized
            '  Me.WindowState = FormWindowState.Minimized
        Catch ex As Exception
            MsgBox(ex.Message & vbNewLine & "Check this ERROR DEVELOPER...")
        End Try
    End Sub

    Private Sub Btn_close_Click(sender As Object, e As EventArgs) Handles Btn_close.Click

        Dim exitMessage As String = "Do you want to Exit?"
        Dim exitdialogresult As DialogResult

        exitdialogresult = MessageBox.Show(exitMessage, "Application Exit", MessageBoxButtons.YesNo, MessageBoxIcon.Question)

        If exitdialogresult = DialogResult.Yes Then
            ' Me.Close()
            'close timer for transition in homepage form
            '   HomePageForm.Timer1.Stop()
            Application.Exit()
        End If

    End Sub

    Private Sub Btn_Maximise_Click(sender As Object, e As EventArgs) Handles Btn_Maximise.Click
        'If Me.WindowState = FormWindowState.Normal Then
        '    Me.WindowState = FormWindowState.Maximized
        '    ' Me.MainPanel.Dock = DockStyle.Fill
        '    Me.Top = 0
        '    Me.Left = 0
        '    Me.Height = Screen.PrimaryScreen.WorkingArea.Height
        '    Me.Width = Screen.PrimaryScreen.WorkingArea.Width
        'Else
        '    Me.WindowState = FormWindowState.Normal
        '    ' Me.MainPanel.Dock = DockStyle.Fill
        '    'Form1.AutoScroll = True

        '    ' Me.WindowState = Me.WindowState
        'End If

        If Me.Height = Screen.PrimaryScreen.WorkingArea.Height Then
            Me.Top = 10
            Me.Left = 10
            Me.StartPosition = FormStartPosition.CenterScreen
            Me.Size = New Point(1149, 740)
        Else
            'Me.WindowState = FormWindowState.Normal
            Me.Top = 0
            Me.Left = 0
            Me.Height = Screen.PrimaryScreen.WorkingArea.Height
            Me.Width = Screen.PrimaryScreen.WorkingArea.Width

        End If
    End Sub

    Private Sub BTN_HomePage_Click(sender As Object, e As EventArgs) Handles BTN_HomePage.Click
        TxtTitleBar.Text = " Home "
        Me.Cursor = Cursors.WaitCursor
        If WindowState = FormWindowState.Maximized Then
            Dim pro As New HomePageForm
            MainPanel2.Controls.Clear()
            pro.TopLevel = False
            MainPanel2.Controls.Add(pro)
            pro.Dock = DockStyle.Fill
            pro.WindowState = FormWindowState.Maximized
            pro.Show()
        ElseIf WindowState = FormWindowState.Normal Then
            Dim pro As New HomePageForm
            MainPanel2.Controls.Clear()
            pro.TopLevel = False
            MainPanel2.Controls.Add(pro)
            pro.Dock = DockStyle.Fill
            pro.WindowState = FormWindowState.Normal
            pro.Show()

        End If
        Me.Cursor = Cursors.Default
    End Sub


    'open new employee form
    'to add new employee
    Private Sub BTN_New_Employee_Click(sender As Object, e As EventArgs) Handles BTN_New_Employee.Click
        TxtTitleBar.Text = "Add New Employee"
        Me.Cursor = Cursors.WaitCursor
        If WindowState = FormWindowState.Maximized Then
            Dim pro As New NewEmployeeForm
            MainPanel2.Controls.Clear()
            pro.TopLevel = False
            MainPanel2.Controls.Add(pro)
            pro.Dock = DockStyle.Fill
            pro.WindowState = FormWindowState.Maximized
            pro.Show()
        ElseIf WindowState = FormWindowState.Normal Then
            Dim pro As New NewEmployeeForm
            MainPanel2.Controls.Clear()
            pro.TopLevel = False
            MainPanel2.Controls.Add(pro)
            pro.Dock = DockStyle.Fill
            pro.WindowState = FormWindowState.Normal
            pro.Show()

        End If
        Me.Cursor = Cursors.Default

    End Sub
    'administrative settings
    Private Sub BTN_Administrative_Click(sender As Object, e As EventArgs) Handles BTN_Administrative.Click
        TxtTitleBar.Text = "Administrative Settings"
        Me.Cursor = Cursors.WaitCursor
        If WindowState = FormWindowState.Maximized Then
            Dim pro As New AdministrativePage
            MainPanel2.Controls.Clear()
            pro.TopLevel = False
            MainPanel2.Controls.Add(pro)
            pro.Dock = DockStyle.Fill
            pro.WindowState = FormWindowState.Maximized
            pro.Show()
        ElseIf WindowState = FormWindowState.Normal Then
            Dim pro As New AdministrativePage
            MainPanel2.Controls.Clear()
            pro.TopLevel = False
            MainPanel2.Controls.Add(pro)
            pro.Dock = DockStyle.Fill
            pro.WindowState = FormWindowState.Normal
            pro.Show()

        End If
        Me.Cursor = Cursors.Default

    End Sub

    'Employee List  to display names of employees
    Private Sub BTN_Employee_List_Click(sender As Object, e As EventArgs) Handles BTN_Employee_List.Click
        TxtTitleBar.Text = "Employee List"
        Me.Cursor = Cursors.WaitCursor
        If WindowState = FormWindowState.Maximized Then
            Dim pro As New EmployeeListForm
            MainPanel2.Controls.Clear()
            pro.TopLevel = False
            MainPanel2.Controls.Add(pro)
            pro.Dock = DockStyle.Fill
            pro.WindowState = FormWindowState.Maximized
            pro.Show()
        ElseIf WindowState = FormWindowState.Normal Then
            Dim pro As New EmployeeListForm
            MainPanel2.Controls.Clear()
            pro.TopLevel = False
            MainPanel2.Controls.Add(pro)
            pro.Dock = DockStyle.Fill
            pro.WindowState = FormWindowState.Normal
            pro.Show()

        End If
        Me.Cursor = Cursors.Default

    End Sub
    Private Sub Btn_close_MouseHover(sender As Object, e As EventArgs) Handles Btn_close.MouseHover
        Btn_close.BackColor = Color.Red
    End Sub
    Private Sub Btn_close_MouseLeave(sender As Object, e As EventArgs) Handles Btn_close.MouseLeave
        Btn_close.BackColor = Color.Transparent
    End Sub

    Private Sub Btn_Maximise_MouseHover(sender As Object, e As EventArgs) Handles Btn_Maximise.MouseHover
        Btn_Maximise.BackColor = Color.LightGray
    End Sub
    Private Sub Btn_Maximise_MouseLeave(sender As Object, e As EventArgs) Handles Btn_Maximise.MouseLeave
        Btn_Maximise.BackColor = Color.Transparent
    End Sub

    Private Sub Btn_minimise_MouseHover(sender As Object, e As EventArgs) Handles Btn_minimise.MouseHover
        Btn_minimise.BackColor = Color.LightGray
    End Sub
    Private Sub Btn_minimise_MouseLeave(sender As Object, e As EventArgs) Handles Btn_minimise.MouseLeave
        Btn_minimise.BackColor = Color.Transparent
    End Sub

    'change color if mouse hover the picturebox
    Private Sub PictureBox1_MouseHover(sender As Object, e As EventArgs) Handles PictureBox1.MouseHover
        PictureBox1.BackColor = Color.LightGray
    End Sub

    Private Sub PictureBox1_MouseLeave(sender As Object, e As EventArgs) Handles PictureBox1.MouseLeave
        PictureBox1.BackColor = Color.Transparent
    End Sub

    Private Sub Timer1_Tick(sender As Object, e As EventArgs) Handles Timer1.Tick
        TxtSysTime.Text = Format(Now, "dd/MM/yyyy hh:mm:ss") ' or TimeOfDay
        'LB_Date.Text = Format(Now, "dd/MM/yyyy")
    End Sub

    'display employee employment Status
    Private Sub BTN_Employee_Status_Click(sender As Object, e As EventArgs) Handles BTN_Employee_Status.Click
        TxtTitleBar.Text = "Employmet Status"
        Me.Cursor = Cursors.WaitCursor
        If WindowState = FormWindowState.Maximized Then
            Dim pro As New EmployeeStatusForm
            MainPanel2.Controls.Clear()
            pro.TopLevel = False
            MainPanel2.Controls.Add(pro)
            pro.Dock = DockStyle.Fill
            pro.WindowState = FormWindowState.Maximized
            pro.Show()
        ElseIf WindowState = FormWindowState.Normal Then
            Dim pro As New EmployeeStatusForm
            MainPanel2.Controls.Clear()
            pro.TopLevel = False
            MainPanel2.Controls.Add(pro)
            pro.Dock = DockStyle.Fill
            pro.WindowState = FormWindowState.Normal
            pro.Show()

        End If
        Me.Cursor = Cursors.Default
    End Sub

    'display employee payroll summary
    Private Sub BTN_HR_Summary_Click(sender As Object, e As EventArgs) Handles BTN_HR_Summary.Click

        TxtTitleBar.Text = "Payroll Summary"
        Me.Cursor = Cursors.WaitCursor
        If WindowState = FormWindowState.Maximized Then
            Dim pro As New Payroll_Summary
            MainPanel2.Controls.Clear()
            pro.TopLevel = False
            MainPanel2.Controls.Add(pro)
            pro.Dock = DockStyle.Fill
            pro.WindowState = FormWindowState.Maximized
            pro.Show()
        ElseIf WindowState = FormWindowState.Normal Then
            Dim pro As New Payroll_Summary
            MainPanel2.Controls.Clear()
            pro.TopLevel = False
            MainPanel2.Controls.Add(pro)
            pro.Dock = DockStyle.Fill
            pro.WindowState = FormWindowState.Normal
            pro.Show()

        End If
        Me.Cursor = Cursors.Default

    End Sub

    'display employeee payroll
    Private Sub BTN_HR_Payroll_Click(sender As Object, e As EventArgs) Handles BTN_HR_Payroll.Click
        TxtTitleBar.Text = "Employee Payroll"
        Me.Cursor = Cursors.WaitCursor
        If WindowState = FormWindowState.Maximized Then
            Dim pro As New PayrollSheet
            MainPanel2.Controls.Clear()
            pro.TopLevel = False
            MainPanel2.Controls.Add(pro)
            pro.Dock = DockStyle.Fill
            pro.WindowState = FormWindowState.Maximized
            pro.Show()
        ElseIf WindowState = FormWindowState.Normal Then
            Dim pro As New PayrollSheet
            MainPanel2.Controls.Clear()
            pro.TopLevel = False
            MainPanel2.Controls.Add(pro)
            pro.Dock = DockStyle.Fill
            pro.WindowState = FormWindowState.Normal
            pro.Show()

        End If
        Me.Cursor = Cursors.Default
    End Sub

    'dsplay banking info 
    Private Sub BTN_HR_BankingInfo_Click(sender As Object, e As EventArgs) Handles BTN_HR_BankingInfo.Click
        TxtTitleBar.Text = "Banking Information"
        Me.Cursor = Cursors.WaitCursor
        If WindowState = FormWindowState.Maximized Then
            Dim pro As New BankingInfo
            MainPanel2.Controls.Clear()
            pro.TopLevel = False
            MainPanel2.Controls.Add(pro)
            pro.Dock = DockStyle.Fill
            pro.WindowState = FormWindowState.Maximized
            pro.Show()
        ElseIf WindowState = FormWindowState.Normal Then
            Dim pro As New BankingInfo
            MainPanel2.Controls.Clear()
            pro.TopLevel = False
            MainPanel2.Controls.Add(pro)
            pro.Dock = DockStyle.Fill
            pro.WindowState = FormWindowState.Normal
            pro.Show()

        End If
        Me.Cursor = Cursors.Default
    End Sub

    'consultancy signing sheet
    Private Sub BTN_Sign_Consultancy_Click(sender As Object, e As EventArgs) Handles BTN_Sign_Consultancy.Click
        TxtTitleBar.Text = "Consultancy Signing Sheet"
        Me.Cursor = Cursors.WaitCursor
        If WindowState = FormWindowState.Maximized Then
            Dim pro As New ConsultancySigningSheet
            MainPanel2.Controls.Clear()
            pro.TopLevel = False
            MainPanel2.Controls.Add(pro)
            pro.Dock = DockStyle.Fill
            pro.WindowState = FormWindowState.Maximized
            pro.Show()
        ElseIf WindowState = FormWindowState.Normal Then
            Dim pro As New ConsultancySigningSheet
            MainPanel2.Controls.Clear()
            pro.TopLevel = False
            MainPanel2.Controls.Add(pro)
            pro.Dock = DockStyle.Fill
            pro.WindowState = FormWindowState.Normal
            pro.Show()

        End If
        Me.Cursor = Cursors.Default
    End Sub

    'salary signing sheet
    Private Sub BTN_Sign_Salary_Click(sender As Object, e As EventArgs) Handles BTN_Sign_Salary.Click
        TxtTitleBar.Text = "Salary Signing Sheet"
        Me.Cursor = Cursors.WaitCursor
        If WindowState = FormWindowState.Maximized Then
            Dim pro As New SalarySigningSheet
            MainPanel2.Controls.Clear()
            pro.TopLevel = False
            MainPanel2.Controls.Add(pro)
            pro.Dock = DockStyle.Fill
            pro.WindowState = FormWindowState.Maximized
            pro.Show()
        ElseIf WindowState = FormWindowState.Normal Then
            Dim pro As New SalarySigningSheet
            MainPanel2.Controls.Clear()
            pro.TopLevel = False
            MainPanel2.Controls.Add(pro)
            pro.Dock = DockStyle.Fill
            pro.WindowState = FormWindowState.Normal
            pro.Show()

        End If
        Me.Cursor = Cursors.Default
    End Sub

    'wages signing sheet
    Private Sub BTN_Sign_Wages_Click(sender As Object, e As EventArgs) Handles BTN_Sign_Wages.Click
        TxtTitleBar.Text = "Wages Signing Sheet"
        Me.Cursor = Cursors.WaitCursor
        If WindowState = FormWindowState.Maximized Then
            Dim pro As New WagesSigningSheet
            MainPanel2.Controls.Clear()
            pro.TopLevel = False
            MainPanel2.Controls.Add(pro)
            pro.Dock = DockStyle.Fill
            pro.WindowState = FormWindowState.Maximized
            pro.Show()
        ElseIf WindowState = FormWindowState.Normal Then
            Dim pro As New WagesSigningSheet
            MainPanel2.Controls.Clear()
            pro.TopLevel = False
            MainPanel2.Controls.Add(pro)
            pro.Dock = DockStyle.Fill
            pro.WindowState = FormWindowState.Normal
            pro.Show()

        End If
        Me.Cursor = Cursors.Default
    End Sub

    'admin signing sheet
    Private Sub BTN_Sign_Admin_Click(sender As Object, e As EventArgs) Handles BTN_Sign_Admin.Click
        TxtTitleBar.Text = "Administrator Signing Sheet"
        Me.Cursor = Cursors.WaitCursor
        If WindowState = FormWindowState.Maximized Then
            Dim pro As New AdminSigningSheet
            MainPanel2.Controls.Clear()
            pro.TopLevel = False
            MainPanel2.Controls.Add(pro)
            pro.Dock = DockStyle.Fill
            pro.WindowState = FormWindowState.Maximized
            pro.Show()
        ElseIf WindowState = FormWindowState.Normal Then
            Dim pro As New AdminSigningSheet
            MainPanel2.Controls.Clear()
            pro.TopLevel = False
            MainPanel2.Controls.Add(pro)
            pro.Dock = DockStyle.Fill
            pro.WindowState = FormWindowState.Normal
            pro.Show()

        End If
        Me.Cursor = Cursors.Default
    End Sub
End Class
