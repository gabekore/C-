namespace XMLSettingsSample
{
    public class XMLSettingsModel
    {
        // アプリとしてのデフォルト値を明示的に入れておく方がいい
        // 設定値を全てデフォルトにしたい時のためにも便利だし
        public bool   boolCheckBox   { get; set; } = false;
        public string strTextBox     { get; set; } = "initial";
        public int    intRadioButton { get; set; } = -1;
    }
}
