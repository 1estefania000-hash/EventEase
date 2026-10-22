namespace EventEase.Services;

public static class EventCatalog
{
    public static IReadOnlyList<EventItem> Events { get; } =
    [
        new(1, "Auckland Music Festival", "20 October 2026", "Auckland",
            "Join us for an exciting day of music and entertainment."),
        new(2, "Corporate Networking Night", "25 October 2026", "Wellington",
            "Connect with other professionals at our networking night."),
        new(3, "Summer Charity Ball", "5 November 2026", "Christchurch",
            "Enjoy an evening together in support of charity.")
    ];

    public static EventItem? Find(int? id) => Events.FirstOrDefault(item => item.Id == id);
}

public sealed record EventItem(int Id, string Name, string Date, string Location, string Description);