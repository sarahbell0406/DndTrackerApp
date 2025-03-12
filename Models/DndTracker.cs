using System.ComponentModel.DataAnnotations;
using System.ComponentModel;

namespace DndTrackerApp.Models;

public class DndTracker
{
    public Guid Id { get; set; }
    public required string CharacterName { get; set; }
    public required string CharacterClass { get; set; }
    public int? CharacterLevel { get; set; }
    public int? CurrentXp { get; set; }
    public bool ActiveCampaign { get; set; }
    public DateTime? SessionOneDate { get; set; }
    public DateTime? LastSessionDate { get; set; }
    public DateTime CreatedAt { get; set; }
    public DateTime UpdatedAt { get; set; }

    /*
    Possible additions: HeroForge link, character sheet (link or PDF?), image, etc.
    */
}