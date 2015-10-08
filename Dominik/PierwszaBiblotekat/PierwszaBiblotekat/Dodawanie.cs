using System;
using System.Linq;

namespace PierwszaBiblotekat
{
	public class Dodawanie
	{
		public int _jeden;
		public int _dwa;
		private char[] tab = {'a','b','c'};
		public Dodawanie()
		{

		}
		public Dodawanie(int jeden, int dwa)
		{
			_jeden = jeden;
			_dwa = dwa;
		}

		public string WynikDodawania()
		{
			
			string imie = "Moje i3mie1";
			
			imie.Where(item => Char.IsDigit(item));
			return new string(tab);

		}
	}
}