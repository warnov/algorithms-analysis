#pragma warning disable CS8602
#pragma warning disable CS8321
#pragma warning disable IDE0059
#pragma warning disable CS8604 
#pragma warning disable CS8600

using SignsGenerator;
using System;
using System.Diagnostics;
using System.Text;

const int ITERATIONS = 100;
;
const string PATH = @"C:\Users\wnovoa\Desktop\test.txt";
string[] lines = System.IO.File.ReadAllLines(PATH);
const int N_TESTS = 1000000;
const int LENGTH_TO_SHOW = 200;
var parameters = new object[] { lines, N_TESTS };
var sw = new Stopwatch();
var methodsToInvoke = new string[]
{
    //"OpenCharList",
  //  "OpenStringBuilderWithStrings",
  "PointersXorCharConv",
     "PointersXor",

    "XorCharStringBuilder",
    "PointersXorTotal0",
    "PointersUnsafeCode",
    "OpenStringBuilderWithChars"
};
Dictionary<string, List<long>> stats = new();


//OrderedExecution(methodsToInvoke, sw, stats, parameters);
RandomExecution(methodsToInvoke, sw, stats, parameters);

QuickReport(stats);



static void OrderedExecution(string[] methodsToInvoke, Stopwatch sw, Dictionary<string, List<long>> stats, object[] parameters)
{
    foreach (var methodName in methodsToInvoke)
    {

        stats.Add(methodName, new List<long>());



        for (int i = 0; i < ITERATIONS; i++)
        {


            //Preparing execution
            var method = typeof(Methods).GetMethod(methodName);
            Methods.CleanMemory();
            sw.Start();




            //Executing
            var resultObject = method.Invoke(null, parameters);





            //Post-Execution
            //=====================================

            //Stoping stopwatch
            sw.Stop();
            stats[methodName].Add(sw.ElapsedMilliseconds);


            //Extracting result
            //string result = string.Empty;
            //if (resultObject.GetType() == typeof(char[]))
            //{
            //    result = new string((char[])resultObject);
            //}
            //else if (resultObject.GetType() == typeof(List<char>))
            //{
            //    var listCharResult = (List<char>)resultObject;
            //    result = new string((char[])listCharResult.ToArray());
            //}
            //string result = resultObject.ToString();
            //PrintResultPreview(resultObject.ToString());
            //SaveResultToFile(result.ToString());
            //Console.WriteLine($"{methodName} iteration {i} took {sw.ElapsedMilliseconds} ms");
            //Measuring Memory Taken
            //var before = GlobalState.BeforeMemory / 1000;
            //var after = GlobalState.AfterMemory / 1000;
            //Console.WriteLine($"Taken Memory: {after - before}Kb");
            /*Console.WriteLine("Press any key to continue");
            Console.ReadKey();*/
            sw.Reset();
            Console.WriteLine($"{methodName}:{i}                                    ");
            Console.SetCursorPosition(0, Console.CursorTop - 1);
        }
        //AssembleReport(stats);

    }
}

static void RandomExecution(string[] methodsToInvoke, Stopwatch sw, Dictionary<string, List<long>> stats, object[] parameters)
{
    for (int i = 0; i < ITERATIONS; i++)
    {
        //Setup list
        var methodList = ShuffleArray(methodsToInvoke);
        //Console.WriteLine(String.Join(',', methodList));
        //Console.ReadKey();

        foreach (var methodName in methodList)
        {
            if (!stats.ContainsKey(methodName))
            {
                stats.Add(methodName, new List<long>());
            }

            //Preparing execution
            var method = typeof(Methods).GetMethod(methodName);
            Methods.CleanMemory();
            sw.Start();

            //Executing
            var resultObject = method.Invoke(null, parameters);

            //Post-Execution
            //=====================================

            //Stoping stopwatch
            sw.Stop();
            stats[methodName].Add(sw.ElapsedMilliseconds);
            

            //Extracting result
            //string result = string.Empty;
            //if (resultObject.GetType() == typeof(char[]))
            //{
            //    result = new string((char[])resultObject);
            //}
            //else if (resultObject.GetType() == typeof(List<char>))
            //{
            //    var listCharResult = (List<char>)resultObject;
            //    result = new string((char[])listCharResult.ToArray());
            //}
            //string result = resultObject.ToString();
            //PrintResultPreview(resultObject.ToString());
            //SaveResultToFile(result.ToString());
            //Console.WriteLine($"{methodName} iteration {i} took {sw.ElapsedMilliseconds} ms");
            //Measuring Memory Taken
            //var before = GlobalState.BeforeMemory / 1000;
            //var after = GlobalState.AfterMemory / 1000;
            //Console.WriteLine($"Taken Memory: {after - before}Kb");
            /*Console.WriteLine("Press any key to continue");
            Console.ReadKey();*/
            sw.Reset();
            Console.WriteLine($"{methodName}:{i}                                    ");
            Console.SetCursorPosition(0, Console.CursorTop - 1);
        }
        //AssembleReport(stats);

    }
}


static void QuickReport(Dictionary<string, List<long>> stats)
{
    foreach (var method in stats)
    {
        var average = method.Value.Average();
        Console.WriteLine($"{method.Key} took {average} ms on average");
    }
}

static void AssembleReport(Dictionary<string, List<long>> stats)
{
    var sb = new StringBuilder();
    foreach (var method in stats.Keys)
    {
        sb.Append($"{method};");
        foreach (var result in stats[method])
        {
            sb.Append($"{result};");
        }
        sb.AppendLine();
    }
    System.IO.File.WriteAllText(@"C:\Users\wnovoa\Desktop\report.txt", sb.ToString());
}




static void SaveResultToFile(string result)
{
    string resultPath = PATH.Replace("test.txt", "testResult.txt");
    File.WriteAllText(resultPath, result);
    //Open path in file explorer
    //Get folder of a file
    var directory = Path.GetDirectoryName(resultPath);
    Process.Start("explorer.exe", directory);
}




static void PrintResultPreview(string result)
{
    var printLength = result.Length > LENGTH_TO_SHOW ? LENGTH_TO_SHOW : result.Length;
    Console.WriteLine(result.Substring(0, printLength));
}




static int M3(int x)
{
    return x + 4;
}


//Method to shuffle a list
static List<string> ShuffleArray(string[] array)
{
    var list = new List<string>(array);
    var rng = new Random();
    var n = list.Count;
    while (n > 1)
    {
        n--;
        var k = rng.Next(n + 1);
        var value = list[k];
        list[k] = list[n];
        list[n] = value;
    }
    return list;
}

public class Methods
{


    private static void StartMemoryMeasure()
    {
        GlobalState.BeforeMemory = System.Diagnostics.Process.GetCurrentProcess().VirtualMemorySize64;
    }

    private static void FinishMemoryMeasure()
    {
        GlobalState.AfterMemory = System.Diagnostics.Process.GetCurrentProcess().VirtualMemorySize64;
        CleanMemory();
    }
    internal static void CleanMemory()
    {
        GC.Collect();
        GC.WaitForPendingFinalizers();
        GC.Collect();
    }

    /// <summary>
    /// All operations opened. StringBuilder Used adding chars.
    /// </summary>
    /// <param name="lines"></param>
    /// <returns></returns>
    public static string OpenStringBuilderWithChars(string[] lines, int nTests)
    {
        //StartMemoryMeasure();
        var sb = new StringBuilder();
        int cursor = 1;
        for (int i = 0; i < nTests; i++)
        {
            var length = int.Parse(lines[cursor++]);
            string a = lines[cursor++];
            int total = a[0] - '0';
            for (int j = 1; j < length; j++)
            {
                int current = a[j] - '0';
                if (total == 0)
                {
                    sb.Append('+');
                    if (current == 1)
                    {
                        total = 1;
                    }
                }
                else
                {
                    if (current == 0)
                    {
                        sb.Append('+');
                    }
                    if (current == 1)
                    {
                        sb.Append('-');
                        total = 0;
                    }
                }
            }
            sb.AppendLine();
        }
        // FinishMemoryMeasure();
        return sb.ToString();
    }

    /// <summary>
    /// All operations opened. StringBuilder Used adding strings.
    /// It is very notable that even when the CA1834 is not applied, 
    /// the performance is better than the method 1 that applies it.
    /// </summary>
    /// <param name="lines"></param>
    /// <returns></returns>
    public static string OpenStringBuilderWithStrings(string[] lines, int nTests)
    {
        // StartMemoryMeasure();
        var sb = new StringBuilder();
        int cursor = 1;
        for (int i = 0; i < nTests; i++)
        {
            var length = int.Parse(lines[cursor++]);
            string a = lines[cursor++];
            int total = a[0] - '0';
            for (int j = 1; j < length; j++)
            {
                int current = a[j] - '0';
                if (total == 0)
                {
                    sb.Append("+");
                    if (current == 1)
                    {
                        total = 1;
                    }
                }
                else
                {
                    if (current == 0)
                    {
                        sb.Append("+");
                    }
                    if (current == 1)
                    {
                        sb.Append("-");
                        total = 0;
                    }
                }
            }
            sb.AppendLine();
        }
        //FinishMemoryMeasure();
        return sb.ToString();
    }

    /// <summary>
    /// Using pointers and unsafe code
    /// </summary>
    /// <param name="lines"></param>
    /// <returns></returns>
    public static unsafe string PointersUnsafeCode(string[] lines, int nTests)
    {
        //StartMemoryMeasure();

        var result = new char[60000000];
        fixed (char* pResult = result)
        {
            int cursor = 1;
            var resultCursor = pResult;
            for (int i = 0; i < nTests; i++)
            {
                int length = int.Parse(lines[cursor++]);
                string a = lines[cursor++];
                int total = a[0] - '0';
                for (int j = 1; j < length; j++)
                {

                    int current = a[j] - '0';

                    //current==0
                    if (current == 0)
                        *(resultCursor++) = '+';

                    //current==1
                    else
                    {
                        if (total == 0)
                        {
                            *(resultCursor++) = '+';
                            total = 1;
                        }
                        else
                        {
                            *(resultCursor++) = '-';
                            total = 0;
                        }
                    }
                }
                *(resultCursor++) = '\n';
            }
        }
        //FinishMemoryMeasure();

        return new string(result);
    }


    /// <summary>
    /// Using a list of char
    /// </summary>
    /// <param name="lines"></param>
    /// <param name="nTests"></param>
    /// <returns></returns>
    public static string OpenCharList(string[] lines, int nTests)
    {
        //StartMemoryMeasure();

        var result = new List<char>();

        int cursor = 1;

        for (int i = 0; i < nTests; i++)
        {
            int length = int.Parse(lines[cursor++]);
            string a = lines[cursor++];
            int total = a[0] - '0';
            for (int j = 1; j < length; j++)
            {

                int current = a[j] - '0';

                //current==0
                if (current == 0)
                    result.Add('+');

                //current==1
                else
                {
                    if (total == 0)
                    {
                        result.Add('+');
                        total = 1;
                    }
                    else
                    {
                        result.Add('-');
                        total = 0;
                    }
                }
            }
            result.Add('\n');
        }
        //FinishMemoryMeasure();

        return new string(result.ToArray());
    }

    /// <summary>
    /// Using a list of string
    /// </summary>
    /// <param name="lines"></param>
    /// <param name="nTests"></param>
    /// <returns></returns>
    public static string OpenStringList(string[] lines, int nTests)
    {
        //StartMemoryMeasure();

        var result = new List<string>();

        int cursor = 1;

        for (int i = 0; i < nTests; i++)
        {
            int length = int.Parse(lines[cursor++]);
            string a = lines[cursor++];
            int total = a[0] - '0';
            for (int j = 1; j < length; j++)
            {

                int current = a[j] - '0';

                //current==0
                if (current == 0)
                    result.Add("+");

                //current==1
                else
                {
                    if (total == 0)
                    {
                        result.Add("+");
                        total = 1;
                    }
                    else
                    {
                        result.Add("-");
                        total = 0;
                    }
                }
            }
            result.Add("\n");
        }
        //FinishMemoryMeasure();

        return String.Join(null, result);
    }

    public static string XorCharStringBuilder(string[] lines, int nTests)
    {

        var sb = new StringBuilder();
        int cursor = 1;
        for (int i = 0; i < nTests; i++)
        {
            int length = int.Parse(lines[cursor++]);
            string a = lines[cursor++];
            int total = a[0] - '0';
            for (int j = 1; j < length; j++)
            {
                int current = a[j] - '0';

                //current==0
                if (current == 0)
                    sb.Append('+');

                //current==1
                else
                {
                    var sign = total == 1 ? '-' : '+';
                    sb.Append(sign);
                    total ^= current;
                }
            }
            sb.Append('\n');
        }
        return sb.ToString();
    }

    public static unsafe string PointersXor(string[] lines, int nTests)
    {

        var result = new char[60000000];
        fixed (char* pResult = result)
        {
            int cursor = 1;
            var resultCursor = pResult;
            for (int i = 0; i < nTests; i++)
            {
                int length = int.Parse(lines[cursor++]);
                string a = lines[cursor++];
                int total = a[0] - '0';
                for (int j = 1; j < length; j++)
                {

                    int current = a[j] - '0';

                    //current==0
                    if (current == 0)
                        *(resultCursor++) = '+';


                    //current==1
                    else
                    {
                        var sign = total == 1 ? '-' : '+';
                        *(resultCursor++) = sign;
                        total ^= current;
                    }
                }
                *(resultCursor++) = '\n';
            }
        }
        //FinishMemoryMeasure();

        return new string(result);
    }

    public static unsafe string PointersXorCharConv(string[] lines, int nTests)
    {

        var result = new char[60000000];
        fixed (char* pResult = result)
        {
            int cursor = 1;
            var resultCursor = pResult;
            for (int i = 0; i < nTests; i++)
            {
                int length = int.Parse(lines[cursor++]);
                string a = lines[cursor++];
                int total = a[0] - '0';
                for (int j = 1; j < length; j++)
                {

                    int current = a[j] - '0';

                    //current==0
                    if (current == 0)
                        *(resultCursor++) = '+';


                    //current==1
                    else
                    {
                        //var sign = total == 1 ? '-' : '+';
                        var sign = (char)(43 + 2 * total);
                        *(resultCursor++) = sign;
                        total ^= current;
                    }
                }
                *(resultCursor++) = '\n';
            }
        }
        //FinishMemoryMeasure();

        return new string(result);
    }

    public static unsafe string PointersXorTotal0(string[] lines, int nTests)
    {

        var result = new char[60000000];
        fixed (char* pResult = result)
        {
            int cursor = 1;
            var resultCursor = pResult;
            for (int i = 0; i < nTests; i++)
            {
                int length = int.Parse(lines[cursor++]);
                string a = lines[cursor++];
                bool total0 = a[0] == '0';
                for (int j = 1; j < length; j++)
                {

                    if (a[j] == '0')
                        *(resultCursor++) = '+';

                    else
                    {
                        var sign = total0 ? '+' : '-';
                        total0 = !total0;
                        *(resultCursor++) = sign;
                    }
                }
                *(resultCursor++) = '\n';
            }
        }
        //FinishMemoryMeasure();

        return new string(result);
    }



}