namespace FighterGame
{
	public class Player
	{
		private Random rand = new Random();
		public Player(string name, int health)
		{
			Name = name;
			Health = health;
		}
		public string Name { get; set; }
		public int Health { get; set; }
		public int Attack { get; set; }

		public void DecreaseHealth(int attack)
		{
			Health -= attack;
		}

		public void SetAttack()
		{
			Attack = rand.Next(1, 51);
		}
	}

	public class GameEngine
	{
		public Player Player1 { get; set; }
		public Player Player2 { get; set; }
		public GameEngine(Player player1, Player player2)
		{
			Player1 = player1;
			Player2 = player2;
		}
		public void StartGame()
		{
			int round = 0;
			while (Player1.Health > 0 && Player2.Health > 0)
			{
				round++;
				Console.WriteLine($"Round: {round}");
				Console.WriteLine("-------------------------------------------------");
				Console.WriteLine($"Player1: Name: {Player1.Name}, Health:{Player1.Health}");
				Console.WriteLine($"Player2: Name: {Player2.Name}, Health:{Player2.Health}");
				Console.WriteLine("-------------------------------------------------");
				//Player1 attack
				LaunchAttack(Player1, Player2);
				Console.WriteLine("-------------------------------------------------");
				if (Player2.Health < 1) break;
				//Player2 attack
				LaunchAttack(Player2, Player1);
				Console.WriteLine("-------------------------------------------------");
				if (Player1.Health < 1) break;
			}
			if (Player1.Health < 1)
			{
				Console.WriteLine($"{Player2.Name} wins the fight!!!");
			}
			else if (Player2.Health < 1)
			{
				Console.WriteLine($"{Player1.Name} wins the fight!!!");
			}

		}

		private void LaunchAttack(Player p1, Player p2)
		{
			p1.SetAttack();
			Console.WriteLine($"{p1.Name} attacks {p2.Name} with {p1.Attack} hits");
			p2.DecreaseHealth(p1.Attack);
			Console.WriteLine($"{p2.Name}'s health is now: {p2.Health}");
		}
	}
}
public class Program
{
	public static void Main(string[] args)
	{
		FighterGame.Player p1 = new("Kofi", 100);

		FighterGame.Player p2 = new("Ama", 100);

		FighterGame.GameEngine engine = new(p1, p2);

		engine.StartGame();
	}
}


