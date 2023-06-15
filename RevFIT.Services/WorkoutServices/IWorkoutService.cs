﻿using RevFIT.Context.Models;
using RevFIT.Services.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RevFIT.Services.WorkoutServices
{
    internal interface IWorkoutService
    {
        Task<ServiceResponseModel<Workout>> GetTodaysWorkout(int programID, DateTime workoutDate);
    }
}