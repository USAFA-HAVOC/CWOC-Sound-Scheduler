using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CWOC_Audio_Scheduler
{
    public partial class TemplateManager : Form
    {
        private ScheduleTemplate newTemplate = new ScheduleTemplate();
        private BasicFunctionForm parentForm;
        public TemplateManager(BasicFunctionForm basicFunctionForm)
        {
            InitializeComponent();
            basicFunctionForm.PopulateSoundListBox(this.cboSounds);
            basicFunctionForm.PopulateTemplateCboBoxes(this.cboTemplates);

            parentForm = basicFunctionForm;
        }

        public void populateListBox()
        {
            ScheduleTemplate template;
            if (cboTemplates.SelectedIndex != -1)
            {
                newTemplate = (ScheduleTemplate)cboTemplates.SelectedItem;
            }
            else
            {
                newTemplate = new ScheduleTemplate();
            }
            updateFormForNewTemplate(newTemplate);
        }

        public void updateFormForNewTemplate(ScheduleTemplate template)
        {
            updateCheckBoxes(template);
            populateListBoxFromTemplate(template);
        }


        public void populateListBoxFromTemplate(ScheduleTemplate template)
        {
            lbxTemplate.Items.Clear();
            foreach (ScheduleObject so in template.scheduleObjects)
            {
                lbxTemplate.Items.Add(so);
            }
        }

        public void updateCheckBoxes(ScheduleTemplate template)
        {
            chbSunday.Checked = template.daysDefault[0];
            chbMonday.Checked = template.daysDefault[1];
            chbTuesday.Checked = template.daysDefault[2];
            chbWednesday.Checked = template.daysDefault[3];
            chbThursday.Checked = template.daysDefault[4];
            chbFriday.Checked = template.daysDefault[5];
            chbSaturday.Checked = template.daysDefault[6];
        }


        private void updateDaysDefault()
        {
            bool[] defaultDays = {
                chbSunday.Checked,
                chbMonday.Checked,
                chbTuesday.Checked,
                chbWednesday.Checked,
                chbThursday.Checked,
                chbFriday.Checked,
                chbSaturday.Checked,
            };

            newTemplate.defaultTemplate =
                chbSunday.Checked ||
                chbMonday.Checked ||
                chbTuesday.Checked ||
                chbWednesday.Checked ||
                chbThursday.Checked ||
                chbFriday.Checked ||
                chbSaturday.Checked;

            newTemplate.daysDefault = defaultDays;
        }


        public void updateTemplateStartEndDate()
        {
            newTemplate.startDate = new DateOnly();
            newTemplate.endDate = new DateOnly();
        }

        private void btnCreateNew_Click(object sender, EventArgs e)
        {
            updateTemplateStartEndDate();
            updateDaysDefault();
            newTemplate.name = cboTemplates.Text;
            string fileName = Path.Combine(BasicFunctionForm.template_path, newTemplate.getFileName());
            if (File.Exists(fileName))
            {
                if (MessageBox.Show($"This will override the existing \"{newTemplate.name}\" file. Continue?",
                    "Confirm", MessageBoxButtons.OKCancel, MessageBoxIcon.None) != DialogResult.OK)
                {
                    return;
                }
            }
            newTemplate.ToFile(Path.Combine(BasicFunctionForm.template_path, "test.template"));
        }

        private void cboTemplates_SelectedIndexChanged(object sender, EventArgs e)
        {
            newTemplate = cboTemplates.SelectedIndex == -1 ? new ScheduleTemplate() : (ScheduleTemplate)cboTemplates.SelectedItem;
            populateListBox();
        }

        private void btnTemplateAdd_Click(object sender, EventArgs e)
        {
            TimeOnly time;
            try
            {
                time = TimeOnly.ParseExact(txtTime.Text, "HHmm");
            }
            catch (Exception)
            {
                return;
            }

            if (cboSounds.SelectedIndex != -1)
            {
                string path = cboSounds.Text + ".mp3";
                ScheduleObject so = new ScheduleObject(path, time, chbNextDay.Checked);

                newTemplate.insertScheduleObject(so);
                populateListBoxFromTemplate(newTemplate);
            }
        }
    }
}
