using TP3.Paints;
using TP3.Repository;

namespace TP3;

public class Menu
{
    private PaintRepository _repository;
    private string _response;

    public Menu()
    {
        _repository = new PaintRepository();
    }
    public bool StartMenu()
    {
        Console.WriteLine("Bem vindo ao cadastro de pinturas!!!");
        do
        {
            Console.WriteLine(
                              "1 - Enserir pintura.\n" +
                              "2 - Consultar Pintura.\n" +
                              "3 - Sair.\n");
            _response = Console.ReadLine();
            _response = ValidateResponse(_response);

        } while (_response != "3");

        return true;
    }

    private string ValidateResponse(string response)
    {
        switch (response)
        {
            case "1":
                RegisterMenu();
                return response;
            case "2":
                QueryMenu();
                return response;
            case "3":
                return response;
            default:
                Console.WriteLine("==== Opção invalida ====");
                return "0";
        }
    }

    private void RegisterMenu()
    {
        var paint = new Paint();
        Console.WriteLine("+++ Cadastro de Pintura +++");
        
        paint.RegisName();
        paint.RegisId();
        paint.RegisPrice();
        paint.RegisCreationDate();
        paint.RegisOnSale();

        _repository.InsertPaint(paint);
    }

    private void QueryMenu()
    {
        Console.WriteLine("+++ Busca de Pintura +++");
        Console.WriteLine("Informe o nome da pintura");
        string name = Console.ReadLine();
        List<Paint> paints = _repository.GetPaintName(name);

        int index = 0;
        foreach (var paint in paints)
        {
            Console.WriteLine($"\n{paint.Name}, {index}\n");
            index++;
        }
        
        Console.WriteLine("Escolha uma das opções");
        int op = int.Parse(Console.ReadLine());

        Paint selectPaint = paints[op];
        Console.WriteLine($"\nNome:{selectPaint.Name}\n " +
                          $"ID:{selectPaint.Id}\n" +
                          $"Preço:{selectPaint.Price}\n" +
                          $"Está a venda:{selectPaint.IsOnSale}\n" +
                          $"Data de criação:{selectPaint.CreationDate}\n" +
                          $"Idade: {selectPaint.CalculatePaintYear()}");
    }
}