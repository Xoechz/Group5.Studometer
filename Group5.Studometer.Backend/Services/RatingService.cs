using Group5.Studometer.Backend.Models;

namespace Group5.Studometer.Backend.Services;

/// <summary>
/// Represents a service for rating professors.
/// </summary>
/// <param name="logger">The logger instance.</param>
public class RatingService(ILogger<RatingService> logger)
{
    #region Public Fields

    /// <summary>
    /// Dictionary to store the last rating timestamp for each student token.
    /// </summary>
    public Dictionary<string, DateTime> LastRating = [];

    #endregion Public Fields

    #region Public Methods

    /// <summary>
    /// Rates a professor based on the student token, recipient, and rating emoji.
    /// </summary>
    /// <param name="studentToken">The token of the student rating the professor.</param>
    /// <param name="recipient">The recipient of the rating (professor).</param>
    /// <param name="ratingEmoji">The emoji representing the rating.</param>
    /// <returns>The result of the rating operation.</returns>
    public RatingResult RateProfessor(string studentToken, string recipient, string ratingEmoji)
    {
        if (LastRating.TryGetValue(studentToken, out DateTime value) && value > DateTime.Now.AddMinutes(-10))
        {
            _logger.LogInformation("Rate limit exceeded for {studentToken}", studentToken);
            return new RatingResult
            {
                Success = false,
                RetryAfter = DateTime.Now.AddMinutes(10)
            };
        }
        LastRating[studentToken] = DateTime.Now;
        var rating = new Rating(recipient, RatingType.Professor, ratingEmoji);
        _logger.LogInformation("Saving rating for {recipient} with emoji {rating}", recipient, ratingEmoji);
        return new RatingResult
        {
            Success = true,
            Rating = rating
        };
    }

    #endregion Public Methods

    #region Private Fields

    private readonly ILogger<RatingService> _logger = logger;

    #endregion Private Fields
}