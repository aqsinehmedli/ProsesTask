using System;
using System.Diagnostics;

class Program
{
    static void Main(string[] args)
    {
        while (true)
        {
            Process[] processes = Process.GetProcesses();

            Console.WriteLine("1. Show Process" +
                "\n2. New Task" +
                "\n3. End Task" +
                "\nSeçiminizi Edin:");
            var choice = Console.ReadLine();
            switch (choice)
            {
                case "1":
                    foreach (var process in processes)
                    {
                        Console.WriteLine($"ProcessName: {process.ProcessName} (ID: {process.Id})");
                    }
                    break;

                case "2":
                    Console.WriteLine("ProcessName:");
                    var processName = Console.ReadLine();
                    try
                    {
                        if (processName != null)
                        {
                            Process.Start(processName);
                            Console.WriteLine("Yeni proses baslandi.");
                        }

                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine($"Proses Basladilmadi: {ex.Message}");
                    }
                    break;

                case "3":
                    Console.WriteLine("Bitirmek istediyiniz prosesin ID'sini daxil edin:");
                    var input = Console.ReadLine();
                    if (int.TryParse(input, out int prosesId))
                    {
                        try
                        {
                            var proses = Process.GetProcessById(prosesId);
                            if (proses != null)
                            {
                                proses.Kill();
                                Console.WriteLine("Proses sonlandırıldı.");
                            }
                        }
                        catch (ArgumentException)
                        {
                            Console.WriteLine("Lazimsiz Id");
                        }
                        catch (Exception ex)
                        {
                            Console.WriteLine($"Proses Bitirilmedi: {ex.Message}");
                        }
                    }
                    else
                    {
                        Console.WriteLine("Zehmet olmasa duzgun Id-i daxil edin.");
                    }
                    break;

                default:
                    Console.WriteLine("Yalnis Secim.");
                    break;
            }
        }
    }
}
