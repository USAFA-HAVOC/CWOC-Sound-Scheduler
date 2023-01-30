using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.Json;

namespace CWOC_Audio_Scheduler
{
    internal static class ScheduleTemplateSerializer
    {
        public static string SerializeJson(this ScheduleTemplate st)
        {
            return JsonSerializer.Serialize(st);
        }
        public static ScheduleTemplate DeserializeJson(string serialized)
        {
            var st = JsonSerializer.Deserialize<ScheduleTemplate>(serialized);
            if (st == null)
            {
                throw new System.Exception("This bad. Fix it");
            }
            return st;
        }
    }
}
