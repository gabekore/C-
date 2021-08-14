using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Reflection;
using System.ServiceModel;
using System.Windows.Threading;
using ClientCS.ViewModels;
using GalaSoft.MvvmLight.Messaging;
using Server.APIs;
using Server.Message;
using ServiceIF;
using ServiceIF.ApiIF;
using ServiceIF.ObjIF;

namespace Server.ViewModels
{
    public class MainViewModel : ViewModelBase
    {
        //-------------------------------------------------
        // 変数
        //-------------------------------------------------
        // 参照設定：System.ServiceModel.dll
        private ServiceHost serviceHost = null;

        //-------------------------------------------------
        // コンストラクタ
        //-------------------------------------------------
        /// <summary>
        /// コンストラクタ
        /// </summary>
        /// <param name="dispatcher"></param>
        public MainViewModel(Dispatcher dispatcher)
        {
            //-------------------------------------------------
            // 画面コントロールの初期値
            //-------------------------------------------------
            BtnStartServiceEnabled = true;
            BtnStopServiceEnabled = false;

            //-------------------------------------------------
            // コンボボックスの設定値
            //-------------------------------------------------
            // UIスレッド渡す
            //ComboSource = new BindingListAsync<MainViewModelCombo>(dispatcher);
            ComboSource.Add(new MainViewModelCombo(0, "PID_HOGE"));
            ComboSource.Add(new MainViewModelCombo(1, "PID_FUGA"));
            ComboSource.Add(new MainViewModelCombo(2, "PID_HEGE"));

            //-------------------------------------------------
            // コールバック登録受付通知受信のための準備
            // ※NuGetでMVVMLightLibs取得
            //-------------------------------------------------
            Messenger.Default.Register<CallbackRegistNty>(this, onReceivedMessage);
        }

        //-------------------------------------------------
        // プロパティ
        //-------------------------------------------------
        /// <summary>
        /// サービス開始ボタン、Enabledプロパティ
        /// </summary>
        private bool _btnStartServiceEnabled = false;
        public bool BtnStartServiceEnabled
        {
            get { return _btnStartServiceEnabled; }
            set
            {
                SetProperty(ref _btnStartServiceEnabled, value);
            }
        }

        /// <summary>
        /// サービス停止ボタン、Enabledプロパティ
        /// </summary>
        private bool _btnStopServiceEnabled = false;
        public bool BtnStopServiceEnabled
        {
            get { return _btnStopServiceEnabled; }
            set
            {
                SetProperty(ref _btnStopServiceEnabled, value);
            }
        }

        /// <summary>
        /// ログテキストボックス、Textプロパティ
        /// </summary>
        private string _txbLogText = string.Empty;
        public string TxbLogText
        {
            get { return _txbLogText; }
            set
            {
                SetProperty(ref _txbLogText, value);
            }
        }



        //------------------------------------------------------
        // 通常のプロパティではあるが、BindingListをプロパティとする
        // これをViewでコンボボックスにDataBindingsする
        // 普通のListでも良さそうに見えるかも知れないが、Listにデータをaddしてもコントロール部品に通知が行かない
        // BindingListだと通知が行く
        //------------------------------------------------------
        /// <summary>
        /// コンボボックス、DataSourceプロパティ（設定値一覧）
        /// </summary>
        // 非同期考えないならこれでいい↓
        public BindingList<MainViewModelCombo> ComboSource { get; set; } = new BindingList<MainViewModelCombo>();
        // 非同期で使うならUIスレッドの事を考えないといけないので、BindingListAsyncクラスを使う（けど、このままでは使えないのでnewはコンストラクタでやる）
        //public BindingListAsync<MainViewModelCombo> ComboSource { get; set; }

        /// <summary>
        /// コンボボックス、SelectedValueプロパティ
        /// </summary>
        private object _cmbPushIdSelectedValue;
        public object CmbPushIdSelectedValue
        {
            get { return _cmbPushIdSelectedValue; }
            set
            {
                SetProperty(ref _cmbPushIdSelectedValue, value);

                CmbPushIdSelectedItem = ComboSource.FirstOrDefault(x => x.Value == (int)value);
            }
        }

        /// <summary>
        /// コンボボックス、SelectedItemプロパティ
        /// </summary>
        public MainViewModelCombo CmbPushIdSelectedItem { get; set; }





        //-------------------------------------------------
        // WCFサービスオープン／クローズの処理
        //-------------------------------------------------
        /// <summary>
        /// サービス開始
        /// </summary>
        public void ServiceStart()
        {
            //---------------------------------------------------------
            // １．ServiceHostの作成
            //---------------------------------------------------------
            {
                Type serviceType = typeof(Service);
                serviceHost = new ServiceHost(serviceType);
            }

            //---------------------------------------------------------
            // ２．サービスのオープン
            //---------------------------------------------------------
            {
                // System.ServiceModel.AddressAccessDeniedException が発生したら、
                // コマンドプロンプト（←管理者モードで起動）で以下のコマンドを打つ
                // netsh http add urlacl url=http://+:8081/ user=hoge
                // ※hogeの部分はWindowsにログインしているユーザー名
                serviceHost.Open();
            }

            //---------------------------------------------------------
            // ログ表示
            //---------------------------------------------------------
            SetLog("サービス開始中");

            //---------------------------------------------------------
            // ボタンの制御
            //---------------------------------------------------------
            BtnStartServiceEnabled = false;
            BtnStopServiceEnabled = true;
        }

        /// <summary>
        /// サービス停止
        /// </summary>
        public void ServiceStop()
        {
            //---------------------------------------------------------
            // 事前のチェック（serviceHostの状態）
            //---------------------------------------------------------
            if (serviceHost == null)
            {
                return;
            }

            //---------------------------------------------------------
            // serviceHost終了
            //---------------------------------------------------------
            using (serviceHost)
            {
                serviceHost.Close();
            }
            serviceHost = null;

            //---------------------------------------------------------
            // ログ表示
            //---------------------------------------------------------
            SetLog("サービス停止中");

            //---------------------------------------------------------
            // ボタンの制御
            //---------------------------------------------------------
            BtnStartServiceEnabled = true;
            BtnStopServiceEnabled = false;
        }

        /// <summary>
        /// コールバック実行
        /// </summary>
        public void DoCallback()
        {
            SetLog("コールバック実行");

            //var context = OperationContext.Current;
            //var callback = context.GetCallbackChannel<ICallbackType>();

            //callback.CallbackFuntion(
            //                    "callbakc-message",
            //                    123,
            //                    45.67,
            //                    new string[] { "a", "bb", "ccc", "dddd", "eeeee" },
            //                    new List<RetClass> {
            //                                new RetClass(1, "Hoge"),
            //                                new RetClass(2, "Fuga"),
            //                                new RetClass(3, "Hege"),
            //                    });
            string push_id = CmbPushIdSelectedItem.DisplayValue;
            if (push_id == null || push_id.Trim() == string.Empty)
            {
                SetLog("プッシュIDが空なので中止");
                return;
            }

            string param1 = "abc";
            int param2 = 123; ;
            double param3 = 45.678;
            string[] param4 = new string[] { "ZZZ", "XXX", "CCC" };
            List<RetClass> param5 = new List<RetClass>() {
                                                    new RetClass(10, "ほげ"),
                                                    new RetClass(20, "ふが"),
                                                    new RetClass(30, "へげ"),
            };

            BroadcastMessage(
                        push_id,
                        param1,
                        param2,
                        param3,
                        param4,
                        param5);
        }


        public delegate void ServerPushEventHandler(
                                            string push_id,
                                            string param1,
                                            int param2,
                                            double param3,
                                            string[] param4,
                                            List<RetClass> param5);

        //各クライアントのコールバックを管理する

        // DictionaryじゃなくてConcurrentDictionaryにしてlockを使わない方法もあるけど、
        // 結局メソッドを複数個使うので、クリティカルセクションを作る必要がある（結局lockが必要）
        // ConcurrentDictionaryのメソッド一つひとつはスレッドセーフでアトミック性も保たれるけど、
        // メソッドを連続して使うと、メソッドとメソッドの間で別スレッドが入る可能性がある
        // なのでConcurrentDictionaryにしたところで結局lockは必要
        // lock使うならConcurrentDictionaryにしを使う意味が無い・・・と思う、多分、知らんけど
        // -----------
        // keyにはpush_idが入る
        public static Dictionary<string, List<ServerPushEventHandler>> endPointManager 
                                            = new Dictionary<string, List<ServerPushEventHandler>>();

        public void BroadcastMessage(
                                string push_id,
                                string param1,
                                int param2,
                                double param3,
                                string[] param4,
                                List<RetClass> param5)
        {
            foreach (string pid in endPointManager.Keys)
            {
                if (pid != push_id)
                {
                    continue;
                }

                foreach (var value in endPointManager[pid])
                {
                    value.Invoke(
                            push_id,
                            param1,
                            param2,
                            param3,
                            param4,
                            param5);
                } 
            }
        }

        //-------------------------------------------------
        // Private
        //-------------------------------------------------
        /// <summary>
        /// ログ用テキストボックスにテキスト表示
        /// </summary>
        /// <param name="log"></param>
        public void SetLog(string log)
        {
            TxbLogText += (log + Environment.NewLine);
        }

        /// <summary>
        /// コールバック登録受付通知受信
        /// Service.csがコールバック登録を受けたらここに通知される
        /// ※NuGetでMVVMLightLibs取得
        /// </summary>
        /// <param name="req"></param>
        private void onReceivedMessage(CallbackRegistNty req)
        {
            SetLog("コールバック登録あり");
        }
    }
}
