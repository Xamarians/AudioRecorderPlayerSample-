//using AudioRecorderDemo.Droid.DS;
//using AudioRecorderDemo.Interfaces;
//using System;
//using Xamarin.Forms;
//using Xamarin.Forms.Xaml;

//namespace AudioRecorderDemo.Views
//{
//    [XamlCompilation(XamlCompilationOptions.Compile)]
//	public partial class AudioRecorderPage : ContentPage
//	{
//        public AudioRecorderPage()
//        {           
//            InitializeComponent();            
//        }             

//        private void TapGestureRecognizer_PauseButton(object sender2, EventArgs e)
//        {
//            MessagingCenter.Subscribe<AudioRecorder, int>(this, "Maximum", (sender, args) =>
//            {
//                progress.Minimum = 0;
//                progress.Maximum = args;
//            });
//            DependencyService.Get<IAudioRecorder>().StopRecording();
//            pausebutton.IsVisible = false;
//            savegrid.IsVisible = true;
//        }

//        private async void TapGestureRecognizer_RecordButton(object sender, EventArgs e)
//        {

//            int i = 0;


//            //Movement of Record Button Animation
//            await timer.TranslateTo(0, -3, 10);
//            await pausebutton.TranslateTo(-50, 0, 10);
//            await recordbutton.TranslateTo(-50, 0, 500);
//            DependencyService.Get<IAudioRecorder>().StartRecording();
//            recordbutton.IsVisible = false;
//            pausebutton.IsVisible = true;
//            timer.IsVisible = true;
//            DateTime count = new DateTime();


//            //Animation for the timer Associated with Audio Recorder
//            boxtop.Animate(
//            name: "animate",
//            animation: new Animation((val) =>
//            {
//                timer.Text = count.AddSeconds(i++).ToString("HH:mm");
//            }),
//            length: 3000,

//            repeat: () => { return true; }
            
//       );

//        }

//        //private void TapGestureRecognizer_StopButton(object sender2, EventArgs e)
//        //{          
//        //    DependencyService.Get<IAudioRecorder>().StopRecording();
//        //    savegrid.IsVisible = true;
//        //}

//        private void TapGestureRecognizer_PlayButton(object sender1, EventArgs e)
//        {
//            playbutton.IsVisible = false;
//            DependencyService.Get<IAudioRecorder>().PlayRecording();
//            progress.IsVisible = true;
//            MessagingCenter.Subscribe<AudioRecorder, int>(this, "CurrentPosition", (sender, args) =>
//            {
//                progress.Value = args;
//            });
//        }
//        private void TapGestureRecognizer_DeleteButton(object sender, EventArgs e)
//        {
//            savegrid.IsVisible = false;
//        }
//    }
//}
