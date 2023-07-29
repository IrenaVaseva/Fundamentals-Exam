using System.Collections.Generic;
using System.Net.NetworkInformation;

namespace _03._The_Pianist
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            Dictionary<string, Piece> dicPiecees = new Dictionary<string, Piece>();

            for (int i = 0; i < n; i++)
            {
                string[] piesesList = Console.ReadLine().Split("|").ToArray();
                Piece pieceN = new Piece(piesesList[0], piesesList[1], piesesList[2]);
                dicPiecees.Add(piesesList[0], pieceN);
            }
            //***
            string input = string.Empty;

            while ((input = Console.ReadLine()) != "Stop")
            {
                string[] detailsPiece = input.Split("|").ToArray();

                string command = detailsPiece[0];
                string piece = detailsPiece[1];

                switch (command)
                {
                    case "Add":
                        string composer = detailsPiece[2];
                        string key = detailsPiece[3];
                        dicPiecees = AddPiece(dicPiecees, piece, composer, key);
                        break;
                    case "Remove":
                        dicPiecees = RemovePiece(dicPiecees, piece);
                        break;
                    case "ChangeKey":
                        string newKey = detailsPiece[2];
                        dicPiecees = ChangeKey(dicPiecees, piece, newKey);
                        break;
                }
            }

            foreach (var piece in dicPiecees)
            {
                Console.WriteLine($"{piece.Value.Name} -> Composer: {piece.Value.Composer}, Key: {piece.Value.KeyP}");
            }
        }

        private static Dictionary<string, Piece> ChangeKey(Dictionary<string, Piece> dicPiecees, string piece, string newKey)
        {
            if (!dicPiecees.ContainsKey(piece))
            {
                Console.WriteLine($"Invalid operation! {piece} does not exist in the collection.");
            }
            else
            {
                dicPiecees[piece].KeyP = newKey;
                Console.WriteLine($"Changed the key of {piece} to {newKey}!");
            }

            return dicPiecees;
        }

        private static Dictionary<string, Piece> RemovePiece(Dictionary<string, Piece> dicPiecees, string piece)
        {
            if (!dicPiecees.ContainsKey(piece))
            {
                Console.WriteLine($"Invalid operation! {piece} does not exist in the collection.");
            }
            else
            {
                dicPiecees.Remove(piece);
                Console.WriteLine($"Successfully removed {piece}!");
            }

            return dicPiecees;
        }

        private static Dictionary<string, Piece> AddPiece(Dictionary<string, Piece> dicPiecees, string piece, string composer, string key)
        {
            if (!dicPiecees.ContainsKey(piece))
            {
                Piece newPiece = new Piece(piece, composer, key);
                dicPiecees.Add(piece, newPiece);

                Console.WriteLine($"{piece} by {composer} in {key} added to the collection!");
            }
            else
            {
                Console.WriteLine($"{piece} is already in the collection!");
            }

            return dicPiecees;
        }
    }

    public class Piece
    {
        public Piece(string name, string composer, string key)
        {
            Name = name;
            Composer = composer;
            KeyP = key;
        }

        public string Name { get; set; }
        public string Composer { get; set; }
        public string KeyP { get; set; }
    }
}