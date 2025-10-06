using Artigos.Referencias.DomainEvents.Application;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace Artigos.Referencias.DomainEvents.Infrastructure;

/// <summary>
/// Implementação fake de <see cref="IMessageBroker"/> que apenas escreve
/// no console as mensagens e o tópico, simulando uma publicação.
/// </summary>
public class FakeMessageBroker : IMessageBroker
{
    /// <summary>
    /// Simula a publicação de uma mensagem serializando-a e exibindo no console.
    /// </summary>
    /// <param name="message">Mensagem a ser publicada.</param>
    /// <param name="topic">Tópico ou rota onde a mensagem seria publicada.</param>
    public Task Publish(object message, string topic)
    {
        var serializedMessage = JsonSerializer.Serialize(message, new JsonSerializerOptions { WriteIndented = true });
        Console.WriteLine("-------------------------------------------------");
        Console.WriteLine($"[INFRA] Publicando mensagem no tópico '{topic}'...");
        Console.WriteLine(serializedMessage);
        Console.WriteLine("-------------------------------------------------");
        return Task.CompletedTask;
    }
}