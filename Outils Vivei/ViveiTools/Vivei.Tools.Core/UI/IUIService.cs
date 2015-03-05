using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ComponentModel;
using System.Collections.ObjectModel;

namespace Vivei.Tools.Core.UI
{
    /// <summary>
    /// 
    /// </summary>
    public interface IUIService : IService
    {
        /// <summary>
        /// 
        /// </summary>
        MenuItemCollection MainMenu { get; }

        MenuItem HomeMenuItem { get; }
        MenuItem BackMenuItem { get; }
        MenuItem ForwardMenuItem { get; }
        MenuItem UndoMenuItem { get; }
        MenuItem RedoMenuItem { get; }
        MenuItem WindowsMenuItem { get; }
        MenuItem OptionsMenuItem { get; }
        MenuItem HelpMenuItem { get; }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="caption"></param>
        /// <param name="icone"></param>
        /// <param name="view"></param>
        IToolWindow RegisterWindow(string id, string caption, string icon, object view);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="caption"></param>
        /// <param name="icone"></param>
        /// <param name="view"></param>
        IDocumentWindow OpenDocument(string caption, string icon, object view);

        IWindowCollection Windows { get; }
    }

    public interface IWindow : System.ComponentModel.INotifyPropertyChanged, System.ComponentModel.INotifyPropertyChanging
    {
        string Icon { get; set; }
        string Caption { get; set; }
        bool IsActive { get; set; }
        bool IsVisible { get; set; }
        object View { get; }
    }
    public interface IToolWindow : IWindow
    {
        string Name { get; }
        object State { get; }
        bool IsHidden { get; }
        void Hide();
    }
    public interface IDocumentWindow : IWindow
    {
        bool IsClosed { get; }
        void Close();
    }
}