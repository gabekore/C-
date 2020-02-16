using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MainProgramGUI
{
    public partial class MainForm : Form
    {
        /// <summary>
        /// ログレベル
        /// </summary>
        public enum LOG_LEVEL
        {
            TRACE,
            DEBUG,
            INFO,
            WARN,
            ERROR,
            FATAL,
        }

        /// <summary>
        /// フォームのコンストラクタ
        /// </summary>
        public MainForm()
        {
            InitializeComponent();
        }

        /// <summary>
        /// 画面部品のリストボックスにログ出力
        /// </summary>
        /// <param name="level"></param>
        /// <param name="log"></param>
        private void LogOut(LOG_LEVEL level, string log)
        {
            listLog.Items.Add($"{DateTime.Now} [{level.ToString()}] {log}");
            listLog.SelectedIndex = listLog.Items.Count - 1;
        }





        #region イベントハンドラ
        /// <summary>
        /// Thread Startボタンのクリックイベント
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnThreadStart_Click(object sender, EventArgs e)
        {
            cancelTokenSource = new CancellationTokenSource();
            cancelToken = cancelTokenSource.Token;

            var task = new Task(() => ThreadWorkerAsync());
            task.Start();

            // ↑じゃなくて、↓のawaitならスレッドがメインのままなのでInvoke()なんか使わなくてもいいはず
            //await ThreadWorkerAsync();
            // ↑await使うならbtnThreadStart_Click()をasyncにする

            listLog.Items.Add("-------------");
        }
        /// <summary>
        /// Thread Stopボタンのクリックイベント
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnThreadStop_Click(object sender, EventArgs e)
        {
            cancelTokenSource.Cancel();
        }
        #endregion


        #region UIスレッドとワーカースレッドのI/F
        /// <summary>
        /// ワーカースレッドからUIスレッドの画面部品のリストボックスにログを出力するためのデリゲート
        /// </summary>
        /// <param name="level"></param>
        /// <param name="log"></param>
        delegate void LogOutDelegate(LOG_LEVEL level, string log);
        /// <summary>
        /// ワーカースレッドからUIスレッドの画面部品のリストボックスにログを出力
        /// </summary>
        /// <param name="level"></param>
        /// <param name="log"></param>
        public void LogOutInvoke(LOG_LEVEL level, string log)
        {
            // カンケー無いけど、Invokeってのは呼び出すっていう意味
            Invoke(new LogOutDelegate(LogOut), level, log);
        }
        #endregion


        #region ワーカースレッド
        // ワーカースレッドのキャンセル
        CancellationTokenSource cancelTokenSource;
        CancellationToken cancelToken;

        /// <summary>
        /// ワーカースレッド本体
        /// </summary>
        /// <returns></returns>
        private async Task ThreadWorkerAsync()
        {
            // プラグインをロードして実行
            var plugin = new PluginAccessor();
            var numDll = plugin.LoadPlugins();
            LogOutInvoke(LOG_LEVEL.INFO, $"[Main] numDll={numDll}");
            LogOutInvoke(LOG_LEVEL.INFO, "");



            while (!cancelToken.IsCancellationRequested)
            {

                LogOutInvoke(LOG_LEVEL.INFO, "[Main] 全てのプラグイン実行=========");
                plugin.AllPluginExec(new PluginLogWriter(this));
                LogOutInvoke(LOG_LEVEL.INFO, "");


                LogOutInvoke(LOG_LEVEL.INFO, "[Main] 1つ目のプラグイン実行=========");
                var idxDll = 0;
                plugin.PluginShow(idxDll);
                plugin.PluginSetNo(idxDll, 5);
                var getno = plugin.PluginGetNo(idxDll);
                LogOutInvoke(LOG_LEVEL.INFO, $"[Main] getno1={getno}");
                LogOutInvoke(LOG_LEVEL.INFO, "");


                LogOutInvoke(LOG_LEVEL.INFO, "[Main] 2つ目のプラグイン実行=========");
                idxDll = 1;
                plugin.PluginShow(idxDll);
                plugin.PluginSetNo(idxDll, 7);
                getno = plugin.PluginGetNo(idxDll);
                LogOutInvoke(LOG_LEVEL.INFO, $"[Main] getno2={getno}");
                LogOutInvoke(LOG_LEVEL.INFO, "");

                // ワーカースレッドから画面部品にはアクセスできない
                // 画面部品にアクセスできるのはUIスレッドのみ
                // なので、↓の二行は例外になる
                // listLog.Items.Add($"{DateTime.Now} [{LOG_LEVEL.ERROR}] ワーカースレッド");
                // LogOut(LOG_LEVEL.INFO, "ワーカースレッド");

                // ワーカースレッドから画面部品にアクセスするにはInvoke()を使う
                // ↓
                LogOutInvoke(LOG_LEVEL.INFO, "ワーカースレッド実行中");
                LogOutInvoke(LOG_LEVEL.INFO, "");
                LogOutInvoke(LOG_LEVEL.INFO, "");

                await Task.Delay(3000);
            }
            LogOutInvoke(LOG_LEVEL.INFO, "ワーカースレッド終了");
        }
        #endregion
    }
}
