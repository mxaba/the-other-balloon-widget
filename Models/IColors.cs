using System;

namespace the_other_balloon_widget.Models
{
    public interface IColors
    {
        string Id { get; set; }
        string Name { get; set; }
        int Counter { get; set; }
        string Type { get; set; }
        DateTime Timestamp { get; set; }
    }
}
