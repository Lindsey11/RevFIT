﻿using RevFIT.Context.Models;
using RevFIT.Services.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RevFIT.Services.WorkoutServices
{
    public interface IWorkoutService
    {
        Task<ServiceResponseModel<List<Wod>>> GetTodaysWorkout(int programID, DateTime workoutDate);
        Task<ServiceResponseModel<int>> AddMainWorkout(WorkoutAddRequestModel model);
    }
}
