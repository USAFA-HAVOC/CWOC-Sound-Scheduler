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

namespace CWOC_Audio_Scheduler
{
    public partial class BasicFunctionForm : Form
    {
        WaveOutEvent outputDevice = new WaveOutEvent();
        ScheduleManager manager;
        string path;
        public BasicFunctionForm()
        {
            manager = new ScheduleManager(this);
            InitializeComponent();

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

            if (lbxToday.Items.Count > 0)
            {

                for (int i = 0; i < manager.todaysExceptions.Count; i++)
                {
                    ScheduleObject scheduleException = manager.todaysExceptions[i];

                    int j = 0;
                    ScheduleObject comparingObject = (ScheduleObject)lbxToday.Items[0];
                    while (j < WorkBench.staticTemplates.Count - 1 && scheduleException.time > comparingObject.time)
                    {
                        j++;
                        comparingObject = (ScheduleObject)lbxToday.Items[j];
                    }
                    lbxToday.Items.Insert(j, scheduleException);
                }
            }
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
            }
        }

        private void btnTodayAdd_Click(object sender, EventArgs e)
        {
            if (cboSoundsToday.SelectedIndex != -1)
            {
                string path = Path.Combine(this.path, cboSoundsToday.Text + ".mp3");
                ScheduleObject so = new ScheduleObject(path, TimeOnly.Parse(dtpTodayTime.Text));
                manager.CreateExceptionToday(path, TimeOnly.Parse(dtpTodayTime.Text));
                updateTodayListBox();
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

            if (day.CompareTo(today) >= 0)
            {
                cboChangeDayTemplates.SelectedItem = manager.GetTemplateForDay(day);
            }
            else
            {
                cboChangeDayTemplates.SelectedItem = null;
            }
        }
    }
}
