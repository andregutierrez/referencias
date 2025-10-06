using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Artigos.Referencias.DomainEvents.Application;

/// <summary>
/// Abstração para publicação de mensagens em um broker de mensagens.
/// </summary>
public interface IMessageBroker
{
    /// <summary>
    /// Publica uma <paramref name="message"/> em um determinado <paramref name="topic"/>.
    /// </summary>
    /// <param name="message">Mensagem a ser publicada. Pode ser um DTO ou envelope.</param>
    /// <param name="topic">Tópico, fila ou rota onde a mensagem será publicada.</param>
    Task Publish(object message, string topic);
}