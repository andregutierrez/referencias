
/***************************************************************************************************
 *
 *  O padrão de Eventos de Domínio implementado neste exemplo é baseado nos conceitos
 *  apresentados no seguinte artigo, que detalha como essa abordagem ajuda a criar
 *  arquiteturas de software mais limpas, desacopladas e sustentáveis.
 *
 *  Artigo: "Como Eventos de Domínio auxiliam na Arquitetura de Software"
 *  Autor: André Luiz Gutierrez Filho
 *  Link: https://www.linkedin.com/pulse/como-eventos-de-dominio-auxiliam-na-arquitetura-gutierrez-filho-hc27f
 *
 ***************************************************************************************************/

using Artigos.Referencias.DomainEvents.Application;
using Artigos.Referencias.DomainEvents.Domain;
using Artigos.Referencias.DomainEvents.Infrastructure;

// -----------------------------------------------------------------------------
// SIMULAÇÃO didática para demonstrar como eventos de 
// domínio ajudam a desacoplar funcionalidades auxiliares (ex.: envio de e-mail 
// e publicação de integração) da regra de negócio principal do agregado `Pedido`.
// -----------------------------------------------------------------------------
var pedido = new Pedido(Guid.NewGuid(), "cliente@email.com", 150.75m);
Console.WriteLine($"Pedido {pedido.Id} criado com status '{pedido.Status}'.\n");

Console.WriteLine("--> Executando o método MarcarComoPago()...");
try
{
    pedido.MarcarComoPago();
}
catch (InvalidOperationException ex)
{
    Console.WriteLine($"Erro: {ex.Message}");
    return;
}
Console.WriteLine("--> Método MarcarComoPago() concluído.\n");


// -----------------------------------------------------------------------------
// Importante: não estamos usando MediatR, padrões de Observer, ou um event bus
// real. Os handlers são instanciados e chamados manualmente para evidenciar o
// conceito de desacoplamento do domínio em relação às preocupações externas.
// -----------------------------------------------------------------------------
// SUGIRO MediatR EM PORJETOS REAIS
// -----------------------------------------------------------------------------
var emailService = new FakeEmailService();
var messageBroker = new FakeMessageBroker();

// Handlers auxiliares (infraestrutura) que reagem ao evento de domínio
var emailHandler = new NotificacaoEmailPedidoHandler(emailService);
var integrationHandler = new PublicarEventoIntegracaoHandler(messageBroker);

Console.WriteLine($"O agregado 'Pedido' registrou {pedido.DomainEvents.Count} evento(s). Disparando agora...");

// SIMULAÇÃO de "dispatch" de eventos: sem MediatR/Observer; chamada direta dos handlers
foreach (var domainEvent in pedido.DomainEvents)
{
    if (domainEvent is PedidoPagoEvent eventoPago)
    {
        await emailHandler.Handle(eventoPago, CancellationToken.None);
        await integrationHandler.Handle(eventoPago, CancellationToken.None);
    }
}

pedido.ClearDomainEvents();