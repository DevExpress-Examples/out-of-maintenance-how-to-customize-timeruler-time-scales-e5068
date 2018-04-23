using DevExpress.Xpf.Scheduler;
using DevExpress.XtraScheduler.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace DXSample {
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window {
        public MainWindow() {
            InitializeComponent();

            // Add a new TimeRuler with the specified TimeZone.
            #region #newtimeruler
            SchedulerTimeRuler rulerUTC = new SchedulerTimeRuler();
            rulerUTC.TimeZone.Id = DevExpress.XtraScheduler.TimeZoneId.UTC;
            rulerUTC.Caption = "UTC";
            rulerUTC.ShowCurrentTime = false;
            scheduler.DayView.TimeRulers.Add(rulerUTC);
            #endregion #newtimeruler

            SchedulerTimeRuler rulerRussian = new SchedulerTimeRuler();
            rulerRussian.UseClientTimeZone = true;
            rulerRussian.Caption = "Local";
            scheduler.DayView.TimeRulers.Add(rulerRussian);

            // Change DateTime format strings for the TimeRuler.
            #region #replaceservice
            ITimeRulerFormatStringService svc = scheduler.GetService<ITimeRulerFormatStringService>();
            scheduler.RemoveService(typeof(ITimeRulerFormatStringService));
            scheduler.AddService(typeof(ITimeRulerFormatStringService), new MyTimeRulerFormatStringService(svc));
            #endregion #replaceservice

            #region #timeslots
            scheduler.DayView.TimeSlots.AddRange(scheduler.DayView.DefaultTimeSlots);
            scheduler.DayView.TimeSlots.Add(new DevExpress.XtraScheduler.TimeSlot(new TimeSpan(0, 20, 0), "20 minutes"));
            #endregion #timeslots
        }
    }
}
