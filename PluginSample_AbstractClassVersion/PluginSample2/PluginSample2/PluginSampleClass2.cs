using PluginBaseDLL;
using System;

// 参照の追加：PluginBaseDLL.dll
// GUIモードの時のLOG_LEVELの設定値は適当なので意味はない、呼び出し側でそのレベルが取れていることを確認したいだけ

namespace PluginSample2
{
    public class PluginSampleClass2 : PluginBaseClass
    {
        private int _no;

        /// <summary>
        /// 表示メソッド
        /// </summary>
        public override void Show()
        {
            if (action_mode == ACTION_MODE.GUI)
            {
                // GUIモード
                Console.WriteLine("プラグインサンプル２のShowメソッドG", LOG_LEVEL.TRACE);
            }
            else
            {
                // GUIモード以外（CUIモードと、無いと思うけど予期しないモード）
                Console.WriteLine("プラグインサンプル２のShowメソッドC");
            }
        }

        /// <summary>
        /// 数値をセット
        /// </summary>
        /// <param name="no"></param>
        public override void SetNo(int no)
        {
            //---------------------------------------------------------------------------------
            // 単にログを出したいだけ
            //---------------------------------------------------------------------------------
            if (action_mode == ACTION_MODE.GUI)
            {
                // GUIモード
                Console.WriteLine($"プラグインサンプル２のSetNoメソッドG:no={no}", LOG_LEVEL.WARN);
            }
            else
            {
                // GUIモード以外（CUIモードと、無いと思うけど予期しないモード）
                Console.WriteLine($"プラグインサンプル２のSetNoメソッドC:no={no}");
            }

            //---------------------------------------------------------------------------------
            // このメソッドでやりたいこと
            //---------------------------------------------------------------------------------
            _no = no;
        }

        /// <summary>
        /// 数値をゲット
        /// </summary>
        /// <returns></returns>
        public override int GetNo()
        {
            //---------------------------------------------------------------------------------
            // 単にログを出したいだけ
            //---------------------------------------------------------------------------------
            if (action_mode == ACTION_MODE.GUI)
            {
                // GUIモード
                Console.WriteLine($"プラグインサンプル２のGetNoメソッドG:_no={_no}", LOG_LEVEL.DEBUG);
            }
            else
            {
                // GUIモード以外（CUIモードと、無いと思うけど予期しないモード）
                Console.WriteLine($"プラグインサンプル２のGetNoメソッドC:_no={_no}");
            }

            //---------------------------------------------------------------------------------
            // このメソッドでやりたいこと
            //---------------------------------------------------------------------------------
            return _no + 20;
        }
    }
}
