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

        public static List<WorkoutPlans> GetWorkoutPlans()
        {
            return DataHandler.db.Table<WorkoutPlans>().ToList<WorkoutPlans>();
        }

        public static List<Workouts> GetWorkouts(int workoutPlanId)
        {
            return DataHandler.db.Table<Workouts>().Where(i => i.WorkoutPlanId == workoutPlanId).ToList<Workouts>();
        }

        public static List<Exercises> GetExercises(int workoutId)
        {
            return DataHandler.db.Table<Exercises>().Where(i => i.WorkoutId == workoutId).ToList<Exercises>();
        }

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

        public int WorkoutPlanId { get; set; }

        public override string ToString()
        {
            return this.Name;
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
}
