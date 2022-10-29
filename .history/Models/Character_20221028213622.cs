using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace dotnet_rgp.Models
{
    public class Character
    {
        public int Id { get; set; }
        public string Name { get; set; } = "Frodo";//default
        public int HitPoints { get; set; } = 100;
        public int Strength { get; set; } = 10;
        public int Defense { get; set; } = 10;
        public int Intelligence { get; set; } = 10;

        public int UserId { get; set; }
        public RpgClass Class { get; set; } = RpgClass.Knight;
    }
}