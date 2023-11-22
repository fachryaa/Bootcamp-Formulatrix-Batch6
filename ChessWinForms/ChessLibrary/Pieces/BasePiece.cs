using ChessLibrary.Enum;
using Color = ChessLibrary.Enum.Color;

namespace ChessLibrary.Pieces;

public abstract class BasePiece : IMoveable
{
	public static int count = 1;
	public int Id;
	public PieceType Type;
	public Enum.Color Color;
	protected BasePiece(PieceType type, Enum.Color color)
	{
		Id = count++;
		Type = type;
		Color = color;
	}

	public BasePiece(BasePiece promoted, PieceType type, Enum.Color color)
	{
		Id = promoted.Id;
		Type = type;
		Color = color;
	}

    public abstract bool AddMoveToResult(GameController game, List<IPosition> result, IPosition position);

    /// <summary>
    /// Returns a list of available moves for the piece, forAttack is used to determine if the piece is checking the king
    /// </summary>
    /// <param name="pos"></param>
    /// <param name="game"></param>
    /// <param name="forAttack"></param>
    /// <returns></returns>
    public abstract IEnumerable<IPosition> GetAvailableMoves(IPosition pos, GameController game, bool forAttack=false);

    public static BasePiece Create(PieceType type, Color color)
    {
	    switch (type)
	    {
		    case PieceType.Rook : return new Rook(color);
		    case PieceType.Knight : return new Knight(color);
		    case PieceType.Bishop : return new Bishop(color);
		    default : return new Queen(color);
	    }
    }
}
