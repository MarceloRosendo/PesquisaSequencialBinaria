using System;
using System.Collections.Generic;
using System.Runtime.ConstrainedExecution;

namespace Lista9
{
    internal class Program
    {
        public static void Main(string[] args)
        {
            Produto[] produtos = new Produto[5];
            insertProd(ref produtos);
            
            int tamanho = produtos.Length/ produtos[0].codigo_barras;
            int lookFor;
            int comparison;
            Boolean flag = true;

            do
            {
                Console.WriteLine("Entre com o codigo de barras a ser pesquisado:");
                lookFor = int.Parse(Console.ReadLine());
                comparison = 0;

                int res = buscaBinaria(produtos, 0, tamanho - 1, lookFor, ref comparison);
                
                if (res == -1)
                {
                    break;
                }
                
                Console.WriteLine("R$" + produtos[res].preco);
                Console.WriteLine(comparison + " comparações na busca binaria");
                buscaSequencial(produtos, lookFor, ref comparison);
                Console.WriteLine(comparison + " comparações na busca sequencial");

            } while (flag);
            
            // A busca binária se antem estável nas buscas mantendo um numero de comparações pequeno enquanto a busca sequencial faz muitas comparações num ritmo evolutivo
        }
        public static int buscaBinaria(Produto[] array, int from, int range, int target, ref int comparison) 
        { 
            if (range >= from)
            {
                comparison++;
                int mid = from + (range - from)/2;

                if (array[mid].codigo_barras == target)
                {
                    comparison++;
                    return mid;
                }

                if (array[mid].codigo_barras > target)
                {
                    comparison++;
                    return buscaBinaria(array, from, mid-1, target, ref comparison);
                }
                
                return buscaBinaria(array, mid+1, range, target, ref comparison); 
            } 
  
            return -1; 
        }

        public static int buscaSequencial(Produto[] produtos, int lookFor, ref int comparison)
        {
            comparison = 0;
            foreach (Produto produto in produtos)
            {
                if (produto.codigo_barras == lookFor)
                {
                    comparison++;
                    
                    return produto.codigo_barras - 1;
                }
                comparison++;
            }

            return -1;
        }

        public static void insertProd(ref Produto[] produtos)
        {
            Produto insert = new Produto();
            insert.codigo_barras = 1;
            insert.nome = "prod 1";
            insert.preco = 1.5;

            produtos[0] = insert;
            
            insert = new Produto();
            insert.codigo_barras = 2;
            insert.nome = "prod 2";
            insert.preco = 2.5;

            produtos[1] = insert;
            
            insert = new Produto();
            insert.codigo_barras = 3;
            insert.nome = "prod 3";
            insert.preco = 3.5;
            
            produtos[2] = insert;
            
            insert = new Produto();
            insert.codigo_barras = 4;
            insert.nome = "prod 4";
            insert.preco = 4.5;
            
            produtos[3] = insert;
            
            insert = new Produto();
            insert.codigo_barras = 5;
            insert.nome = "prod 5";
            insert.preco = 5.5;
            
            produtos[4] = insert;
        }
    }
}