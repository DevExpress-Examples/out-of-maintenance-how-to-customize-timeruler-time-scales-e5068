Imports DevExpress.Xpf.Scheduler
Imports DevExpress.XtraScheduler.Services
Imports System
Imports System.Windows

Namespace DXSample

    ''' <summary>
    ''' Interaction logic for MainWindow.xaml
    ''' </summary>
    Public Partial Class MainWindow
        Inherits Window

        Public Sub New()
            Me.InitializeComponent()
            ' Substitute the service to change DateTime format strings for the TimeRuler.
'#Region "#replaceservice"
            Dim svc As ITimeRulerFormatStringService = Me.scheduler.GetService(Of ITimeRulerFormatStringService)()
            Me.scheduler.ReplaceService(Of ITimeRulerFormatStringService)(New MyTimeRulerFormatStringService(svc))
'#End Region  ' #replaceservice
            ' Add a new TimeRuler with the specified TimeZone.
'#Region "#newtimeruler"
            Dim rulerUTC As SchedulerTimeRuler = New SchedulerTimeRuler()
            rulerUTC.TimeZoneId = TimeZoneInfo.Utc.Id
            rulerUTC.Caption = "UTC"
            rulerUTC.TimeMarkerVisibility = DevExpress.XtraScheduler.TimeMarkerVisibility.Never
            Me.scheduler.DayView.TimeRulers.Add(rulerUTC)
'#End Region  ' #newtimeruler
            Dim rulerLocal As SchedulerTimeRuler = New SchedulerTimeRuler()
            rulerLocal.UseClientTimeZone = True
            rulerLocal.Caption = "Local"
            Me.scheduler.DayView.TimeRulers.Add(rulerLocal)
'#Region "#timeslots"
            ' Add 20-minute time slots to the view.
            Me.scheduler.DayView.TimeSlots.AddRange(Me.scheduler.DayView.DefaultTimeSlots)
            Me.scheduler.DayView.TimeSlots.Add(New DevExpress.XtraScheduler.TimeSlot(New TimeSpan(0, 20, 0), "20 minutes"))
'#End Region  ' #timeslots
        End Sub
    End Class
End Namespace
