using BeachBody_Workout_Tracker.Models;
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
        public static List<WorkoutPlansModel> GetWorkoutPlans()
        {
            return DataHandler.db.Table<WorkoutPlansModel>().ToList<WorkoutPlansModel>();
        }

        /// <summary>
        /// Retrieves the list of distinct workouts for the given workout plan ID
        /// </summary>
        public static List<WorkoutsModel> GetWorkouts(int workoutPlanId)
        {
            return DataHandler.GetWorkouts(workoutPlanId).Distinct<WorkoutsModel>().ToList<WorkoutsModel>();
        }

        /// <summary>
        /// Retrieves the sequence of workouts for the given workout plan ID
        /// </summary>
        public static List<WorkoutsModel> GetWorkoutSequence(int workoutId)
        {
            List<WorkoutSequenceModel> workoutSequence = DataHandler.db.Table<WorkoutSequenceModel>().Where(i => i.WorkoutPlanId == workoutId).OrderBy(i => i.Order).ToList<WorkoutSequenceModel>();
            List<WorkoutsModel> exercises = new List<WorkoutsModel>();
            foreach (WorkoutSequenceModel ws in workoutSequence)
            {
                exercises.Add(DataHandler.db.Table<WorkoutsModel>().Where(i => i.Id == ws.WorkoutId).Single<WorkoutsModel>());
            }

            return exercises;
        }

        /// <summary>
        /// Retrieves the workout plan with the given workout plan ID
        /// </summary>
        public static WorkoutPlansModel GetWorkoutPlan(int workoutPlanId)
        {
            return DataHandler.db.Find<WorkoutPlansModel>(workoutPlanId);
        }
    }
}
