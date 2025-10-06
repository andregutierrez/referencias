using Artigos.Referencias.DomainEvents.Domain;

namespace Artigos.Referencias.DomainEvents.Application;

/// <summary>
/// Manipulador responsável por enviar um e-mail de notificação quando um pedido é pago.
/// </summary>
public class NotificacaoEmailPedidoHandler : IEventHandler<PedidoPagoEvent>
{
    private readonly IEmailService _emailService;

    /// <summary>
    /// Cria uma nova instância do manipulador de notificação por e-mail.
    /// </summary>
    /// <param name="emailService">Serviço de envio de e-mails.</param>
    public NotificacaoEmailPedidoHandler(IEmailService emailService)
    {
        _emailService = emailService;
    }

    /// <summary>
    /// Envia um e-mail ao cliente confirmando o pagamento do pedido.
    /// </summary>
    /// <param name="domainEvent">Evento de domínio que contém os dados do pedido pago.</param>
    /// <param name="cancellationToken">Token para cancelamento cooperativo.</param>
    public async Task Handle(PedidoPagoEvent domainEvent, CancellationToken cancellationToken)
    {
        Console.WriteLine("[HANDLER] NotificacaoEmailPedidoHandler ativado.");
        await _emailService.SendMail(
            domainEvent.ClienteEmail,
            "Seu pedido foi pago!",
            $"Olá! O pagamento do seu pedido {domainEvent.PedidoId} de R$ {domainEvent.Valor} foi confirmado."
        );
    }
}
