using System.Diagnostics;
using System.Text;

const int TEST_CASES = 1000000;
const string PATH= @"C:\Users\wnovoa\Desktop\test.txt";
var sb = new StringBuilder($"{TEST_CASES}\n");

for (int i = 0; i < TEST_CASES; i++)
{
    //random between 2 and 100
    int a = new Random().Next(2, 101);
    sb.AppendLine(a.ToString());
    for (int j = 0; j < a; j++)
    {
        sb.Append(new Random().Next(0, 2));
    }
    sb.AppendLine();
}

File.WriteAllText(PATH, sb.ToString());

Console.WriteLine("Test file written");
//open text file using notepad
Process.Start("notepad.exe", PATH);