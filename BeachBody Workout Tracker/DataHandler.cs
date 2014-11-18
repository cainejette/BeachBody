using BeachBody_Workout_Tracker.Models;
using SQLite;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.ApplicationModel;
using Windows.Storage;

namespace BeachBody_Workout_Tracker
{
    public static class DataHandler
    {
        private static string db_path = Path.Combine(Package.Current.InstalledLocation.Path, "Assets/beachbody2.db3");
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
            return DataHandler.GetWorkoutSequence(workoutPlanId).Distinct<Workouts>().ToList<Workouts>();
        }

        /// <summary>
        /// Retrieves the sequence of workouts for the given workout plan ID
        /// </summary>
        public static List<Workouts> GetWorkoutSequence(int workoutPlanId)
        {
            List<WorkoutSequence> workoutSequence = DataHandler.db.Table<WorkoutSequence>()
                                                                        .Where(i => i.WorkoutPlanId == workoutPlanId)
                                                                        .OrderBy(i => i.Order)
                                                                        .ToList<WorkoutSequence>();
            List<Workouts> workouts = new List<Workouts>();
            foreach (WorkoutSequence ws in workoutSequence)
            {
                Workouts workout = DataHandler.db.Table<Workouts>().Where(i => i.Id == ws.WorkoutId).Single<Workouts>();
                workout.Order = ws.Order + 1;
                workouts.Add(workout);
            }

            return workouts;
        }

        /// <summary>
        /// Retrieves the sequence of exercises for the given workout ID
        /// </summary>
        public static List<Exercises> GetExerciseSequence(int workoutId)
        {
            List<ExerciseSequence> exerciseSequence = DataHandler.db.Table<ExerciseSequence>()
                                                                        .Where(i => i.WorkoutId == workoutId)
                                                                        .OrderBy(i => i.Order)
                                                                        .ToList<ExerciseSequence>();

            List<Exercises> exercises = new List<Exercises>();
            foreach (ExerciseSequence es in exerciseSequence)
            {
                exercises.Add(DataHandler.db.Table<Exercises>().Where(i => i.Id == es.ExerciseId).Single<Exercises>());
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
}
