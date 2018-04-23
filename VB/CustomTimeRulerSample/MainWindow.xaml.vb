Imports DevExpress.Xpf.Scheduler
Imports DevExpress.XtraScheduler.Services
Imports System
Imports System.Collections.Generic
Imports System.Linq
Imports System.Text
Imports System.Threading.Tasks
Imports System.Windows
Imports System.Windows.Controls
Imports System.Windows.Data
Imports System.Windows.Documents
Imports System.Windows.Input
Imports System.Windows.Media
Imports System.Windows.Media.Imaging
Imports System.Windows.Navigation
Imports System.Windows.Shapes

Namespace DXSample
    ''' <summary>
    ''' Interaction logic for MainWindow.xaml
    ''' </summary>
    Partial Public Class MainWindow
        Inherits Window

        Public Sub New()
            InitializeComponent()

            ' Add a new TimeRuler with the specified TimeZone.
'            #Region "#newtimeruler"
            Dim rulerUTC As New SchedulerTimeRuler()
            rulerUTC.TimeZoneId = TimeZoneInfo.Utc.Id
            rulerUTC.Caption = "UTC"
            rulerUTC.ShowCurrentTime = False
            scheduler.DayView.TimeRulers.Add(rulerUTC)
'            #End Region ' #newtimeruler

            Dim rulerRussian As New SchedulerTimeRuler()
            rulerRussian.UseClientTimeZone = True
            rulerRussian.Caption = "Local"
            scheduler.DayView.TimeRulers.Add(rulerRussian)

            ' Change DateTime format strings for the TimeRuler.
'            #Region "#replaceservice"
            Dim svc As ITimeRulerFormatStringService = scheduler.GetService(Of ITimeRulerFormatStringService)()
            scheduler.RemoveService(GetType(ITimeRulerFormatStringService))
            scheduler.AddService(GetType(ITimeRulerFormatStringService), New MyTimeRulerFormatStringService(svc))
'            #End Region ' #replaceservice

'            #Region "#timeslots"
            scheduler.DayView.TimeSlots.AddRange(scheduler.DayView.DefaultTimeSlots)
            scheduler.DayView.TimeSlots.Add(New DevExpress.XtraScheduler.TimeSlot(New TimeSpan(0, 20, 0), "20 minutes"))
'            #End Region ' #timeslots
        End Sub
    End Class
End Namespace
