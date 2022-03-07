using System;
using System.Threading;
using System.Windows.Threading;

namespace WpfDemo;

public static class MyDispatcher
{
    public static Dispatcher StartNew()
    {
        int nLoop = 0;
        Thread oThread = new Thread(new ThreadStart(() => Dispatcher.Run()));
        oThread.SetApartmentState(ApartmentState.STA);
        oThread.IsBackground = true;
        oThread.Start();

        Dispatcher oDispatcher = Dispatcher.FromThread(oThread);
        while (oDispatcher == null)
        {
            if (nLoop++ > 200)
            {
                throw new InvalidOperationException("Can't start a new Dispatcher-thread");
            }
            Thread.Sleep(10);
            oDispatcher = Dispatcher.FromThread(oThread);
        }

        return oDispatcher;
    }
}
