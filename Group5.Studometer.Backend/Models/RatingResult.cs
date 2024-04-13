namespace Group5.Studometer.Backend.Models;

public class RatingResult
{
    #region Public Properties

    /// <summary>
    /// Gets or sets the rating.
    /// </summary>
    public Rating? Rating { get; set; }

    /// <summary>
    /// Gets or sets the retry after date and time.
    /// </summary>
    public DateTime? RetryAfter { get; set; }

    /// <summary>
    /// Gets or sets a value indicating whether the operation was successful.
    /// </summary>
    public bool Success { get; set; }

    #endregion Public Properties
}