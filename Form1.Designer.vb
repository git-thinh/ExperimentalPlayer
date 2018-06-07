<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Form1
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()> _
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        Try
            If disposing AndAlso components IsNot Nothing Then
                components.Dispose()
            End If
        Finally
            MyBase.Dispose(disposing)
        End Try
    End Sub

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Me.components = New System.ComponentModel.Container
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(Form1))
        Me.OpenFileDialog1 = New System.Windows.Forms.OpenFileDialog
        Me.playlist = New System.Windows.Forms.ListBox
        Me.pl_context = New System.Windows.Forms.ContextMenuStrip(Me.components)
        Me.cntxt_add2 = New System.Windows.Forms.ToolStripMenuItem
        Me.cntxt_delete2 = New System.Windows.Forms.ToolStripMenuItem
        Me.mnu_movablePL2 = New System.Windows.Forms.ToolStripMenuItem
        Me.VolBar = New System.Windows.Forms.TrackBar
        Me.Label1 = New System.Windows.Forms.Label
        Me.lbl_vol = New System.Windows.Forms.Label
        Me.SongTrackBar = New System.Windows.Forms.TrackBar
        Me.SaveFileDialog1 = New System.Windows.Forms.SaveFileDialog
        Me.FolderBrowserDialog1 = New System.Windows.Forms.FolderBrowserDialog
        Me.player = New AxWMPLib.AxWindowsMediaPlayer
        Me.Label3 = New System.Windows.Forms.Label
        Me.Label4 = New System.Windows.Forms.Label
        Me.ToolStrip1 = New System.Windows.Forms.ToolStrip
        Me.btn_prev = New System.Windows.Forms.ToolStripButton
        Me.btn_play = New System.Windows.Forms.ToolStripButton
        Me.btn_pause = New System.Windows.Forms.ToolStripButton
        Me.btn_stop = New System.Windows.Forms.ToolStripButton
        Me.btn_next = New System.Windows.Forms.ToolStripButton
        Me.btn_shuffle = New System.Windows.Forms.ToolStripButton
        Me.btn_repeat = New System.Windows.Forms.ToolStripButton
        Me.btn_playlist = New System.Windows.Forms.ToolStripButton
        Me.ToolStrip2 = New System.Windows.Forms.ToolStrip
        Me.btn_plMoveUP = New System.Windows.Forms.ToolStripButton
        Me.btn_plMoveDown = New System.Windows.Forms.ToolStripButton
        Me.btn_plDelete = New System.Windows.Forms.ToolStripButton
        Me.btn_add = New System.Windows.Forms.ToolStripButton
        Me.btn_pl_addFolder = New System.Windows.Forms.ToolStripButton
        Me.btn_clearPL = New System.Windows.Forms.ToolStripButton
        Me.btn_savePL = New System.Windows.Forms.ToolStripButton
        Me.btn_loadPL = New System.Windows.Forms.ToolStripButton
        Me.btn_hidePlayer = New System.Windows.Forms.ToolStripButton
        Me.btn_about = New System.Windows.Forms.ToolStripButton
        Me.btn_help = New System.Windows.Forms.ToolStripButton
        Me.Timer1 = New System.Windows.Forms.Timer(Me.components)
        Me.Timer2 = New System.Windows.Forms.Timer(Me.components)
        Me.lbl_CurDur = New System.Windows.Forms.Label
        Me.Label6 = New System.Windows.Forms.Label
        Me.lbl_dur = New System.Windows.Forms.Label
        Me.lbl_songname = New System.Windows.Forms.Label
        Me.NotifyIcon1 = New System.Windows.Forms.NotifyIcon(Me.components)
        Me.mnu_ntfyCntxt = New System.Windows.Forms.ContextMenuStrip(Me.components)
        Me.ntfyCntxtShow = New System.Windows.Forms.ToolStripMenuItem
        Me.pl_context.SuspendLayout()
        CType(Me.VolBar, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.SongTrackBar, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.player, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.ToolStrip1.SuspendLayout()
        Me.ToolStrip2.SuspendLayout()
        Me.mnu_ntfyCntxt.SuspendLayout()
        Me.SuspendLayout()
        '
        'OpenFileDialog1
        '
        Me.OpenFileDialog1.Filter = "Mp3 Music|*.mp3"
        Me.OpenFileDialog1.Multiselect = True
        '
        'playlist
        '
        Me.playlist.AllowDrop = True
        Me.playlist.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                    Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.playlist.BackColor = System.Drawing.SystemColors.ControlDark
        Me.playlist.ContextMenuStrip = Me.pl_context
        Me.playlist.ForeColor = System.Drawing.Color.White
        Me.playlist.FormattingEnabled = True
        Me.playlist.Location = New System.Drawing.Point(42, 120)
        Me.playlist.Name = "playlist"
        Me.playlist.SelectionMode = System.Windows.Forms.SelectionMode.MultiExtended
        Me.playlist.Size = New System.Drawing.Size(387, 329)
        Me.playlist.TabIndex = 3
        '
        'pl_context
        '
        Me.pl_context.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.cntxt_add2, Me.cntxt_delete2, Me.mnu_movablePL2})
        Me.pl_context.Name = "pl_context"
        Me.pl_context.Size = New System.Drawing.Size(263, 70)
        '
        'cntxt_add2
        '
        Me.cntxt_add2.Name = "cntxt_add2"
        Me.cntxt_add2.Size = New System.Drawing.Size(262, 22)
        Me.cntxt_add2.Text = "Add file(s)..."
        '
        'cntxt_delete2
        '
        Me.cntxt_delete2.Name = "cntxt_delete2"
        Me.cntxt_delete2.Size = New System.Drawing.Size(262, 22)
        Me.cntxt_delete2.Text = "Delete selected item(s) from playlist"
        '
        'mnu_movablePL2
        '
        Me.mnu_movablePL2.Name = "mnu_movablePL2"
        Me.mnu_movablePL2.Size = New System.Drawing.Size(262, 22)
        Me.mnu_movablePL2.Text = "Make movable playlist..."
        '
        'VolBar
        '
        Me.VolBar.Location = New System.Drawing.Point(393, 26)
        Me.VolBar.Maximum = 100
        Me.VolBar.Name = "VolBar"
        Me.VolBar.Orientation = System.Windows.Forms.Orientation.Vertical
        Me.VolBar.Size = New System.Drawing.Size(45, 95)
        Me.VolBar.TabIndex = 17
        Me.VolBar.Value = 50
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(365, 68)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(22, 13)
        Me.Label1.TabIndex = 18
        Me.Label1.Text = "Vol"
        '
        'lbl_vol
        '
        Me.lbl_vol.AutoSize = True
        Me.lbl_vol.Location = New System.Drawing.Point(368, 93)
        Me.lbl_vol.Name = "lbl_vol"
        Me.lbl_vol.Size = New System.Drawing.Size(19, 13)
        Me.lbl_vol.TabIndex = 19
        Me.lbl_vol.Text = "50"
        '
        'SongTrackBar
        '
        Me.SongTrackBar.Enabled = False
        Me.SongTrackBar.Location = New System.Drawing.Point(0, 24)
        Me.SongTrackBar.Maximum = 100
        Me.SongTrackBar.Name = "SongTrackBar"
        Me.SongTrackBar.Size = New System.Drawing.Size(394, 45)
        Me.SongTrackBar.TabIndex = 21
        '
        'SaveFileDialog1
        '
        Me.SaveFileDialog1.DefaultExt = "jpl"
        Me.SaveFileDialog1.Filter = "Juunas Playlist Files .jpl|*.jpl"
        '
        'player
        '
        Me.player.Enabled = True
        Me.player.Location = New System.Drawing.Point(115, 68)
        Me.player.Name = "player"
        Me.player.OcxState = CType(resources.GetObject("player.OcxState"), System.Windows.Forms.AxHost.State)
        Me.player.Size = New System.Drawing.Size(75, 23)
        Me.player.TabIndex = 2
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(671, 226)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(39, 13)
        Me.Label3.TabIndex = 35
        Me.Label3.Text = "Label3"
        Me.Label3.Visible = False
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(671, 243)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(39, 13)
        Me.Label4.TabIndex = 36
        Me.Label4.Text = "Label4"
        Me.Label4.Visible = False
        '
        'ToolStrip1
        '
        Me.ToolStrip1.AutoSize = False
        Me.ToolStrip1.BackColor = System.Drawing.SystemColors.ControlDarkDark
        Me.ToolStrip1.Dock = System.Windows.Forms.DockStyle.None
        Me.ToolStrip1.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden
        Me.ToolStrip1.ImageScalingSize = New System.Drawing.Size(0, 0)
        Me.ToolStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.btn_prev, Me.btn_play, Me.btn_pause, Me.btn_stop, Me.btn_next, Me.btn_shuffle, Me.btn_repeat, Me.btn_playlist})
        Me.ToolStrip1.Location = New System.Drawing.Point(0, 64)
        Me.ToolStrip1.MaximumSize = New System.Drawing.Size(300, 50)
        Me.ToolStrip1.MinimumSize = New System.Drawing.Size(300, 50)
        Me.ToolStrip1.Name = "ToolStrip1"
        Me.ToolStrip1.Size = New System.Drawing.Size(300, 50)
        Me.ToolStrip1.TabIndex = 39
        Me.ToolStrip1.Text = "ToolStrip1"
        '
        'btn_prev
        '
        Me.btn_prev.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.btn_prev.Image = CType(resources.GetObject("btn_prev.Image"), System.Drawing.Image)
        Me.btn_prev.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None
        Me.btn_prev.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.btn_prev.Name = "btn_prev"
        Me.btn_prev.Size = New System.Drawing.Size(36, 47)
        Me.btn_prev.Text = "Previous track"
        '
        'btn_play
        '
        Me.btn_play.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.btn_play.Image = CType(resources.GetObject("btn_play.Image"), System.Drawing.Image)
        Me.btn_play.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None
        Me.btn_play.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.btn_play.Name = "btn_play"
        Me.btn_play.Size = New System.Drawing.Size(36, 47)
        Me.btn_play.Text = "Play"
        '
        'btn_pause
        '
        Me.btn_pause.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.btn_pause.Image = CType(resources.GetObject("btn_pause.Image"), System.Drawing.Image)
        Me.btn_pause.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None
        Me.btn_pause.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.btn_pause.Name = "btn_pause"
        Me.btn_pause.Size = New System.Drawing.Size(36, 47)
        Me.btn_pause.Text = "Pause"
        '
        'btn_stop
        '
        Me.btn_stop.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.btn_stop.Image = CType(resources.GetObject("btn_stop.Image"), System.Drawing.Image)
        Me.btn_stop.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None
        Me.btn_stop.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.btn_stop.Name = "btn_stop"
        Me.btn_stop.Size = New System.Drawing.Size(36, 47)
        Me.btn_stop.Text = "Stop"
        '
        'btn_next
        '
        Me.btn_next.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.btn_next.Image = CType(resources.GetObject("btn_next.Image"), System.Drawing.Image)
        Me.btn_next.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None
        Me.btn_next.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.btn_next.Name = "btn_next"
        Me.btn_next.Size = New System.Drawing.Size(36, 47)
        Me.btn_next.Text = "Next track"
        '
        'btn_shuffle
        '
        Me.btn_shuffle.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.btn_shuffle.Image = CType(resources.GetObject("btn_shuffle.Image"), System.Drawing.Image)
        Me.btn_shuffle.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None
        Me.btn_shuffle.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.btn_shuffle.Name = "btn_shuffle"
        Me.btn_shuffle.Size = New System.Drawing.Size(36, 47)
        Me.btn_shuffle.Text = "Shuffle off"
        '
        'btn_repeat
        '
        Me.btn_repeat.BackColor = System.Drawing.Color.Blue
        Me.btn_repeat.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.btn_repeat.Image = CType(resources.GetObject("btn_repeat.Image"), System.Drawing.Image)
        Me.btn_repeat.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None
        Me.btn_repeat.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.btn_repeat.Name = "btn_repeat"
        Me.btn_repeat.Size = New System.Drawing.Size(36, 47)
        Me.btn_repeat.Text = "Repeating all tracks"
        '
        'btn_playlist
        '
        Me.btn_playlist.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.btn_playlist.Image = CType(resources.GetObject("btn_playlist.Image"), System.Drawing.Image)
        Me.btn_playlist.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None
        Me.btn_playlist.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.btn_playlist.Name = "btn_playlist"
        Me.btn_playlist.Size = New System.Drawing.Size(36, 47)
        Me.btn_playlist.Text = "Show / Hide playlist"
        '
        'ToolStrip2
        '
        Me.ToolStrip2.BackColor = System.Drawing.SystemColors.ControlDarkDark
        Me.ToolStrip2.Dock = System.Windows.Forms.DockStyle.None
        Me.ToolStrip2.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden
        Me.ToolStrip2.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.btn_plMoveUP, Me.btn_plMoveDown, Me.btn_plDelete, Me.btn_add, Me.btn_pl_addFolder, Me.btn_clearPL, Me.btn_savePL, Me.btn_loadPL, Me.btn_hidePlayer, Me.btn_about, Me.btn_help})
        Me.ToolStrip2.LayoutStyle = System.Windows.Forms.ToolStripLayoutStyle.VerticalStackWithOverflow
        Me.ToolStrip2.Location = New System.Drawing.Point(9, 119)
        Me.ToolStrip2.MaximumSize = New System.Drawing.Size(24, 260)
        Me.ToolStrip2.MinimumSize = New System.Drawing.Size(24, 260)
        Me.ToolStrip2.Name = "ToolStrip2"
        Me.ToolStrip2.Size = New System.Drawing.Size(24, 260)
        Me.ToolStrip2.TabIndex = 40
        Me.ToolStrip2.Text = "ToolStrip2"
        '
        'btn_plMoveUP
        '
        Me.btn_plMoveUP.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.btn_plMoveUP.Image = CType(resources.GetObject("btn_plMoveUP.Image"), System.Drawing.Image)
        Me.btn_plMoveUP.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.btn_plMoveUP.Name = "btn_plMoveUP"
        Me.btn_plMoveUP.Size = New System.Drawing.Size(22, 20)
        Me.btn_plMoveUP.Text = "Move selected item(s) up"
        '
        'btn_plMoveDown
        '
        Me.btn_plMoveDown.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.btn_plMoveDown.Image = CType(resources.GetObject("btn_plMoveDown.Image"), System.Drawing.Image)
        Me.btn_plMoveDown.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.btn_plMoveDown.Name = "btn_plMoveDown"
        Me.btn_plMoveDown.Size = New System.Drawing.Size(22, 20)
        Me.btn_plMoveDown.Text = "Move selected item(s) down"
        '
        'btn_plDelete
        '
        Me.btn_plDelete.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.btn_plDelete.Image = CType(resources.GetObject("btn_plDelete.Image"), System.Drawing.Image)
        Me.btn_plDelete.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.btn_plDelete.Name = "btn_plDelete"
        Me.btn_plDelete.Size = New System.Drawing.Size(22, 20)
        Me.btn_plDelete.Text = "Delete selected item(s) from playlist"
        '
        'btn_add
        '
        Me.btn_add.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.btn_add.Image = CType(resources.GetObject("btn_add.Image"), System.Drawing.Image)
        Me.btn_add.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.btn_add.Name = "btn_add"
        Me.btn_add.Size = New System.Drawing.Size(22, 20)
        Me.btn_add.Text = "Add file(s)..."
        '
        'btn_pl_addFolder
        '
        Me.btn_pl_addFolder.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.btn_pl_addFolder.Image = CType(resources.GetObject("btn_pl_addFolder.Image"), System.Drawing.Image)
        Me.btn_pl_addFolder.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.btn_pl_addFolder.Name = "btn_pl_addFolder"
        Me.btn_pl_addFolder.Size = New System.Drawing.Size(22, 20)
        Me.btn_pl_addFolder.Text = "Add folder..."
        '
        'btn_clearPL
        '
        Me.btn_clearPL.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.btn_clearPL.Image = CType(resources.GetObject("btn_clearPL.Image"), System.Drawing.Image)
        Me.btn_clearPL.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.btn_clearPL.Name = "btn_clearPL"
        Me.btn_clearPL.Size = New System.Drawing.Size(22, 20)
        Me.btn_clearPL.Text = "Clear playlist"
        '
        'btn_savePL
        '
        Me.btn_savePL.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.btn_savePL.Image = CType(resources.GetObject("btn_savePL.Image"), System.Drawing.Image)
        Me.btn_savePL.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.btn_savePL.Name = "btn_savePL"
        Me.btn_savePL.Size = New System.Drawing.Size(22, 20)
        Me.btn_savePL.Text = "Save playlist..."
        '
        'btn_loadPL
        '
        Me.btn_loadPL.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.btn_loadPL.Image = CType(resources.GetObject("btn_loadPL.Image"), System.Drawing.Image)
        Me.btn_loadPL.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.btn_loadPL.Name = "btn_loadPL"
        Me.btn_loadPL.Size = New System.Drawing.Size(22, 20)
        Me.btn_loadPL.Text = "Load playlist..."
        '
        'btn_hidePlayer
        '
        Me.btn_hidePlayer.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.btn_hidePlayer.Image = CType(resources.GetObject("btn_hidePlayer.Image"), System.Drawing.Image)
        Me.btn_hidePlayer.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.btn_hidePlayer.Name = "btn_hidePlayer"
        Me.btn_hidePlayer.Size = New System.Drawing.Size(22, 20)
        Me.btn_hidePlayer.Text = "Hide JPlayer"
        '
        'btn_about
        '
        Me.btn_about.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.btn_about.Image = CType(resources.GetObject("btn_about.Image"), System.Drawing.Image)
        Me.btn_about.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.btn_about.Name = "btn_about"
        Me.btn_about.Size = New System.Drawing.Size(22, 20)
        Me.btn_about.Text = "About JPlayer"
        '
        'btn_help
        '
        Me.btn_help.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.btn_help.Image = CType(resources.GetObject("btn_help.Image"), System.Drawing.Image)
        Me.btn_help.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.btn_help.Name = "btn_help"
        Me.btn_help.Size = New System.Drawing.Size(22, 20)
        Me.btn_help.Text = "Help"
        '
        'Timer1
        '
        Me.Timer1.Interval = 1000
        '
        'Timer2
        '
        Me.Timer2.Interval = 10
        '
        'lbl_CurDur
        '
        Me.lbl_CurDur.AutoSize = True
        Me.lbl_CurDur.Location = New System.Drawing.Point(12, 8)
        Me.lbl_CurDur.Name = "lbl_CurDur"
        Me.lbl_CurDur.Size = New System.Drawing.Size(34, 13)
        Me.lbl_CurDur.TabIndex = 41
        Me.lbl_CurDur.Text = "00:00"
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Location = New System.Drawing.Point(42, 8)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(12, 13)
        Me.Label6.TabIndex = 42
        Me.Label6.Text = "/"
        '
        'lbl_dur
        '
        Me.lbl_dur.AutoSize = True
        Me.lbl_dur.Location = New System.Drawing.Point(50, 8)
        Me.lbl_dur.Name = "lbl_dur"
        Me.lbl_dur.Size = New System.Drawing.Size(34, 13)
        Me.lbl_dur.TabIndex = 43
        Me.lbl_dur.Text = "00:00"
        '
        'lbl_songname
        '
        Me.lbl_songname.AutoSize = True
        Me.lbl_songname.BackColor = System.Drawing.Color.Black
        Me.lbl_songname.ForeColor = System.Drawing.Color.White
        Me.lbl_songname.Location = New System.Drawing.Point(90, 8)
        Me.lbl_songname.Name = "lbl_songname"
        Me.lbl_songname.Size = New System.Drawing.Size(13, 13)
        Me.lbl_songname.TabIndex = 44
        Me.lbl_songname.Text = "L"
        '
        'NotifyIcon1
        '
        Me.NotifyIcon1.Icon = CType(resources.GetObject("NotifyIcon1.Icon"), System.Drawing.Icon)
        Me.NotifyIcon1.Text = "JPlayer"
        '
        'mnu_ntfyCntxt
        '
        Me.mnu_ntfyCntxt.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.ntfyCntxtShow})
        Me.mnu_ntfyCntxt.Name = "mnu_ntfyCntxt"
        Me.mnu_ntfyCntxt.Size = New System.Drawing.Size(143, 26)
        '
        'ntfyCntxtShow
        '
        Me.ntfyCntxtShow.Name = "ntfyCntxtShow"
        Me.ntfyCntxtShow.Size = New System.Drawing.Size(142, 22)
        Me.ntfyCntxtShow.Text = "Show JPlayer"
        '
        'Form1
        '
        Me.AllowDrop = True
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.Black
        Me.ClientSize = New System.Drawing.Size(434, 454)
        Me.Controls.Add(Me.ToolStrip1)
        Me.Controls.Add(Me.lbl_songname)
        Me.Controls.Add(Me.lbl_dur)
        Me.Controls.Add(Me.Label6)
        Me.Controls.Add(Me.lbl_CurDur)
        Me.Controls.Add(Me.Label4)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.playlist)
        Me.Controls.Add(Me.player)
        Me.Controls.Add(Me.SongTrackBar)
        Me.Controls.Add(Me.ToolStrip2)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.VolBar)
        Me.Controls.Add(Me.lbl_vol)
        Me.ForeColor = System.Drawing.Color.White
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.MaximizeBox = False
        Me.MinimumSize = New System.Drawing.Size(450, 490)
        Me.Name = "Form1"
        Me.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Hide
        Me.Text = "JPlayer 1.3"
        Me.pl_context.ResumeLayout(False)
        CType(Me.VolBar, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.SongTrackBar, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.player, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ToolStrip1.ResumeLayout(False)
        Me.ToolStrip1.PerformLayout()
        Me.ToolStrip2.ResumeLayout(False)
        Me.ToolStrip2.PerformLayout()
        Me.mnu_ntfyCntxt.ResumeLayout(False)
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents OpenFileDialog1 As System.Windows.Forms.OpenFileDialog
    Friend WithEvents player As AxWMPLib.AxWindowsMediaPlayer
    Friend WithEvents playlist As System.Windows.Forms.ListBox
    Friend WithEvents VolBar As System.Windows.Forms.TrackBar
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents lbl_vol As System.Windows.Forms.Label
    Friend WithEvents SongTrackBar As System.Windows.Forms.TrackBar
    Friend WithEvents SaveFileDialog1 As System.Windows.Forms.SaveFileDialog
    Friend WithEvents FolderBrowserDialog1 As System.Windows.Forms.FolderBrowserDialog
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents ToolStrip1 As System.Windows.Forms.ToolStrip
    Friend WithEvents ToolStrip2 As System.Windows.Forms.ToolStrip
    Friend WithEvents btn_prev As System.Windows.Forms.ToolStripButton
    Friend WithEvents btn_play As System.Windows.Forms.ToolStripButton
    Friend WithEvents btn_pause As System.Windows.Forms.ToolStripButton
    Friend WithEvents btn_plMoveUP As System.Windows.Forms.ToolStripButton
    Friend WithEvents btn_plMoveDown As System.Windows.Forms.ToolStripButton
    Friend WithEvents btn_plDelete As System.Windows.Forms.ToolStripButton
    Friend WithEvents btn_add As System.Windows.Forms.ToolStripButton
    Friend WithEvents btn_stop As System.Windows.Forms.ToolStripButton
    Friend WithEvents btn_next As System.Windows.Forms.ToolStripButton
    Friend WithEvents btn_shuffle As System.Windows.Forms.ToolStripButton
    Friend WithEvents btn_repeat As System.Windows.Forms.ToolStripButton
    Friend WithEvents btn_pl_addFolder As System.Windows.Forms.ToolStripButton
    Friend WithEvents btn_clearPL As System.Windows.Forms.ToolStripButton
    Friend WithEvents btn_savePL As System.Windows.Forms.ToolStripButton
    Friend WithEvents btn_loadPL As System.Windows.Forms.ToolStripButton
    Friend WithEvents btn_hidePlayer As System.Windows.Forms.ToolStripButton
    Friend WithEvents btn_about As System.Windows.Forms.ToolStripButton
    Friend WithEvents btn_help As System.Windows.Forms.ToolStripButton
    Friend WithEvents Timer1 As System.Windows.Forms.Timer
    Friend WithEvents Timer2 As System.Windows.Forms.Timer
    Friend WithEvents lbl_CurDur As System.Windows.Forms.Label
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents lbl_dur As System.Windows.Forms.Label
    Friend WithEvents lbl_songname As System.Windows.Forms.Label
    Friend WithEvents NotifyIcon1 As System.Windows.Forms.NotifyIcon
    Friend WithEvents mnu_ntfyCntxt As System.Windows.Forms.ContextMenuStrip
    Friend WithEvents ntfyCntxtShow As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents pl_context As System.Windows.Forms.ContextMenuStrip
    Friend WithEvents cntxt_add2 As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents cntxt_delete2 As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents mnu_movablePL2 As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents btn_playlist As System.Windows.Forms.ToolStripButton

End Class
