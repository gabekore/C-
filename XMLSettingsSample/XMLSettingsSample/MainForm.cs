using System;
using System.Windows.Forms;

namespace XMLSettingsSample
{
    public partial class MainForm : Form
    {
        // settings情報へのアクセサ
        SettingsAccessor _acs;

        // ラジオボタンのコントロール配列
        // チェックされてるやつを見つけるのにforeach使いたいだけ
        RadioButton[] aryRadioButton = new RadioButton[3];

        /// <summary>
        /// 画面のコンストラクタ
        /// </summary>
        public MainForm()
        {
            InitializeComponent();

            // settings情報のアクセサを取得しておく
            _acs = SettingsAccessor.GetInstance();

            // ラジオボタンのコントロール配列
            aryRadioButton[0] = radioButton1;
            aryRadioButton[1] = radioButton2;
            aryRadioButton[2] = radioButton3;
        }

        /// <summary>
        /// Writeボタン
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnWrite_Click(object sender, EventArgs e)
        {
            // 現在の画面の値を取得
            _acs.boolCheckBox = checkBox1.Checked;
            _acs.strTextBox = textBox1.Text;
            foreach (var (value, index) in aryRadioButton.ToTuples())
            {
                if (value.Checked)
                {
                    _acs.intRadioButton = index;
                }
            }

            // セーブ
            _acs.Save();
        }

        /// <summary>
        /// Readボタン
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnRead_Click(object sender, EventArgs e)
        {
            // ロード
            _acs.Load();

            // 各設定値を画面に反映
            SettingValueToScreen();
        }

        /// <summary>
        /// Initializeボタン
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnInitialize_Click(object sender, EventArgs e)
        {
            // 各設定値を初期値にする
            _acs.Initialize();

            // 各設定値を画面に反映
            SettingValueToScreen();
        }

        /// <summary>
        /// 各設定値を画面に反映
        /// </summary>
        private void SettingValueToScreen()
        {
            // 初期値にしたので、画面に反映
            checkBox1.Checked = _acs.boolCheckBox;
            textBox1.Text = _acs.strTextBox;
            if (_acs.intRadioButton >= 0)
            {
                aryRadioButton[_acs.intRadioButton].Checked = true;
            }
            else
            {
                foreach (var (v,i) in aryRadioButton.ToTuples())
                {
                    v.Checked = false;
                }
            }
        }
    }
}
