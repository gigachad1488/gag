using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Media;
using System.IO;
using NAudio.Wave;
using NAudio;
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
using System.Windows.Forms;
using NAudio.Wave.Compression;
using System.Net.Mime;
using NAudio.MediaFoundation;

namespace говно_осла
{
    public class Song
    {
        public string Name { get; set; }
        public string Path { get; set; }
        private WaveFileReader reader;
        private DirectSoundOut d;
        private WaveChannel32 channel;

        public Song(string songpath, string name)
        {
            Name = name;
            Path = songpath;
            InitializeSong();
        }

        public void InitializeSong()
        {
            d = new DirectSoundOut();
            int start = Path.LastIndexOf('.');
            if (Path.Substring(start, Path.Length - start) == "wav")
            {
                reader = new WaveFileReader(Path);
                channel = new WaveChannel32(reader);
                
            }
            else
            {
                //AcmMp3FrameDecompressor f;
                //Mp3FileReaderBase.FrameDecompressorBuilder builder = new Mp3FileReaderBase.FrameDecompressorBuilder(wf => new AcmMp3FrameDecompressor(wf));
                //Mp3FileReaderBase read = new Mp3FileReaderBase(path, builder);

                WaveStream pcm = WaveFormatConversionStream.CreatePcmStream(new MediaFoundationReader(Path));
                BlockAlignReductionStream stream = new BlockAlignReductionStream(pcm);
                channel = new WaveChannel32(stream);
            }
            d.Init(channel);

        }

        public void DisposeSong()
        {
            d.Dispose();
            d = null;
        }

        public void PlaySong()
        {
            InitializeSong();
            d.Play();
        }

        public void StopSong()
        {
            if (d != null && d.PlaybackState == PlaybackState.Playing)
                d.Stop();
        }

        public void PauseSong()
        {
            d.Pause();
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
                DisposeSong();
                InitializeSong();
                PlaySong();
            }
        }
        
        public void ChangeVolume(float volume)
        {
            channel.Volume = volume;
        }

    }

}
