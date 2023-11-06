namespace MonopolyGame.Players
{
    public class Player
    {
        private int _id;
        private string? _name;
        public Label playerLabel = new Label();

        public Player(int id, string? name)
        {
            _id = id;
            _name = name;
        }
    }
}