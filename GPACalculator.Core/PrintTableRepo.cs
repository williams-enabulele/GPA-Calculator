using System;
using System.Collections.Generic;
using System.Linq;

namespace GPACalculator.Core
{
    internal class TablePrinter
    {
        private readonly string[] titles;
        private readonly List<int> lengths;
        private readonly List<string[]> rows = new List<string[]>();

        /// <summary>
        /// Adds Tables Columns
        /// </summary>
        /// <param name="titles"></param>
        public TablePrinter(params string[] titles)
        {
            this.titles = titles;
            lengths = titles.Select(title => title.Length).ToList();
        }

        /// <summary>
        /// Add Table rows
        /// </summary>
        /// <param name="row"></param>
        public void AddRow(params object[] row)
        {
            // Check For Equility in Rows and Columns
            if (row.Length != titles.Length)
            {
                throw new Exception($"Added row length [{row.Length}] is not equal to title row length [{titles.Length}]");
            }
            rows.Add(row.Select(obj => obj.ToString()).ToArray());
            for (int i = 0; i < titles.Length; i++)
            {
                if (rows.Last()[i].Length > lengths[i])
                {
                    lengths[i] = rows.Last()[i].Length;
                }
            }
        }

        /// <summary>
        /// Print Records
        /// </summary>
        public void Print()
        {
            lengths.ForEach(l => Console.Write("+-" + new string('-', l) + '-'));
            Console.WriteLine("+");

            string line = "";
            for (int i = 0; i < titles.Length; i++)
            {
                line += "| " + titles[i].PadRight(lengths[i]) + ' ';
            }
            Console.WriteLine(line + "|");

            lengths.ForEach(l => Console.Write("+-" + new string('-', l) + '-'));
            Console.WriteLine("+");

            foreach (var row in rows)
            {
                line = "";
                for (int i = 0; i < row.Length; i++)
                {
                    if (int.TryParse(row[i], out int n))
                    {
                        line += "| " + row[i].PadLeft(lengths[i]) + ' ';  // numbers are padded to the left
                    }
                    else
                    {
                        line += "| " + row[i].PadRight(lengths[i]) + ' ';
                    }
                }
                Console.WriteLine(line + "|");
            }

            lengths.ForEach(l => Console.Write("+-" + new string('-', l) + '-'));
            Console.WriteLine("+");
        }
    }
}