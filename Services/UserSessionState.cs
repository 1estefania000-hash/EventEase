namespace EventEase.Services;

// Scoped to one interactive server circuit, not shared between visitors.
public sealed class UserSessionState
{
    public Guid SessionId { get; } = Guid.NewGuid();
    public string Name { get; private set; } = "";
    public string Email { get; private set; } = "";

    private readonly List<AttendanceEntry> registrations = [];
    public IReadOnlyList<AttendanceEntry> Registrations => registrations;

    public void Register(string name, string email, string eventName)
    {
        ArgumentException.ThrowIfNullOrWhiteSpace(name);
        ArgumentException.ThrowIfNullOrWhiteSpace(email);
        ArgumentException.ThrowIfNullOrWhiteSpace(eventName);

        Name = name.Trim();
        Email = email.Trim();

        if (!registrations.Any(entry => entry.EventName == eventName))
        {
            registrations.Add(new AttendanceEntry { EventName = eventName });
        }
    }
}

public sealed class AttendanceEntry
{
    public required string EventName { get; init; }
    public bool Attended { get; set; }
}