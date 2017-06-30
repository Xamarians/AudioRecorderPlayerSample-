using System;
using System.Collections.Generic;
using System.Text;

namespace AudioRecorderDemo.Interfaces
{
    interface IAudioRecorder
    {
        void StartRecording();
        void StopRecording();
        void PlayRecording();
        void SaveRecording();
        void ResetRecording();
    }
}
