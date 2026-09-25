namespace IU2.Core.models;

public class TimeReport
{   
    public required int Id { get; set; }
    public required string Kund { get; set; } = string.Empty;
    public required DateOnly Datum { get; set; }
    public required decimal Timmar { get; set; }
    public string? Beskrivning { get; set; }
}
