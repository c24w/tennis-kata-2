using NUnit.Framework;

namespace TennisKata
{
	[TestFixture]
	public class TennisKataTests
	{
		private TennisGame _tennisGame;

		[SetUp]
		public void SetUp()
		{
			_tennisGame = new TennisGame();
		}

		[Test]
		[TestCase(0, "love")]
		[TestCase(1, "fifteen")]
		[TestCase(2, "thirty")]
		[TestCase(3, "forty")]
		public void Tennis_game_returns_the_expected_score_for_player_one_scoring_n_times(int playerOneScoresTimes, string playerOneExpectedScore)
		{
			PlayerOneScoresTimes(playerOneScoresTimes);

			Assert.That(_tennisGame.GetScore(), Is.EqualTo(playerOneExpectedScore + " - love"));
		}

		private void PlayerOneScoresTimes(int times)
		{
			for (int i = 0; i < times; i++)
			{
				_tennisGame.PlayerOneScores();
			}
		}
	}

	public class TennisGame
	{
		private const string Love = "love";
		private const string Separator = " - ";
		private const string Fifteen = "fifteen";
		private const string Thirty = "thirty";
		private string _platerOneScore = Love;
		private const string Forty = "forty";

		public string GetScore()
		{
			return FormatScore(_platerOneScore, Love);
		}

		public void PlayerOneScores()
		{
			switch (_platerOneScore)
			{
				case Fifteen:
					_platerOneScore = Thirty;
					break;
				case Thirty:
					_platerOneScore = Forty;
					break;
				default:
					_platerOneScore = Fifteen;
					break;
			}
		}

		string FormatScore(string scoreA, string scoreB)
		{
			return scoreA + Separator + scoreB;
		}
	}
}