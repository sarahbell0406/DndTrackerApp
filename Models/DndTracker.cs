using System.ComponentModel.DataAnnotations;
using System.ComponentModel;

namespace DndTrackerApp.Models;

public class DndTracker
{
    public Guid Id { get; set; }

    [Required(ErrorMessage = "Please enter a character name.")]
    [DisplayName("Character Name")]
    public string? CharacterName { get; set; }

    [Required(ErrorMessage = "Please enter a character class.")]
    [DisplayName("Character Class")]
    public string? CharacterClass { get; set; }

    [Required(ErrorMessage = "Please enter a character level.")]
    [DisplayName("Character Level")]
    public int CharacterLevel { get; set; }

    [DisplayName("Current XP")]
    public int CurrentXp { get; set; }

    [DisplayName("Active Campaign")]
    public bool ActiveCampaign { get; set; }

    [DisplayName("First Session")]
    public DateTime SessionOneDate { get; set; }

    [DisplayName("Last Session")]
    public DateTime LastSessionDate { get; set; }

    /*
    Possible additions: HeroForge link, character sheet (link or PDF?), image, etc.
    */

    public DateTime CreatedAt { get; set; } = DateTime.Now;
    public DateTime UpdatedAt { get; set; } = DateTime.Now;

}