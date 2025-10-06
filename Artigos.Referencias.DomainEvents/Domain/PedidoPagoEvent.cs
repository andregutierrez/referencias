using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Artigos.Referencias.DomainEvents.Domain;

/// <summary>
/// Evento de domínio disparado quando um pedido é marcado como pago.
/// </summary>
public class PedidoPagoEvent : IDomainEvent
{
    /// <summary>
    /// Identificador do pedido relacionado ao pagamento.
    /// </summary>
    public Guid PedidoId { get; }

    /// <summary>
    /// E-mail do cliente associado ao pedido.
    /// </summary>
    public string ClienteEmail { get; }

    /// <summary>
    /// Valor pago no pedido.
    /// </summary>
    public decimal Valor { get; }

    /// <summary>
    /// Data e hora em que o pagamento foi registrado.
    /// </summary>
    public DateTime DataPagamento { get; }

    /// <summary>
    /// Cria um novo evento de pedido pago.
    /// </summary>
    /// <param name="pedidoId">Identificador do pedido.</param>
    /// <param name="clienteEmail">E-mail do cliente.</param>
    /// <param name="valor">Valor pago.</param>
    public PedidoPagoEvent(Guid pedidoId, string clienteEmail, decimal valor)
    {
        PedidoId = pedidoId;
        ClienteEmail = clienteEmail;
        Valor = valor;
        DataPagamento = DateTime.UtcNow;
    }
}