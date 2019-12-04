using System;

namespace parking_lot
{
    public class NotFoundException : Exception
    {
        public NotFoundException(string invalidTicket):base(invalidTicket)
        {
            
        }
    }
}