using System;
using System.Collections.Generic;

namespace RevFIT.Context.Models;

public partial class WorkoutScore
{
    public int ScoreId { get; set; }

    public int Sets { get; set; }

    public int MeasureTypeId { get; set; }

    public int ScoreCalculationTypeId { get; set; }

    public int ScoreOrderId { get; set; }

    public int WorkoutId { get; set; }

    public int DateCreated { get; set; }

    public virtual ScoreMeasureType MeasureType { get; set; } = null!;

    public virtual ScoreCalculationType ScoreCalculationType { get; set; } = null!;

    public virtual ScoreOrderType ScoreOrder { get; set; } = null!;

    public virtual Wod Workout { get; set; } = null!;
}
