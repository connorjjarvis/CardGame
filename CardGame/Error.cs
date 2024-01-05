using CardGame.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CardGame
{
    public class Error : IError
    {
        public string Message { get; set; }

        public Error(string message)
        {
            Message = message;
        }
    }
}
