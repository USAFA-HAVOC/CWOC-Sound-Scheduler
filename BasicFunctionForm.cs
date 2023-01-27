using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Text;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using NAudio.Wave;

namespace CWOC_Audio_Scheduler
{
    public partial class BasicFunctionForm : Form
    {
        WaveOutEvent outputDevice = new WaveOutEvent();
        ScheduleManager manager = new ScheduleManager();
        string path;
        public BasicFunctionForm()
        {
            InitializeComponent();

            path =  Application.StartupPath + @"\sounds"; //This is production, but doesn't work in a debug environment
            string[] sounds = { };

            path = "C:\\Users\\cadet_admin\\source\\repos\\CWOC-Sound-Scheduler\\sounds\\";
            try
            {
                sounds = Directory.GetFiles(path, "*.mp3*", SearchOption.AllDirectories);
            } catch (Exception e)
            {
                MessageBox.Show(e.Message);
            }

            for (int i = 0; i < sounds.Length; i++) 
            {
                sounds[i] = Path.GetFileNameWithoutExtension(sounds[i]);
            }

            cboSounds.Items.AddRange(sounds);
            cboSoundsToday.Items.AddRange(sounds);
        }

        private void play_now_btn_click(object sender, EventArgs e)
        {
            if (cboSounds.SelectedIndex != -1)
            {
                play_sound(path + cboSounds.SelectedItem);
                //play_sound(@"\sounds" + (string) cboSounds.SelectedItem); //Dev path. Doesn't work in debug
            }
        }

        private void play_sound(string path)
        {
            if (outputDevice != null)
            {
                outputDevice.Stop();
            }

            var audioFile = new Mp3FileReader(path + ".mp3");
            outputDevice = new WaveOutEvent();
            outputDevice.Init(audioFile);
            outputDevice.Play();

        }
    }
}
