using System;
using System.Linq;
using System.Runtime.CompilerServices;
using System.ServiceModel;
using System.Windows.Forms;
using System.Windows.Threading;
using ClientCS.GabekoreService;
using Interface;

namespace ClientCS.ViewModels
{
    public class MainViewModel : ViewModelBase
    {
        //★App.config化により、以下の対応が必要
        // 1. サーバーアプリを起動
        // 2. サーバーアプリでサービス起動
        // 3. 事前確認
        //      Webブラウザで「http://localhost:8081/Gabekore」にアクセス
        //      ※「Service サービス」「サービスを作成しました。このサービスをテストするには、クライアントを作成し、そのクライアントを使用してサービスを呼び出す必要があります。これは、コマンド ラインから次の構文を使用し、svcutil.exe ツールを呼び出すことによって行えます。」
        //        ↑のメッセージが出ればOK、出ていなければサーバーアプリの作り方がおかしいのでやり直し
        // 4. 事前確認がOKなら次へ進む、NGならサーバーアプリ作り直し
        // 5. クライアントアプリのプロジェクト→右クリック→追加→サービス参照
        // 6. 必要があればダイアログ下部の名前空間を入力（別にデフォルトのServiceReference1のままでもいいけど、分かりやすいのに変更する方がいいでしょう）
        // 7. アドレスに「http://localhost:8081/Gabekore」入力→移動ボタン
        // 8. ソリューションエクスプローラー見ると、以下ができている
        //      Connected Service
        //        ServiceReference1  ←これが名前空間、このソースではGabekoreServiceという名前にしている
        //      Properties
        //        DataSources
        //-------------------------------------------------
        // 変数
        //-------------------------------------------------
        //★App.config化により不要 private const string ServiceBaseAddr = @"http://localhost:8081/Gabekore";
        //★App.config化により不要 private IService _service = null;
        //★App.config化により不要 private ChannelFactory<IService> _channel = null;

        //-------------------------------------------------
        // コンストラクタ
        //-------------------------------------------------
        /// <summary>
        /// コンストラクタ
        /// </summary>
        /// <param name="dispatcher"></param>
        public MainViewModel(Dispatcher dispatcher)
        {
            base.Dispatcher = dispatcher;
        }

        //-------------------------------------------------
        // プロパティ
        //-------------------------------------------------
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
        //★App.config化により不要 /// <summary>
        //★App.config化により不要 /// WCFサービス開始
        //★App.config化により不要 /// </summary>
        //★App.config化により不要 private void StartService()
        //★App.config化により不要 {
        //★App.config化により不要     if (_service != null || _channel != null)
        //★App.config化により不要     {
        //★App.config化により不要         return;
        //★App.config化により不要     }
        //★App.config化により不要 
        //★App.config化により不要     try
        //★App.config化により不要     {
        //★App.config化により不要         // 参照設定：System.ServiceModel.dll
        //★App.config化により不要         EndpointAddress endpointAddr = new EndpointAddress(ServiceBaseAddr);
        //★App.config化により不要 
        //★App.config化により不要         // チャネルを構築しサービス呼び出しを行う.
        //★App.config化により不要         _channel = new ChannelFactory<IService>(new BasicHttpBinding());
        //★App.config化により不要 
        //★App.config化により不要         // サービスへのプロキシを取得.
        //★App.config化により不要         _service = _channel.CreateChannel(endpointAddr);
        //★App.config化により不要     }
        //★App.config化により不要     catch (CommunicationException ex)
        //★App.config化により不要     {
        //★App.config化により不要         // エラー発生
        //★App.config化により不要         // 
        //★App.config化により不要         // WCFでは、サービスとクライアント間の通信中にエラーが発生した場合
        //★App.config化により不要         // CommunicationExceptionがスローされる。
        //★App.config化により不要         MessageBox.Show(ex.Message);
        //★App.config化により不要         SetLog(ex.Message);
        //★App.config化により不要     }
        //★App.config化により不要 }

        //★App.config化により不要 /// <summary>
        //★App.config化により不要 /// WCFサービス終了
        //★App.config化により不要 /// </summary>
        //★App.config化により不要 public void StopService()
        //★App.config化により不要 {
        //★App.config化により不要     if (_service == null && _channel == null)
        //★App.config化により不要     {
        //★App.config化により不要         return;
        //★App.config化により不要     }
        //★App.config化により不要 
        //★App.config化により不要     using (_channel)
        //★App.config化により不要     {
        //★App.config化により不要         _channel.Close();
        //★App.config化により不要     }
        //★App.config化により不要     _service = null;
        //★App.config化により不要     _channel = null;
        //★App.config化により不要 }

        //-------------------------------------------------
        // WCFの公開メソッドをコール
        //-------------------------------------------------
        public void HelloWorld()
        {
            SetLog("-- ↓ --");

            //★App.config化により不要 StartService();

            try
            {
                //★App.config化により追記
                using (var client = new ServiceClient())
                {
                    // サービスメソッドの呼び出し.
                    // string HelloWorld(string name);
                    //★App.config化により変更 var result = _service.HelloWorld("Pochi");
                    var result = client.HelloWorld("Pochi");

                    SetLog(result);
                }
            }
            catch (CommunicationException ex)
            {
                // エラー発生
                // 
                // WCFでは、サービスとクライアント間の通信中にエラーが発生した場合
                // CommunicationExceptionがスローされる。
                MessageBox.Show(ex.Message);
                SetLog(ex.Message);
            }
            SetLog("-- ↑ --");
        }

        public void CalcPlus()
        {
            SetLog("-- ↓ --");

            //★App.config化により不要 StartService();

            try
            {
                //★App.config化により追記
                using (var client = new ServiceClient())
                {
                    // サービスメソッドの呼び出し.
                    // int CalcPlus(int a, int b);
                    //★App.config化により変更 var result = _service.CalcPlus(5, 6);
                    var result = client.CalcPlus(5, 6);

                    SetLog(result.ToString());
                }
            }
            catch (CommunicationException ex)
            {
                // エラー発生
                // 
                // WCFでは、サービスとクライアント間の通信中にエラーが発生した場合
                // CommunicationExceptionがスローされる。
                MessageBox.Show(ex.Message);
                SetLog(ex.Message);
            }

            SetLog("-- ↑ --");
        }

        public void CalcMinus()
        {
            SetLog("-- ↓ --");

            //★App.config化により不要 StartService();

            try
            {
                //★App.config化により追記
                using (var client = new ServiceClient())
                {
                    // サービスメソッドの呼び出し.
                    // void CalcMinus(int a, int b, ref int result);
                    int result = 0;
                    //★App.config化により変更 _service.CalcMinus(5, 6, ref result);
                    client.CalcMinus(5, 6, ref result);

                    SetLog(result.ToString());
                }
            }
            catch (CommunicationException ex)
            {
                // エラー発生
                // 
                // WCFでは、サービスとクライアント間の通信中にエラーが発生した場合
                // CommunicationExceptionがスローされる。
                MessageBox.Show(ex.Message);
                SetLog(ex.Message);
            }

            SetLog("-- ↑ --");
        }

        public void UseTuple()
        {
            SetLog("-- ↓ --");

            //★App.config化により不要 StartService();

            try
            {
                //★App.config化により追記
                using (var client = new ServiceClient())
                {
                    // サービスメソッドの呼び出し.
                    // (string, int) UseTuple(string name, int age);
                    //★App.config化により変更 var ret = _service.UseTuple("Pochi", 5);
                    var ret = client.UseTuple("Pochi", 5);

                    //★App.config化によりTupleの変数名使えない SetLog(ret.retStr + "/" + ret.retInt.ToString());
                    SetLog(ret.Item1 + "/" + ret.Item2.ToString());
                }
            }
            catch (CommunicationException ex)
            {
                // エラー発生
                // 
                // WCFでは、サービスとクライアント間の通信中にエラーが発生した場合
                // CommunicationExceptionがスローされる。
                MessageBox.Show(ex.Message);
                SetLog(ex.Message);
            }

            SetLog("-- ↑ --");
        }

        public void UseClass()
        {
            SetLog("-- ↓ --");

            //★App.config化により不要 StartService();

            try
            {
                //★App.config化により追記
                using (var client = new ServiceClient())
                {
                    // サービスメソッドの呼び出し.
                    // RetClass UseClass(ArgClass argClass);
                    //★App.config化により変更 var result = _service.UseClass(new ArgClass(123, "456"));
                    var result = client.UseClass(new ArgClass(123, "456"));

                    SetLog(result.Code.ToString() + "/" + result.Name);
                }
            }
            catch (CommunicationException ex)
            {
                // エラー発生
                // 
                // WCFでは、サービスとクライアント間の通信中にエラーが発生した場合
                // CommunicationExceptionがスローされる。
                MessageBox.Show(ex.Message);
                SetLog(ex.Message);
            }

            SetLog("-- ↑ --");
        }

        public void UseListClass()
        {
            SetLog("-- ↓ --");

            //★App.config化により不要 StartService();

            try
            {
                // サービスメソッドの呼び出し.
                // List<RetClass> UseListClass(List<ArgClass> argClass);
                //★App.config化により変更 var argClasss = new List<ArgClass>() {
                var argClasss = new ArgClass[] {
                    new ArgClass(123, "abc"),
                    new ArgClass(456, "DEF"),
                    new ArgClass(789, "Ghi"),
                    new ArgClass(101112, "JkL"),
                };
                //★App.config化により追記
                using (var client = new ServiceClient())
                {
                    //★App.config化により変更 var result = _service.UseListClass(argClasss);
                    //★App.config化によりList使えない var result = client.UseListClass(argClasss);
                    var result = client.UseListClass(argClasss);

                    result.ToList().ForEach(r => SetLog(r.Code.ToString() + "/" + r.Name));
                }
            }
            catch (CommunicationException ex)
            {
                // エラー発生
                // 
                // WCFでは、サービスとクライアント間の通信中にエラーが発生した場合
                // CommunicationExceptionがスローされる。
                MessageBox.Show(ex.Message);
                SetLog(ex.Message);
            }

            SetLog("-- ↑ --");
        }

        public void UseArray()
        {
            SetLog("-- ↓ --");

            //★App.config化により不要 StartService();

            try
            {
                //★App.config化により追記
                using (var client = new ServiceClient())
                {
                    // サービスメソッドの呼び出し.
                    //★App.config化により変更 var result = _service.UseArray(new string[] { "11", "222", "3333" });
                    var result = client.UseArray(new string[] { "11", "222", "3333" });

                    result.ToList().ForEach(r => SetLog(r.ToString()));
                }
            }
            catch (CommunicationException ex)
            {
                // エラー発生
                // 
                // WCFでは、サービスとクライアント間の通信中にエラーが発生した場合
                // CommunicationExceptionがスローされる。
                MessageBox.Show(ex.Message);
                SetLog(ex.Message);
            }

            SetLog("-- ↑ --");
        }

        // オーバロードは使えない
        public void UseOverLoad()
        {
            //SetLog("-- ↓ --");

            ////★App.config化により不要 StartService();

            //try
            //{
            //    //★App.config化により追記
            //    using (var client = new ServiceClient())
            //    {
            //        // サービスメソッドの呼び出し.
            //        // int[] NumCharToInteger(string[] numCharAry);
            //        //★App.config化により変更 var result = _service.UseOverLoad(9);
            //        var result = client.HelloWorld(9);

            //        SetLog(result.ToString());
            //    }
            //}
            //catch (CommunicationException ex)
            //{
            //    // エラー発生
            //    // 
            //    // WCFでは、サービスとクライアント間の通信中にエラーが発生した場合
            //    // CommunicationExceptionがスローされる。
            //    MessageBox.Show(ex.Message);
            //    SetLog(ex.Message);
            //}

            //SetLog("-- ↑ --");
        }




        //-------------------------------------------------
        // Private
        //-------------------------------------------------
        /// <summary>
        /// ログ用テキストボックスにテキスト表示
        /// </summary>
        /// <param name="log"></param>
        private void SetLog(string log, [CallerMemberName]string mehodName = "unknown")
        {
            TxbLogText += $"{mehodName} : {log}{Environment.NewLine}";
        }
    }
}
