using System.ComponentModel.DataAnnotations;

namespace EventManagementApp.Models;

public class EventItem
{
    public int Id { get; set; }

    [Required(ErrorMessage = "Event title is required.")]
    public string Title { get; set; } = string.Empty;

    [Required(ErrorMessage = "Location is required.")]
    public string Location { get; set; } = string.Empty;

    [Required(ErrorMessage = "Event date is required.")]
    public DateTime Date { get; set; } = DateTime.Now.AddDays(7);

    [Range(1, 1000, ErrorMessage = "Capacity must be between 1 and 1000.")]
    public int Capacity { get; set; } = 50;

    public List<string> Attendees { get; set; } = new();
}