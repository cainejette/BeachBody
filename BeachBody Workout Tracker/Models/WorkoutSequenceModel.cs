using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BeachBody_Workout_Tracker.Models
{
    public sealed class WorkoutSequence
    {
        public int WorkoutPlanId { get; set; }

        public int Order { get; set; }

        public int WorkoutId { get; set; }
    }
}
