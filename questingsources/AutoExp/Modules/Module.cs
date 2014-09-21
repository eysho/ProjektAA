using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace AutoExp.Modules
{

    internal class Module
    {
        private CancellationTokenSource ts;
        CancellationToken ct;
        internal Host host;

        public virtual void Start(Host host)
        {
            this.host = host;
            try
            {
                ts = new CancellationTokenSource();
                ct = ts.Token;
                Task.Factory.StartNew(() =>
                {
                    Run(ct);
                }, ct);
            }
            catch (Exception error)
            { Console.WriteLine(error.ToString()); }
        }

        public virtual void Run(CancellationToken ct)
        {
            ct.ThrowIfCancellationRequested();
        }

        public virtual void Stop()
        {
            try
            {
                ts.Cancel();
            }
            catch { }
        }
    }
}
