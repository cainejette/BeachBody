using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BeachBody_Workout_Tracker.Models
{
    public sealed class WorkoutsModel
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

            WorkoutsModel w = (WorkoutsModel)obj;
            return w.Name.Equals(this.Name);
        }

        public override int GetHashCode()
        {
            return this.Id * this.Name.GetHashCode();
        }
    }
}
