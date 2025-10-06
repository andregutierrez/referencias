namespace Artigos.Referencias.DomainEvents.Application;

/// <summary>
/// Serviço responsável por enviar mensagens de e-mail.
/// </summary>
public interface IEmailService
{
    /// <summary>
    /// Envia um e-mail simples com destinatário, assunto e corpo.
    /// </summary>
    /// <param name="to">Endereço de e-mail do destinatário.</param>
    /// <param name="subject">Assunto da mensagem.</param>
    /// <param name="body">Conteúdo da mensagem em texto simples.</param>
    Task SendMail(string to, string subject, string body);
}
