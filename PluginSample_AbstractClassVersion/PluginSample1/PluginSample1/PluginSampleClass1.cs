//#define GUI ←今回のサンプルではこいつを使う事は無い
//#define CUI ←こいつを消せばGUIを定義しているような感じになる

using PluginBaseDLL;
using System;

// 参照の追加：PluginBaseDLL.dll
// GUIモードの時のLOG_LEVELの設定値は適当なので意味はない、呼び出し側でそのレベルが取れていることを確認したいだけ


namespace PluginSample1
{
    public class PluginSampleClass1 : PluginBaseClass
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
                Console.WriteLine("プラグインサンプル１のShowメソッドG", LOG_LEVEL.WARN);
            }
            else
            {
                // GUIモード以外（CUIモードと、無いと思うけど予期しないモード）
                Console.WriteLine("プラグインサンプル１のShowメソッドC");
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
                Console.WriteLine($"プラグインサンプル１のSetNoメソッドG:no={no}", LOG_LEVEL.FATAL);
            }
            else
            {
                // GUIモード以外（CUIモードと、無いと思うけど予期しないモード）
                Console.WriteLine($"プラグインサンプル１のSetNoメソッドC:no={no}");
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
                Console.WriteLine($"プラグインサンプル１のGetNoメソッドG:no={_no}", LOG_LEVEL.ERROR);
            }
            else
            {
                // GUIモード以外（CUIモードと、無いと思うけど予期しないモード）
                Console.WriteLine($"プラグインサンプル１のGetNoメソッドC:no={_no}");
            }

            //---------------------------------------------------------------------------------
            // このメソッドでやりたいこと
            //---------------------------------------------------------------------------------
            return _no + 10;
        }
    }
}
