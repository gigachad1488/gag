using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Media;
using System.IO;
using NAudio.Wave;
using NAudio.Wave.SampleProviders;
using NAudio.CoreAudioApi;
using NAudio.FileFormats;
using NAudio.Dmo;
using NAudio.Utils;
using NAudio.Dsp;
using NAudio.Codecs;
using NAudio.SoundFont;
using static System.Net.WebRequestMethods;
using System.Security.Cryptography;

namespace говно_осла
{
    public class Song
    {
        public string Name { get; set; }
        private WaveFileReader path;
        private DirectSoundOut d;
        private DirectSoundOut origd;

        public Song(WaveFileReader songpath, string name)
        {
            Name = name;
            path = songpath;
            InitializeSong(path);
        }

        public void InitializeSong(WaveFileReader songpath)
        {
            d = new DirectSoundOut();
            d.Init(new WaveChannel32(songpath));
            origd = new DirectSoundOut();
            origd.Init(new WaveChannel32(songpath));

        }

        public void PlaySong()
        {
            d.Play();
        }

        public void StopSong()
        {
            if (d != null && d.PlaybackState == PlaybackState.Playing) 
                d.Stop();
        }

        public void ResumeSong()
        {
            if (d != null && d.PlaybackState == PlaybackState.Stopped)
                d.Play();
        }

        public void RestartSong()
        {
            if (d != null)
            {
                WaveFileReader f = path;
                d.Stop();
                d.Dispose();
                d = null;
                path.Dispose();
                path = null;
                path = f;
                InitializeSong(path);
               
                d.Play();
            }
        }


    }

}
