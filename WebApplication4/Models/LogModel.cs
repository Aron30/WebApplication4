using System;

public class LogModel
{
    [Required]
    public int Id { get; set; }

    [Required]
    public DateTime DateTime { get; set; }

    [Required]
    [Range (0.01, 1000.00)]
    public double Distance { get; set; }

    [Required]
    public TimeSpan Time { get; set; }

    public string ShortDate
    {
        get
        {
            return RunDate.ToLocalTime().ToShortDateString();
        }
    }
}
