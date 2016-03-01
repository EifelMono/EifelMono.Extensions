using System;
using System.Threading.Tasks;

namespace EifelMono.Extensions
{
    public static class Flow
    {
        /// <summary>
        /// Execute the specified action.
        /// Run.Execute(async()=> {doSomeThing;});
        /// </summary>
        /// <param name="action">Action.</param>
        public static void Run(Action action)
        {
            action();
        }

        public static async Task RunAsyn(Func<Task> action)
        {
            await action();
        }

        public static async Task<T> RunAsyn<T>(Func<Task<T>> action)
        {
            return await action();
        }
    }
}

