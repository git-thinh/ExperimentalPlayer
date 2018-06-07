Public Class help

    Private Sub help_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        RichTextBox1.LoadFile(ExperimentalPlayer.My.Settings.playerLocation & "Resources\jplayer_help.rtf")
    End Sub
End Class