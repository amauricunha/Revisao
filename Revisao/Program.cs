using System;
using Revisao.Model;

namespace Revisao
{
    class Program
    {
        static void Main(string[] args)
        {
            Aluno[] alunos = new Aluno[5];
            var indiceAluno = 0;
            string opcaoUsuario = ObterOpcoesUsusario();

            while (opcaoUsuario.ToUpper() != "X")
            {
                switch (opcaoUsuario)
                {
                    case "1":
                        Console.WriteLine("CADASTRO DE ALUNO");
                        Console.WriteLine("Digite o nome do Aluno");
                        Aluno aluno = new Aluno();
                        aluno.Nome = Console.ReadLine();
                        Console.WriteLine("Digite a note do Aluno");
                        
                        if (Decimal.TryParse(Console.ReadLine(),out decimal nota))
                        {
                             aluno.Nota = nota;

                        }  else {

                            throw new ArgumentException("O valor da nota deve ser decimal!");
                        }
                        if (indiceAluno < 5)
                        {
                           alunos[indiceAluno] = aluno;
                            indiceAluno++; 
                        } else {
                            Console.WriteLine();
                            Console.WriteLine("NÚMERO MÁXIMO DE ALUNOS ATINGIDO!");
                            Console.WriteLine("NÃO É POSSÍVEL INCLUIR NOVOS ALUNOS!");
                        }

                        
                        Console.WriteLine();
                        break;

                    case "2":
                        Console.WriteLine("RELAÇÃO DE ALUNOS");
                        foreach (var a in alunos)
                        {
                            if (!string.IsNullOrEmpty(a.Nome))
                            {
                                Console.WriteLine($"Aluno: {a.Nome}, Nota {a.Nota}");    
                            }
                            
                        }
                        Console.WriteLine();
                        break;
                    case "3":

                        decimal notaTotal = 0;
                        var nrAlunos = 0;
                        ConceitoEnum conceitoGeral;
                        conceitoGeral = ConceitoEnum.A;

                        for (int i = 0; i < indiceAluno; i++)
                        {        
                            if (!string.IsNullOrEmpty(alunos[i].Nome))
                            {                    
                            notaTotal = notaTotal + alunos[i].Nota;
                            nrAlunos++;
                            }
                        }                        

                        decimal mediaGeral = notaTotal/nrAlunos;

                        
                            if (mediaGeral == 0)
                            {
                                conceitoGeral = ConceitoEnum.F;    
                            } 
                            else if (mediaGeral < 3)
                            {
                                conceitoGeral = ConceitoEnum.E;    
                            }
                            else if (mediaGeral < 5)
                            {
                                conceitoGeral = ConceitoEnum.D;    
                            }
                            else if (mediaGeral < 7)
                            {
                                conceitoGeral = ConceitoEnum.C;    
                            }
                            else if (mediaGeral < 8)
                            {
                                conceitoGeral = ConceitoEnum.B;    
                            }
                            else 
                            {
                                conceitoGeral = ConceitoEnum.A;    
                            }

                        Console.WriteLine("Média Geral = " + mediaGeral);
                        Console.WriteLine("Conceito Geral = " + conceitoGeral);
                        Console.WriteLine();
                        break;                        
                    default:
                        throw new ArgumentOutOfRangeException();
                }            

                opcaoUsuario = ObterOpcoesUsusario();
            }

        }

        private static string ObterOpcoesUsusario()
        {
            Console.WriteLine("Informe a opção desejada:");
            Console.WriteLine("1 - Adicionar novo aluno");
            Console.WriteLine("2 - Listar alunos");
            Console.WriteLine("3 - Calcular média geral");
            Console.WriteLine("X - Sair");
            Console.WriteLine();

            string opcaoUsuario = Console.ReadLine();
            return opcaoUsuario;
        }
    }
}
