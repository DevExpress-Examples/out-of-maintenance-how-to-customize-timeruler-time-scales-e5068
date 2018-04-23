using DevExpress.XtraScheduler;
using DevExpress.XtraScheduler.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DXSample
{
#region #myservice    
public class MyTimeRulerFormatStringService : TimeRulerFormatStringServiceWrapper
    {
        public MyTimeRulerFormatStringService(ITimeRulerFormatStringService service)
            : base(service)
        {
        }
        public override string GetHalfDayHourFormat(TimeRuler ruler)
        {
            return ruler.UseClientTimeZone ? "htt" : "HH:mm";
        }
        public override string GetHourFormat(TimeRuler ruler)
        {
            return ruler.UseClientTimeZone ? "htt" : "HH:mm";
        }
        public override string GetHourOnlyFormat(TimeRuler ruler)
        {
            return ruler.UseClientTimeZone ? "htt" : "HH";
        }
        public override string GetMinutesOnlyFormat(TimeRuler ruler)
        {
            return ruler.UseClientTimeZone ? "''" : "mm";
        }
        public override string GetTimeDesignatorOnlyFormat(TimeRuler ruler)
        {
            return ruler.UseClientTimeZone ? "''" : "mm";
        }
    }
#endregion #myservice
}
