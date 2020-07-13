using System;
using System.Collections.Generic;
using DotNetTable;

namespace DotNetTableSample
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Default Table With Colors and overall width");
            CreateTable1();
            Console.WriteLine("\nTable with unequal Row Cells");
            CreateTable2();
            Console.WriteLine("\nTable with custom width");
            CreateTable3();
            Console.ReadKey();
        }

        static void CreateTable1()
        {
            //border color optional

            Table table = new Table();
            table.BorderColor = ConsoleColor.Red;

            table.Width = 100;//optional wisth defaults to 60

            TableRow row1 = new TableRow();
            row1.RowData.Add(new TableData("Opinion", ConsoleColor.Magenta));
            row1.RowData.Add(new TableData("C# is awesome", ConsoleColor.Blue));
            row1.RowData.Add(new TableData("C++ is ♥", ConsoleColor.Yellow));
            row1.RowData.Add(new TableData("python rocks", ConsoleColor.Green));
            table.Rows.Add(row1);

            TableRow row2 = new TableRow();
            row2.RowData.Add(new TableData("Yes"));
            row2.RowData.Add(new TableData("88%"));
            row2.RowData.Add(new TableData("70%"));
            row2.RowData.Add(new TableData("63%"));
            table.Rows.Add(row2);

            TableRow row3 = new TableRow();
            row3.RowData.Add(new TableData("No"));
            row3.RowData.Add(new TableData("12%"));
            row3.RowData.Add(new TableData("30%"));
            row3.RowData.Add(new TableData("37%"));
            table.Rows.Add(row3);

            table.Draw();
        }
        static void CreateTable2()
        {
            //border color optional

            Table table = new Table();
            table.BorderColor = ConsoleColor.Green;


            TableRow row1 = new TableRow();
            row1.RowData.Add(new TableData("Opinion", ConsoleColor.Magenta));
            row1.RowData.Add(new TableData("C# is awesome", ConsoleColor.Blue));
            row1.RowData.Add(new TableData("C++ is ♥", ConsoleColor.Yellow));
            table.Rows.Add(row1);

            TableRow row2 = new TableRow();
            row2.RowData.Add(new TableData("Yes"));
            row2.RowData.Add(new TableData("88%"));
            row2.RowData.Add(new TableData("70%"));
            row2.RowData.Add(new TableData("63%"));
            table.Rows.Add(row2);

            TableRow row3 = new TableRow();
            row3.RowData.Add(new TableData("No"));
            row3.RowData.Add(new TableData("12%"));
            row3.RowData.Add(new TableData("30%"));
            row3.RowData.Add(new TableData("37%"));
            table.Rows.Add(row3);

            table.Draw();
        }
        static void CreateTable3()
        {

            Table table = new Table();
            table.BorderColor = ConsoleColor.Cyan;

            TableRow row1 = new TableRow();
            row1.RowData.Add(new TableData("Opinion", ConsoleColor.Magenta) {Width=30 });
            row1.RowData.Add(new TableData("C# is awesome", ConsoleColor.Blue) { Width = 20 });
            row1.RowData.Add(new TableData("C++ is ♥", ConsoleColor.Yellow) { Width = 10 });
            table.Rows.Add(row1);

            TableRow row2 = new TableRow();
            row2.RowData.Add(new TableData("Yes") { Width = 30 });
            row2.RowData.Add(new TableData("88%") { Width = 20 });
            row2.RowData.Add(new TableData("70%") { Width = 10 });
            table.Rows.Add(row2);

            TableRow row3 = new TableRow();
            row3.RowData.Add(new TableData("No") { Width = 30 });
            row3.RowData.Add(new TableData("12%") { Width = 20 });
            row3.RowData.Add(new TableData("30%") { Width = 10 });
            table.Rows.Add(row3);

            table.Draw(false);
        }


    }
}
