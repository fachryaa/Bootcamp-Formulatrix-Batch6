namespace ChessGame.ChessLibrary.Players
{
    public class Player : IPlayer
    {
        private int _id;
        private string? _name;

        public Player(int id, string? name)
        {
            _id = id;
            _name = name;
        }

        public int GetId()
        {
            throw new System.NotImplementedException();
        }

        public string GetName()
        {
            throw new System.NotImplementedException();
        }
    }
}