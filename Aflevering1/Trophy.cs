namespace Aflevering1
{
    public class Trophy
    {
        public int Id { get; set; }

        private string competition;
        public string Competition
        {
            get => competition;
            set
            {
                if (value == null)
                    throw new ArgumentNullException(nameof(Competition), "Competition cannot be null");
                if (value.Length < 3)
                    throw new ArgumentException("Competition name must be at least 3 characters long");
                competition = value;
            }
        }

        private int year;
        public int Year
        {
            get => year;
            set
            {
                if (value < 1970 || value > 2025)
                    throw new ArgumentOutOfRangeException(nameof(Year), "Year must be between 1970 and 2025");
                year = value;
            }
        }

        //Default constructor
        public Trophy() 
        {

        }

        //Copy constructor
        public Trophy(Trophy other)
        {
            if (other == null) throw new ArgumentNullException(nameof(other));
            Id = other.Id;
            Competition = other.Competition;
            Year = other.Year;
        }


        public override string ToString()
        {
            return $"Id: {Id}, Competition: {Competition}, Year: {Year}";
        }
    }
}
