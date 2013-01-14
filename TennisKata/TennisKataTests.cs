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

		[Test]
		public void Score_should_be_thirty_love_when_player_one_scores_twice()
		{
			_tennisGame.PlayerOneScores();
			_tennisGame.PlayerOneScores();

			Assert.That(_tennisGame.GetScore(), Is.EqualTo("thirty - love"));
		}
	}

	public class TennisGame
	{
		private const string Love = "love";
		private const string Separator = " - ";
		private const string Fifteen = "fifteen";
		private const string Thirty = "thirty";
		private string _platerOneScore = Love;

		public string GetScore()
		{
			return FormatScore(_platerOneScore, Love);
		}

		public void PlayerOneScores()
		{
			if (_platerOneScore == Fifteen)
				_platerOneScore = Thirty;
			else
				_platerOneScore = Fifteen;
		}

		string FormatScore(string scoreA, string scoreB)
		{
			return scoreA + Separator + scoreB;
		}
	}
}