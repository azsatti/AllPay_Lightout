using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LightOutConsole
{
    class Program
    {
        const int _rows = 5;
        const int _columns = 5;
        const int _gridSize = _rows * _columns;

        static void Main(string[] args)
        {
            // Calculate the patterns for each light
            var gridLights = new int[_gridSize];
            for (var r = 0; r < _rows; r++)
            for (var c = 0; c < _columns; c++)
            {
                gridLights[GetIndex(r, c)] = GetLightoutPattern(r, c);
            }
        }

        private static int GetLightoutPattern(int h, int w)
        {
            var result = SetLightBit(h, w) |
                         SetLightBit(h - 1, w) |
                         SetLightBit(h + 1, w) |
                         SetLightBit(h, w - 1) |
                         SetLightBit(h, w + 1);
            return result;
        }

        private static void PrintLights(int p)
        {
            for (var r = 0; r < _rows; r++)
            {
                for (var c = 0; c < _columns; c++)
                {
                    Console.Write((p & SetLightBit(r, c)) != 0 ? "1 " : "0 ");
                }
                Console.WriteLine();
            }
        }

        private static int SetLightBit(int r, int c)
        {
            if (r < 0 || c < 0 || r >= _rows || c >= _columns)
                return 0;
            return 1 << GetIndex(r, c);
        }

        private static int GetIndex(int r, int c)
        {
            return _columns * r + c;
        }
    }
}
