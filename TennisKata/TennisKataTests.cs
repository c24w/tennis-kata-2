using NUnit.Framework;

namespace TennisKata
{
	[TestFixture]
	public class TennisKataTests
	{
		[Test]
		public void Tennis_game_should_start_player_scores_on_zero()
		{
			var tennisGame = new TennisGame();

			Assert.That(tennisGame.GetScore(), Is.EqualTo("love - love"));
		}
	}

	public class TennisGame {
		public string GetScore()
		{
			return "love - love";
		}
	}
}