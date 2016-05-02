using System.Collections.Generic;

namespace XamarinFormsPreviewer
{
	public class Monkey
	{
		public string Name { get; set; }
		public string Location { get; set; }
		public string Details { get; set; }
		public string Image { get; set; }

		public static List<Monkey> DesignData
		{
			get
			{
				return new List<Monkey>
				{
					new Monkey()
					{
						Name = "Baboon",
						Location = "Africa & Asia",
						Details = "Baboons are African and Arabian Old World monkeys belonging to the genus Papio, part of the subfamily Cercopithecinae.",
						Image = "http://upload.wikimedia.org/wikipedia/commons/thumb/f/fc/Papio_anubis_%28Serengeti%2C_2009%29.jpg/200px-Papio_anubis_%28Serengeti%2C_2009%29.jpg"
					},
					new Monkey
					{
						Name = "Capuchin Monkey",
						Location = "Central & South America",
						Details = "The capuchin monkeys are New World monkeys of the subfamily Cebinae. Prior to 2011, the subfamily contained only a single genus, Cebus.",
						Image= "https://upload.wikimedia.org/wikipedia/commons/thumb/4/40/Capuchin_Costa_Rica.jpg/200px-Capuchin_Costa_Rica.jpg"
					}
				};
			}
		}
	}
}