using Group5.Studometer.Backend.Models;
using Microsoft.AspNetCore.Mvc;

namespace Group5.Studometer.Backend.Controllers
{
    /// <summary>
    /// Controller for getting scores.
    /// </summary>
    [ApiController]
    [Route("[controller]")]
    public class ScoreController : ControllerBase
    {
        #region Public Methods

        /// <summary>
        /// Get the score for a specific recipient.
        /// </summary>
        /// <param name="recipient">The recipient's name.</param>
        /// <returns>The score for the recipient.</returns>
        [HttpGet("{recipient}", Name = "GetScore")]
        public Score GetScore(string recipient) =>
            new(recipient, RatingType.Professor)
            {
                Ratings = new Dictionary<string, int>()
                {
                        { Emojis[0], Random.Shared.Next(100) },
                        { Emojis[1], Random.Shared.Next(100) },
                        { Emojis[2], Random.Shared.Next(100) },
                        { Emojis[3], Random.Shared.Next(100) },
                        { Emojis[4], Random.Shared.Next(100) },
                }
            };

        /// <summary>
        /// Get the scores for all recipients.
        /// </summary>
        /// <returns>The scores for all recipients.</returns>
        [HttpGet(Name = "GetScores")]
        public IEnumerable<Score> GetScores() =>
            Enumerable.Range(1, 5).Select(index => new Score($"Professor {index}", RatingType.Professor)
            {
                Ratings = new Dictionary<string, int>(){
                        { Emojis[0], Random.Shared.Next(100) },
                        { Emojis[1], Random.Shared.Next(100) },
                        { Emojis[2], Random.Shared.Next(100) },
                        { Emojis[3], Random.Shared.Next(100) },
                        { Emojis[4], Random.Shared.Next(100) },
                }
            });

        #endregion Public Methods

        #region Private Fields

        private static readonly string[] Emojis =
        [
                ":)",
                ":(",
                ":D",
                ":O",
                ":P"
            ];

        #endregion Private Fields
    }
}