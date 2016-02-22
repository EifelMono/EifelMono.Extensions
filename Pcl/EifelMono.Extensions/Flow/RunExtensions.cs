using System;
using System.Threading.Tasks;

namespace EifelMono.Extensions
{
    public static class Run
    {
        /// <summary>
        /// Execute the specified action.
        /// Run.Execute(async()=> {doSomeThing;});
        /// </summary>
        /// <param name="action">Action.</param>
        public static void Execute(Action action)
        {
            action();
        }
    }
}

