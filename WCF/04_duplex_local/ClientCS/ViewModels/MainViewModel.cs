using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.ServiceModel;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Threading;
using ClientCS.GabekoreApiService;
using ServiceIF;
using ServiceIF.ObjIF;

namespace ClientCS.ViewModels
{
    public class MainViewModel : ViewModelBase, GabekoreApiService.IServiceCallback
    {
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
        // コールバック登録処理
        //-------------------------------------------------
        //private GabekoreApiService.ServiceClient _client;
        public void CallbackInitial()
        {
            // 双方向通信を行う場合、サービス側にコールバックの実装を教える必要がある。
            // 参照設定：System.ServiceModel.dll
            var context = new InstanceContext(this);
            var _client = new GabekoreApiService.ServiceClient(context);
            
            _client.CallbackRegist("PID_HOGE");
        }

        public void CallbackFunction(
                string param1,
                int param2,
                double param3,
                string[] param4,
                RetClass[] param5)
        {
            SetLog("コールバック来た");
        }
        


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
                using (var client = new GabekoreApiService.ServiceClient(new InstanceContext(this)))
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
                using (var client = new ServiceClient(new InstanceContext(this)))
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
                using (var client = new ServiceClient(new InstanceContext(this)))
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
                using (var client = new ServiceClient(new InstanceContext(this)))
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
                using (var client = new ServiceClient(new InstanceContext(this)))
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
                using (var client = new ServiceClient(new InstanceContext(this)))
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
                using (var client = new ServiceClient(new InstanceContext(this)))
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
