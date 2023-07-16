using RevFIT.Context.Models;
using RevFIT.DataAccess.WorkoutRepo;
using RevFIT.Services.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RevFIT.DataAccess.ScoreMeasureTypeRepo;

namespace RevFIT.Services.WorkoutServices
{
    public class WorkoutService : IWorkoutService
    {
        private readonly IWODRepository _workoutRepository;
        private readonly IScoreDataRepository _scoreDataRepository;
        public WorkoutService(IWODRepository workoutRepository, IScoreDataRepository scoreDataRepository)
        {
            _workoutRepository = workoutRepository;
            _scoreDataRepository = scoreDataRepository;
        }

        public async Task<ServiceResponseModel<List<Wod>>> GetTodaysWorkout(int programID, DateTime workoutDate)
        {
            try
            {
                var workout = await _workoutRepository.GetWorkoutByProgramAndDateAsync(programID, workoutDate);
                if (workout == null)
                {
                    return new() { Data = null, IsSuccess = false, Message = "No workout found for today." };
                }

                return new() { Data = workout, IsSuccess = true, Message = "Workout found." };
            }
            catch (Exception error)
            {
                return new() { Data = null, IsSuccess = false, Message = $"Error getting today's workout. {error.Message}" };
            }
        }

        public async Task<ServiceResponseModel<int>> AddMainWorkout(WorkoutAddRequestModel model)
        {
            try
            {
                var workoutToAdd = new Wod()
                {
                    WorkoutName = model.WorkoutName,
                    WorkoutDefinition = model.WorkoutDefinition,
                    ScheduleDate = model.ScheduleDate,
                    ProgramId = model.ProgramId,
                    DateCreated = DateTime.Now,
                    IsLive = model.IsLive,
                    ScoreType = model.ScoreType
                };

                var addResult = await _workoutRepository.AddWorkoutAsync(workoutToAdd);

                if(addResult == 0)
                    return new() { IsSuccess = false, Message = $"Workout could not be added" };


                var newsScore = new WorkoutScore()
                {
                    WorkoutId = addResult,
                    MeasureTypeId = model.MeasureTypeID,
                    ScoreCalculationTypeId = model.CalcTypeID,
                    ScoreOrderId = model.OrderTypeID,
                    Sets = model.set
                };

                var addScoreResult = await _workoutRepository.AddWorkoutScroreingType(newsScore);

                if(addScoreResult == 0)
                    return new() { IsSuccess = false, Message = $"Score could not be added" };


                return new() { Data = addResult, IsSuccess = true, Message = "Workout added" };
            }
            catch (Exception error)
            {

                return new() { IsSuccess = false, Message = $"Error adding workout. {error.Message}" };
            }
        }

        public async Task<WodBuilderViewModel> GetWodBuilderPageData()
        {
            try
            {
                var orders = await _scoreDataRepository.GetScoreOrderTypes();
                var measures = await _scoreDataRepository.GetScoreMeasureTypes();
                var calcTypes = await _scoreDataRepository.GetScoreCalculationsTypes();

                var wodBuilderModel = new WodBuilderViewModel()
                {
                    ScoreCalculationTypes = calcTypes,
                    ScoreOrderTypes = orders,
                    ScoreMeasureTypes = measures,
                    Message = "Retrieved Scoring data",
                    Success = true
                };

                return wodBuilderModel;

            }
            catch (Exception error)
            {
                return new() { Success = false, Message = $"Error adding workout. {error.Message}" };
            }
        }
    }
}
