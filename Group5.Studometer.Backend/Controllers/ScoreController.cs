using Group5.Studometer.Backend.Models;
using Microsoft.AspNetCore.Mvc;

namespace Group5.Studometer.Backend.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ScoreController : ControllerBase
    {
        #region Public Methods

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