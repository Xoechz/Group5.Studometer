using Group5.Studometer.Backend.Models;
using Group5.Studometer.Backend.Services;
using Microsoft.AspNetCore.Mvc;

namespace Group5.Studometer.Backend.Controllers;

[ApiController]
[Route("[controller]")]
public class RatingController(RatingService ratingService) : ControllerBase
{
    #region Public Methods

    [HttpPost("{studentToken}/{recipient}", Name = "RateProfessor")]
    public RatingResult RateProfessor(string studentToken, string recipient, [FromBody] string ratingEmoji)
    => _ratingService.RateProfessor(studentToken, recipient, ratingEmoji);

    #endregion Public Methods

    #region Private Fields

    private readonly RatingService _ratingService = ratingService;

    #endregion Private Fields
}