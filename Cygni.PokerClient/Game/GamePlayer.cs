using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cygni.PokerClient.Game
{
    public class GamePlayer
    {
        public string Name { get; set; }
        public long ChipCount { get; set; }

        public override bool Equals(object obj)
        {
            var gp = obj as GamePlayer;
            if (gp == null)
                return false;

            return Name == gp.Name;
        }

        public override int GetHashCode()
        {
            return Name.GetHashCode();
        }

        public override string ToString()
        {
            return Name;
        }
    }
}
