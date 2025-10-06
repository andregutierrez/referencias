namespace Artigos.Referencias.DomainEvents.Domain;

/// <summary>
/// Entidade de domínio que representa um pedido de compra.
/// </summary>
public class Pedido : AggregateRoot
{
    /// <summary>
    /// Identificador único do pedido.
    /// </summary>
    public Guid Id { get; private set; }

    /// <summary>
    /// E-mail do cliente associado ao pedido.
    /// </summary>
    public string ClienteEmail { get; private set; }

    /// <summary>
    /// Status atual do pedido (ex.: Pendente, Pago).
    /// </summary>
    public string Status { get; private set; }

    /// <summary>
    /// Valor total do pedido.
    /// </summary>
    public decimal Valor { get; private set; }

    /// <summary>
    /// Cria um novo pedido com status inicial "Pendente".
    /// </summary>
    /// <param name="id">Identificador do pedido.</param>
    /// <param name="clienteEmail">E-mail do cliente.</param>
    /// <param name="valor">Valor total do pedido.</param>
    public Pedido(Guid id, string clienteEmail, decimal valor)
    {
        Id = id;
        ClienteEmail = clienteEmail;
        Valor = valor;
        Status = "Pendente"; // Status inicial
    }

    /// <summary>
    /// Regra de negócio: marca o pedido como pago e registra o evento correspondente.
    /// </summary>
    /// <exception cref="InvalidOperationException">Lançada quando o pedido não está pendente.</exception>
    public void MarcarComoPago()
    {
        if (Status != "Pendente")
        {
            throw new InvalidOperationException("Apenas pedidos pendentes podem ser pagos.");
        }

        Status = "Pago";
        Console.WriteLine($"[DOMÍNIO] Status do Pedido {Id} alterado para 'Pago'.");

        // Registra o evento de domínio. O agregado apenas notifica que algo aconteceu.
        // Ele não sabe quem vai ouvir ou o que será feito.
        RegisterEvent(new PedidoPagoEvent(this.Id, this.ClienteEmail, this.Valor));
    }
}
