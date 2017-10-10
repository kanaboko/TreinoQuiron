using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Text;
using System.Threading.Tasks;

namespace QuironLojaVirtual.Domain.Entities
{
    public class EmailPedido
    {
        private readonly EmailConfiguracoes _emailConfiguracoes;

        public EmailPedido(EmailConfiguracoes emailConfiguracoes)
        {
            _emailConfiguracoes = emailConfiguracoes;
        }

        public void ProcessarPedido(Carrinho carrinho, Pedido pedido)
        {
            using (var smtpClient = new SmtpClient())
            {
                smtpClient.EnableSsl = _emailConfiguracoes.UsarSsl;
                smtpClient.Host = _emailConfiguracoes.ServidorSmtp;
                smtpClient.Port = _emailConfiguracoes.ServidorPorta;
                smtpClient.UseDefaultCredentials = false;
                smtpClient.Credentials = new NetworkCredential(_emailConfiguracoes.Usuario, _emailConfiguracoes.ServidorSmtp);
                if (_emailConfiguracoes.EscreverArquivo)
                {
                    smtpClient.DeliveryMethod = SmtpDeliveryMethod.SpecifiedPickupDirectory;
                    smtpClient.PickupDirectoryLocation = _emailConfiguracoes.PastaArquivo;
                    smtpClient.EnableSsl = false;
                }

                StringBuilder emailBody = new StringBuilder()
                    .AppendLine("Novo pedido:")
                    .AppendLine("-------")
                    .AppendLine("Itens:");

                foreach (var item in carrinho.ItensCarrinho)
                {
                    var subtotal = item.Produto.Preco * item.Quantidade;
                    emailBody.Append($"{item.Quantidade} x {item.Produto.Nome} ( subtotal:  {subtotal:C}");
                }

                emailBody.AppendLine($"Valor total do pedido: {carrinho.ObterValorTotal():C}")
                    .AppendLine("------------------------")
                    .AppendLine("Enviar para:")
                    .AppendLine(pedido.Nome)
                    .AppendLine(pedido.Email)
                    .AppendLine(pedido.Endereco ?? "")
                    .AppendLine(pedido.Complemento ?? "")
                    .AppendLine(pedido.Bairro ?? "")
                    .AppendLine(pedido.Cidade ?? "")
                    .AppendLine(pedido.Estado ?? "")
                    .AppendLine("-------------------------")
                    .AppendLine($"Embrulhar para presente? {(pedido.EmbrulhaPresente ? "Sim" : "Não")}");

                MailMessage mailMessage = new MailMessage(
                    _emailConfiguracoes.De, 
                    _emailConfiguracoes.Para, 
                    "Novo pedido", 
                    emailBody.ToString());

                if (_emailConfiguracoes.EscreverArquivo)
                {
                    mailMessage.BodyEncoding = Encoding.GetEncoding("ISO-8859-1");
                }

                smtpClient.Send(mailMessage);
            }
        }
    }

}
