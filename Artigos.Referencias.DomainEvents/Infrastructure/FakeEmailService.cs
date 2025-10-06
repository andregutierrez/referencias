using Artigos.Referencias.DomainEvents.Application;

namespace Artigos.Referencias.DomainEvents.Infrastructure;

/// <summary>
/// Implementação fake de <see cref="IEmailService"/> que apenas registra
/// no console o envio de e-mails para fins de demonstração/teste.
/// </summary>
public class FakeEmailService : IEmailService
{
    /// <summary>
    /// Simula o envio de um e-mail escrevendo as informações no console.
    /// </summary>
    /// <param name="to">Endereço de e-mail do destinatário.</param>
    /// <param name="subject">Assunto da mensagem.</param>
    /// <param name="body">Conteúdo da mensagem.</param>
    public Task SendMail(string to, string subject, string body)
    {
        Console.WriteLine("-------------------------------------------------");
        Console.WriteLine($"[INFRA] Enviando e-mail para: {to}");
        Console.WriteLine($"[INFRA] Assunto: {subject}");
        Console.WriteLine($"[INFRA] Corpo: {body}");
        Console.WriteLine("-------------------------------------------------");
        return Task.CompletedTask;
    }
}
