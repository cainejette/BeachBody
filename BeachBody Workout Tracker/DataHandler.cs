using SQLite;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.Storage;

namespace BeachBody_Workout_Tracker
{
    public static class DataHandler
    {
        private static string db_path = Path.Combine(Path.Combine(ApplicationData.Current.LocalFolder.Path, "beachbody2.db3"));
        private static SQLiteConnection db = new SQLiteConnection(DataHandler.db_path);

        /// <summary>
        /// Retrieves the list of workout plans
        /// </summary>
        public static List<WorkoutPlans> GetWorkoutPlans()
        {
            return DataHandler.db.Table<WorkoutPlans>().ToList<WorkoutPlans>();
        }

        /// <summary>
        /// Retrieves the list of distinct workouts for the given workout plan ID
        /// </summary>
        public static List<Workouts> GetWorkouts(int workoutPlanId)
        {
            return DataHandler.GetWorkouts(workoutPlanId).Distinct<Workouts>().ToList<Workouts>();
        }

        /// <summary>
        /// Retrieves the sequence of workouts for the given workout plan ID
        /// </summary>
        public static List<Workouts> GetWorkoutSequence(int workoutId)
        {
            List<WorkoutSequence> workoutSequence = DataHandler.db.Table<WorkoutSequence>().Where(i => i.WorkoutPlanId == workoutId).OrderBy(i => i.Order).ToList<WorkoutSequence>();
            List<Workouts> exercises = new List<Workouts>();
            foreach (WorkoutSequence ws in workoutSequence)
            {
                exercises.Add(DataHandler.db.Table<Workouts>().Where(i => i.Id == ws.WorkoutId).Single<Workouts>());
            }

            return exercises;
        }

        /// <summary>
        /// Retrieves the workout plan with the given workout plan ID
        /// </summary>
        public static WorkoutPlans GetWorkoutPlan(int workoutPlanId)
        {
            return DataHandler.db.Find<WorkoutPlans>(workoutPlanId);
        }
    }

    public sealed class WorkoutPlans
    {
        [PrimaryKey]
        public int Id { get; set; }

        public string Name { get; set; }

        public override string ToString()
        {
            return this.Name;
        }
    }

    public sealed class Workouts
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public override string ToString()
        {
            return this.Name;
        }

        public override bool Equals(object obj)
        {
            // Check for null values and compare run-time types.
            if (obj == null || GetType() != obj.GetType())
                return false;

            Workouts w = (Workouts)obj;
            return w.Name.Equals(this.Name);
        }

        public override int GetHashCode()
        {
            return this.Id * this.Name.GetHashCode();
        }
    }

    public sealed class Exercises
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public int WorkoutId { get; set; }

        public override string ToString()
        {
            return this.Name;
        }
    }

    public sealed class WorkoutSequence
    {
        public int WorkoutPlanId { get; set; }

        public int Order { get; set; }

        public int WorkoutId { get; set; }
    }
}
