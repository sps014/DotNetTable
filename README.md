# DotNetTable

 [![NuGet Package](https://img.shields.io/badge/nuget-v1.0.0-orange.svg)](https://www.nuget.org/packages/DotNetTable/)
 
 ```shell
 Install-Package DotNetTable -Version 1.0.0
 ```

 Beautiful Console Tables,Highly Customizable table building characters
 
 #### Pro tip:
 make sure your Table Size is perfectly divisble by the number of cells in each results.
 
 ##### 1. Default Table With Equal Block Width and Colors
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
##### 2. Table With Unequal Row Cells
![capt2](https://user-images.githubusercontent.com/45932883/86245175-b9012480-bbc6-11ea-8ac8-2ca97f5060ff.PNG)
```cs
            //border color optional
            Console.ForegroundColor = ConsoleColor.Green;

            Table table = new Table();

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

```

##### 3. Table With Specific Row Size
![capt3](https://user-images.githubusercontent.com/45932883/86245180-bacae800-bbc6-11ea-9fee-a0a13473b6eb.PNG)

```cs
            //border color optional
            Console.ForegroundColor = ConsoleColor.Cyan;

            Table table = new Table();

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
```
