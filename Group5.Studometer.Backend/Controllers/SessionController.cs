using Group5.Studometer.Backend.Models;
using Microsoft.AspNetCore.Mvc;

namespace Group5.Studometer.Backend.Controllers
{
    /// <summary>
    /// Controller for managing sessions.
    /// </summary>
    [ApiController]
    [Route("[controller]")]
    public class SessionController(ILogger<SessionController> logger) : ControllerBase
    {
        #region Public Fields

        public readonly ILogger<SessionController> _logger = logger;

        #endregion Public Fields

        #region Public Methods

        /// <summary>
        /// Ends a session and saves the rating.
        /// </summary>
        /// <param name="students">The students involved in the session.</param>
        /// <param name="ratingEmoji">The emoji representing the rating.</param>
        /// <returns>The rating object.</returns>
        [HttpPost("end/{students}", Name = "EndSession")]
        public Rating EndSession(string students, [FromBody] string ratingEmoji)
        {
            var rating = new Rating(students, RatingType.Student, ratingEmoji);
            _logger.LogInformation("Saving rating for {recipient} with emoji {rating}", students, ratingEmoji);
            return rating;
        }

        /// <summary>
        /// Logs in to a session.
        /// </summary>
        /// <param name="sessionCode">The session code.</param>
        /// <returns>The student token.</returns>
        [HttpPost("login/{sessionCode}", Name = "LoginSession")]
        public string LoginSession(string sessionCode)
        {
            _logger.LogInformation("Logging in to session {sessionCode}", sessionCode);
            return "StudentToken";
        }

        /// <summary>
        /// Starts a session and returns the session code.
        /// </summary>
        /// <param name="students">The students involved in the session.</param>
        /// <returns>The session code.</returns>
        [HttpPost("start/{students}", Name = "StartSession")]
        public string StartSession(string students)
            => $"Session Code for {students}";

        #endregion Public Methods
    }
}