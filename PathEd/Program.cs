using System;
using System.IO;
using System.Reflection;

namespace PathEd
{
    // 定義主程式類別
    static class Program
    {
        // 引入外部DLL函式，用於設定程式的DPI感知能力
        [System.Runtime.InteropServices.DllImport("user32.dll")]
        private static extern bool SetProcessDPIAware();

        // 程式入口點
        static void Main(string[] args)
        {
            bool isMachine = false; // 是否為系統環境變數
            int mode = 0; // -1: 刪除路徑, 0: 顯示路徑, 1: 新增路徑
            string path = "";

            // 檢查每個引數
            foreach (string arg in args)
            {
                if (arg.Length > 2 && !arg.StartsWith("--"))
                {
                    path = arg;
                    continue;
                }
                string nArg = arg.Replace('-', '/');
                if (nArg.Equals("/?", StringComparison.OrdinalIgnoreCase))
                {
                    ShowHowToUse();
                    return;
                }
                else if (nArg.Equals("/a", StringComparison.OrdinalIgnoreCase) || nArg.StartsWith("--add", StringComparison.OrdinalIgnoreCase))
                {
                    mode = 1;
                    isMachine = nArg.Equals("/A", StringComparison.Ordinal) || nArg.EndsWith("-system", StringComparison.OrdinalIgnoreCase);
                }
                else if (nArg.Equals("/d", StringComparison.OrdinalIgnoreCase) || nArg.StartsWith("--remove", StringComparison.OrdinalIgnoreCase))
                {
                    mode = -1;
                    isMachine = nArg.Equals("/D", StringComparison.Ordinal) || nArg.EndsWith("-system", StringComparison.OrdinalIgnoreCase);
                }
                else if (nArg.Equals("/v", StringComparison.OrdinalIgnoreCase) || nArg.StartsWith("--view", StringComparison.OrdinalIgnoreCase))
                {
                    mode = 0;
                    isMachine = nArg.Equals("/V", StringComparison.Ordinal) || nArg.EndsWith("-system", StringComparison.OrdinalIgnoreCase);
                }
            }
            try
            {
                PathUpdater updater = new PathUpdater(new MachinePath()); // 建立路徑更新器
                // 根據引數執行相應的操作
                if (mode >= 1)
                {
                    // 新增路徑
                    updater.Add(path, isMachine);
                }
                else if (mode <= -1)
                {
                    // 刪除路徑
                    updater.Remove(path, isMachine);
                }
                // 顯示更新後的路徑
                Console.WriteLine(updater.Get(isMachine));
            }
            catch (Exception ex)
            {
                // 捕捉例外並顯示錯誤訊息
                Console.Error.WriteLine("ERROR: " + ex.ToString());
                Environment.Exit(1); // 結束程式並設定退出碼為1
            }
        }

        // 顯示如何使用此程式的說明
        private static void ShowHowToUse()
        {
            // 獲取程式集資訊
            Assembly assembly = Assembly.GetExecutingAssembly();
            AssemblyName assemblyName = assembly.GetName();
            // 版本號
            Version version = assemblyName.Version;
            // 版權資訊
            object[] attributes = assembly.GetCustomAttributes(typeof(AssemblyCopyrightAttribute), false);
            string copyright = ((AssemblyCopyrightAttribute)attributes[0]).Copyright;
            string appName = Path.GetFileName(assembly.Location);
            Console.WriteLine($"PathEd {version} - A simple tool to edit the PATH environment variable.");
            Console.WriteLine(copyright);
            Console.WriteLine("https://github.com/kagurazakayashi/PathEd");
            Console.WriteLine($"Usage: {appName} [/a] [/A] [/d] [/D] [/v] [/V] [/?] VAL");
            Console.WriteLine("  /a or /A : Add");
            Console.WriteLine("  /d or /D : Delete.");
            Console.WriteLine("  /v or /V or No argument : View.");
            Console.WriteLine("  /a or /d or /v or No argument : User level");
            Console.WriteLine("  /A or /D or /V : System level.");
            Console.WriteLine("  /? : Show this help message.");
            Console.WriteLine("  VAL : The path to add or delete.");
        }
    }
}
