using DevExpress.Xpf.Scheduler;
using DevExpress.XtraScheduler.Services;
using System;
using System.Windows;

namespace DXSample {
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window {
        public MainWindow() {
            InitializeComponent();

            // Substitute the service to change DateTime format strings for the TimeRuler.
            #region #replaceservice
            ITimeRulerFormatStringService svc = scheduler.GetService<ITimeRulerFormatStringService>();
            scheduler.ReplaceService<ITimeRulerFormatStringService>(new MyTimeRulerFormatStringService(svc));
            #endregion #replaceservice

            // Add a new TimeRuler with the specified TimeZone.
            #region #newtimeruler
            SchedulerTimeRuler rulerUTC = new SchedulerTimeRuler();
            rulerUTC.TimeZoneId = TimeZoneInfo.Utc.Id;
            rulerUTC.Caption = "UTC";
            rulerUTC.ShowCurrentTime = DevExpress.XtraScheduler.CurrentTimeVisibility.Never;
            scheduler.DayView.TimeRulers.Add(rulerUTC);
            #endregion #newtimeruler

            SchedulerTimeRuler rulerLocal = new SchedulerTimeRuler();
            rulerLocal.UseClientTimeZone = true;
            rulerLocal.Caption = "Local";
            scheduler.DayView.TimeRulers.Add(rulerLocal);

            #region #timeslots
            // Add 20-minute time slots to the view.
            scheduler.DayView.TimeSlots.AddRange(scheduler.DayView.DefaultTimeSlots);
            scheduler.DayView.TimeSlots.Add(new DevExpress.XtraScheduler.TimeSlot(new TimeSpan(0, 20, 0), "20 minutes"));
            #endregion #timeslots

        }
    }
}
