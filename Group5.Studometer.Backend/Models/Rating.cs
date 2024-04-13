namespace Group5.Studometer.Backend.Models
{
    public class Rating(string recipient, RatingType ratingType, string ratingEmoji)
    {
        #region Public Properties

        public string RatingEmoji { get; set; } = ratingEmoji;
        public DateTime RatingTime { get; set; } = DateTime.Now;
        public RatingType RatingType { get; set; } = ratingType;
        public string Recipient { get; set; } = recipient;

        #endregion Public Properties
    }
}