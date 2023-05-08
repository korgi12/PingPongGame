using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PingPongGame.BackProgram
{
    class PositionNotFullySpecifiedException : ApplicationException
    {

        public PositionNotFullySpecifiedException() : base() { }

        public PositionNotFullySpecifiedException(string message) : base(message) { }

    }
}
