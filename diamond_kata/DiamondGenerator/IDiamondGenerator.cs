using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace diamond_kata.DiamondGenerator
{
    internal interface IDiamondGenerator
    {
        internal string[] CreateDiamond(char inputChar);
    }
}
