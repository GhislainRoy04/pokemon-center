namespace PokemonCenterAPI.DTO
{
    public class PokemonDTO
    {
        public int Id { get; set; }
        public string Name { get; set; }   
        public string Type1 { get; set; }
        public string Type2 { get; set; }
        public int Hp { get; set; }
        public int Attack { get; set; }
        public int Defense { get; set; }
        public int SpecialAttack { get; set; }
        public int SpecialDefense { get; set; }
        public int Speed { get; set; }
        public int Generation { get; set; }
        public Boolean Legendary { get; set; }

        public int GetTotal() { 
            return this.Hp + this.Attack + this.Defense + this.SpecialAttack + this.SpecialDefense + this.Speed;
        }
    }
}
