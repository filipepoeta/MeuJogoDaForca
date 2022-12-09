using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MeuJogoDaForca;

public static class Palavras
{
    public static string[] temaAnimal = { "papagaio", "rinoceronte", "macaco", "tigre", "ornitorrinco"};
    public static string[] temaObjeto = { "prateleira", "anzol", "modem", "navalha", "ampulheta" };
    public static string[] temaComida = { "canjica", "sushi", "almondega", "omelete", "espaguete" };

    public static string EscolherPalavra(string[] tema)
    {
        Random random = new Random();
        int indiceRandom = random.Next(tema.Length);
        String palavra = tema[indiceRandom];
        if(palavra == null){
            throw new ArgumentNullException(paramName: nameof(palavra), message: "Palavra não pode ser nula");
        }
        return palavra;
    }

    public static int Opcao(int opt){
        
        if (opt > 3 || opt < 1)
        {
            opt = -1;
            throw new ArgumentException(paramName: nameof(opt), message: "Escolha um tema válido");
        }
        return opt;
    }
}