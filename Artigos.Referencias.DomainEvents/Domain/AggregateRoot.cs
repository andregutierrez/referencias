namespace Artigos.Referencias.DomainEvents.Domain;

/// <summary>
/// Classe base para agregados do domínio, responsável por armazenar
/// e expor os eventos de domínio gerados durante mudanças de estado.
/// </summary>
public abstract class AggregateRoot
{
    private readonly List<IDomainEvent> _domainEvents = new();

    /// <summary>
    /// Eventos de domínio registrados pelo agregado durante a execução.
    /// </summary>
    public IReadOnlyCollection<IDomainEvent> DomainEvents => _domainEvents.AsReadOnly();

    /// <summary>
    /// Registra um novo evento de domínio a ser publicado externamente.
    /// </summary>
    /// <param name="domainEvent">Instância do evento de domínio gerado.</param>
    protected void RegisterEvent(IDomainEvent domainEvent)
    {
        _domainEvents.Add(domainEvent);
    }

    /// <summary>
    /// Remove todos os eventos de domínio já processados.
    /// </summary>
    public void ClearDomainEvents()
    {
        _domainEvents.Clear();
    }
}
