namespace Day07;

public class ActionTest
{
	public static void Run()
	{
		CardCreator cardCreator = new();
		UI ui = new();
		Database database = new();
		
		cardCreator.onCardUpdate += ui.Notification;
		cardCreator.onCardUpdate += database.AddCardToDb;
		
		cardCreator.CreateCard(1, "satu");
		cardCreator.CreateCard(2, "dua");
		cardCreator.CreateCard(3, "tiga");
	}
}

class CardCreator
{
	public List<Card>? cards;
	public Action<Card>? onCardUpdate;
	
	public void CreateCard(int id, string description)
	{
		Card card = new Card()
		{
			id = id,
			description = description
		};
		cards?.Add(card);
		Update(card);
	}
	public void Update(Card card)
	{
		onCardUpdate?.Invoke(card);
	}
}

class Card
{
	public int id;
	public string? description;
}

class UI
{
	public void Notification(Card data)
	{
		Console.WriteLine($"Update UI location {data.id}, {data.description}");
	}
}

class Database
{
	public void AddCardToDb(Card data)
	{
		Console.WriteLine($"Update Database {data.id}, {data.description}");
	}
}