using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static MainProgramGUI.MainForm;

namespace MainProgramGUI
{
    public class PluginLogWriter : TextWriter
    {
        public override Encoding Encoding => Encoding.UTF8;

        MainForm _frm = null;

        /// <summary>
        /// コンストラクタ
        /// </summary>
        /// <param name="frm">呼び元のForm</param>
        public PluginLogWriter(MainForm frm)
        {
            this._frm = frm;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="value"></param>
        public override void WriteLine(string value)
        {
            _frm.LogOutInvoke(LOG_LEVEL.ERROR, value);
        }

        public override void WriteLine(string format, object arg0)
        {
            LOG_LEVEL level = (LOG_LEVEL)arg0;
            _frm.LogOutInvoke(level, format);
        }

    }
}
