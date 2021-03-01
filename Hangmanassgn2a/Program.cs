using System;
using System.Text;

namespace Hangmanassgn2a
{
    class Program
    {
        static void Main(string[] args)
        {
            char[] chars = {'a', 'n', 'u', 'm', 'g', 'o', 'e', 'b', 'i', 'r',};
            var stringChars = new char[10];
            var random = new Random();
            char[] guesswords = { '_', '_', '_', '_', '_', '_', };

           
            
            var retry = true;
            StringBuilder sb = new StringBuilder(10);

            for (int i = 0; i < 6; i++)
            {
                stringChars[i] = chars[random.Next(chars.Length)];
            }

            var secretWord = new String(stringChars);
            Console.WriteLine(secretWord);

            int noOfGuessesLeft = 10;
            int numberOfRightGuesse = 0;

            while (noOfGuessesLeft > 0)
            {
                Console.WriteLine("Pls guess a letter or a word");
                string input = Console.ReadLine();
                if (input.Length > 1)
                {
                    Console.WriteLine("U've guessed a word");
                    if (input == secretWord)
                    {
                        Console.WriteLine("Congrats u guessed right");
                        break;
                    }


                } else
                {
                    Console.WriteLine("U've guessed a letter");
                    bool found = false;

                    for (int i = 0; i < secretWord.Length; i++)
                    {
                       
                        if (Char.ToString(secretWord[i]) == input)
                        {
                            guesswords[i] = input.ToCharArray()[0];
                            found = true;
                            numberOfRightGuesse++;
                            
                            if (numberOfRightGuesse == 6)
                            {
                                Console.WriteLine("Congratulations, You guessed the whole world correctly which was " + secretWord);
                                noOfGuessesLeft = 0;
                            }
                        }
                        
                    }
                    if (found == false)
                    {
                        if (sb.ToString().Contains(input))
                        {
                            Console.WriteLine("U have guessed that letter already \n");
                        } else
                        {
                                 noOfGuessesLeft--;
                                Console.WriteLine("An incorrect letter was guessed, You have " + noOfGuessesLeft + " guesses left \n");
                                sb.Append(new char[] { input.ToCharArray()[0]});
                                Console.WriteLine("Ur incorrect letters so far are " + sb.ToString());
                        }
                        
                       
                    } else
                    {
                        Console.WriteLine(new String(guesswords));
                    }
                   
                }
            }
        }
    }
}
