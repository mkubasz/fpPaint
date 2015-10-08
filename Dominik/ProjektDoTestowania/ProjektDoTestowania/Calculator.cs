namespace ProjektDoTestowania
{
	public class Calculator
	{
		public int firstNumber;
		public int secondNumber;
		public int result;
		public void Add()
		{
			result= firstNumber + secondNumber;
		}

		public int Substraction()
		{
			return firstNumber - secondNumber;
		}

		public int Div()
		{

				return (secondNumber != 0)
				?(firstNumber / secondNumber)
					:-1;
		}
	}
}