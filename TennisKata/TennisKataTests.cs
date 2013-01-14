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

		[Test]
		public void Player_one_annihilates_player2()
		{
			PlayerOneScoresTimes(4);

			Assert.That(_tennisGame.GetScore(), Is.EqualTo("player 1 wins"));
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
		private string _playerOneScore = Love;
		private const string Separator = " - ";
		private const string Love = "love";
		private const string Fifteen = "fifteen";
		private const string Thirty = "thirty";
		private const string Forty = "forty";
		private const string PlayerOneWins = "player 1 wins";

		public string GetScore()
		{
			if (_playerOneScore == PlayerOneWins)
				return _playerOneScore;
			return FormatScore(_playerOneScore, Love);
		}

		public void PlayerOneScores()
		{
			switch (_playerOneScore)
			{
				case Fifteen:
					_playerOneScore = Thirty;
					break;
				case Thirty:
					_playerOneScore = Forty;
					break;
				case Forty:
					_playerOneScore = PlayerOneWins;
					break;
				default:
					_playerOneScore = Fifteen;
					break;
			}
		}

		string FormatScore(string scoreA, string scoreB)
		{
			return scoreA + Separator + scoreB;
		}
	}
}