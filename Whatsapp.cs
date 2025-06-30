// Estrutura do Código C#

// Arquivo 1: Contato.cs

public class Contato
{
    public string Nome { get; private set; }
    public string Celular { get; private set; }

    public Contato(string nome, string celular)
    {
        Nome = nome;
        Celular = celular;
    }

    public override string ToString()
    {
        return $"{Nome} ({Celular})";
    }
}

// Arquivo 2: Mensagem.cs

public abstract class Mensagem
{
    public Contato Destinatario { get; protected set; }
    public string HoraEnvio { get; protected set; }
    public string Conteudo { get; protected set; }

    public Mensagem(Contato destinatario, string horaEnvio, string conteudo)
    {
        Destinatario = destinatario;
        HoraEnvio = horaEnvio;
        Conteudo = conteudo;
    }

    public abstract void ExibirMensagem();
}

// Arquivo 3: MensagemTexto.cs

public class MensagemTexto : Mensagem
{
    public MensagemTexto(Contato destinatario, string horaEnvio, string conteudo)
        : base(destinatario, horaEnvio, conteudo)
    {
    }

    public override void ExibirMensagem()
    {
        Console.WriteLine($"Para: {Destinatario} | Hora: {HoraEnvio} | Conteúdo: {Conteudo}");
    }
}

// Arquivo 4: Whatsapp.cs

using System;
using System.Collections.Generic;

public class Whatsapp
{
    private List<Contato> contatos;
    private List<Mensagem> mensagens;

    public Whatsapp()
    {
        contatos = new List<Contato>();
        mensagens = new List<Mensagem>();
    }

    public void AdicionarContato(Contato contato)
    {
        contatos.Add(contato);
    }

    public void AdicionarMensagem(Mensagem mensagem)
    {
        mensagens.Add(mensagem);
    }

    public void ListarContatos()
    {
        Console.WriteLine("Contatos:");
        foreach (var contato in contatos)
        {
            Console.WriteLine($"- {contato}");
        }
    }

    public void ListarMensagens()
    {
        Console.WriteLine("Mensagens:");
        foreach (var mensagem in mensagens)
        {
            mensagem.ExibirMensagem();
        }
    }
}

// Arquivo 5: Program.cs (classe principal)

using System;

class Program
{
    static void Main(string[] args)
    {
        var app = new Whatsapp();

        var contato1 = new Contato("Alice", "9999-0001");
        var contato2 = new Contato("Bob", "9999-0002");

        app.AdicionarContato(contato1);
        app.AdicionarContato(contato2);

        var mensagem1 = new MensagemTexto(contato1, "10:00", "Bom dia!");
        var mensagem2 = new MensagemTexto(contato2, "10:05", "Olá, tudo bem?");

        app.AdicionarMensagem(mensagem1);
        app.AdicionarMensagem(mensagem2);

        app.ListarContatos();
        Console.WriteLine();
        app.ListarMensagens();
    }
}
