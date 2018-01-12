using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProgramLogicUtilits.Bombuzle
{
    public class Cell
    {
        // Значение в ячейке
        public CellState State { get; set; }
        // Является ли помеченной
        public bool Marked { get; set; }
    }
}
