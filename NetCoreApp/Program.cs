using System;
using System.Diagnostics;


namespace NetCoreApp
{
    internal class Program
    {
        //static string plcIp = "127.0.0.1"; // Snap7 Server
        static string plcIp = "10.90.233.181"; //S7-1214
        //static string plcIp = "192.168.1.10"; //S7-410
        static int plcRack = 0;
        static int plcSlot = 0;

        static void Main(string[] args)
        {
            Snap7Test(1000, 200, Snap7.S7Client.S7AreaMK, 1);
            Sharp7v110Test(1000, 200, Sharp7_v110.S7Consts.S7AreaMK, 1);
            Sharp7Test(1000, 200, Sharp7.S7Consts.S7AreaMK, 1);

            Console.Write("Done!");
            Console.ReadLine();
        }


        static void Snap7Test(int targetReadCount, int byteAmount, int area, int dbNo = 1)
        {
            var count = 0;
            var client = new Snap7.S7Client();

            Console.WriteLine($"Snap7 {byteAmount} bytes will be read {targetReadCount} times...");

            var result = client.ConnectTo(plcIp, plcRack, plcSlot);
            Console.WriteLine(client.ErrorText(result));

            if (result != 0)
                return;

            var sw = Stopwatch.StartNew();

            byte[] buffer = new byte[byteAmount];

            while (count < targetReadCount)
            {
                result = client.ReadArea(area, dbNo, 0, byteAmount, Snap7.S7Client.S7WLByte, buffer);

                if (result != 0)
                {
                    Console.WriteLine(client.ErrorText(result));
                    return;
                }

                count++;
            }

            sw.Stop();

            Console.WriteLine($"Snap7 {byteAmount} bytes {targetReadCount} times read in {sw.ElapsedMilliseconds} ms\n");
        }

        static void Sharp7Test(int targetReadCount, int byteAmount, int area, int dbNo = 1)
        {
            var count = 0;
            var client = new Sharp7.S7Client();

            Console.WriteLine($"Sharp7 {byteAmount} bytes will be read {targetReadCount} times...");

            var result = client.ConnectTo(plcIp, plcRack, plcSlot);
            Console.WriteLine(client.ErrorText(result));

            if (result != 0)
                return;

            var sw = Stopwatch.StartNew();

            byte[] buffer = new byte[byteAmount];

            while (count < targetReadCount)
            {
                result = client.ReadArea(area, dbNo, 0, byteAmount, Sharp7.S7Consts.S7WLByte, buffer);

                if (result != 0)
                {
                    Console.WriteLine(client.ErrorText(result));
                    return;
                }

                count++;
            }

            sw.Stop();

            Console.WriteLine($"Sharp7 {byteAmount} bytes {targetReadCount} times read in {sw.ElapsedMilliseconds} ms\n");
        }

        static void Sharp7v110Test(int targetReadCount, int byteAmount, int area, int dbNo = 1)
        {
            var count = 0;
            var client = new Sharp7_v110.S7Client();

            Console.WriteLine($"Sharp7_v110 {byteAmount} bytes will be read {targetReadCount} times...");

            var result = client.ConnectTo(plcIp, plcRack, plcSlot);
            Console.WriteLine(client.ErrorText(result));

            if (result != 0)
                return;

            var sw = Stopwatch.StartNew();

            byte[] buffer = new byte[byteAmount];

            while (count < targetReadCount)
            {
                result = client.ReadArea(area, dbNo, 0, byteAmount, Sharp7_v110.S7Consts.S7WLByte, buffer);

                if (result != 0)
                {
                    Console.WriteLine(client.ErrorText(result));
                    return;
                }

                count++;
            }

            sw.Stop();

            Console.WriteLine($"Sharp7_v110 {byteAmount} bytes {targetReadCount} times read in {sw.ElapsedMilliseconds} ms\n");
        }
    }
}
