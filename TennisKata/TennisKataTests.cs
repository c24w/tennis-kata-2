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

		[TestCase(0, "love")]
		[TestCase(1, "fifteen")]
		[TestCase(2, "thirty")]
		[TestCase(3, "forty")]
		public void Tennis_game_returns_the_expected_score_for_player_one_scoring_n_times(int playerOneScoresTimes, string playerOneExpectedScore)
		{
			PlayerOneScoresTimes(playerOneScoresTimes);

			Assert.That(_tennisGame.GetScore(), Is.EqualTo(playerOneExpectedScore + " - love"));
		}

		[TestCase(0, "love")]
		[TestCase(1, "fifteen")]
		[TestCase(2, "thirty")]
		public void Tennis_game_returns_the_expected_score_for_player_two_scoring_n_times(int playerTwoScoresTimes, string playerTwoExpectedScore)
		{
			PlayerTwoScoresTimes(playerTwoScoresTimes);

			Assert.That(_tennisGame.GetScore(), Is.EqualTo("love - " + playerTwoExpectedScore));
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

		private void PlayerTwoScoresTimes(int times)
		{
			for (int i = 0; i < times; i++)
			{
				_tennisGame.PlayerTwoScores();
			}
		}
	}

	public class TennisGame
	{
		private string _playerOneScore = Love;
		private string _playerTwoScore = Love;
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
			return FormatScore(_playerOneScore, _playerTwoScore);
		}

		public void PlayerOneScores()
		{
			_playerOneScore = GetNextScore();
		}

		private string GetNextScore()
		{
			switch (_playerOneScore)
			{
				case Fifteen:
					return Thirty;
				case Thirty:
					return Forty;
				case Forty:
					return PlayerOneWins;
				default:
					return Fifteen;
			}
		}

		string FormatScore(string scoreA, string scoreB)
		{
			return scoreA + Separator + scoreB;
		}

		public void PlayerTwoScores()
		{
			if (_playerTwoScore == Fifteen)
				_playerTwoScore = Thirty;
			else _playerTwoScore = Fifteen;
		}
	}
}