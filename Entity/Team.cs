namespace Motocliclisti.Entity
{
    public class Team
    {
        private int code;
        private string name;

        public Team(int code, string name)
        {
            this.code = code;
            this.name = name;
        }

        public int Code
        {
            get => code;
            set => code = value;
        }

        public string Name
        {
            get => name;
            set => name = value;
        }
    }
}