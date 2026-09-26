using IU2.Core.Calendar;
using Xunit;

namespace IU2.Core.Tests;

public class CalendarMonthTests
{
    [Fact]
    public void September_2026_borjar_pa_tisdag_med_en_tom_ruta()
    {
        var grid = CalendarMonth.BuildGrid(2026, 9);

        Assert.Null(grid[0]);
        Assert.Equal(new DateTime(2026, 9, 1), grid[1]);
    }

    [Fact]
    public void Mars_2026_borjar_pa_sondag_med_sex_tomma_rutor()
    {
        var grid = CalendarMonth.BuildGrid(2026, 3);

        Assert.All(grid.Take(6), cell => Assert.Null(cell));
        Assert.Equal(new DateTime(2026, 3, 1), grid[6]);
    }

    [Fact]
    public void Juni_2026_borjar_pa_mandag_utan_tomma_rutor()
    {
        var grid = CalendarMonth.BuildGrid(2026, 6);

        Assert.Equal(new DateTime(2026, 6, 1), grid[0]);
    }

    [Fact]
    public void Kalendern_visar_mars_nar_klockan_sager_mars()
    {
        // Arrange: låtsas att det är 15 mars 2026
        IClock klocka = new FakeClock(new DateTimeOffset(2026, 3, 15, 9, 0, 0, TimeSpan.FromHours(1)));

        // Act: gör som Calendar.razor gör
        var today = klocka.Now.Date;
        var grid = CalendarMonth.BuildGrid(today.Year, today.Month);

        // Assert
        Assert.Equal(31, grid.Count(d => d is not null));      // mars har 31 dagar
        Assert.Equal(new DateTime(2026, 3, 1), grid[6]);       // 1:a mars under SÖN
    }





    [Theory]
    [InlineData(2026, 2, 28)]
    [InlineData(2026, 9, 30)]
    [InlineData(2028, 2, 29)]
    public void Rutnatet_innehaller_alla_dagar_och_hela_veckor(int year, int month, int expectedDays)
    {
        var grid = CalendarMonth.BuildGrid(year, month);

        Assert.Equal(0, grid.Count % 7);
        Assert.Equal(expectedDays, grid.Count(cell => cell is not null));
    }
}
