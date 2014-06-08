using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassLibrary
{
    /*
     * Interface defining contract for Actions
     * 
     * Implemented by Ryan Brown
     */
    public interface IAction
    {
        Message Execute(Message message);
    }
}
