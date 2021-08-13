using System;
using System.Collections.Generic;
using System.Reflection;
using System.ServiceModel;
using System.Windows.Threading;
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
            string param1 = "abc";
            int param2 = 123; ;
            double param3 = 45.678;
            string[] param4 = new string[] { "ZZZ", "XXX", "CCC" };
            List<RetClass> param5 = new List<RetClass>() {
                                                    new RetClass(10, "ほげ"),
                                                    new RetClass(20, "ふが"),
                                                    new RetClass(30, "へげ"),
            };

            BroadcastMessage(param1,
                                        param2,
                                        param3,
                                        param4,
                                        param5);
        }


        public delegate void ServerPushEventHandler(
                                            string param1,
                                            int param2,
                                            double param3,
                                            string[] param4,
                                            List<RetClass> param5);

        //各クライアントのコールバックを管理する
        public static Dictionary<string, ServerPushEventHandler> endPointManager = new Dictionary<string, ServerPushEventHandler>();



        public void BroadcastMessage(
                                string param1,
                                int param2,
                                double param3,
                                string[] param4,
                                List<RetClass> param5)
        {
            foreach (string key in endPointManager.Keys)
            {
                endPointManager[key].Invoke(
                                        param1,
                                        param2,
                                        param3,
                                        param4,
                                        param5);
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
