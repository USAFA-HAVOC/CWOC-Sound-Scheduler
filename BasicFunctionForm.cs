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
using System.IO;
using System.Media;
using System.Globalization;

namespace CWOC_Audio_Scheduler
{
    public partial class BasicFunctionForm : Form
    {
        WaveOutEvent outputDevice = new WaveOutEvent();
        ScheduleManager manager;

        string path;
        public BasicFunctionForm()
        {
            InitializeComponent();
            manager = new ScheduleManager(this);
            dtpTodayTime.ShowUpDown = true;

            WorkBench.BuildTemplates();
            InitTemplateCboBoxes();
            manager.CreateNextDayEvents();
            path = Path.Combine(Environment.CurrentDirectory, "sounds");
            path = Path.Combine(Directory.GetParent(Environment.CurrentDirectory).Parent.Parent.FullName, "sounds\\");

            ScheduleTemplate[] templates = WorkBench.staticTemplates.ToArray();
            string[] sounds = { };

            try
            {
                sounds = Directory.GetFiles(path, "*.mp3*", SearchOption.AllDirectories);
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message);
            }

            for (int i = 0; i < sounds.Length; i++)
            {
                sounds[i] = Path.GetFileNameWithoutExtension(sounds[i]);
            }

            cboSounds.Items.AddRange(sounds);
            cboSoundsToday.Items.AddRange(sounds);
            updateTodayListBox();
            updateChangeDaySchedule();
            updateTodayLabels();
        }

        private void InitTemplateCboBoxes()
        {
            for (int i = 0; i < WorkBench.staticTemplates.Count; i++)
            {
                manager.templates.Add(WorkBench.staticTemplates[i]);
                cboChangeDayTemplates.Items.Add(WorkBench.staticTemplates[i]);
            }
        }

        public void updateTodayListBox()
        {
            buildUpdateListBox();
        }

        public void updateTodayLabels()
        {
            if (lbxToday.Items.Count == 0)
            {
                lblTodayNextSound.Text = "Unknown";
                return;
            }
            TimeOnly now = TimeOnly.FromDateTime(DateTime.Now);
            ScheduleObject nextSound = (ScheduleObject)lbxToday.Items[0];

            for (int i = 0; i < lbxToday.Items.Count; i++)
            {
                ScheduleObject item = (ScheduleObject) lbxToday.Items[i];
                if (item.time.IsBetween(now, nextSound.time))
                {
                    nextSound = item;
                }
            }

            lblTodayNextSound.Text = nextSound.ToString();
            lblTodayDay.Text = DateTime.Now.ToString("MMMM d, yyyy");
        }

        private void buildUpdateListBox()
        {
            lbxToday.Items.Clear();
            for (int i = 0; i < manager.backgroundWorkers.Count; i++)
            {
                if (!manager.backgroundWorkers[i].scheduleObject.disabled)
                {
                    lbxToday.Items.Add(manager.backgroundWorkers[i].scheduleObject);
                }
            }

            lblTodayTemplate.Text = manager.todayTemplate.ToString();
        }

        private void play_now_btn_click(object sender, EventArgs e)
        {
            if (cboSounds.SelectedIndex != -1)
            {
                play_sound(path + cboSounds.SelectedItem);
            }
        }

        /**
         * Should be deleted in favor of schedule manager play_now function
         */
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

        private void btnTodayRemove_Click(object sender, EventArgs e)
        {
            if (lbxToday.SelectedIndex != -1)
            {
                ScheduleObject ob = (ScheduleObject)lbxToday.SelectedItem;
                manager.killWorker(ob);
                updateTodayListBox();
                updateTodayLabels();
            }
        }

        private void btnTodayAdd_Click(object sender, EventArgs e)
        {
            if (cboSoundsToday.SelectedIndex != -1)
            {
                string path = Path.Combine(this.path, cboSoundsToday.Text + ".mp3");
                TimeOnly time = TimeOnly.ParseExact(dtpTodayTime.Text, "HHmm");
                ScheduleObject so = new ScheduleObject(path, time, chbNextDay.Checked);
                manager.CreateExceptionToday(so);
                updateTodayListBox();
                updateTodayLabels();
            }
        }

        private void create_template_day_exception_Click(object sender, EventArgs e)
        {
            if (cboChangeDayTemplates.SelectedItem != null)
            {
                manager.CreateTemplateDayException((ScheduleTemplate)cboChangeDayTemplates.SelectedItem, DateOnly.Parse(dtpTemplateDayChanger.Text));
            }
        }

        private void dtpTemplateDayChanger_ValueChanged(object sender, EventArgs e)
        {
            updateChangeDaySchedule();
        }

        private void updateChangeDaySchedule()
        {
            DateOnly day = DateOnly.FromDateTime(dtpTemplateDayChanger.Value);
            DateOnly today = DateOnly.FromDateTime(DateTime.Now);
            int compare = day.CompareTo(today);
            cboChangeDayTemplates.SelectedItem = manager.GetTemplateForDay(day);

            if (compare < 0)
            {
                btnCreateTemplateDayException.Enabled = false;
            } else
            {
                btnCreateTemplateDayException.Enabled = true;
            }
        }
    }
}
