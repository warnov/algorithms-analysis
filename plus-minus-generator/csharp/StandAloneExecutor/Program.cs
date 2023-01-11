using System.Text;

int nTests = int.Parse(FastLineReader());
var result = new StringBuilder();
for (int i = 0; i < nTests; i++)
{
    int length = int.Parse(FastLineReader());
    string a = FastLineReader();
    int total = a[0] - '0';
    for (int j = 1; j < length; j++)
    {
        int current = a[j] - '0';

        //current==0
        if (current == 0)
            result.Append('+');

        //current==1
        else
        {
            var sign = total == 1 ? '-' : '+';
            result.Append(sign);
            total ^= current;
        }
    }
    result.Append('\n');
}
Console.Write(result.ToString());


static string FastLineReader()
{
    string line = String.Empty;
    do
    {
        var keyInfo = Console.ReadKey(true);
        if (keyInfo.Key == ConsoleKey.Enter)
        {
            return line;
        }
        else
        {
            line += keyInfo.KeyChar;
        }

    } while (true);
}