namespace PathEd
{
    /// <summary>
    /// IPath 介面定義了用於取得和設置路徑的功能。
    /// </summary>
    public interface IPath
    {
        /// <summary>
        /// 取得路徑的字串表示。
        /// </summary>
        /// <returns>路徑的字串表示。</returns>
        string Get();

        /// <summary>
        /// 設置路徑的值。
        /// </summary>
        /// <param name="value">要設置的路徑值。</param>
        void Set(string value);
    }
}
