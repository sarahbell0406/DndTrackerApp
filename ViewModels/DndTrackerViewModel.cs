using System.ComponentModel.DataAnnotations;
using System.ComponentModel;
using Microsoft.AspNetCore.Mvc;
using DndTrackerApp.Models;

namespace DndTrackerApp.ViewModels;

public class DndTrackerViewModel
{
    [HiddenInput]
    public Guid Id { get; set; }

    [Required(ErrorMessage = "Please enter a character name.")]
    [DisplayName("Name")]
    public required string CharacterName { get; set; }

    [Required(ErrorMessage = "Please enter a character class.")]
    [DisplayName("Class")]
    public required string CharacterClass { get; set; }

    [DisplayName("Level")]
    public int? CharacterLevel { get; set; }

    [DisplayName("Current XP")]
    public int? CurrentXp { get; set; }

    [DisplayName("Active Campaign?")]
    public bool ActiveCampaign { get; set; }

    [DisplayName("First Session")]
    public string? SessionOneDate { get; set; }

    [DisplayName("Latest Session")]
    public string? LastSessionDate { get; set; }

    public DateTime CreatedAt { get; set; } = DateTime.Now;
    public DateTime UpdatedAt { get; set; } = DateTime.Now;


    public static DndTrackerViewModel ConvertToViewModel(DndTracker dndTracker)
    {
        return new DndTrackerViewModel
        {
            Id = dndTracker.Id,
            CharacterName = dndTracker.CharacterName,
            CharacterClass = dndTracker.CharacterClass,
            CharacterLevel = dndTracker.CharacterLevel,
            CurrentXp = dndTracker.CurrentXp,
            ActiveCampaign = dndTracker.ActiveCampaign,
            SessionOneDate = dndTracker.SessionOneDate?.ToString("yyyy-MM-dd"),
            LastSessionDate = dndTracker.LastSessionDate?.ToString("yyyy-MM-dd"),
            CreatedAt = dndTracker.CreatedAt,
            UpdatedAt = dndTracker.UpdatedAt
        };
    }

    public static DndTracker ConvertToModel(DndTrackerViewModel viewModel)
    {
        return new DndTracker
        {
            Id = viewModel.Id,
            CharacterName = viewModel.CharacterName,
            CharacterClass = viewModel.CharacterClass,
            CharacterLevel = viewModel.CharacterLevel,
            CurrentXp = viewModel.CurrentXp,
            ActiveCampaign = viewModel.ActiveCampaign,
            SessionOneDate = viewModel.SessionOneDate != null ? DateTime.Parse(viewModel.SessionOneDate) : (DateTime?)null,
            LastSessionDate = viewModel.LastSessionDate != null ? DateTime.Parse(viewModel.LastSessionDate) : (DateTime?)null,
            CreatedAt = viewModel.CreatedAt,
            UpdatedAt = viewModel.UpdatedAt
        };
    }
}