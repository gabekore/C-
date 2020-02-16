//#define GUI

using System;
using System.IO;

namespace PluginBaseDLL
{
    /// <summary>
    /// プラグインベースのクラス
    /// </summary>
    public abstract class PluginBaseClass
    {
        /// <summary>
        /// 動作モード
        /// GUIで動くのか、CUIで動くのか
        /// </summary>
        public enum ACTION_MODE
        {
            CUI,
            GUI,
        }
        public ACTION_MODE action_mode { get; set; } = ACTION_MODE.CUI;



        /// <summary>
        /// ログレベル
        /// MainProgramGUIのLOG_LEVELと同じもの
        /// 本当は一元管理にして、MainProgramGUIとPluginBaseで共通的に参照するのがいいのだろうけど
        /// そこまでするのは面倒なのでMainProgramGUIからコピるだけにしておく
        /// </summary>
        protected enum LOG_LEVEL
        {
            TRACE,
            DEBUG,
            INFO,
            WARN,
            ERROR,
            FATAL,
        }


        /// <summary>
        /// 表示メソッド
        /// </summary>
        public abstract void Show();

        /// <summary>
        /// 数値をセット
        /// </summary>
        /// <param name="no"></param>
        public abstract void SetNo(int no);

        /// <summary>
        /// 数値をゲット
        /// </summary>
        /// <returns></returns>
        public abstract int GetNo();

        /// <summary>
        /// 標準出力先を変更
        /// 
        /// 呼び側で自作のTextWriter系クラスを使ってログ出力する
        /// 今回のサンプルでは、画面部品のログ用リストボックスに出力することになる
        /// 子クラスでこれを触る必要は無い
        /// オーバーライド禁止
        /// 
        /// 子クラスでConsole.WriteLine(LOG_LEVEL.INFO, "ログの文言だよ～ん");って感じで書いてもらえば
        /// 呼び側で自作のTextWriter系クラスへ渡すことができる
        /// </summary>
        /// <param name="newOut"></param>
        public void SetOut(TextWriter newOut)
        {
            Console.SetOut(newOut);
        }

    }
}
