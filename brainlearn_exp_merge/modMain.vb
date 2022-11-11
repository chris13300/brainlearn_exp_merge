Module modMain

    Sub Main()
        If InStr(Command(), "defrag", CompareMethod.Text) > 0 Then
            Console.WriteLine(defragBIN("experience.bin", 1))
            Console.WriteLine("press ENTER to close this window.")
            Console.ReadLine()
        Else
            Dim index As Integer, modele As String

            index = 0
            modele = "experience*-*.bin"
            If My.Computer.FileSystem.GetFiles(My.Application.Info.DirectoryPath, FileIO.SearchOption.SearchTopLevelOnly, modele).Count = 0 Then
                modele = "experience*_*.bin"
                If My.Computer.FileSystem.GetFiles(My.Application.Info.DirectoryPath, FileIO.SearchOption.SearchTopLevelOnly, "experience*_*.bin").Count = 0 Then
                    End
                End If
            End If
            For Each file In My.Computer.FileSystem.GetFiles(My.Application.Info.DirectoryPath, FileIO.SearchOption.SearchTopLevelOnly, modele)
                My.Computer.FileSystem.RenameFile(file, "experience" & index & ".bin")
                index = index + 1
            Next
        End If
    End Sub

End Module
