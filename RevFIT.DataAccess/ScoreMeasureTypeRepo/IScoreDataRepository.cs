using RevFIT.Context.Models;

namespace RevFIT.DataAccess.ScoreMeasureTypeRepo;

public interface IScoreDataRepository
{
    Task<List<ScoreMeasureType>> GetScoreMeasureTypes();
    Task<List<ScoreOrderType>> GetScoreOrderTypes();
    Task<List<ScoreCalculationType>> GetScoreCalculationsTypes();
}