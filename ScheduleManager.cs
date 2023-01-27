using Microsoft.VisualBasic.ApplicationServices;
using Microsoft.VisualBasic.Devices;
using NAudio.Wave;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CWOC_Audio_Scheduler
{
    internal class ScheduleManager
    {
        public List<ScheduleTemplate> templates;
        public List<DayScheduleException> todaysExceptions;
        public List<TemplateDayException> templateDayExceptions;


        
        public ScheduleManager()
        {
            templates = new List<ScheduleTemplate>();
            todaysExceptions = new List<DayScheduleException>();
            templateDayExceptions = new List<TemplateDayException>();
        }

        public void CreateNextEvent()
        {
            BackgroundWorker worker;
            DateOnly today = DateOnly.FromDateTime(DateTime.Now);
            for (int i = 0; i < templates.Count; i++)
            {
                if (templates[i].schedulesDay(today))
                {
                    for (int j = 0; j < templates[i].scheduleObjects.Count; j++)
                    {
                        worker = new BackgroundWorker();
                        worker.DoWork += new DoWorkEventHandler(WaitUntilEventTime);
                        worker.RunWorkerAsync(templates[i].scheduleObjects[j]);
                    }
                    return;
                }
            }
        }

        private void WaitUntilEventTime(object sender, DoWorkEventArgs args)
        {
            ScheduleObject scheduleObject = (ScheduleObject)args.Argument;
            TimeSpan eventTime = scheduleObject.time.ToTimeSpan();
            Thread.Sleep(eventTime);
            play_sound("C:\\Users\\Kayleb\\source\\repos\\CWOC Audio Scheduler\\CWOC-Sound-Scheduler-main\\sounds\\" + scheduleObject.path);
        }



        private void play_sound(string path)
        {
            var audioFile = new Mp3FileReader(path);
            var outputDevice = new WaveOutEvent();
            outputDevice.Init(audioFile);
            outputDevice.Play();

        }
    }

    internal struct TemplateDayException
    {
        public DateOnly date;
        public ScheduleTemplate template;
    }

    internal struct DayScheduleException
    {
        // DateOnly day; // Will be needed for future functionality
        TimeOnly time;
        string soundPath;

        public DayScheduleException(TimeOnly time, string soundPath)
        {
            this.time = time;
            this.soundPath = soundPath;
        }
    }
}
