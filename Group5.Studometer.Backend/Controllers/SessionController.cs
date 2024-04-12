using Group5.Studometer.Backend.Models;
using Microsoft.AspNetCore.Mvc;

namespace Group5.Studometer.Backend.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class SessionController(ILogger<SessionController> logger) : ControllerBase
    {
        #region Public Fields

        public readonly ILogger<SessionController> _logger = logger;

        #endregion Public Fields

        #region Public Methods

        [HttpPost("end/{students}", Name = "EndSession")]
        public Rating EndSession(string students, [FromBody] string ratingEmoji)
        {
            var rating = new Rating(students, RatingType.Student, ratingEmoji);
            _logger.LogInformation("Saving rating for {recipient} with emoji {rating}", students, ratingEmoji);
            return rating;
        }

        [HttpPost("login/{sessionCode}", Name = "LoginSession")]
        public string LoginSession(string sessionCode)
        {
            _logger.LogInformation("Logging in to session {sessionCode}", sessionCode);
            return "StudentToken";
        }

        [HttpPost("start/{students}", Name = "StartSession")]
        public string StartSession(string students)
            => $"Session Code for {students}";

        #endregion Public Methods
    }
}