using Moq;
using ChessLibrary;
namespace ChessGameController.Test;

[TestFixture]
public class Tests
{
	GameController game;
	[SetUp]
	public void Setup()
	{
		game = new GameController(new Board(boardSize : 8));
	}

	[Test]
	public void OnChangeTurnTest()
	{
		// Arrange
		ChessLibrary.Enum.Color currentPlayer = game.GetCurrentPlayer();
		ChessLibrary.Enum.Color expected = currentPlayer == ChessLibrary.Enum.Color.White ?
			ChessLibrary.Enum.Color.Black : ChessLibrary.Enum.Color.Black;
		
		// Act
		game.OnChangeTurn.Invoke(null, EventArgs.Empty);
		ChessLibrary.Enum.Color actual = game.GetCurrentPlayer();
		
		// Assert
		Assert.That(actual, Is.EqualTo(expected));
	}
	
	[Test]
	public void SelectPieceTest_OnInitialBoard()
	{
		// Arrange
		
	}
	
}