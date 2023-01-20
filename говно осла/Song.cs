using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Media;

namespace говно_осла
{
    public class Song
    {
        public string Name { get; set; }
        private SoundPlayer songpath;

        public Song(SoundPlayer songpath, string name)
        {
            this.songpath = songpath;
            Name = name;
        }

        public void PlaySong()
        {
            songpath.PlayLooping();
        }

        public void StopSong()
        {
            songpath.Stop();
        }

        public void ResumeSong()
        {
            songpath.Play();
        }
    }
}
