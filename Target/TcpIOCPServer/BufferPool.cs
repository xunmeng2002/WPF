using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TcpIOCPServer
{
    public class BufferPool
    {
        Stack<byte[]> m_pool;
        int m_bufferSize;
        public BufferPool(int capacity, int bufferSize)
        {
            m_pool = new Stack<byte[]>(capacity);
            m_bufferSize = bufferSize;
        }
        public void Push(byte[] item)
        {
            if (item == null)
            {
                throw new ArgumentNullException("Items added to a SocketAsyncEventArgsPool cannot be null");
            }
            lock (m_pool)
            {
                m_pool.Push(item);
            }
        }
        public byte[] Pop()
        {
            lock (m_pool)
            {
                if (m_pool.Count == 0)
                {
                    return new byte[m_bufferSize];
                }
                return m_pool.Pop();
            }
        }
        public int Count
        {
            get { return m_pool.Count; }
        }
    }
}
