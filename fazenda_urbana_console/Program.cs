using System.Reflection;
using fazenda_urbana_crud_dll.Controllers;
using fazenda_urbana_crud_dll.Models.Entities;
using System.Text.RegularExpressions;

IController controller = null;
Object table = null;
int menu = 0;

var optionMappings = new Dictionary<int, (IController controller, object table)>
{
    { 1, (new ClienteController(), new Cliente()) },
    { 2, (new DetalheVendaController(), new DetalheVenda()) },
    { 3, (new FornecedorController(), new Fornecedor()) },
    { 4, (new FuncionarioController(), new Funcionario()) },
    { 5, (new InventarioController(), new Inventario()) },
    { 6, (new PagamentoController(), new Pagamento()) },
    { 7, (new ProducaoController(), new Producao()) },
    { 8, (new ProdutoController(), new Produto()) },
    { 9, (new RelatorioController(), new Relatorio()) },
    { 10, (new TransporteController(), new Transporte()) },
    { 11, (new VendaController(), new Venda()) }
};

while(true)
{
    switch(menu)
    {
        case 0:
        {
            Console.WriteLine("Em qual tabela deseja realizar uma transação?\n");
            Console.WriteLine("1. Clientes\n2. Detalhes Vendas\n3. Fornecedores\n"
                    + "4. Funcionarios\n5. Inventarios\n6. Pagamentos\n7. Produção\n"
                    + "8. Produtos\n9. Relatorios\n10. Transportes\n11. Vendas");

            if (!int.TryParse(Console.ReadLine(), out int tableOption) || !optionMappings.ContainsKey(tableOption))
            {
                Console.WriteLine("Opção inválida!");
                Console.Clear();
                continue;
            }
            
            (controller, table) = optionMappings[tableOption];

            menu = 1;
            Console.Clear();
            break;
        }

        case 1:
        {
            while(true)
            {
                Console.WriteLine($"Tabela: {MyRegex().Replace(table.GetType().Name, " $1")}\n");
                Console.WriteLine("Qual operação deseja realizar?");
                Console.WriteLine("1. Criar registro\n2. Encontrar por ID\n3. Encontrar todos os registros\n"
                    + "4. Atualizar registro\n5. Apagar registro\n6. Voltar");

                try
                {
                    int crudOption = int.Parse(Console.ReadLine());

                    switch(crudOption)
                    {
                        case 1: Create(); break;
                        case 2: GetById(); break;
                        case 3: GetAll(); break;
                        case 4: Update(); break;
                        case 5: Delete(); break;
                        case 6: 
                        {
                            Console.Clear();
                            menu = 0; 
                            break;
                        }    
                        default: 
                        {
                            Console.WriteLine("Entrada inválida!");
                            Thread.Sleep(500);
                            Console.Clear();
                            continue;
                        }
                    }

                    break;
                }
                catch(ArgumentException)
                {
                    Console.WriteLine("Entrada inválida!");
                    Console.Clear();
                    continue;
                }
            }

            break;
        }
    }
}

void Create()
{
    Console.Clear();
    Console.WriteLine($"Criar registro de {MyRegex().Replace(table.GetType().Name, " $1")}\n");

    PropertyInfo[] createProps = table.GetType().GetProperties();

    for(int i = 1; i < createProps.Length; i++)
    {
        var p = createProps[i];

        if(p.CanWrite)
        {
            Console.Write($"{MyRegex().Replace(p.Name, " $1")}: ");
            var prop = Console.ReadLine();

            object value = ConvertToType(prop, p.PropertyType);
            
            if (value != null)
            {
                p.SetValue(table, value);
            }
        }
    }
    
    Console.WriteLine();
    controller.Create(table);
    Console.WriteLine("\nRegistro criado com sucesso!");
    Thread.Sleep(2000);
    Console.Clear();
}

void GetById()
{
    Console.Clear();
    Console.WriteLine($"Encontrar registro de {MyRegex().Replace(table.GetType().Name, " $1")}\n");

    int id;
    while(true)
    {
        try
        {
            Console.Write("Digite o id do registro que deseja encontrar: ");
            id = int.Parse(Console.ReadLine());

            Console.WriteLine();
            controller.GetById(id);
            Console.WriteLine("\nAperte ENTER para continuar...");
            Console.ReadLine();
            Console.Clear();
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

    Thread.Sleep(2000);
}

void GetAll()
{
    Console.Clear();
    Console.WriteLine($"Exibindo todos os registros de {MyRegex().Replace(table.GetType().Name, " $1")}\n");

    controller.GetAll();
    Console.ReadLine();
    Console.WriteLine("\nAperte ENTER para continuar...");
    Console.ReadLine();
    Console.Clear();
}

void Update()
{
    Console.Clear();
    Console.WriteLine($"Atualizar registro de {MyRegex().Replace(table.GetType().Name, " $1")}\n");
    
    int id;
    PropertyInfo[] updateProps = table.GetType().GetProperties();
    while(true)
    {
        try
        {
            Console.Write($"Digite o id do {MyRegex().Replace(table.GetType().Name, " $1")}: ");
            id = int.Parse(Console.ReadLine());

            Console.Clear();
            Console.WriteLine("Registro encontrado\n");
            if(!controller.GetById(id))
            {
                Console.WriteLine($"Registro com id {id} não encontrado!");
                Thread.Sleep(1000);
                Console.Clear();
                continue;
            };
            Console.WriteLine();
        
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
    
    Console.WriteLine("Quais atributos deseja alterar? Digite os atributos separados por virgula");
    string input = Console.ReadLine();
    List<string> atributos = input.Split(',').ToList();

    for(int i = 1; i < updateProps.Length; i++)
    {
        var p = updateProps[i];
        Console.WriteLine(p.Name);
        if(atributos.Contains(MyRegex().Replace(p.Name, " $1")))
        {
            if(p.CanWrite)
                {
                    Console.WriteLine($"{MyRegex().Replace(p.Name, " $1")}: ");
                    var prop = Console.ReadLine();

                    object value = ConvertToType(prop, p.PropertyType);
                    
                    if (value != null)
                    {
                        p.SetValue(table, value);
                    }
                }
        }
    }
     
    Console.WriteLine();
    controller.Update(id, table);
    Console.WriteLine("\nRegistro atualizado com sucesso!");
    Thread.Sleep(2000);
    Console.Clear();
}

void Delete()
{
    Console.Clear();
    Console.WriteLine($"Remover registro de {MyRegex().Replace(table.GetType().Name, " $1")}\n");

    int id;
    while(true)
    {
        try
        {
            Console.Write($"Digite o id do {MyRegex().Replace(table.GetType().Name, " $1")}: ");
            id = int.Parse(Console.ReadLine());

            Console.WriteLine();
            if(controller.Delete(id))
            {
                Console.WriteLine($"\nRegistro com id {id} deletado com sucesso!");
                Thread.Sleep(2000);
                Console.Clear();
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
            return DateTime.ParseExact(input, "dd-MM-yyyy", null);
        }
        else if (type == typeof(decimal))
        {
            return decimal.Parse(input);
        }
        else if (type == typeof(bool))
        {
            return bool.Parse(input);
        }
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

partial class Program
{
    [GeneratedRegex("(?<!^)([A-Z])")]
    private static partial Regex MyRegex();
}