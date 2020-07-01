# DotNetTable

 Beautiful Console Tables,Highly Customizable table building characters
 
 ### Default Table With Equal Block Width and Colors
![capt1](https://user-images.githubusercontent.com/45932883/86245167-b7cff780-bbc6-11ea-80ef-46aeb3098f81.PNG)

```cs
            //border color optional
            Console.ForegroundColor = ConsoleColor.Red;

            Table table = new Table();

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

```

![capt2](https://user-images.githubusercontent.com/45932883/86245175-b9012480-bbc6-11ea-8ac8-2ca97f5060ff.PNG)
![capt3](https://user-images.githubusercontent.com/45932883/86245180-bacae800-bbc6-11ea-9fee-a0a13473b6eb.PNG)
