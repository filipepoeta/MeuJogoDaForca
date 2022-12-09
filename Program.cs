

using MeuJogoDaForca;

public class Program
{
    private static void Main(string[] args)
    {

        Console.Clear();
        Console.ForegroundColor = System.ConsoleColor.Cyan;
        Console.WriteLine("Bem vindo ao jogo da forca".ToUpper());
        Console.ResetColor();
        //


        System.Console.WriteLine("Escolha o tema do Jogo");
        System.Console.WriteLine("1 - Animal");
        System.Console.WriteLine("2 - Objeto");
        System.Console.WriteLine("3 - Comida");
        bool resOpcao = true;
        int opcao = 0;

        while (true)
        {
            resOpcao = int.TryParse(Console.ReadLine(), out opcao);
            if(resOpcao){
                break;
            }
            System.Console.WriteLine("Número inválido!");
        }

        try
        {

            Palavras.Opcao(opcao);


        }
        finally
        {
            System.Console.WriteLine("Tente Novamente!");
        }


        string palavra = "";
        string tema = "";
        try
        {
            switch (opcao)
            {
                case 1:
                    palavra = Palavras.EscolherPalavra(Palavras.temaAnimal);
                    tema = "Tema escolhido: Animal";

                    break;

                case 2:
                    palavra = Palavras.EscolherPalavra(Palavras.temaObjeto);
                    tema = ("Tema escolhido: Objeto");

                    break;

                case 3:
                    palavra = Palavras.EscolherPalavra(Palavras.temaComida);
                    tema = "Tema escolhido: Comida";

                    break;

            }
        }
        catch (ArgumentNullException e)
        {

            System.Console.WriteLine($"Occoreu um erro de arugmento: {e}");
        }



        Console.Clear();

        int chances = 5;
        List<char> letrasCorretas = new List<char>(); // 
        List<char> letrasIncorretas = new List<char>(); // len(word)
        bool vitoria = false;

        while (chances != 0)
        {
            System.Console.WriteLine(tema);
            System.Console.Write($"Letras Incorretas: ");
            foreach (var l in letrasIncorretas)
            {
                System.Console.Write(l + " ");
            }
            Console.WriteLine($"\nChances: {chances}");
            int acertos = 0;
            for (int i = 0; i < palavra.Length; i++)
            {
                if (letrasCorretas.Contains(palavra.ElementAt(i)))
                {
                    Console.Write(palavra.ElementAt(i) + " ");
                    acertos++;
                }
                else
                {
                    Console.Write("_ ");
                }
            } // end for

            if (acertos == palavra.Length)
            {
                vitoria = true;
                break;
            }

            Console.WriteLine("\n\nInforme uma letra");

            char letra;
            while (true)
            {
                letra = Console.ReadLine().ToLower().ElementAt(0);

                if (letrasCorretas.Contains(letra) || letrasIncorretas.Contains(letra))
                {
                    Console.ForegroundColor = System.ConsoleColor.Yellow;
                    System.Console.WriteLine("Letra já digitada, informe outra");
                    Console.ResetColor();

                    continue;
                }
                break;
            }

            Console.Clear();
            if (palavra.Contains(letra))
            {
                Console.ForegroundColor = System.ConsoleColor.Green;
                Console.WriteLine("ACERTOU!!!\n");
                Console.ResetColor();
                letrasCorretas.Add(letra);

            }
            else
            {

                Console.ForegroundColor = System.ConsoleColor.Red;
                Console.WriteLine($"A letra digitada não existe na palavra-chave".ToUpper());
                Console.ResetColor();
                letrasIncorretas.Add(letra);
                chances--;
            }
        } // end While

        if (vitoria)
        {
            Console.ForegroundColor = System.ConsoleColor.Cyan;
            Console.WriteLine("\nParabens, voce acertou a palavra!".ToUpper());
            Console.ResetColor();
            Console.ForegroundColor = System.ConsoleColor.Red;
            Console.WriteLine("Total de letras erradas: " + letrasIncorretas.Count());
            Console.ResetColor();
        }
        else
        {
            Console.ForegroundColor = System.ConsoleColor.DarkRed;
            Console.WriteLine("\nSuas chances acabaram ):".ToUpper());
            Console.WriteLine($"A palavra era {palavra}");
            Console.ResetColor();
        }
    } // end Main


} // end class