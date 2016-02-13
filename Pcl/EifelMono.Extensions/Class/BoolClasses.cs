using System;
using System.Threading;

namespace EifelMono.Extensions
{
    public class First
    {
        public First()
        {
            Reset();
        }

        private bool m_IsFirst = true;

        public bool IsFirst
        {
            get
            {
                if (m_IsFirst)
                {
                    m_IsFirst = false;
                    return true;
                }
                return false;
            }
        }

        public void Reset()
        {
            m_IsFirst = true;
        }
    }
}

