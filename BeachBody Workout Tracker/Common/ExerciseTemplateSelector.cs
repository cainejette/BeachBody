using BeachBody_Workout_Tracker.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;

namespace BeachBody_Workout_Tracker
{
    public class ExerciseTemplateSelector : DataTemplateSelector
    {
        public ExerciseTemplateSelector()
        {

        }

        protected override DataTemplate SelectTemplateCore(object item, DependencyObject container)
        {
            FrameworkElement element = container as FrameworkElement;

            if (element != null && item != null && item is Exercises)
            {
                Exercises exercise = item as Exercises;

                switch (exercise.ExerciseLoggingTypeId)
                {

                    case -1:
                        return Application.Current.Resources["workoutCompleteTemplate"] as DataTemplate;

                    case 0:
                        return Application.Current.Resources["repTemplate"] as DataTemplate;

                    case 1:
                        return Application.Current.Resources["repWeightTemplate"] as DataTemplate;

                    case 2:
                        return Application.Current.Resources["durationTemplate"] as DataTemplate;

                    default:
                        return Application.Current.Resources["leftRightTemplate"] as DataTemplate;
                }
            }

            return null;
        }
    }
}
