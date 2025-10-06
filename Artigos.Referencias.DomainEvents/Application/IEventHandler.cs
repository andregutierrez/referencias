using Artigos.Referencias.DomainEvents.Domain;

namespace Artigos.Referencias.DomainEvents.Application;

/// <summary>
///  Contrato para manipuladores (handlers) de eventos de domínio.
/// </summary>
/// <typeparam name="TEvent">
///  Tipo concreto do evento de domínio que será tratado pelo manipulador.
/// </typeparam>
public interface IEventHandler<in TEvent> where TEvent : IDomainEvent
{
    /// <summary>
    ///  Trata o <typeparamref name="TEvent"/> recebido.
    /// </summary>
    /// <param name="domainEvent">Instância do evento de domínio a ser processado.</param>
    /// <param name="cancellationToken">Token para cancelamento cooperativo da operação assíncrona.</param>
    Task Handle(TEvent domainEvent, CancellationToken cancellationToken);
}
