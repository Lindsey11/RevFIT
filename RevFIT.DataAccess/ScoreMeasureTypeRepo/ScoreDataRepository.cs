using Microsoft.EntityFrameworkCore;
using RevFIT.Context.Context;
using RevFIT.Context.Models;

namespace RevFIT.DataAccess.ScoreMeasureTypeRepo;

public class ScoreDataRepository : IScoreDataRepository
{
    private readonly DataContext _dataContext;
    
    public ScoreDataRepository(DataContext dataContext)
    {
        _dataContext = dataContext;
    }
    
    public async Task<List<ScoreMeasureType>> GetScoreMeasureTypes()
    {
        var measureTypes = await _dataContext.ScoreMeasureTypes.ToListAsync();
        return measureTypes;
    }

    public async Task<List<ScoreCalculationType>> GetScoreCalculationsTypes()
    {
        var calucTypes = await _dataContext.ScoreCalculationTypes.ToListAsync();
        return calucTypes;
    }

    public async Task<List<ScoreOrderType>> GetScoreOrderTypes()
    {
        var orderTypes = await _dataContext.ScoreOrderTypes.ToListAsync();
        return orderTypes;
    }
}