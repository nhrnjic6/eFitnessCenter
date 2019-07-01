using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace RS2_Seminarski.Database
{
    public class Trainer
    {
        [ForeignKey("Id")]
        public AppUser AppUser { get; set; } = new AppUser();
        public ICollection<Workout> Workouts { get; set; }
    }
}
