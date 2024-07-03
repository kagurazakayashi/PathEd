namespace PathEd
{
    /// <summary>
    /// IPath 介面定義了用於取得和設定路徑的功能。
    /// </summary>
    public interface IPath
    {
        /// <summary>
        /// 讀取 PATH 環境變數。
        /// </summary>
        /// <param name="isMachine">是否為機器層級的環境變數。</param>
        /// <returns>機器層級的 PATH 環境變數字串。</returns>
        string Get(bool isMachine);

        /// <summary>
        /// 寫入 PATH 環境變數。
        /// </summary>
        /// <param name="value">新的 PATH 變數值。</param>
        /// <param name="isMachine">是否為機器層級的環境變數。</param>
        void Set(string value, bool isMachine);
    }
}
