using System;

namespace MassInmemoryTransport.DataAccess
{
    public class SimpleRepository : IRepository
    {
        public void DoAnything()
        {
            Console.WriteLine("Database In Action");
        }
    }
}
