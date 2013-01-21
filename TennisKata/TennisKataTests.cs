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

		[TestCase(1, "Fifteen")]
		[TestCase(2, "Thirty")]
		[TestCase(3, "Forty")]
		public void Tennis_game_returns_the_expected_score_for_player_one_scoring_n_times(int playerOneScoresTimes, string playerOneExpectedScore)
		{
			PlayerOneScoresTimes(playerOneScoresTimes);

			Assert.That(_tennisGame.GetScore(), Is.EqualTo(playerOneExpectedScore + " - Love"));
		}

		[TestCase(1, "Fifteen")]
		[TestCase(2, "Thirty")]
		[TestCase(3, "Forty")]
		public void Tennis_game_returns_the_expected_score_for_player_two_scoring_n_times(int playerTwoScoresTimes, string playerTwoExpectedScore)
		{
			PlayerTwoScoresTimes(playerTwoScoresTimes);

			Assert.That(_tennisGame.GetScore(), Is.EqualTo("Love - " + playerTwoExpectedScore));
		}

		[Test]
		public void Player_one_annihilates_player2()
		{
			PlayerOneScoresTimes(4);

			Assert.That(_tennisGame.GetScore(), Is.EqualTo("Game player 1"));
		}

		[Test]
		public void Player_two_annihilates_player1()
		{
			PlayerTwoScoresTimes(4);

			Assert.That(_tennisGame.GetScore(), Is.EqualTo("Game player 2"));
		}

		[TestCase(0, "Love")]
		[TestCase(1, "Fifteen")]
		public void Tennis_game_returns_the_expected_score_for_fifteen_all(int pointsEach, string expectedScore)
		{
			PlayerOneScoresTimes(pointsEach);
			PlayerTwoScoresTimes(pointsEach);

			Assert.That(_tennisGame.GetScore(), Is.EqualTo(expectedScore + " all"));
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

	public enum Scores
	{
		Love,
		Fifteen,
		Thirty,
		Forty,
		Game
	}

	public class TennisGame
	{
		private Scores _playerOneScore = Scores.Love;
		private Scores _playerTwoScore = Scores.Love;
		private const string Separator = " - ";

		public string GetScore()
		{
			if (_playerOneScore == Scores.Game)
				return Scores.Game + " player 1";
			if (_playerTwoScore == Scores.Game)
				return Scores.Game + " player 2";
			if (_playerOneScore == _playerTwoScore)
				return _playerOneScore + " all";
			return _playerOneScore + Separator + _playerTwoScore;
		}



		public void PlayerOneScores()
		{
			_playerOneScore = GetNextScore(_playerOneScore);
		}

		public void PlayerTwoScores()
		{
			_playerTwoScore = GetNextScore(_playerTwoScore);
		}

		private Scores GetNextScore(Scores currentScore)
		{
			switch (currentScore)
			{
				case Scores.Fifteen:
					return Scores.Thirty;
				case Scores.Thirty:
					return Scores.Forty;
				case Scores.Forty:
					return Scores.Game;
				default:
					return Scores.Fifteen;
			}
		}
	}
}