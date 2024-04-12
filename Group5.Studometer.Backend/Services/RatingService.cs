using Group5.Studometer.Backend.Models;

namespace Group5.Studometer.Backend.Services;

public class RatingService(ILogger<RatingService> logger)
{
    #region Public Fields

    public Dictionary<string, DateTime> LastRating = [];

    #endregion Public Fields

    #region Public Methods

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