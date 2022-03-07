using System;
using System.Windows.Input;

namespace WpfDemo;

public class RelayCommand : ICommand
{
    #region Fields

    private readonly Action<object> oExecute;
    private readonly Predicate<object> oCanExecute;

    #endregion // Fields

    #region Constructors

    public RelayCommand(Action<object> fExecute)
        : this(fExecute, null)
    {
    }

    public RelayCommand(Action<object> fExecute, Predicate<object> fCanExecute)
    {
        oExecute = fExecute ?? throw new ArgumentNullException("execute");
        oCanExecute = fCanExecute;
    }

    #endregion // Constructors

    #region ICommand Members

    public bool CanExecute(object oParameters)
    {
        return oCanExecute == null || oCanExecute(oParameters);
    }

    public event EventHandler CanExecuteChanged
    {
        add => CommandManager.RequerySuggested += value;
        remove => CommandManager.RequerySuggested -= value;
    }

    public void Execute(object oParameters)
    {
        oExecute(oParameters);
    }

    #endregion // ICommand Members
}
