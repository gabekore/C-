using System;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Windows.Threading;

/// <summary>
/// 参照設定でWindowsBaseが必要かも
/// </summary>
namespace Server.ViewModels
{
    public abstract class ViewModelBase : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

        // UIスレッド等を管理してくれる
        protected Dispatcher Dispatcher { get; set; }

        protected bool SetProperty<T>(
                                ref T field,
                                T value, 
                                [CallerMemberName]string propertyName = null)
        {
            if (Equals(field, value))
            {
                return false;
            }

            field = value;
            var h = this.PropertyChanged;
            if (h != null)
            {
                if (Dispatcher != null)
                {
                    // DispatcherはUIスレッドという前提
                    // nullじゃない（UIスレッドである）のであればUIスレッドを呼び出す
                    Dispatcher.Invoke(() => h(this, new PropertyChangedEventArgs(propertyName)));
                }
                else
                {
                    h(this, new PropertyChangedEventArgs(propertyName));
                }
            }

            return true;
        }

        public virtual DateTime GetDateTime()
        {
            return DateTime.Now;
        }
    }
}
