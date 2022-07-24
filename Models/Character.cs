namespace API_RPG.Models
{
    public class Character
    {
        public int Id { get; set; }
        public string Name { get; set; } = "Frodorik";
        public int HitPoints { get; set; } = 100;
        public int Strenght { get; set; } = 10;
        public int Defence { get; set; } = 10;
        public int Intiligence { get; set; } = 10;
        public RPGClass Class { get; set; } = RPGClass.Knight;
    }
}