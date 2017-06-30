using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using Android.Media;
using Xamarin.Forms;
using System.Threading.Tasks;
using AudioRecorderDemo.Interfaces;
using AudioRecorderDemo.Droid.DS;

[assembly: Xamarin.Forms.Dependency(typeof(AudioRecorder))]
namespace AudioRecorderDemo.Droid.DS
{
    class AudioRecorder : IAudioRecorder
    {
        static long Time { get; set; }
        MediaRecorder _recorder;
        MediaPlayer _player;
        string path = "/sdcard/test.3gpp";
        public AudioRecorder()
        {


            _recorder = new MediaRecorder();
            _player = new MediaPlayer();

            _player.Completion += (sender, e) =>
            {
                _player.Reset();
            };
        }


        public void SaveRecording()
        {

        }

        public void StartRecording()
        {
            try
            {

                _recorder.SetAudioSource(AudioSource.Mic);
                _recorder.SetOutputFormat(OutputFormat.ThreeGpp);
                _recorder.SetAudioEncoder(AudioEncoder.AmrNb);
                _recorder.SetOutputFile(path);
                _recorder.Prepare();
                _recorder.Start();
            }
            catch(Exception e)
            {
                var str=e.Message;
            }

        }
        public void StopRecording()
        {
            try
            {
                _recorder.Stop();
                _recorder.Reset();
                _player.SetDataSource(path);
            }
            catch(Exception e)
            {
                var str = e.Message;
            }

        }

        public void ResetRecording()
        {
            _recorder = new MediaRecorder();
            _player = new Android.Media.MediaPlayer();

            _player.Completion += (sender, e) =>
            {
                _player.Reset();
               
            };
        }

        public async void PlayRecording()
        {

            _player.Prepare();
            Time = _player.Duration;
            _player.Looping = true;
            _player.Start();
            MessagingCenter.Send<AudioRecorder, int>(this, "Maximum", _player.Duration);
            while (_player.IsPlaying)
            {
                await Task.Delay(100);
                // Time = _player.CurrentPosition;
                MessagingCenter.Send<AudioRecorder, int>(this, "CurrentPosition", _player.CurrentPosition);
            }

        }

        public async void ValueChanged(int value)
        {
            _player.SeekTo(value);
            while (_player.IsPlaying)
            {
                await Task.Delay(100);
                // Time = _player.CurrentPosition;
                MessagingCenter.Send<AudioRecorder, int>(this, "CurrentPosition", _player.CurrentPosition);
            }
        }
    }
}