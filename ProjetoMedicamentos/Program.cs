using System;

class Program
{
    static void Main(string[] args)
    {
        Medicamentos estoque = new Medicamentos();
        int opcao = -1;

        while (opcao != 0)
        {
            Console.WriteLine("\n--- MENU FARMÁCIA ---");
            Console.WriteLine("0. Finalizar processo");
            Console.WriteLine("1. Cadastrar medicamento");
            Console.WriteLine("2. Consultar medicamento (sintético)");
            Console.WriteLine("3. Consultar medicamento (analítico)");
            Console.WriteLine("4. Comprar medicamento (cadastrar lote)");
            Console.WriteLine("5. Vender medicamento");
            Console.WriteLine("6. Listar medicamentos");
            Console.Write("Escolha uma opção: ");

            if (!int.TryParse(Console.ReadLine(), out opcao)) continue;

            switch (opcao)
            {
                case 0:
                    Console.WriteLine("Encerrando...");
                    break;
                case 1:
                    Console.Write("ID do medicamento: ");
                    int id = int.Parse(Console.ReadLine());
                    Console.Write("Nome: ");
                    string nome = Console.ReadLine();
                    Console.Write("Laboratório: ");
                    string lab = Console.ReadLine();
                    estoque.adicionar(new Medicamento(id, nome, lab));
                    Console.WriteLine("Medicamento cadastrado!");
                    break;
                case 2:
                    Console.Write("ID do medicamento para consulta: ");
                    int idCons = int.Parse(Console.ReadLine());
                    Medicamento medCons = estoque.pesquisar(new Medicamento(idCons, "", ""));
                    if (medCons.Id != 0)
                        Console.WriteLine(medCons.ToString());
                    else
                        Console.WriteLine("Medicamento não encontrado.");
                    break;
                case 3:
                    Console.Write("ID do medicamento para consulta analítica: ");
                    int idAna = int.Parse(Console.ReadLine());
                    Medicamento medAna = estoque.pesquisar(new Medicamento(idAna, "", ""));
                    if (medAna.Id != 0)
                    {
                        Console.WriteLine(medAna.ToString());
                        foreach (var lote in medAna.Lotes)
                        {
                            Console.WriteLine($"  Lote: {lote.ToString()}");
                        }
                    }
                    else
                    {
                        Console.WriteLine("Medicamento não encontrado.");
                    }
                    break;
                case 4:
                    Console.Write("ID do medicamento para compra: ");
                    int idComp = int.Parse(Console.ReadLine());
                    Medicamento medComp = estoque.pesquisar(new Medicamento(idComp, "", ""));
                    if (medComp.Id != 0)
                    {
                        Console.Write("ID do Lote: ");
                        int idLote = int.Parse(Console.ReadLine());
                        Console.Write("Quantidade: ");
                        int qtde = int.Parse(Console.ReadLine());
                        Console.Write("Data de vencimento (dd/MM/yyyy): ");
                        DateTime venc = DateTime.Parse(Console.ReadLine());
                        medComp.comprar(new Lote(idLote, qtde, venc));
                        Console.WriteLine("Lote cadastrado na fila!");
                    }
                    else
                    {
                        Console.WriteLine("Medicamento não encontrado.");
                    }
                    break;
                case 5:
                    Console.Write("ID do medicamento para venda: ");
                    int idVend = int.Parse(Console.ReadLine());
                    Medicamento medVend = estoque.pesquisar(new Medicamento(idVend, "", ""));
                    if (medVend.Id != 0)
                    {
                        Console.Write("Quantidade para vender: ");
                        int qtdeVend = int.Parse(Console.ReadLine());
                        if (medVend.vender(qtdeVend))
                            Console.WriteLine("Venda realizada com sucesso!");
                        else
                            Console.WriteLine("Saldo insuficiente.");
                    }
                    else
                    {
                        Console.WriteLine("Medicamento não encontrado.");
                    }
                    break;
                case 6:
                    foreach (var m in estoque.ListaMedicamentos)
                    {
                        Console.WriteLine(m.ToString());
                    }
                    break;
                default:
                    Console.WriteLine("Opção inválida.");
                    break;
            }
        }
    }
}