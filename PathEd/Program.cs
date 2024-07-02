using System;
using System.IO;

namespace PathEd
{
    // 定義主程式類別
    class Program
    {
        // 引入外部DLL函式，用於設置程序的DPI感知能力
        [System.Runtime.InteropServices.DllImport("user32.dll")]
        private static extern bool SetProcessDPIAware();

        // 程式入口點
        static void Main(string[] args)
        {
            // 檢查命令行參數是否有效
            var hasValidArguments = args?.Length >= 2 && (args[0].ToUpper() == "/A" || args[0].ToUpper() == "/D" || args[0] == "/?");

            // 建立 PathUpdater 物件
            var updater = new PathUpdater(new MachinePath());

            // 如果參數無效，顯示目前的路徑並退出程式
            if (!hasValidArguments)
            {
                Console.WriteLine(updater.Get());
                //ShowHowToUse();
                return;
            }

            try
            {
                // 根據參數執行相應的操作
                if (args[0].ToUpper() == "/A")
                {
                    // 添加路徑
                    updater.Add(args[1]);
                }
                else if (args[0].ToUpper() == "/D")
                {
                    // 刪除路徑
                    updater.Remove(args[1]);
                }
                else if (args[0] == "/?")
                {
                    // 顯示如何使用程式
                    ShowHowToUse();
                }
                // 顯示更新後的路徑
                Console.WriteLine(updater.Get());
            }
            catch (Exception ex)
            {
                // 捕捉例外並顯示錯誤訊息
                Console.WriteLine("ERROR: " + ex.ToString());
                Environment.Exit(1); // 結束程式並設置退出碼為1
            }
        }

        // 顯示如何使用此程式的說明
        private static void ShowHowToUse()
        {
            var appName = Path.GetFileName(System.Reflection.Assembly.GetExecutingAssembly().Location);
            Console.WriteLine($"\r\nUsage: {appName} [/A or /D] VAL");
        }

        // 初始化 Windows 表單應用程式的 DPI 設定
        private static void InitWinForms()
        {
            if (Environment.OSVersion.Version.Major >= 6)
                SetProcessDPIAware();
        }
    }
}
