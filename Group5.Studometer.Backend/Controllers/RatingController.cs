using Group5.Studometer.Backend.Models;
using Group5.Studometer.Backend.Services;
using Microsoft.AspNetCore.Mvc;

namespace Group5.Studometer.Backend.Controllers;

/// <summary>
/// Represents a controller for rating professors.
/// </summary>
[ApiController]
[Route("[controller]")]
public class RatingController(RatingService ratingService) : ControllerBase
{
    #region Public Methods

    /// <summary>
    /// Rates a professor.
    /// </summary>
    /// <param name="studentToken">The token of the student.</param>
    /// <param name="recipient">The recipient of the rating.</param>
    /// <param name="ratingEmoji">The emoji representing the rating.</param>
    /// <returns>The result of the rating or a retry date if it fails.</returns>
    [HttpPost("{studentToken}/{recipient}", Name = "RateProfessor")]
    public RatingResult RateProfessor(string studentToken, string recipient, [FromBody] string ratingEmoji)
        => _ratingService.RateProfessor(studentToken, recipient, ratingEmoji);

    #endregion Public Methods

    #region Private Fields

    private readonly RatingService _ratingService = ratingService;

    #endregion Private Fields
}