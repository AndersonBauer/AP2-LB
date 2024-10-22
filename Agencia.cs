using System.Runtime.ConstrainedExecution;
using System.Runtime.InteropServices;
using System.Runtime.InteropServices.Marshalling;
using Microsoft.VisualBasic;
public class Agencia 
{
    private List<Destino> Destinos;
    private List<Cliente> Clientes;
    private List<PacoteTuristico> PacotesTuristicos;
    private List<Reserva> Reservas;

    public Agencia()
    {
        Reservas = new List<Reserva>();
        Destinos = new List<Destino>();
        Clientes = new List<Cliente>();
        PacotesTuristicos = new List<PacoteTuristico>();
    }
    public void CadastrarDestino(Destino Destino)
    {   
        // percorendo a lista de destinos para ver se nao tem uma destino ja cadastrado ou se esta nulo
        if(Destino == null)
        {
            Console.WriteLine("Destino inválido. Não pode ser nulo\n");
            return;
        }
        foreach(var destinoExistente in Destinos)
        {
            if(destinoExistente.CodigoDestino == destinoExistente.CodigoDestino)
            {
                Console.WriteLine("\nEsse destino já está cadastrado.\n");
                return;
            }
        }

        Destinos.Add(Destino);
        Console.WriteLine("\nDestino cadastrado com sucesso.\n");
    }
    public void ConsultarDestinoPorCodigo(string codigoDestino)
    {
        foreach (var destino in Destinos )
        {
            if (destino.CodigoDestino == codigoDestino)
            {
                destino.ExibirInformacoesDestino();
                return;
            }
        }
        Console.WriteLine("\nDestino com o codigo informado não foi encontrado.\n");
    }
    public void ListarDestino()
    {
        if (Destinos.Count == 0)
        {
            Console.WriteLine("\nNão ha destinos cadastrados \n");
            return;
        }
        foreach(var destino in Destinos)
        {
            destino.ExibirInformacoesDestino();
            return;
        }
    }
    public void CadastrarCliente(Cliente Cliente)
    {
        foreach(var cliente in Clientes)
        {
            if(cliente == null)
            {
                Console.WriteLine("\nCliente inválido. Não pode ser nulo.\n");
                break;
            }
        }
        foreach(var cliente in Clientes)
        {
            if(cliente.IdCliente == Cliente.IdCliente)
            {
                Console.WriteLine("\nCliente já cadastrado.\n");
                break;
            }
        }
        Clientes.Add(Cliente);
        Console.WriteLine("Cliente cadastrado com sucesso.\n");
    }
    public void ConsultarClientePorId(string IdCliente)
    {
        foreach(var cliente in Clientes)
        {
            if (cliente.IdCliente == IdCliente)
            {
                cliente.ExibirInformacoesCliente();
                return;
            }
        }
        Console.WriteLine("\nCódigo do cliente não encontrado!\n");
    }
    public void ListarCliente()
    {
        if(Clientes.Count == 0)
        {
            Console.WriteLine("\nNão existem clientes cadastrados.\n");
        }
        foreach(var cliente in Clientes)
        {
            cliente.ExibirInformacoesCliente();
        }
    }
    public void CadastrarPacote(PacoteTuristico PacoteTuristico)
    {
        if(PacoteTuristico == null)
        {
                Console.WriteLine("\nPacote turistico inválido. Não pode ser nulo.");
                return;
        }
        foreach(var pacote in PacotesTuristicos)
        {
            if(pacote.CodigoPacote == PacoteTuristico.CodigoPacote)
            {
                Console.WriteLine("\nPacote turistico já cadastrado.\n");
                return;
            }
        }
        PacotesTuristicos.Add(PacoteTuristico);
        Console.WriteLine("\nPacote turistico cadastrado com sucesso!\n");
    }
    public PacoteTuristico ConsultarPacotePorCodigo(string CodigoPacote)
    {
        foreach(var pacote in PacotesTuristicos)
        {
            if(pacote.CodigoPacote == CodigoPacote)
            {
                Console.WriteLine($"\nPacote encontrado\nDestino do Pacote: {pacote.Destino}\nCodigo do pacote: {pacote.CodigoPacote}\nDescrição: {pacote.DescricaoServico}\nDataInicio: {pacote.DataInicio.ToString("dd/MM/yyyy")}\nData fim: {pacote.DataFim.ToString("dd/MM/yyyy")}\nPreço do pacote: {pacote.Preco}\n");
                return pacote;
            }
        }
        Console.WriteLine("");
        return null;
    }
    public void ListarPacote()
    {
        if(PacotesTuristicos.Count == 0)
        {
            Console.WriteLine("\nNenhum pacote encontrado.\n");
        }
        foreach(var pacote in PacotesTuristicos)
        {
            Console.WriteLine($"\nPacote encontrado\nDestino do Pacote: {pacote.Destino}\nCodigo do pacote: {pacote.CodigoPacote}\nDescrição: {pacote.DescricaoServico}\nDataInicio: {pacote.DataInicio}\nData fim: {pacote.DataFim}\nPreço do pacote: {pacote.Preco}\n");
        }
    }
    public void ReservarPacote(string codigoPacote, Cliente cliente)
    {
        if(cliente == null)
        {
            Console.WriteLine("\nCliente invalido.zn");
            return;
        }
        var pacote = ConsultarPacotePorCodigo(codigoPacote);
        if(codigoPacote  == null)
        {
            Console.WriteLine("\nPacote não encontrado.\n");
            return;
        }
        if(pacote == null)
        {
            Console.WriteLine("\nPacote não encontrado.\n");
            return;
        }
        if(pacote.VagasDisponiveis<= 0)
        {
            Console.WriteLine("\nNão há vagas disponiveis para esse pacote.\n");
        }
        pacote.Reservar();
        Console.WriteLine("\nPacote Reservado!\n");
    }
    public void CancelarReserva(string codigoReserva)
    {
        Reserva? reservaEncontrada = null;
        foreach(var reserva in Reservas)
        {
            if (reserva.CodigoReserva == codigoReserva)
            {
                reservaEncontrada = reserva;
                break;
            }
            if(reservaEncontrada != null)
            {
                reservaEncontrada.Cancelar();
                Console.WriteLine($"\nReserva com código {codigoReserva} foi cancelada com sucesso.\n");
            }
            else
            {
                Console.WriteLine("\nReserva não encontrada.\n");
            }
        }
    }
}