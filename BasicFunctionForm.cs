using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using NAudio.Wave;

namespace CWOC_Audio_Scheduler
{
    public partial class BasicFunctionForm : Form
    {
        public BasicFunctionForm()
        {
            InitializeComponent();
        }

        private void play_now_btn_click(object sender, EventArgs e)
        {
            play_sound(@"sounds/ file_example_MP3_700KB.mp3");
        }

        private void play_sound(string path)
        {
            var audioFile = new Mp3FileReader(path);
            var outputDevice = new WaveOutEvent();
            outputDevice.Init(audioFile);
            outputDevice.Play();

        }
    }
}
