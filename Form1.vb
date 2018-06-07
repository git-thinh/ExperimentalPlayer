Imports System.IO

''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
''Ohjelman nimi: JPlayer                                    ''
''Versio: 1.3                                               ''
''Tekijä: Joonas Westlin                                    ''
''Teko aloitettu: 25.3.09                                   ''
''Historiaa: Alpha 5 läpi, Beta 5 läpi, 1.0, 1.1, 1.2, 1.3  ''
''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
Public Class Form1
    Private Declare Function GetAsyncKeyState Lib "user32" (ByVal vkey As Long) As Integer
#Region "Global variables"
    Dim currentPlaying As Integer 'Tällä hetkellä soivan biisin indeksi soittolistalla
    Dim barDragged As Boolean = False 'Katsoo siirretäänkö palkkia, ettei automaattisiirto sotke
    Dim shuffle As Boolean = False 'Sekoitustila
    Dim balloonShow As Boolean = False 'Halutaanko näyttää ilmoitus
    Dim repeat As String = "All" 'Toistotila, All tai One
    Dim songs As New List(Of String) 'Biisien koko polut säilötään tänne, soittolistalla näkyy vain tiedostonimi
    Dim showNIcon As Boolean = False 'Jätetäänko notifyicon näkyviin
    Dim Plloc As String = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments) & "\JPlayer playlist data\savedPL.jpl"
    Dim showPL As Boolean = True
    Dim plHiddenSize As System.Drawing.Size
    Dim minSize As System.Drawing.Size
    Dim currentSize As System.Drawing.Size

#End Region

#Region "Form load & close events"
    Private Sub Form1_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        If ExperimentalPlayer.My.Settings.FirstTime = True Then
            Dim result As DialogResult = MsgBox("Welcome to JPlayer!" & vbCrLf & "Will this location be saved as the install location?", MsgBoxStyle.YesNo)

            If result = Windows.Forms.DialogResult.Yes Then
                ExperimentalPlayer.My.Settings.playerLocation = Directory.GetCurrentDirectory & "\"
                ExperimentalPlayer.My.Settings.FirstTime = False
            End If
        End If
        Dim NeedToLoad As Boolean = True

        player.BeginInit()
        plHiddenSize.Height = 153
        plHiddenSize.Width = 450
        minSize.Height = 490
        minSize.Width = 450
        If Environment.GetCommandLineArgs.Length > 1 Then
            Dim param As String
            param = Environment.GetCommandLineArgs(1).ToString
            If param.Substring(param.LastIndexOf(".") + 1, 3) = "jpl" Then
                Dim tracks() As String
                tracks = File.ReadAllLines(param).ToArray
                For i As Integer = 0 To tracks.Length - 1
                    If File.Exists(tracks(i)) Then
                        songs.Add(tracks(i))
                        playlist.Items.Add(tracks(i).Substring(tracks(i).LastIndexOf("\") + 1))
                    End If
                Next
            End If
            NeedToLoad = False
        End If
        Timer2.Start()
        lbl_songname.Text = ""
        GUIMode("Stop")
        If File.Exists(Plloc) And NeedToLoad = True Then
            Dim tracks() As String
            tracks = File.ReadAllLines(Plloc).ToArray()
            For i As Integer = 0 To tracks.Length - 1
                If File.Exists(tracks(i)) Then
                    songs.Add(tracks(i))
                    playlist.Items.Add(tracks(i).Substring(tracks(i).LastIndexOf("\") + 1))
                End If
            Next

        End If
        If ExperimentalPlayer.My.Settings.shuffle = True Then
            shuffle = True
            btn_shuffle.BackColor = Color.Blue
            btn_shuffle.Text = "Shuffle on"
        End If
        If ExperimentalPlayer.My.Settings.repeat = "One" Then
            repeat = "One"
            btn_repeat.BackColor = System.Drawing.SystemColors.ControlDarkDark
            btn_repeat.Text = "Repeating one track"
        End If
    End Sub

    Private Sub Form1_FormClosing(ByVal sender As System.Object, ByVal e As System.Windows.Forms.FormClosingEventArgs) Handles MyBase.FormClosing
        ExperimentalPlayer.My.Settings.repeat = repeat
        If Directory.Exists(Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments) & "\JPlayer playlist data") = False Then
            Directory.CreateDirectory(Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments) & "\JPlayer playlist data")
        End If
        If playlist.Items.Count > 0 Then
            For Each track As String In songs
                Dim writer As New StreamWriter(Plloc, False)
                For Each song In songs
                    writer.WriteLine(song)
                Next
                writer.Flush()
                writer.Close()
            Next
        Else
            File.Delete(Plloc)
        End If
    End Sub
#End Region

#Region "Main timer"
    Private Sub Timer1_Tick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Timer1.Tick
        If player.playState = WMPLib.WMPPlayState.wmppsPlaying Then
            Me.Text = lbl_songname.Text & " - JPlayer 1.3"
            If barDragged = False Then
                SongTrackBar.Value = (player.Ctlcontrols.currentPosition / player.currentMedia.duration) * 100
            End If
            lbl_CurDur.Text = player.Ctlcontrols.currentPositionString
            If showNIcon Then
                NotifyIcon1.Text = "Np: " & lbl_songname.Text & vbCrLf & player.Ctlcontrols.currentPositionString & " / " & player.currentMedia.durationString
            End If
        End If
        If lbl_songname.Text <> player.currentMedia.name Then
            updatePlayer()
        End If
        If lbl_songname.Text = player.currentMedia.name And balloonShow = True Then
            If showNIcon = False Then
                NotifyIcon1.Visible = True
            End If
            NotifyIcon1.BalloonTipText = "Np: " & lbl_songname.Text
            NotifyIcon1.ShowBalloonTip(1000)
            balloonShow = False
        End If
        If lbl_dur.Text <> player.currentMedia.durationString Then
            lbl_dur.Text = player.currentMedia.durationString
        End If
    End Sub
#End Region

#Region "Keyboard watch timer"
    Private Sub Timer2_Tick(ByVal sender As System.Object, ByVal e As System.EventArgs)
        Dim prevKey As Boolean = GetAsyncKeyState(Keys.MediaPreviousTrack)
        Dim nextKey As Boolean = GetAsyncKeyState(Keys.MediaNextTrack)
        'Dim PlayPauseKey As Boolean = GetAsyncKeyState(Keys.MediaPlayPause)

        'If PlayPauseKey Then
        '    PlayPause()
        'End If
        If prevKey Then
            GoPrevious()
        ElseIf nextKey Then
            GoNext()
        End If
    End Sub
#End Region

#Region "Main Toolstrip buttons"

    Private Sub btn_play_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_play.Click
        If playlist.SelectedIndex <> -1 Then
            player.URL = songs(playlist.SelectedIndex)
            player.Ctlcontrols.play()
            Timer1.Enabled = True
            currentPlaying = playlist.SelectedIndex
            GUIMode("Play")
            updatePlayer()
        Else
            If playlist.Items.Count > 0 Then
                If shuffle = True Then
                    Dim randGen As New Random(Now.Millisecond)
                    Dim randNum As Integer

                    randNum = randGen.Next(0, playlist.Items.Count)
                    While randNum = currentPlaying
                        randNum = randGen.Next(0, playlist.Items.Count)
                    End While
                    playlist.SelectedIndex = randNum
                Else
                    playlist.SelectedIndex = 0
                End If
                player.URL = songs(playlist.SelectedIndex)
                player.Ctlcontrols.play()
                Timer1.Enabled = True
                currentPlaying = playlist.SelectedIndex
                GUIMode("Play")
                updatePlayer()
            End If
        End If
    End Sub

    Private Sub btn_pause_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_pause.Click
        If player.playState = WMPLib.WMPPlayState.wmppsPlaying Then 'Pause
            player.Ctlcontrols.pause()
            Timer1.Enabled = False
            GUIMode("Pause")
        ElseIf player.playState = WMPLib.WMPPlayState.wmppsPaused Then 'Jatko
            player.Ctlcontrols.play()
            Timer1.Enabled = True
            GUIMode("Play")
        End If
    End Sub

    Private Sub btn_stop_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_stop.Click
        GUIMode("Stop")
    End Sub

    Private Sub btn_shuffle_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_shuffle.Click
        If shuffle = False Then
            btn_shuffle.BackColor = Color.Blue
            shuffle = True
            ExperimentalPlayer.My.Settings.shuffle = True
            btn_shuffle.Text = "Shuffle on"
        Else
            btn_shuffle.BackColor = System.Drawing.SystemColors.ControlDarkDark
            shuffle = False
            ExperimentalPlayer.My.Settings.shuffle = False
            btn_shuffle.Text = "Shuffle off"
        End If
    End Sub

    Private Sub btn_repeat_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_repeat.Click
        If repeat = "All" Then
            repeat = "One"
            btn_repeat.BackColor = System.Drawing.SystemColors.ControlDarkDark
            btn_repeat.Text = "Repeating one track"
        ElseIf repeat = "One" Then
            repeat = "All"
            btn_repeat.BackColor = Color.Blue
            btn_repeat.Text = "Repeating all tracks"
        End If
    End Sub

    Private Sub btn_hidePlayer_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_hidePlayer.Click
        NotifyIcon1.ContextMenuStrip = mnu_ntfyCntxt
        Me.Hide()
        showNIcon = True
        NotifyIcon1.Visible = True
    End Sub

    Private Sub btn_prev_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_prev.Click
        GoPrevious()
    End Sub

    Private Sub btn_next_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_next.Click
        GoNext()
    End Sub

    Private Sub btn_playlist_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_playlist.Click
        If showPL = True Then
            currentSize.Height = Me.Size.Height
            currentSize.Width = Me.Size.Width

            playlist.Visible = False
            ToolStrip2.Visible = False

            Me.MinimumSize = plHiddenSize
            Me.MaximumSize = plHiddenSize
            showPL = False
        ElseIf showPL = False Then
            Dim zeroSize As System.Drawing.Size
            zeroSize.Height = 0
            zeroSize.Width = 0
            Me.MinimumSize = minSize
            Me.MaximumSize = zeroSize
            Me.Size = currentSize
            playlist.Visible = True
            ToolStrip2.Visible = True
            showPL = True
        End If

    End Sub

#End Region

#Region "Playlist manipulation & misc toolstrip buttons"
    Private Sub btn_loadPL_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_loadPL.Click
        Dim dr As DialogResult
        OpenFileDialog1.Filter = "Juunas Playlist files .jpl|*.jpl"
        dr = OpenFileDialog1.ShowDialog()
        If dr = Windows.Forms.DialogResult.OK Then
            Dim tracks() As String
            playlist.Items.Clear()
            songs.Clear()
            tracks = File.ReadAllLines(OpenFileDialog1.FileName).ToArray
            For i As Integer = 0 To tracks.Length - 1 'Tässä on -1, koska viimeinen rivi tiedostossa on tyhjä rivi, sitä ei tarvita
                '''''Uusi taulukko''''''
                If File.Exists(tracks(i)) Then
                    songs.Add(tracks(i))
                    playlist.Items.Add(tracks(i).Substring(tracks(i).LastIndexOf("\") + 1))
                End If
            Next
            OpenFileDialog1.FileName = ""
        End If

    End Sub

    Private Sub btn_clearPL_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_clearPL.Click
        If playlist.Items.Count > 0 Then
            Dim dr As DialogResult = MsgBox("Are you sure?" & vbCrLf & "Clear the playlist?", MsgBoxStyle.YesNo)
            If dr = Windows.Forms.DialogResult.Yes Then
                playlist.Items.Clear()
                songs.Clear()
                GUIMode("Stop")
            End If
        End If
    End Sub

    Private Sub btn_savePL_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_savePL.Click
        If playlist.Items.Count > 0 Then
            Dim dr As DialogResult
            dr = SaveFileDialog1.ShowDialog()
            If dr = Windows.Forms.DialogResult.OK Then
                Dim writer As New StreamWriter(SaveFileDialog1.FileName, False)
                For Each track In songs
                    writer.WriteLine(track)
                Next
                writer.Flush()
                writer.Close()
            End If
        End If
    End Sub

    Private Sub btn_add_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_add.Click
        pl_Add()
    End Sub

    Private Sub playlist_DoubleClick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles playlist.DoubleClick
        If playlist.SelectedIndex <> -1 Then
            player.URL = songs(playlist.SelectedIndex)
            player.Ctlcontrols.play()
            Timer1.Enabled = True
            currentPlaying = playlist.SelectedIndex
            GUIMode("Play")
            updatePlayer()
        End If

    End Sub

    Private Sub btn_plMoveUp_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_plMoveUP.Click
        plMoveUp()
    End Sub

    Private Sub btn_plMoveDown_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_plMoveDown.Click
        plMoveDown()
    End Sub

    Private Sub btn_plDelete_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_plDelete.Click
        pl_Delete()
    End Sub

    Private Sub btn_pl_addFolder_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_pl_addFolder.Click
        Dim dr As DialogResult = FolderBrowserDialog1.ShowDialog()
        Dim tracks() As String
        If dr = Windows.Forms.DialogResult.OK Then
            tracks = Directory.GetFiles(FolderBrowserDialog1.SelectedPath, "*.mp3", SearchOption.AllDirectories)
            For Each track As String In tracks
                songs.Add(track)
                playlist.Items.Add(track.Substring(track.LastIndexOf("\") + 1))
            Next
        End If
    End Sub

    Public Sub plMoveDown()
        If playlist.SelectedIndex <> -1 Then
            Dim IsAnyAtBottom As Boolean = False

            For Each sIndex As Integer In playlist.SelectedIndices
                If sIndex = playlist.Items.Count - 1 Then
                    IsAnyAtBottom = True
                End If
            Next
            If IsAnyAtBottom = False Then
                Dim selectedSongs As New List(Of Integer)
                For Each sSong As Integer In playlist.SelectedIndices
                    selectedSongs.Add(sSong)
                Next
                selectedSongs.Reverse()
                For Each i As Integer In selectedSongs
                    playlist.SelectedIndex = -1
                    playlist.SelectedIndex = i
                    Dim songToMovePL, songToMoveTable As String
                    Dim lowerSongPL, lowerSongTable As String
                    If playlist.SelectedIndex < (playlist.Items.Count - 1) Then
                        If currentPlaying = playlist.SelectedIndex + 1 Then
                            currentPlaying -= 1
                        End If
                        songToMovePL = playlist.Items(playlist.SelectedIndex)
                        lowerSongPL = playlist.Items(playlist.SelectedIndex + 1)
                        playlist.Items(playlist.SelectedIndex + 1) = songToMovePL
                        playlist.Items(playlist.SelectedIndex) = lowerSongPL

                        songToMoveTable = songs(playlist.SelectedIndex)
                        lowerSongTable = songs(playlist.SelectedIndex + 1)
                        songs(playlist.SelectedIndex + 1) = songToMoveTable
                        songs(playlist.SelectedIndex) = lowerSongTable

                        songToMovePL = ""
                        lowerSongPL = ""
                        songToMoveTable = ""
                        lowerSongTable = ""
                        playlist.SelectedIndex += 1
                        If player.URL = playlist.SelectedItem And (player.playState = WMPLib.WMPPlayState.wmppsPaused Or player.playState = WMPLib.WMPPlayState.wmppsPlaying) Then
                            currentPlaying = playlist.SelectedIndex
                        End If
                    End If
                Next
                selectedSongs.Reverse()
                playlist.SelectedIndex = -1
                For Each ssong As Integer In selectedSongs
                    If ssong < playlist.Items.Count - 1 Then
                        playlist.SelectedIndex = ssong + 1
                    Else
                        playlist.SelectedIndex = ssong
                    End If

                Next
            End If

        End If
    End Sub

    Public Sub plMoveUp()
        If playlist.SelectedIndex <> -1 Then
            Dim IsAnyAtTop As Boolean = False

            For Each sIndex As Integer In playlist.SelectedIndices
                If sIndex = 0 Then
                    IsAnyAtTop = True
                End If
            Next
            If IsAnyAtTop = False Then
                Dim selectedSongs As New List(Of Integer)
                For Each sSong As Integer In playlist.SelectedIndices
                    selectedSongs.Add(sSong)
                Next
                For Each i As Integer In selectedSongs
                    playlist.SelectedIndex = -1
                    playlist.SelectedIndex = i
                    Dim songToMovePL, songToMoveTable As String
                    Dim upperSongPL, upperSongTable As String
                    If playlist.SelectedIndex > 0 Then
                        If currentPlaying = playlist.SelectedIndex - 1 Then
                            currentPlaying += 1
                        End If
                        songToMovePL = playlist.Items(playlist.SelectedIndex)
                        upperSongPL = playlist.Items(playlist.SelectedIndex - 1)
                        playlist.Items(playlist.SelectedIndex - 1) = songToMovePL
                        playlist.Items(playlist.SelectedIndex) = upperSongPL
                        'Ylhäällä näkyvät muutokset, alla pitkien nimien listan muutokset
                        songToMoveTable = songs(playlist.SelectedIndex)
                        upperSongTable = songs(playlist.SelectedIndex - 1)
                        songs(playlist.SelectedIndex - 1) = songToMoveTable
                        songs(playlist.SelectedIndex) = upperSongTable

                        songToMovePL = ""
                        upperSongPL = ""
                        songToMoveTable = ""
                        upperSongTable = ""
                        playlist.SelectedIndex -= 1
                        If player.URL = playlist.SelectedItem And (player.playState = WMPLib.WMPPlayState.wmppsPaused Or player.playState = WMPLib.WMPPlayState.wmppsPlaying) Then
                            currentPlaying = playlist.SelectedIndex
                        End If
                    End If
                Next
                playlist.SelectedIndex = -1
                For Each ssong As Integer In selectedSongs
                    If ssong > 0 Then
                        playlist.SelectedIndex = ssong - 1
                    Else
                        playlist.SelectedIndex = ssong
                    End If

                Next
            End If
        End If
    End Sub

    Private Sub playlist_KeyDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles playlist.KeyDown
        If e.KeyCode = Keys.Delete Then
            pl_Delete()
        ElseIf e.KeyCode = Keys.F1 Then
            plMoveUp()
        ElseIf e.KeyCode = Keys.F2 Then 'Toimii nyt, mutta kylläpä listboxeissa on näppäintoimintoja... Oli pakko laittaa F1 & F2
            plMoveDown()
        End If
    End Sub

    ''' <summary>
    ''' Sub for adding songs to the PL
    ''' </summary>
    Public Sub pl_Add() 'Biisien lisäys PL:lle
        OpenFileDialog1.Filter = "MP3 Files|*.mp3"
        Dim dr As DialogResult = OpenFileDialog1.ShowDialog()
        If dr = Windows.Forms.DialogResult.OK Then
            For Each track As String In OpenFileDialog1.FileNames
                songs.Add(track)
                playlist.Items.Add(track.Substring(track.LastIndexOf("\") + 1))
            Next
        End If
        OpenFileDialog1.FileName = ""
    End Sub

    ''' <summary>
    ''' Sub for removing songs from the PL
    ''' </summary>
    Public Sub pl_Delete() 'Biisien poisto PL:stä
        If playlist.SelectedIndex <> -1 Then
            Dim curIndex As Integer = playlist.SelectedIndex
            Dim selectedSongs As New List(Of String)

            For Each sSong As String In playlist.SelectedItems
                selectedSongs.Add(sSong)
            Next
            For Each SongToBeDeleted As String In selectedSongs
                playlist.SelectedIndex = -1
                playlist.SelectedItem = SongToBeDeleted
                If playlist.SelectedIndex <= currentPlaying Then
                    currentPlaying -= 1
                End If
                songs.RemoveAt(playlist.SelectedIndex)
                playlist.Items.RemoveAt(playlist.SelectedIndex)
                If playlist.Items.Count > 0 And curIndex < playlist.Items.Count Then
                    playlist.SelectedIndex = curIndex
                End If
            Next
        End If
    End Sub

    Private Sub btn_help_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_help.Click
        help.Show()
    End Sub

    Private Sub btn_about_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_about.Click
        AboutBox.Show()
    End Sub

#End Region

#Region "TrackBars code = volume bar + song bar"

    Private Sub VolBar_Scroll(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles VolBar.Scroll
        player.settings.volume = VolBar.Value
        lbl_vol.Text = VolBar.Value
    End Sub

    Private Sub SongTrackBar_MouseUp(ByVal sender As System.Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles SongTrackBar.MouseUp
        If player.playState = WMPLib.WMPPlayState.wmppsPlaying Then
            player.Ctlcontrols.currentPosition = player.currentMedia.duration * (SongTrackBar.Value / 100)
            barDragged = False
        End If
    End Sub

    Private Sub SongTrackBar_MouseDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles SongTrackBar.MouseDown
        barDragged = True
    End Sub
#End Region

#Region "Switch to next song = Repeat"
    Private Sub AxWindowsMediaPlayer1_PlayStateChange(ByVal sender As Object, ByVal e As AxWMPLib._WMPOCXEvents_PlayStateChangeEvent) Handles player.PlayStateChange
        Static Dim PlayAllowed As Boolean = True
        If shuffle = False Then 'Ei shufflea
            Select Case CType(player.playState, WMPLib.WMPPlayState)
                Case WMPLib.WMPPlayState.wmppsReady
                    If PlayAllowed Then
                        player.Ctlcontrols.play()
                        If repeat = "All" Then
                            balloonShow = True
                        End If
                    End If
                Case WMPLib.WMPPlayState.wmppsMediaEnded
                    If repeat = "All" Then
                        currentPlaying = (currentPlaying + 1) Mod playlist.Items.Count
                    End If
                    PlayAllowed = False
                    playlist.SelectedIndex = -1
                    playlist.SelectedIndex = currentPlaying
                    player.URL = songs(currentPlaying)
                    player.Ctlcontrols.play()
                    PlayAllowed = True
            End Select
        Else 'Shuffle
            Dim randGen As New Random(Now.Millisecond)
            Dim shuffledSong As Integer
            Select Case CType(player.playState, WMPLib.WMPPlayState)
                Case WMPLib.WMPPlayState.wmppsReady
                    If PlayAllowed Then
                        player.Ctlcontrols.play()
                        If repeat = "All" Then
                            balloonShow = True
                        End If
                    End If
                Case WMPLib.WMPPlayState.wmppsMediaEnded
                    'arvo satunnaisluku, muista katsoa onko se sama kuin tämänhetkinen biisi
                    If repeat = "All" Then
                        shuffledSong = randGen.Next(0, playlist.Items.Count)
                        While shuffledSong = currentPlaying
                            shuffledSong = randGen.Next(0, playlist.Items.Count)
                        End While
                        currentPlaying = shuffledSong
                    End If
                    PlayAllowed = False
                    playlist.SelectedIndex = -1
                    playlist.SelectedIndex = currentPlaying
                    player.URL = songs(currentPlaying)
                    player.Ctlcontrols.play()
                    PlayAllowed = True
            End Select
        End If
    End Sub

#End Region

#Region "Subprograms"

    ''' <summary>
    ''' Puts the thread to sleep for a set time
    ''' </summary>
    ''' <param name="delay">Delay in milliseconds</param>
    Public Sub Delay(ByVal delay As Integer)
        System.Threading.Thread.Sleep(delay) 'Viive aliohjelma
    End Sub

    ''' <summary>
    ''' Updates the total duration and songname labels (With a 500ms delay)
    ''' </summary>
    Public Sub updatePlayer() 'Playerin päivitysaliohjelma, kutsutaan biisin vaihdossa
        Delay(500)
        lbl_dur.Text = player.currentMedia.durationString
        lbl_songname.Text = player.currentMedia.name
    End Sub

    ''' <summary>
    ''' Changes the GUI mode to the desired one
    ''' </summary>
    ''' <param name="Mode">The mode to switch to (Play, Pause or Stop)</param>
    Public Sub GUIMode(ByVal Mode As String) 'Käyttöliittymän moodin vaihto (Play, Pause, Stop)
        Select Case Mode
            Case "Play"
                btn_stop.Enabled = True
                btn_pause.Enabled = True
                btn_pause.BackColor = System.Drawing.SystemColors.ControlDarkDark
                SongTrackBar.Enabled = True
                Timer2.Start()
            Case "Pause"
                btn_pause.BackColor = Color.Yellow
                SongTrackBar.Enabled = True
            Case "Stop"
                Timer2.Stop()
                player.Ctlcontrols.stop()
                lbl_songname.Text = " "
                lbl_curDur.Text = "00:00"
                lbl_dur.Text = "00:00"
                Timer1.Enabled = False
                SongTrackBar.Value = 0
                btn_pause.Enabled = False
                btn_stop.Enabled = False
                btn_pause.BackColor = System.Drawing.SystemColors.ControlDarkDark
                SongTrackBar.Enabled = False
                Me.Text = "JPlayer 1.3"
        End Select
    End Sub

    ''' <summary>
    ''' Jumps to the previous song
    ''' </summary>
    Public Sub GoPrevious()
        If player.playState = WMPLib.WMPPlayState.wmppsPlaying Then
            If shuffle = False Then
                If currentPlaying <> 0 Then
                    currentPlaying -= 1
                    player.URL = songs(currentPlaying)
                    playlist.SelectedIndex = -1
                    playlist.SelectedIndex = currentPlaying
                    player.Ctlcontrols.play()
                    updatePlayer()
                Else
                    currentPlaying = playlist.Items.Count - 1
                    player.URL = songs(currentPlaying)
                    playlist.SelectedIndex = -1
                    playlist.SelectedIndex = currentPlaying
                    player.Ctlcontrols.play()
                    updatePlayer()
                End If
            Else
                Dim randGen As New Random(Now.Millisecond)
                Dim randNum As Integer

                randNum = randGen.Next(0, playlist.Items.Count)
                While randNum = currentPlaying
                    randNum = randGen.Next(0, playlist.Items.Count)
                End While
                player.URL = songs(randNum)
                currentPlaying = randNum
                playlist.SelectedIndex = -1
                playlist.SelectedIndex = currentPlaying
                player.Ctlcontrols.play()
                updatePlayer()
            End If


        End If
    End Sub

    ''' <summary>
    ''' Jumps to the next song
    ''' </summary>
    Public Sub GoNext()
        If player.playState = WMPLib.WMPPlayState.wmppsPlaying Then
            If shuffle = False Then
                If currentPlaying <> (playlist.Items.Count - 1) Then
                    currentPlaying += 1
                    player.URL = songs(currentPlaying)
                    playlist.SelectedIndex = -1
                    playlist.SelectedIndex = currentPlaying
                    player.Ctlcontrols.play()
                    updatePlayer()
                Else
                    currentPlaying = 0
                    player.URL = songs(currentPlaying)
                    playlist.SelectedIndex = -1
                    playlist.SelectedIndex = currentPlaying
                    player.Ctlcontrols.play()
                    updatePlayer()
                End If
            Else
                Dim randGen As New Random(Now.Millisecond)
                Dim randNum As Integer

                randNum = randGen.Next(0, playlist.Items.Count)
                While randNum = currentPlaying
                    randNum = randGen.Next(0, playlist.Items.Count)
                End While
                player.URL = songs(randNum)
                currentPlaying = randNum
                playlist.SelectedIndex = -1
                playlist.SelectedIndex = currentPlaying
                player.Ctlcontrols.play()
                updatePlayer()
            End If
        End If
    End Sub

    Public Sub PlayPause()
        If player.playState = WMPLib.WMPPlayState.wmppsPlaying Then 'Pause
            player.Ctlcontrols.pause()
            Timer1.Enabled = False
            GUIMode("Pause")
        ElseIf player.playState = WMPLib.WMPPlayState.wmppsPaused Then 'Jatko
            player.Ctlcontrols.play()
            Timer1.Enabled = True
            GUIMode("Play")
        End If
    End Sub

#End Region

#Region "PL Context menu"
    Private Sub cntxt_add2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cntxt_add2.Click
        pl_Add()
    End Sub

    Private Sub cntxt_delete2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cntxt_delete2.Click
        pl_Delete()
    End Sub

    Private Sub mnu_movablePL2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mnu_movablePL2.Click
        If playlist.Items.Count > 0 Then
            Dim dr As DialogResult
            dr = SaveFileDialog1.ShowDialog()
            If dr = Windows.Forms.DialogResult.OK Then
                Dim writer As New StreamWriter(SaveFileDialog1.FileName, False)
                For Each track In playlist.Items
                    writer.WriteLine(track)
                Next
                writer.Flush()
                writer.Close()
            End If
        End If
    End Sub
#End Region

#Region "NotifyIcon stuff"
    Private Sub NotifyIcon1_BalloonTipClosed(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles NotifyIcon1.BalloonTipClosed
        If showNIcon = False Then
            NotifyIcon1.Visible = False
        End If
    End Sub

    Private Sub ntfyCntxtShow_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ntfyCntxtShow.Click
        Me.Show()
        NotifyIcon1.ContextMenuStrip = Nothing
        showNIcon = False
        NotifyIcon1.Visible = False
    End Sub

    Private Sub NotifyIcon1_MouseDoubleClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles NotifyIcon1.MouseDoubleClick
        If showNIcon Then
            Me.Show()
            NotifyIcon1.ContextMenuStrip = Nothing
            showNIcon = False
            NotifyIcon1.Visible = False
        End If
    End Sub
#End Region

    'Private Sub playlist_DragDrop(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DragEventArgs) Handles playlist.DragDrop
    '    Label3.Visible = True
    '    Label3.Text = e.Data.ToString
    'End Sub

End Class