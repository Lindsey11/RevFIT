﻿using Microsoft.AspNetCore.Http;
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
        [ProducesResponseType(typeof(ServiceResponseModel<Workout>),200)]
        public async Task<IActionResult> GetTodaysWorkouts(int progrogramID, DateTime dateTime)
        {
            return Ok(await _workoutService.GetTodaysWorkout(progrogramID, DateTime.Now));
        }
    }
}