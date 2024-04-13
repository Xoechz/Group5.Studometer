namespace Group5.Studometer.Backend.Models;

public class RatingResult
{
    #region Public Properties

    public Rating? Rating { get; set; }
    public DateTime? RetryAfter { get; set; }
    public bool Success { get; set; }

    #endregion Public Properties
}