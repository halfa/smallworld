using System;
using System.Windows.Media;

namespace SmallWorld.gui
{
    class BackgroundAudioPlayer
    {
        private MediaPlayer mediaPlayer = new MediaPlayer();

        public void play()
        {
            mediaPlayer.Open(new Uri("music\\bg.m4a", UriKind.Relative));
            mediaPlayer.MediaEnded += MediaPlayer_MediaEnded;
            mediaPlayer.Play();
        }

        private void MediaPlayer_MediaEnded(object sender, EventArgs e)
        {
            (sender as MediaPlayer).Open(new Uri("music\\bg.m4a", UriKind.Relative));
            (sender as MediaPlayer).Play();
        }

        public void stop()
        {
            mediaPlayer.Stop();
            mediaPlayer.Close();
        }
    }
}
