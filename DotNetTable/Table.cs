using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DotNetTable
{
    public class Table
    {
        public char TableHorizontalChar { get; set; } = '─';
        public char TableVerticalChar{ get; set; } = '│';
        public char TableTopRightChar { get; set; } = '┐';
        public char TableBottomRightChar { get; set; } = '┘';
        public char TableTopLeftChar { get; set; } = '┌';
        public char TableBottomLeftChar { get; set; } = '└';
        public char TableMidJoinUpper { get; set; } = '┬';
        public char TableMidJoinLower { get; set; } = '┴';
        public char TableCentralJoin { get; set; } = '┼';
        public char TableRightJoin { get; set; } = '┤';
        public char TableLeftJoin { get; set; } = '├';
        public int Width { get; set; } = 60;
        public ConsoleColor BorderColor { get; set; } = ConsoleColor.White;
        public List<TableRow> Rows { get; private set; } = new List<TableRow>();
        public void Draw(bool autoWidth=true, List<TableRow> rows=null)
        {
            if (rows != null)
                Rows = rows;
            else
                rows = Rows;

            if (Rows == null)
                return;


            if (autoWidth)
                AdjustWidth(rows);

            DrawTopHorizontal(rows.First());
            PrintContent(rows.First());
            for(int i=1;i<rows.Count;i++)
            {
                DrawMidHorizontal(rows[i], rows[i - 1]);
                PrintContent(rows[i]);

            }
            DrawBottomHorizontal(rows.Last());
        }

        void AdjustWidth(List<TableRow> rows)
        {
            foreach (var item in rows)
            {
                int width = Width / item.RowData.Count;
                foreach (var data in item.RowData)
                {
                    data.Width = width;
                }
            }
        }
        void DrawTopHorizontal(TableRow top)
        {
            int totalWidth = SumRow(top);
            char[] buffer = new char[totalWidth];
            
            buffer[0] = TableTopLeftChar;
            buffer[totalWidth - 1] = TableTopRightChar;
            int curWidth = top.RowData[0].Width-1;
            int no = 0;
            for (int i = 1; i < totalWidth-1; i++,curWidth--)
            {
                if (curWidth == 0)
                {
                    buffer[i] = TableMidJoinUpper;
                    curWidth=top.RowData[++no].Width;
                }
                else
                {
                    buffer[i] = TableHorizontalChar;
                }
            }
            Console.ForegroundColor = BorderColor;
            Console.WriteLine(new string(buffer));
        }
        void DrawBottomHorizontal(TableRow bottom)
        {
            int totalWidth = SumRow(bottom);
            char[] buffer = new char[totalWidth];

            buffer[0] = TableBottomLeftChar;
            buffer[totalWidth - 1] = TableBottomRightChar;
            int curWidth = bottom.RowData[0].Width - 1;
            int no = 0;
            for (int i = 1; i < totalWidth - 1; i++, curWidth--)
            {
                if (curWidth == 0)
                {
                    buffer[i] = TableMidJoinLower;
                    curWidth = bottom.RowData[++no].Width;
                }
                else
                {
                    buffer[i] = TableHorizontalChar;
                }
            }
            Console.ForegroundColor = BorderColor;
            Console.WriteLine(new string(buffer));

        }
        void DrawMidHorizontal(TableRow mid, TableRow upper)
        {
            int totalWidthMid = SumRow(mid);
            int totalWidthUpper = SumRow(upper);
            int maxWidth = Math.Max(totalWidthMid, totalWidthUpper);

            char[] buffer = new char[maxWidth];

            buffer[0] = TableLeftJoin;
            buffer[maxWidth - 1] = TableRightJoin;

            int curWidthMid = mid.RowData[0].Width - 1;
            int curWidthUpper = upper.RowData[0].Width - 1;

            int no = 0,no_upper=0;
            for (int i = 1; i < maxWidth - 1; i++, curWidthMid--,curWidthUpper--)
            {
                if(curWidthUpper==0 && curWidthMid==0)
                {
                    buffer[i] = TableCentralJoin;
                    curWidthMid = mid.RowData[++no].Width;
                    curWidthUpper = upper.RowData[++no_upper].Width;
                }
                else if (curWidthMid == 0)
                {
                    buffer[i] = TableMidJoinUpper;
                    curWidthMid = mid.RowData[++no].Width;
                }
                else if(curWidthUpper==0)
                {
                    buffer[i] = TableMidJoinLower;
                    curWidthUpper = upper.RowData[++no_upper].Width;
                }
                else
                {
                    buffer[i] = TableHorizontalChar;
                }
            }
            Console.ForegroundColor = BorderColor;
            Console.WriteLine(new string(buffer));
        }

        void PrintContent(TableRow tableRow)
        {
            int totalWidth = SumRow(tableRow);
            char[] buffer = new char[totalWidth];

            buffer[0] = TableVerticalChar;
            buffer[totalWidth - 1] = TableVerticalChar;
            int curWidth = tableRow.RowData[0].Width - 1;
            tableRow.RowData[0].Value=tableRow.RowData[0].Value.PadRight(curWidth+1);
            var stringIndex = 0;
            int no = 0;
            for (int i = 1; i < totalWidth - 1; i++, curWidth--)
            {
                if (curWidth == 0)
                {
                    buffer[i] = TableVerticalChar;
                    curWidth = tableRow.RowData[++no].Width;
                    stringIndex = 0;
                    tableRow.RowData[no].Value=tableRow.RowData[no].Value.PadRight(curWidth);
                }
                else
                {
                    buffer[i] = tableRow.RowData[no].Value[stringIndex++];
                }
            }

            var generatedString = new string(buffer).Split(TableVerticalChar).Where(x=>x.Length>0).ToList();
            Console.Write(TableVerticalChar);
            for (int i = 0; i < generatedString.Count; i++)
            {
                Console.ForegroundColor = tableRow.RowData[i].ForegroundColor;
                Console.BackgroundColor = tableRow.RowData[i].BackgroundColor;
                string item = generatedString[i];
                Console.Write(item);
                Console.ForegroundColor=BorderColor;
                Console.Write(TableVerticalChar);
            }
            Console.Write("\n");
            Console.ResetColor();

        }
        int SumRow(TableRow tr)
        {
            return tr.RowData.Sum(x => x.Width);
        }

    }


    public class TableRow
    {
        public List<TableData> RowData { get; set; } = new List<TableData>();
        public TableRow(List<TableData> rowsData=null)
        {
            if (rowsData == null)
                return;

            RowData = rowsData;
        }
        public TableRow(TableData[] rowsData)
        {
            if (rowsData == null)
                return;

            RowData = rowsData.ToList();
        }
    }
    public class TableData
    {
        public string Value { get; set; }
        public ConsoleColor ForegroundColor { get; set; } = ConsoleColor.White;
        public ConsoleColor BackgroundColor { get; set; } = ConsoleColor.Black;
        public int Width { get; set; } = 30;
        public TableData()
        {
            Value = "";
        }
        public TableData(string value,ConsoleColor foregroundColor=ConsoleColor.White, ConsoleColor backgroundColor = ConsoleColor.Black)
        {
            Value = value;
            ForegroundColor = foregroundColor;
            BackgroundColor = backgroundColor;
        }

    }
}
