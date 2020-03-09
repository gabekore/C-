using System.IO;
using System.Text;
using System.Xml.Serialization;

namespace XMLSettingsSample
{
    /// <summary>
    /// シングルトンクラス
    /// </summary>
    public class SettingsAccessor
    {
        // シングルトンのインスタンス
        private static SettingsAccessor _instance = new SettingsAccessor();

        // settings情報のモデル
        private XMLSettingsModel _model;

        // settings情報のファイル
        private string SETTINGS_XML = @"./settings.xml";

        /// <summary>
        /// シングルトンなのでインスタンスの取得が必要
        /// </summary>
        /// <returns></returns>
        public static SettingsAccessor GetInstance()
        {
            return _instance;
        }

        /// <summary>
        /// コンストラクタ
        /// シングルなので外からのnew禁止
        /// </summary>
        private SettingsAccessor()
        {
            // 最初にモデルを作っておく
            _model = new XMLSettingsModel();
        }

        /// <summary>
        /// settings情報の保存
        /// </summary>
        public void Save()
        {
            // シリアライズする（書き込む）
            using (var sw = new StreamWriter(SETTINGS_XML, false, new UTF8Encoding(false)))
            {
                XmlSerializer se = new XmlSerializer(typeof(XMLSettingsModel));
                se.Serialize(sw, _model);
            }
        }

        /// <summary>
        /// settings情報の読み込み
        /// </summary>
        public void Load()
        {
            // デシリアライズする（読み込み）
            using (var sr = new StreamReader(SETTINGS_XML, new UTF8Encoding(false)))
            {
                XmlSerializer se = new XmlSerializer(typeof(XMLSettingsModel));
                _model = (XMLSettingsModel)se.Deserialize(sr);
            }
        }

        /// <summary>
        /// settings情報を初期値に戻す
        /// </summary>
        public void Initialize()
        {
            _model = new XMLSettingsModel();
        }


        //=============================================================
        // 以下、プロパティ
        // 事前にLoad() or Initializeしてることが前提
        //=============================================================
        public bool boolCheckBox
        {
            get { return _model.boolCheckBox;  }
            set { _model.boolCheckBox = value; }
        }
        public string strTextBox
        {
            get { return _model.strTextBox; }
            set { _model.strTextBox = value; }
        }
        public int intRadioButton
        {
            get { return _model.intRadioButton; }
            set { _model.intRadioButton = value; }
        }
    }
}
