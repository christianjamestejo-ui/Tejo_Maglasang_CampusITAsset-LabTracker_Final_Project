using System;
namespace MT_Campus_IT_Asset___Lab_Tracker.Functions
{
	public class Validation
	{
        public Validation()
        {
             static double ReadPositiveAmount(string prompt)
            {
                //To do 5
                while (true)
                {
                    double.TryParse(prompt = Console.ReadLine(), out double validValue);
                    if (validValue > 0)
                    {
                        return validValue;
                        break;
                    }
                }
            }
        }
	}
}

