using RevFIT.Context.Models;

namespace RevFIT.Services.ViewModels;

public class WodBuilderViewModel
{
    public string Message { get; set; } = string.Empty;
    public bool Success { get; set; } 
    public List<ScoreCalculationType> ScoreCalculationTypes { get; set; } = new List<ScoreCalculationType>();
    public List<ScoreMeasureType> ScoreMeasureTypes { get; set; } = new List<ScoreMeasureType>();
    public List<ScoreOrderType> ScoreOrderTypes { get; set; } = new List<ScoreOrderType>();
}