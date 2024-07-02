using System;

namespace PathEd
{
    /// <summary>
    /// MachinePath 類別實作了 IPath 介面，用於獲取及設定系統機器層級的 PATH 環境變數。
    /// </summary>
    public class MachinePath : IPath
    {
        /// <summary>
        /// 獲取機器層級的 PATH 環境變數。
        /// </summary>
        /// <returns>機器層級的 PATH 環境變數字串。</returns>
        public string Get()
        {
            // 從機器層級的環境變數中取得 PATH 變數的值
            return Environment.GetEnvironmentVariable("PATH", EnvironmentVariableTarget.Machine);
        }

        /// <summary>
        /// 設定機器層級的 PATH 環境變數。
        /// </summary>
        /// <param name="value">新的 PATH 變數值。</param>
        public void Set(string value)
        {
            // 設定機器層級的環境變數 PATH 的值
            Environment.SetEnvironmentVariable("PATH", value, EnvironmentVariableTarget.Machine);
        }
    }
}
