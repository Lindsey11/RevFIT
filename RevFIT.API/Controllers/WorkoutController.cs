using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using RevFIT.Context.Models;
using RevFIT.Services.ViewModels;
using RevFIT.Services.WorkoutServices;

namespace RevFIT.API.Controllers
{
    [Route("workout")]
    [ApiController]
    public class WorkoutController : ControllerBase
    {
        private readonly IWorkoutService _workoutService;
        public WorkoutController(IWorkoutService workoutService)
        {
            _workoutService = workoutService;
        }

        [HttpGet("todays-workout")]
        [ProducesResponseType(typeof(ServiceResponseModel<List<Wod>>), 200)]
        public async Task<IActionResult> GetTodaysWorkouts(int progrogramID, DateTime dateTime)
        {
            return Ok(await _workoutService.GetTodaysWorkout(progrogramID, dateTime));
        }

        [HttpPost("add-workout")]
        [ProducesResponseType(typeof(ServiceResponseModel<int>),200)]
        public async Task<IActionResult> AddMainWorkout([FromBody] WorkoutAddRequestModel workoutAddRequestModel)
        {
            return Ok(await _workoutService.AddMainWorkout(workoutAddRequestModel));
        }
    }
}
