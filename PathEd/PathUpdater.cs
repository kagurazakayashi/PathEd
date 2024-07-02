using System;
using System.Text.RegularExpressions;

namespace PathEd
{
    /// <summary>
    /// PathUpdater 類別負責更新 PATH 變數。
    /// </summary>
	public class PathUpdater
    {
        /// <summary>
        /// 初始化 PathUpdater 類別的新執行個體。
        /// </summary>
        /// <param name="path">IPath 介面實作的物件。</param>
		public PathUpdater(IPath path)
        {
            // 檢查 path 是否為 null，如果是，則拋出 ArgumentNullException。
            Path = path ?? throw new ArgumentNullException(nameof(path));
        }

        /// <summary>
        /// 取得目前的 PATH 變數。
        /// </summary>
        /// <returns>目前的 PATH 變數字串。</returns>
        public string Get()
        {
            return Path.Get();
        }

        /// <summary>
        /// 新增一個值到 PATH 變數中。
        /// </summary>
        /// <param name="value">要新增到 PATH 變數的值。</param>
        /// <exception cref="ArgumentNullException">當 value 為 null 時拋出此例外。</exception>
        public void Add(string value)
        {
            // 檢查 value 是否為 null，如果是，則拋出 ArgumentNullException。
            if (value == null)
                throw new ArgumentNullException(nameof(value));

            // 取得目前的 PATH 變數。
            var pathVariables = Path.Get();

            // 如果 PATH 變數為空，直接設定為新的值。
            if (string.IsNullOrEmpty(pathVariables))
            {
                pathVariables = value;
            }
            else
            {
                // 如果 PATH 變數中已包含該值，則直接返回。
                if (pathVariables.IndexOf(value, StringComparison.OrdinalIgnoreCase) > -1)
                    return;

                // 去除 PATH 變數末尾的分號。
                pathVariables = pathVariables.TrimEnd(';');
                // 將新的值附加到 PATH 變數後面。
                pathVariables = pathVariables + ";" + value;
            }

            // 設定更新後的 PATH 變數。
            Path.Set(pathVariables);
        }

        /// <summary>
        /// 從 PATH 變數中移除一個值。
        /// </summary>
        /// <param name="value">要從 PATH 變數中移除的值。</param>
        /// <exception cref="ArgumentNullException">當 value 為 null 時拋出此例外。</exception>
		public void Remove(string value)
        {
            // 檢查 value 是否為 null，如果是，則拋出 ArgumentNullException。
            if (value == null)
                throw new ArgumentNullException(nameof(value));

            // 取得目前的 PATH 變數。
            var pathVariables = Path.Get();

            // 如果 PATH 變數為空，則直接返回。
            if (string.IsNullOrEmpty(pathVariables))
                return;

            // 如果 PATH 變數中不包含該值，則直接返回。
            if (pathVariables.IndexOf(value, StringComparison.OrdinalIgnoreCase) == -1)
                return;

            // 使用正規表達式移除指定的值及其後的分號。
            pathVariables = Regex.Replace(pathVariables, $"\"?{Regex.Escape(value)}\"?;?", "", RegexOptions.IgnoreCase);

            // 如果 PATH 變數末尾有多餘的分號，則移除。
            if (pathVariables.EndsWith(";"))
                pathVariables = pathVariables.Substring(0, pathVariables.Length - 1);

            // 設定更新後的 PATH 變數。
            Path.Set(pathVariables);
        }

        /// <summary>
        /// 取得或設定 IPath 介面實作的物件。
        /// </summary>
		public IPath Path { get; }
    }
}
