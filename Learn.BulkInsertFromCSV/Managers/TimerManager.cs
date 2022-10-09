using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Learn.BulkInsertFromCSV.Managers;

internal static class TimerManager
{
    private static Stopwatch? timer;
    private static DateTime? dateStart;
    public static void StartWatches(string watchesName)
    {
        timer = new Stopwatch();
        timer.Start();
        dateStart = DateTime.Now;//.ToString("dd-MM-yyyy hh:mm:ss-ffff");
        Console.WriteLine($"{watchesName} Timer start at: {dateStart.Value.ToString("dd-MM-yyyy hh:mm:ss-ffff")}");
    }
    public static void StopWatches(string watchesName)
    {
        timer.Stop();
        Console.WriteLine($"{watchesName} Timer end at: {dateStart.Value.AddMilliseconds(timer.ElapsedMilliseconds).ToString("dd-MM-yyyy hh:mm:ss-ffff")}"); 
        Console.WriteLine($"{watchesName} Timer elapsedMiliseconds: {timer.ElapsedMilliseconds}");
        //Console.WriteLine($"Timer ticks: {timer.ElapsedTicks}");
        Console.WriteLine("_____________________________________________________________________________");
    }
}
