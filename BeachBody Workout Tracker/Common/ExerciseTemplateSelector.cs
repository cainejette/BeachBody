using BeachBody_Workout_Tracker.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;

namespace BeachBody_Workout_Tracker.Common
{
    public class ExerciseTemplateSelector : DataTemplateSelector
    {
        //protected override DataTemplate SelectTemplateCore(object item, DependencyObject container)
        //{
        //    FrameworkElement element = container as FrameworkElement;

        //    if (element != null && item != null && item is Exercises)
        //    {
        //        Exercises exercise = item as Exercises;

        //        switch (exercise.ExerciseLoggingTypeId)
        //        {

        //            case 0:
        //                return element.Resources["repExerciseTemplate"] as DataTemplate;
        //                return element.FindResource("repExerciseTemplate") as DataTemplate;
        //            case 1:

        //            case 2:

        //            default:

        //        }
        //    }
        //}
    }
}
