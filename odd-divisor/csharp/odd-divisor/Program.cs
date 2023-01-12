using System.Text;

var sb = new StringBuilder();
var t = int.Parse(Console.ReadLine());
while (t-- > 0)
{
    var n = Int64.Parse(Console.ReadLine());
    if ((n & (n - 1)) != 0) sb.AppendLine("YES");
    else sb.AppendLine("NO");
}
Console.Write(sb.ToString());