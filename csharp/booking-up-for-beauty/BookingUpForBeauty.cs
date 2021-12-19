using System;

static class Appointment
{
    public static DateTime Schedule(string appointmentDateDescription)
    {
        DateTime date = DateTime.Parse(appointmentDateDescription);
        return date;
    }

    public static bool HasPassed(DateTime appointmentDate)
    {
        DateTime today = DateTime.Now;
        return  today > appointmentDate;
    }

    public static bool IsAfternoonAppointment(DateTime appointmentDate)
    {
        int appointmentHour = appointmentDate.Hour;
        return appointmentHour >= 12 && appointmentHour < 18;
    }

    public static string Description(DateTime appointmentDate)
    {
        string datestring = appointmentDate.ToShortDateString();
        string timestring = appointmentDate.ToLongTimeString();
        return $"You have an appointment on {datestring} {timestring}.";
    }

    public static DateTime AnniversaryDate()
    {
        int currentyear = DateTime.Now.Year;
        return new DateTime(currentyear, 9, 15, 0, 0, 0);
    }
}
