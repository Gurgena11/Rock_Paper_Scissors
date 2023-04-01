using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;
using System.IO;

namespace Jeirani
{
    public class R_P_S
    {
        public int ComputerPoint { get; set; }
        public int PlayersPoint { get; set; }
        private string PlayerChoice { get; set; }
        private int Computerchoose { get; set; }

        public  R_P_S Play(R_P_S jeirani)
        {
            string[] choices = { "rock", "paper", "scissors" };

            bool gameOver = false;
            while (!gameOver)
            {
                Random rand = new Random();
                Computerchoose = rand.Next(0, 2);
                Console.WriteLine("Enter your choice: rock, paper, scissors");
                PlayerChoice = Console.ReadLine().ToLower();
                Console.WriteLine("Computer chose " + choices[Computerchoose]);

                if (PlayerChoice == "rock")
                {
                    if (Computerchoose == 0)
                    {
                        Console.WriteLine("Tie!");
                    }
                    else if (Computerchoose == 1)
                    {
                        Console.WriteLine("Computer wins!");
                        ComputerPoint++;
                    }
                    else
                    {
                        Console.WriteLine("Player wins!");
                        PlayersPoint++;
                    }
                }
                else if (PlayerChoice == "paper")
                {
                    if (Computerchoose == 0)
                    {
                        Console.WriteLine("Player wins!");
                        PlayersPoint++;
                    }
                    else if (Computerchoose == 1)
                    {
                        Console.WriteLine("Tie!");
                    }
                    else
                    {
                        Console.WriteLine("Computer wins!");
                        ComputerPoint++;
                    }
                }
                else if (PlayerChoice == "scissors")
                {
                    if (Computerchoose == 0)
                    {
                        Console.WriteLine("Computer wins!");
                        ComputerPoint++;
                    }
                    else if (Computerchoose == 1)
                    {
                        Console.WriteLine("Player wins!");
                        PlayersPoint++;
                    }
                    else
                    {
                        Console.WriteLine("Tie!");
                    }
                }
                else
                {
                    Console.WriteLine("Invalid choice. Please enter rock, paper, or scissors.");
                }
                Console.WriteLine($"players points: {PlayersPoint} - computers points {ComputerPoint}");
                if (PlayersPoint == 3)
                {
                    Console.WriteLine("player wins-- game is over");
                    gameOver = true;
                }
                else if (ComputerPoint == 3)
                {
                    Console.WriteLine("you lost the game");
                    gameOver = true;
                }
            }
            return jeirani;

        }

        public void Serializeor(R_P_S jeirani)
        {
            XmlSerializer serializer = new XmlSerializer(typeof(R_P_S));
            Stream stream = File.OpenWrite("R-P-G.xml");

            serializer.Serialize(stream, jeirani);
            stream.Dispose();
        }
        public R_P_S Deserializeor()
        {
            XmlSerializer serializer = new XmlSerializer(typeof(R_P_S));
            Stream stream = File.OpenRead("R-P-G.xml");
            R_P_S jeiran = (R_P_S)serializer.Deserialize(stream);
            stream.Dispose();

            return jeiran;
        }

        public void Start()
        {
            if (File.Exists("R-P-G.xml"))
            {
                Play(Deserializeor());
            }
            else
            {
                R_P_S forserialize = Play(this);
                Serializeor(forserialize);
            }
        }
    }
}
