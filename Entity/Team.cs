namespace Motocliclisti.Entity
{
    public class Team
    {
        public Team(int code, string name)
        {
            this.Code = code;
            this.Name = name;
        }

        public int Code { get; set; }

        public string Name { get; set; }
    }
}