Imports DevExpress.Xpf.Scheduler
Imports DevExpress.XtraScheduler.Services
Imports System
Imports System.Windows

Namespace DXSample
    ''' <summary>
    ''' Interaction logic for MainWindow.xaml
    ''' </summary>
    Partial Public Class MainWindow
        Inherits Window

        Public Sub New()
            InitializeComponent()

            ' Substitute the service to change DateTime format strings for the TimeRuler.
'            #Region "#replaceservice"
            Dim svc As ITimeRulerFormatStringService = scheduler.GetService(Of ITimeRulerFormatStringService)()
            scheduler.ReplaceService(Of ITimeRulerFormatStringService)(New MyTimeRulerFormatStringService(svc))
'            #End Region ' #replaceservice

            ' Add a new TimeRuler with the specified TimeZone.
'            #Region "#newtimeruler"
            Dim rulerUTC As New SchedulerTimeRuler()
            rulerUTC.TimeZoneId = TimeZoneInfo.Utc.Id
            rulerUTC.Caption = "UTC"
            rulerUTC.ShowCurrentTime = DevExpress.XtraScheduler.CurrentTimeVisibility.Never
            scheduler.DayView.TimeRulers.Add(rulerUTC)
'            #End Region ' #newtimeruler

            Dim rulerLocal As New SchedulerTimeRuler()
            rulerLocal.UseClientTimeZone = True
            rulerLocal.Caption = "Local"
            scheduler.DayView.TimeRulers.Add(rulerLocal)

'            #Region "#timeslots"
            ' Add 20-minute time slots to the view.
            scheduler.DayView.TimeSlots.AddRange(scheduler.DayView.DefaultTimeSlots)
            scheduler.DayView.TimeSlots.Add(New DevExpress.XtraScheduler.TimeSlot(New TimeSpan(0, 20, 0), "20 minutes"))
'            #End Region ' #timeslots

        End Sub
    End Class
End Namespace
