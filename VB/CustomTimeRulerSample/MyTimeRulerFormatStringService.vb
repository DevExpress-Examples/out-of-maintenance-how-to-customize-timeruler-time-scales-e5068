Imports DevExpress.XtraScheduler
Imports DevExpress.XtraScheduler.Services

Namespace DXSample

'#Region "#myservice    "
    Public Class MyTimeRulerFormatStringService
        Inherits TimeRulerFormatStringServiceWrapper

        Public Sub New(ByVal service As ITimeRulerFormatStringService)
            MyBase.New(service)
        End Sub

        Public Overrides Function GetHalfDayHourFormat(ByVal ruler As TimeRuler) As String
            Return If(ruler.UseClientTimeZone, "htt", "HH:mm")
        End Function

        Public Overrides Function GetHourFormat(ByVal ruler As TimeRuler) As String
            Return If(ruler.UseClientTimeZone, "htt", "HH:mm")
        End Function

        Public Overrides Function GetHourOnlyFormat(ByVal ruler As TimeRuler) As String
            Return If(ruler.UseClientTimeZone, "htt", "HH")
        End Function

        Public Overrides Function GetMinutesOnlyFormat(ByVal ruler As TimeRuler) As String
            Return If(ruler.UseClientTimeZone, "''", "mm")
        End Function

        Public Overrides Function GetTimeDesignatorOnlyFormat(ByVal ruler As TimeRuler) As String
            Return If(ruler.UseClientTimeZone, "''", "mm")
        End Function
    End Class
'#End Region  ' #myservice
End Namespace
