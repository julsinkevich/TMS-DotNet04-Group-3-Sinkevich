using System.Collections.Generic;

namespace TryBefore
{
    class Shop
    {
        public string Name { get; set; }

        public List<Terminal> Terminals;

        public Shop()
        {
            Name = "Соседи";
            Terminals = new List<Terminal>();
        }

        public Shop(int termialsCount)
        {
            Name = "Соседи";
            Terminals = new List<Terminal>();
            for (int i = 0; i < termialsCount; i++)
            {
                Terminals.Add(new Terminal());
            }
        }
    }
}