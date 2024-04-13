namespace Group5.Studometer.Backend.Models
{
    /// <summary>
    /// Represents a score for a recipient.
    /// </summary>
    /// <remarks>
    /// Initializes a new instance of the <see cref="Score"/> class.
    /// </remarks>
    /// <param name="recipient">The recipient of the score.</param>
    /// <param name="ratingType">The rating type for the score.</param>
    public class Score(string recipient, RatingType ratingType)
    {
        #region Public Properties

        /// <summary>
        /// Gets or sets the ratings for the score.
        /// </summary>
        public IDictionary<string, int> Ratings { get; set; } = new Dictionary<string, int>();

        /// <summary>
        /// Gets or sets the rating type for the score.
        /// </summary>
        public RatingType RatingType { get; set; } = ratingType;

        /// <summary>
        /// Gets or sets the recipient of the score.
        /// </summary>
        public string Recipient { get; set; } = recipient;

        #endregion Public Properties
    }
}