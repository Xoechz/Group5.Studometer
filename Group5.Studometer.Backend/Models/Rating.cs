namespace Group5.Studometer.Backend.Models
{
    /// <summary>
    /// Represents a rating given to a recipient.
    /// </summary>
    /// <remarks>
    /// Initializes a new instance of the <see cref="Rating"/> class.
    /// </remarks>
    /// <param name="recipient">The recipient of the rating.</param>
    /// <param name="ratingType">The type of the rating.</param>
    /// <param name="ratingEmoji">The emoji associated with the rating.</param>
    public class Rating(string recipient, RatingType ratingType, string ratingEmoji)
    {
        #region Public Properties

        /// <summary>
        /// Gets or sets the emoji associated with the rating.
        /// </summary>
        public string RatingEmoji { get; set; } = ratingEmoji;

        /// <summary>
        /// Gets or sets the time when the rating was given.
        /// </summary>
        public DateTime RatingTime { get; set; } = DateTime.Now;

        /// <summary>
        /// Gets or sets the type of the rating.
        /// </summary>
        public RatingType RatingType { get; set; } = ratingType;

        /// <summary>
        /// Gets or sets the recipient of the rating.
        /// </summary>
        public string Recipient { get; set; } = recipient;

        #endregion Public Properties
    }
}