using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API_RPG.Dtos.CharacterDtos
{
    public class AddCharacterDto
    {
        public string Name { get; set; } = "Frodorik";
        public int HitPoints { get; set; } = 100;
        public int Strenght { get; set; } = 10;
        public int Defence { get; set; } = 10;
        public int Intiligence { get; set; } = 10;
        public RPGClass Class { get; set; } = RPGClass.Knight;
    }
}