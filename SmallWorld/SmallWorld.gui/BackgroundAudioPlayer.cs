using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media;

namespace SmallWorld.gui
{
    class BackgroundAudioPlayer
    {
        private MediaPlayer mediaPlayer = new MediaPlayer();

        public void play()
        {
            mediaPlayer.Open(new Uri("music\\bg.m4a", UriKind.Relative));
            mediaPlayer.Play();
        }
    }
}
