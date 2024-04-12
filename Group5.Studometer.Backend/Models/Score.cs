namespace Group5.Studometer.Backend.Models
{
    public class Score(string recipient, RatingType ratingType)
    {
        #region Public Properties

        public IDictionary<string, int> Ratings { get; set; } = new Dictionary<string, int>();
        public RatingType RatingType { get; set; } = ratingType;
        public string Recipient { get; set; } = recipient;

        #endregion Public Properties
    }
}