using Artigos.Referencias.DomainEvents.Domain;

namespace Artigos.Referencias.DomainEvents.Application;

/// <summary>
///     Manipulador responsável por publicar um evento de integração quando um pedido é pago.
/// </summary>
public class PublicarEventoIntegracaoHandler : IEventHandler<PedidoPagoEvent>
{
    private readonly IMessageBroker _messageBroker;

    /// <summary>
    /// Cria uma nova instância do manipulador de publicação em broker.
    /// </summary>
    /// <param name="messageBroker">Abstração do broker de mensagens para publicar eventos.</param>
    public PublicarEventoIntegracaoHandler(IMessageBroker messageBroker)
    {
        _messageBroker = messageBroker;
    }

    /// <summary>
    /// Constrói um evento de integração e o publica no broker de mensagens.
    /// </summary>
    /// <param name="domainEvent">Evento de domínio com os dados do pedido pago.</param>
    /// <param name="cancellationToken">Token para cancelamento cooperativo.</param>
    public async Task Handle(PedidoPagoEvent domainEvent, CancellationToken cancellationToken)
    {
        Console.WriteLine("[HANDLER] PublicarEventoIntegracaoHandler ativado.");

        // Cria um evento de integração
        var integrationEvent = new
        {
            EventId = Guid.NewGuid(),
            Timestamp = DateTime.UtcNow,
            EventType = "PedidoPago",
            Payload = new
            {
                IdPedido = domainEvent.PedidoId,
                ValorPago = domainEvent.Valor,
                DataPagamento = domainEvent.DataPagamento
            }
        };

        // Publica no broker para outros serviços (Logística, Financeiro, etc.)
        await _messageBroker.Publish(integrationEvent, "topico-pedidos");
    }
}
