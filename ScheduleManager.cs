using Microsoft.VisualBasic.ApplicationServices;
using Microsoft.VisualBasic.Devices;
using NAudio.Wave;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing.Drawing2D;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Xsl;

namespace CWOC_Audio_Scheduler
{
    internal class ScheduleManager
    {
        public List<ScheduleTemplate> templates;
        public List<ScheduleObject> todaysExceptions;
        public List<TemplateDayException> templateDayExceptions;
        public List<WorkerPair> backgroundWorkers;
        public BasicFunctionForm? parentForm = null;
        public ScheduleTemplate? todayTemplate;

        string logFilePath = "logfile.txt";
        StreamWriter? streamWriter;

        public ScheduleManager(BasicFunctionForm? form=null)
        {
            this.parentForm = form;
            WriteToLog("Begining Log File on " + DateTime.Now.ToString());
            templates = new List<ScheduleTemplate>();
            todaysExceptions = new List<ScheduleObject>();
            templateDayExceptions = new List<TemplateDayException>();
            backgroundWorkers = new List<WorkerPair>(); 
        }

        public void CreateNextDayEvents()
        {
            todaysExceptions = new List<ScheduleObject>();
            RefreshBackgroundWorkerList();

            DateOnly today = DateOnly.FromDateTime(DateTime.Now);

            for (int i = 0; i < templateDayExceptions.Count; i++)
            {
                if (templateDayExceptions[i].date == today)
                {
                    ScheduleTemplate template = templateDayExceptions[i].template;
                    CreateScheduleEvents(template);
                    CreateEndOfDayEvent();
                    return;
                }
            }

            for (int i = 0; i < templates.Count; i++)
            {
                if (templates[i].schedulesDay(today))
                {
                    ScheduleTemplate template = templates[i];
                    CreateScheduleEvents(template);
                    CreateEndOfDayEvent();
                    return;
                }
            }
        }

        private void CreateEndOfDayEvent()
        {
            BackgroundWorker nextDayWorker = new BackgroundWorker();
            nextDayWorker.DoWork += new DoWorkEventHandler(LoadNextDay);
            nextDayWorker.RunWorkerAsync(nextDayWorker);
        }

        private void CreateScheduleEvents(ScheduleTemplate template)
        {
            this.todayTemplate = template;
            WriteToLog("Creating events based on template: " + template.name);
            for (int j = 0; j < template.scheduleObjects.Count; j++)
            {
                TimeOnly eventTime = template.scheduleObjects[j].time;
                BackgroundWorker worker = new();
                worker.DoWork += new DoWorkEventHandler(WaitUntilEventTime);
                worker.WorkerSupportsCancellation = true;
                WorkerPair pair = new WorkerPair();
                pair.worker = worker;
                pair.scheduleObject = template.scheduleObjects[j];
                backgroundWorkers.Add(pair);
                if (worker != null)
                {
                    worker.RunWorkerAsync(pair);
                }
            }
            if (parentForm != null)
            {
                if (parentForm.InvokeRequired)
                {
                    parentForm.BeginInvoke((MethodInvoker)delegate
                    {
                        parentForm.updateTodayListBox();
                        parentForm.updateTodayLabels();
                    });
                } else
                {
                    parentForm.updateTodayListBox();
                    parentForm.updateTodayLabels();
                }
            }
        }

        public void appendTemplate(ScheduleTemplate template)
        {
            templates.Add(template);
        }

        private void WaitUntilEventTime(object sender, DoWorkEventArgs args)
        {
            WorkerPair pair = (WorkerPair) args.Argument;
            ScheduleObject scheduleObject = pair.scheduleObject;
            TimeSpan sleepTime = scheduleObject.time.ToTimeSpan() - DateTime.Now.TimeOfDay;
            if (pair.scheduleObject.nextDay)
            {
                sleepTime += new TimeSpan(days: 1, 0, 0, 0);
                WriteToLog("Scheduling next day event for: " + scheduleObject.path + " " + DateTime.Now.Add(sleepTime));
            }
            if (sleepTime.TotalMilliseconds > 0)
            {
                Thread.Sleep(sleepTime);
                if (!((BackgroundWorker) sender).CancellationPending)
                {
                    play_sound(scheduleObject.path);
                    WriteToLog(pair.scheduleObject.ToString() + "," + DateTime.Now.ToString());
                } else
                {
                    WriteToLog(pair.scheduleObject.ToString() + "," + DateTime.Now.ToString() + " ---DISABLED---");
                }
            }
        }

        public void CreateExceptionToday(ScheduleObject so)
        {

            todaysExceptions.Add(so);

            BackgroundWorker worker = new BackgroundWorker();
            worker.DoWork += new DoWorkEventHandler(WaitUntilEventTime);
            WorkerPair pair = new WorkerPair();
            worker.WorkerSupportsCancellation = true;
            pair.worker = worker;
            pair.scheduleObject = so;

            TimeSpan time = so.time.ToTimeSpan();
            if (so.nextDay)
            {
                time = time.Add(new TimeSpan(days: 1, 0, 0, 0));
            }

            TimeSpan compTime = new TimeSpan();
            if (backgroundWorkers.Count() > 0)
            {
                compTime = backgroundWorkers[0].scheduleObject.time.ToTimeSpan();
                if (backgroundWorkers[0].scheduleObject.nextDay)
                {
                    compTime = compTime.Add(new TimeSpan(1, 0, 0, 0));
                }
            }

            int index = 0;
            bool exit = false;
            while (!exit && backgroundWorkers.Count() > index)
            {
                compTime = backgroundWorkers[index].scheduleObject.time.ToTimeSpan();
                if (backgroundWorkers[index].scheduleObject.nextDay)
                {
                    compTime = compTime.Add(new TimeSpan(1, 0, 0, 0));
                }

                if (compTime < time)
                {
                    index++;
                } else
                {
                    exit = true;
                }
            }
            backgroundWorkers.Insert(index, pair);
            worker.RunWorkerAsync(pair);

            if (parentForm != null && parentForm.InvokeRequired)
            {
                parentForm.BeginInvoke((MethodInvoker)delegate {
                    parentForm.updateTodayLabels();
                });
            }
        }

        public void CreateTemplateDayException(ScheduleTemplate template, DateOnly day)
        {
            if (day == DateOnly.FromDateTime(DateTime.Now)) 
            {
                for (int i = 0; i < backgroundWorkers.Count; i++)
                {
                    killWorker(backgroundWorkers[i].scheduleObject);
                }
                CreateScheduleEvents(template);

            } else
            {
                TemplateDayException exception = new TemplateDayException();
                exception.template = template;
                exception.date = day;

                templateDayExceptions.Add(exception);
            }
        }

        public void killWorker(ScheduleObject scheduleObject)
        {
            for (int i = 0; i < backgroundWorkers.Count; i++)
            {
                ScheduleObject so = backgroundWorkers[i].scheduleObject;
                BackgroundWorker worker = backgroundWorkers[i].worker;
                if (so.time == scheduleObject.time && so.path == scheduleObject.path)
                {
                    worker.CancelAsync();
                    so.disabled = true;
                    WorkerPair newPair = new();
                    newPair.scheduleObject = so;
                    newPair.worker = worker;
                    backgroundWorkers[i] = newPair;
                }
            }
        }

        private void LoadNextDay(object sender, DoWorkEventArgs args)
        {
            TimeSpan sleepTime = (new TimeSpan(23, 59, 59) - DateTime.Now.TimeOfDay) + new TimeSpan(0, 0, 1);
            Thread.Sleep(sleepTime);
            this.CreateNextDayEvents();
            WriteToLog("New Day Loaded " + DateTime.Now);
        }

        private void play_sound(string path)
        {
            var audioFile = new Mp3FileReader(path);
            var outputDevice = new WaveOutEvent();
            outputDevice.Init(audioFile);
            outputDevice.Play();

            if (parentForm != null && parentForm.InvokeRequired)
            {
                parentForm.BeginInvoke((MethodInvoker) delegate {
                    parentForm.updateTodayLabels();
                });
            }
        }

        private void WriteToLog(string str)
        {
            string logFileFullPath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData), logFilePath);
            logFileFullPath = Path.Combine(Directory.GetParent(Environment.CurrentDirectory).Parent.Parent.FullName, logFilePath);

            if (!File.Exists(logFileFullPath))
            {
                streamWriter = new StreamWriter(logFileFullPath);
            } else
            {
                streamWriter = new StreamWriter(logFileFullPath, true);
            }
            streamWriter.WriteLine(str);
            streamWriter.Close();
        }

        public ScheduleTemplate GetTemplateForDay(DateOnly day)
        {
            for (int i = 0; i < templateDayExceptions.Count; i++)
            {
                if (templateDayExceptions[i].date.Equals(day))
                {
                    return templateDayExceptions[i].template;
                }
            }

            for (int i = 0; i < templates.Count; i++)
            {
                if (templates[i].schedulesDay(day))
                {
                    return templates[i];
                }
            }
            return templates.Last();
        }

        public void RefreshBackgroundWorkerList()
        {
            List<WorkerPair> outList = new List<WorkerPair>();

            for (int i = 0; i < backgroundWorkers.Count; i++)
            {
                if (backgroundWorkers[i].scheduleObject.nextDay)
                {
                    ScheduleObject newObj = backgroundWorkers[i].scheduleObject;
                    newObj.nextDay = false;
                    newObj.scheduled = true;
                    BackgroundWorker newWorker = backgroundWorkers[i].worker;

                    WorkerPair newPair = new WorkerPair();
                    newPair.scheduleObject = newObj;
                    newPair.worker = newWorker;

                    TimeOnly time = newObj.time;

                    int index = 0;
                    while(index < outList.Count && outList[index].scheduleObject.time < time)
                    {
                        index++;
                    }
                    MessageBox.Show(newObj.ToString() + " " + index);
                    outList.Insert(index, newPair);
                }
            }
            backgroundWorkers = outList;
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
        ScheduleObject scheduleObject;

        public DayScheduleException(TimeOnly time, string soundPath)
        {
            scheduleObject = new ScheduleObject(soundPath, time);
        }
    }

    internal struct WorkerPair
    {
        public WorkerPair()
        {
            worker = new BackgroundWorker();
            scheduleObject = new();
        }
        public BackgroundWorker worker;
        public ScheduleObject scheduleObject;
    }
}
