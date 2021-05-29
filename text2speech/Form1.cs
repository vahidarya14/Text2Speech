using System;
using System.Windows.Forms;
using System.Speech.Synthesis;

namespace texttospeech
{
    public partial class Form1 : Form
    {
        int _speed;
        SpeechSynthesizer _speaker= new SpeechSynthesizer();
        public Form1()
        {
            InitializeComponent();
           
        }

        private void Button1Click(object sender, EventArgs e)
        {
            
            try
            {
                if (_speaker.State==SynthesizerState.Paused)
                {
                    _speaker.Resume();
                    return;
                }
                if (!(_speaker.State == SynthesizerState.Speaking))
                {
                    _speaker = new SpeechSynthesizer
                                   {
                                       Volume = trackBar1.Value,
                                       Rate = _speed
                                   };

                    // speaker.Speak(textBox1.Text);
                    _speaker.SpeakCompleted += ( obj, speakCompletedEventArgs ) => { };
                    //speaker.SelectVoice("a");
                    //speaker.SetOutputToWaveFile("d:\\a.wav");

                    _speaker.SpeakAsync(textBox1.Text);
                }
            }
            catch
            {
                _speaker.Resume();
            }
        }



        private void Button2Click(object sender, EventArgs e)
        {
              _speaker.Pause();
        }

        private void Button3Click(object sender, EventArgs e)
        {
            if (_speed >= 10)
            { 
                button3.Enabled = false;
                _speed = 10; return; 
            }
            button4.Enabled = true;
            _speed+=5;
            
            _speaker.Rate = _speed;

            if (_speaker != null)
            {
                _speaker.Pause();
                _speaker.Resume();
            }
        }

        private void Button4Click(object sender, EventArgs e)
        {
            if (_speed <= -10)
            {
                button4.Enabled = false;
                _speed = -10; return;
            }
            button3.Enabled = true;
            _speed -= 5;


            _speaker.Rate = _speed;
            if (_speaker != null)
            {
                _speaker.Pause();
                _speaker.Resume();
            }
        }

        private void TrackBar1Scroll(object sender, EventArgs e)
        {
            
        }

        private void TrackBar1MouseUp(object sender, MouseEventArgs e)
        {
            _speaker.Volume = trackBar1.Value;
        }



     }
}
