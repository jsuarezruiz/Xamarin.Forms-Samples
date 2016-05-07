using System;

namespace DataPages
{
	public class Monkey
	{
		public string Name { get; set; }
		public string Location { get; set; }
		public string Details { get; set; }
		public string Image { get; set; }


		public string NameSort
		{
			get
			{
				if (string.IsNullOrWhiteSpace(Name) || Name.Length == 0)
					return "?";

				return Name[0].ToString().ToUpper();
			}
		}

	}
}

