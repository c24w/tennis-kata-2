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
		public void Tennis_game_should_start_at_love_love()
		{
			Assert.That(_tennisGame.GetScore(), Is.EqualTo("love - love"));
		}

		[Test]
		public void Score_should_be_fifteen_love_when_player_one_scores()
		{
			_tennisGame.PlayerOneScores();

			Assert.That(_tennisGame.GetScore(), Is.EqualTo("fifteen - love"));
		}
	}

	public class TennisGame
	{
		private string _currentScore = "love - love";

		public string GetScore()
		{
			return _currentScore;
		}

		public void PlayerOneScores()
		{
			_currentScore = "fifteen - love";
		}
	}
}