using EventManagementApp.Models;

namespace EventManagementApp.Services;

public class EventState
{
    public List<EventItem> Events { get; } = new()
    {
        new EventItem
        {
            Id = 1,
            Title = "Blazor Web Development",
            Location = "Room A",
            Date = DateTime.Now.AddDays(7),
            Capacity = 30
        },
        new EventItem
        {
            Id = 2,
            Title = "Object-Oriented Programming",
            Location = "Room B",
            Date = DateTime.Now.AddDays(14),
            Capacity = 40
        },
        new EventItem
        {
            Id = 3,
            Title = "Cloud Computing Workshop",
            Location = "Online",
            Date = DateTime.Now.AddDays(21),
            Capacity = 50
        }
    };

    public EventItem? GetEvent(int id)
    {
        return Events.FirstOrDefault(e => e.Id == id);
    }

    public bool Register(int eventId, string email)
    {
        var selectedEvent = GetEvent(eventId);

        if (selectedEvent == null)
            return false;

        if (selectedEvent.Attendees.Count >= selectedEvent.Capacity)
            return false;

        if (selectedEvent.Attendees.Any(
            x => x.Equals(email, StringComparison.OrdinalIgnoreCase)))
            return false;

        selectedEvent.Attendees.Add(email);

        return true;
    }
}