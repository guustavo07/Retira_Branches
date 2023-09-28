using System;
using System.Collections.Generic;
using System.IO;
using System.Reflection;

class Program
{
    static void Main()
    {
        string diretorio = "C:\\Exemplo\\Exemplo\\Exemplo\\teste";
        List<string> listCaminhos = new List<string>();
        int index = 0;
        if (Directory.Exists(diretorio))
        {
            string[] subdiretorios = Directory.GetDirectories(diretorio);

            foreach (string subdiretorio in subdiretorios)
            {
                string nomePasta = Path.GetFileName(subdiretorio);

                // Verifica se o nome da pasta contém "-feature"
                if (nomePasta.Contains("-feature"))
                {
                    // Armazena o caminho para renomeação
                    index = nomePasta.IndexOf("-feature");
                    listCaminhos.Add(subdiretorio);
                }
                else if (nomePasta.Contains("-master"))
                {
                    index = nomePasta.IndexOf("-master");
                    listCaminhos.Add(subdiretorio);
                }

            }

            foreach (string caminho in listCaminhos)
            {
                string nomePasta = Path.GetFileName(caminho);
                if (nomePasta.Contains("-feature"))
                {
                    index = nomePasta.LastIndexOf("-feature");
                    if (nomePasta.Contains("-feature"))
                    {
                        index = nomePasta.IndexOf("-feature");
                    }
                }
                else if (nomePasta.Contains("-master"))
                {
                    index = nomePasta.LastIndexOf("-master");
                    if (nomePasta.Contains("-master"))
                    {
                        index = nomePasta.IndexOf("-master");
                    }
                }
                else
                {
                    Console.WriteLine("O traço '-' não foi encontrado no nome da pasta: " + nomePasta);
                }

                if (index == 1)
                {
                    index = nomePasta.IndexOf("-master");
                }
                else
                {
                    string novoNomePasta = nomePasta.Substring(0, index);
                    string novoCaminhoPasta = Path.Combine(Path.GetDirectoryName(caminho), novoNomePasta);
                    Directory.Move(caminho, novoCaminhoPasta);
                    Console.WriteLine("Pasta renomeada: " + novoNomePasta);
                }
            }
        }
    }
}

