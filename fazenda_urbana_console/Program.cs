using System.Reflection;
using System.Runtime.InteropServices;
using fazenda_urbana_crud_dll;
using fazenda_urbana_crud_dll.Controllers;
using fazenda_urbana_crud_dll.Models.Entities;
using Microsoft.EntityFrameworkCore;
using System.Text.RegularExpressions;

IController controller = null;
Object table = null;
string pattern = @"ID";

while (true)
{
    Console.WriteLine("Em qual tabela deseja realizar uma consulta?\n");
    Console.WriteLine("1. Clientes\n2. Detalhes Vendas\n3. Fornecedores\n"
                    + "4. Funcionarios\n5. Inventarios\n6. Pagamentos\n7. Produção\n"
                    + "8. Produtos\n9. Relatorios\n10. Transportes\n11. Vendas");
    try
    {
        int tableOption = int.Parse(Console.ReadLine());

        switch(tableOption)
        {
            case 1: 
                controller = new ClienteController();
                table = new Cliente();
                break;
            case 2:
                controller = new DetalheVendaController();
                table = new DetalheVenda();
                break;
            case 3:
                controller = new FornecedorController();
                table = new Fornecedor();
                break;
            case 4:
                controller = new FuncionarioController();
                table = new Funcionario();
                break;
            case 5:
                controller = new InventarioController();
                table = new Inventario();
                break;
            case 6:
                controller = new PagamentoController();
                table = new Pagamento();
                break;
            case 7:
                controller = new ProducaoController();
                table = new Producao();
                break;
            case 8:
                controller = new ProdutoController();
                table = new Produto();
                break;
            case 9:
                controller = new RelatorioController();
                table = new Relatorio();
                break;
            case 10:
                controller = new TransporteController();
                table = new Transporte();
                break;
            case 11:
                controller = new VendaController();
                table = new Venda();
                break;
            default:
                Console.WriteLine("Opção inválida!");
                Thread.Sleep(1000);
                Console.Clear();
                continue;
        }
    }
    catch(ArgumentException)
    {
        Console.WriteLine("Opção inválida!");
        Thread.Sleep(1000);
        Console.Clear();
        continue;
    }

        Console.WriteLine("Qual operação deseja fazer?");
        Console.WriteLine("1. Criar registro\n2. Encontrar por ID\n3. Encontrar todos os registros\n4. Atualizar registro\n5. Apagar registro");

        int crudOption = int.Parse(Console.ReadLine());

        switch(crudOption)
        {
            case 1:
                PropertyInfo[] createProps = table.GetType().GetProperties();
                
                for(int i = 1; i < createProps.Length; i++)
                {
                    var p = createProps[i];

                    if(p.CanWrite)
                    {
                        Console.WriteLine($"{p.Name}: ");
                        var prop = Console.ReadLine();

                        object value = ConvertToType(prop, p.PropertyType);
                        
                        if (value != null)
                        {
                            p.SetValue(table, value);
                        }
                    }
                }

                controller.Create(table);
                table = null;
                controller = null;
                Console.WriteLine("Registro criado com sucesso!");
                break;

            case 2:
                int id;
                while(true)
                {
                    try
                    {
                        Console.WriteLine($"Digite o id do {table.GetType()}: ");
                        id = int.Parse(Console.ReadLine());

                        controller.GetById(id);
                        break;
                    }
                    catch(ArgumentException)
                    {
                        Console.WriteLine("Entrada inválida!");
                        Thread.Sleep(1000);
                        Console.Clear();
                        continue;
                    }
                }

                table = null;
                controller = null;
                break;

            case 3:
                controller.GetAll();
                Console.ReadLine();
                table = null;
                controller = null;
                break;

            case 4:
                PropertyInfo[] updateProps = table.GetType().GetProperties();
                while(true)
                {
                    try
                    {
                        Console.WriteLine($"Digite o id do registro: ");
                        id = int.Parse(Console.ReadLine());

                        if(!controller.GetById(id))
                        {
                            Console.WriteLine($"Registro com id {id} não encontrado!");
                            Thread.Sleep(1000);
                            Console.Clear();
                            continue;
                        };
                    
                        break;
                    }
                    catch(ArgumentException)
                    {
                        Console.WriteLine("Opção inválida!");
                        Thread.Sleep(1000);
                        Console.Clear();
                        continue;
                    }
                }
                
                for(int i = 1; i < updateProps.Length; i++)
                {
                    var p = updateProps[i];

                    if(p.CanWrite)
                    {
                        Console.WriteLine($"{p.Name}: ");
                        var prop = Console.ReadLine();

                        object value = ConvertToType(prop, p.PropertyType);
                        
                        if (value != null)
                        {
                            p.SetValue(table, value);
                        }
                    }
                }
                controller.Update(id, table);
                table = null;
                controller = null;
                break;
            case 5:
                while(true)
                {
                    try
                    {
                        Console.WriteLine($"Digite o id do {table.GetType()}: ");
                        id = int.Parse(Console.ReadLine());

                        if(controller.Delete(id))
                        {
                            Console.WriteLine($"Registro com id {id} deletado com sucesso!");
                        };
                        break;
                    }
                    catch(ArgumentException)
                    {
                        Console.WriteLine("Entrada inválida!");
                        Thread.Sleep(1000);
                        Console.Clear();
                        continue;
                    }
                }
                
                table = null;
                controller = null;
                break;

            default:
                Console.WriteLine("Opção inválida!");
                Thread.Sleep(1000);
                Console.Clear();
                continue;
        }

}

static object ConvertToType(string input, Type type)
    {
        try
        {
            if (type == typeof(int))
            {
                return int.Parse(input);
            }
            else if (type == typeof(string))
            {
                return input;
            }
            else if (type == typeof(DateTime))
            {
                return DateTime.Parse(input);
            }
            else if (type == typeof(decimal))
            {
                return decimal.Parse(input);
            }
            else if (type == typeof(bool))
            {
                return bool.Parse(input);
            }
            // Adicione outros tipos conforme necessário
            else
            {
                throw new NotSupportedException($"Tipo {type.Name} não suportado.");
            }
        }
        catch (Exception)
        {
            return null;
        }
    }