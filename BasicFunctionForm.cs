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
        BackgroundWorker? repeatThread;

        public static string sound_path = Path.Combine(Environment.CurrentDirectory, "sounds\\");
        public static string template_path = Path.Combine(Environment.CurrentDirectory, "templates\\");
        public BasicFunctionForm()
        {
            InitializeComponent();
            manager = new ScheduleManager(this);

            //WorkBench.BuildTemplates();
            PopulateTemplateCboBoxes(cboChangeDayTemplates);
            manager.CreateNextDayEvents();

            //path = Path.Combine(Directory.GetParent(Environment.CurrentDirectory).Parent.Parent.FullName, "sounds\\");

            List<ScheduleTemplate> templates = manager.templates;
            PopulateSoundListBox(this.cboSounds);
            PopulateSoundListBox(this.cboSoundsToday);
            updateTodayListBox();
            updateChangeDaySchedule();
            updateTodayLabels();
        }

        public void PopulateSoundListBox(ComboBox cbo)
        {
            string[] sounds = { };
            cbo.Items.Clear();
            try
            {
                sounds = Directory.GetFiles(sound_path, "*.mp3*", SearchOption.AllDirectories);
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message);
            }

            for (int i = 0; i < sounds.Length; i++)
            {
                sounds[i] = Path.GetFileNameWithoutExtension(sounds[i]);
            } 

            if (sounds.Length == 0)
            {
                cbo.Enabled = false;
            } else
            {
                cbo.Enabled = true;
                cbo.Items.AddRange(sounds);
            }
        }

        public void PopulateTemplateCboBoxes(ComboBox cbo)
        {
            cbo.Items.Clear();
            manager.templates.Clear();

            string[] template_files = Directory.GetFiles(template_path, "*.template", SearchOption.AllDirectories);
            for (int i = 0; i < template_files.Count(); i++)
            {
                ScheduleTemplate template = ScheduleTemplate.FromFile(template_files[i]);
                manager.templates.Add(template);
                cbo.Items.Add(template);
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
            if (cboSounds.SelectedIndex != -1 && !manager.isPlayingSound)
            {
                BackgroundWorker bgWorker = new BackgroundWorker();
                bgWorker.WorkerSupportsCancellation = true;
                this.repeatThread = bgWorker;
                bgWorker.DoWork += new DoWorkEventHandler(manager.delegate_sound_playing);
                bgWorker.RunWorkerAsync(sound_path + cboSounds.SelectedItem + ".mp3");
            }
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

            try
            {
                TimeOnly time = TimeOnly.ParseExact(txtTime.Text, "HHmm");
                if (cboSoundsToday.SelectedIndex != -1)
                {
                    string path = Path.Combine(sound_path, cboSoundsToday.Text + ".mp3");
                    ScheduleObject so = new ScheduleObject(path, time, chbNextDay.Checked);
                    manager.CreateExceptionToday(so);
                    updateTodayListBox();
                    updateTodayLabels();
                }
            }
            catch (Exception exception)
            {
                return;
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

        private void checkBoxMuted_CheckedChanged(object sender, EventArgs e)
        {
            manager.muted = checkBoxMuted.Checked;
        }

        private void stopRepeatButton_Click(object sender, EventArgs e)
        {
            manager.cancelRepeat = true;
            manager.StopSound();
        }
        private void checkBoxRepeat_CheckedChanged(object sender, EventArgs e)
        {
            //btnStopRepeat.Enabled = checkBoxRepeat.Checked;
        }

        private void reloadFilesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            PopulateSoundListBox(this.cboSounds);
            PopulateSoundListBox(this.cboSoundsToday);
        }

        public void updateNowPLayingLabel(string fileName)
        {
            lblNowPlaying.Text = "Now Playing: " + fileName;
        }

        private void btnTemplateManager_Click(object sender, EventArgs e)
        {
            TemplateManager managerForm = new TemplateManager(this);
            managerForm.Show();
        }
    }
}
