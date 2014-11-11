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
    }
}
