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

    Public Function defragBIN(cheminBIN As String, profMin As Integer) As String
        Dim tabBIN(0) As Byte, i As Long, tabNEW() As Byte, offset As Long
        Dim tabTampon(23) As Byte, compteur As Integer, nbSuppression As Integer
        Dim message As String, pos As Long
        Dim lectureBIN As IO.FileStream, posLecture As Long, tailleBIN As Long, tailleTampon As Long, reservation As Boolean

        message = ""

        If My.Computer.FileSystem.FileExists(cheminBIN & ".bak") Then
            My.Computer.FileSystem.DeleteFile(cheminBIN & ".bak")
        End If

        posLecture = 0
        tailleBIN = FileLen(cheminBIN)
        tailleTampon = tailleBIN
        i = 50
        lectureBIN = New IO.FileStream(cheminBIN, IO.FileMode.Open, IO.FileAccess.Read, IO.FileShare.ReadWrite)

        compteur = 0
        nbSuppression = 0

        While posLecture < tailleBIN
            If posLecture + tailleTampon <= tailleBIN Then
                reservation = False
                Do
                    Try
                        ReDim tabBIN(tailleTampon - 1)
                        reservation = True
                    Catch ex As Exception
                        i = i - 1
                        tailleTampon = 24 * i * 1000000
                    End Try
                Loop Until reservation
                lectureBIN.Read(tabBIN, 0, tabBIN.Length)
            Else
                tailleTampon = tailleBIN - posLecture
                ReDim tabBIN(tailleTampon - 1)
                lectureBIN.Read(tabBIN, 0, tabBIN.Length)
            End If

            ReDim tabNEW(UBound(tabBIN))
            pos = 0
            offset = 0
            Do
                Array.Copy(tabBIN, pos, tabTampon, 0, 24)
                If profMin <= tabTampon(8) Then
                    Array.Copy(tabTampon, 0, tabNEW, offset * 24, 24)
                    offset = offset + 1
                Else
                    nbSuppression = nbSuppression + 1
                End If

                compteur = compteur + 1
                pos = pos + 24
            Loop While pos < tabBIN.Length

            tabBIN = Nothing

            ReDim Preserve tabNEW(offset * 24 - 1)
            My.Computer.FileSystem.WriteAllBytes(cheminBIN & ".bak", tabNEW, True)

            tabNEW = Nothing

            posLecture = lectureBIN.Position
        End While

        lectureBIN.Close()

        message = "info string " & nomFichier(cheminBIN) & " -> Total moves: " & compteur & ". Empty moves: " & nbSuppression & ". Fragmentation: " & Format(nbSuppression / compteur, "0.00%") & vbCrLf
        message = message & "info string Saved " & Format(compteur - nbSuppression, "0 moves") & " to " & nomFichier(cheminBIN) & " file"

        If compteur > nbSuppression Then
            My.Computer.FileSystem.DeleteFile(cheminBIN)
            My.Computer.FileSystem.RenameFile(cheminBIN & ".bak", nomFichier(cheminBIN))
        End If

        Return message
    End Function

End Module
