using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Common.Interfaces
{
    public interface IMessageProducer
    {
        Task PublishAsync<TEvent>(TEvent eventMassage , string topic )where TEvent:IEvent ;

    }
}