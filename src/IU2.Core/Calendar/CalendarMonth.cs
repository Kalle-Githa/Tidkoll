namespace IU2.Core.Calendar;

/// <summary>
/// Bygger upp rutnätet för en månadskalender med måndag som första veckodag.
/// Tomma rutor (före den 1:a och efter sista dagen) representeras av null.
/// </summary>
public static class CalendarMonth
{
    public static IReadOnlyList<DateTime?> BuildGrid(int year, int month)
    {
        var firstDay = new DateTime(year, month, 1);
        var daysInMonth = DateTime.DaysInMonth(year, month);

        var leadingBlanks = GetLeadingBlanks(firstDay);

        var cells = new List<DateTime?>();

        for (var i = 0; i < leadingBlanks; i++)
        {
            cells.Add(null);
        }

        for (var day = 1; day <= daysInMonth; day++)
        {
            cells.Add(new DateTime(year, month, day));
        }

        while (cells.Count % 7 != 0)
        {
            cells.Add(null);
        }

        return cells;
    }

    /// <summary>
    /// Antal tomma rutor före den 1:a så att måndag hamnar i första kolumnen.
    /// </summary>
    public static int GetLeadingBlanks(DateTime firstDay)
    {

        switch (firstDay.DayOfWeek)
        {
            case DayOfWeek.Monday:
                return 0;
            case DayOfWeek.Tuesday:
                return 1;
            case DayOfWeek.Wednesday:
                return 2;
            case DayOfWeek.Thursday:
                return 3;
            case DayOfWeek.Friday:
                return 4;
            case DayOfWeek.Saturday:
                return 5;
            case DayOfWeek.Sunday:
                return 6;
            default:
                throw new ArgumentOutOfRangeException();
        }



    }
}
