using System.Collections.Generic;
using System.Linq;

// ▼参考URL
// ＠IT
// foreachループで現在の繰り返し回数を使うには？［C#／VB］
// https://www.atmarkit.co.jp/ait/articles/1702/22/news019.html

namespace XMLSettingsSample
{
    public static class LinqExtensions
    {
        // コレクションの要素を、要素とインデックスのタプルに変換する拡張メソッド
        public static IEnumerable<(T value, int index)> ToTuples<T>(this IEnumerable<T> collection) => collection.Select((v, i) => (v, i));
    }
}
