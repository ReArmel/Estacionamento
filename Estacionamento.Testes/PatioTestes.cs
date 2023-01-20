using Alura.Estacionamento.Alura.Estacionamento.Modelos;
using Alura.Estacionamento.Modelos;
using Estacionamento.Estacionamento.Modelos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Reflection;
using System.Runtime.ConstrainedExecution;
using System.Text;
using System.Threading.Tasks;
using Xunit.Abstractions;

namespace Estacionamento.Testes
{
    public class PatioTestes : IDisposable
    {
        private Veiculo veiculo;
        private Operador operador;

        public ITestOutputHelper SaidaConsoleTeste;

        public PatioTestes(ITestOutputHelper _saidaConsoleTeste)
        {
            SaidaConsoleTeste = _saidaConsoleTeste;
            SaidaConsoleTeste.WriteLine("Chamando o Construtor.");
            veiculo = new Veiculo();
            operador = new Operador();
            operador.Nome = "Mauricio Garcia";

        }

        [Fact]
        public void ValidaFaturamento()
        {
            //Arrange
            var estacionamento = new Patio();
            //Operador operador = new Operador();
            //operador.Nome = "Mauricio Garcia";

            estacionamento.OperadorPatio = operador;

            //var veiculo = new Veiculo();
            veiculo.Proprietario = "Renata Armel";
            veiculo.Tipo = TipoVeiculo.Automovel;
            veiculo.Cor = "Azul";
            veiculo.Modelo = "Kicks";
            veiculo.Placa = "REA-1985";

            estacionamento.RegistrarEntradaVeiculo(veiculo);
            estacionamento.RegistrarSaidaVeiculo(veiculo.Placa);

            //Act
            double faturamento = estacionamento.TotalFaturado();

            //Assert
            Assert.Equal(2, faturamento);

        }
        //Mesmo método porém usado para mais de um veículo.
        //Theory - Permite trabalhar com um conjunto maior de dados.
        //Trabalha com o [InlineData] onde é passado os parâmetros que vão ser usados no método de teste.
        [Theory]
        [InlineData("Fernanda Gusman", "ANM-1632", "preto", "Gol")]
        [InlineData("André Ferreira", "OPT-2000", "cinza", "HB20")]
        [InlineData("Maia Trusman", "TRU-1526", "branco", "Fusca")]
        [InlineData("Rodrigo Sampaio", "GTO-4829", "preto", "Argo")]
        //Cada InlineData é reconhecido como um novo teste

        public void ValidaFaturamentoComVariosVeiculos(string proprietario, string placa, string cor, string modelo)
        {
            //Arrange
            var estacionamento = new Patio();
            estacionamento.OperadorPatio = operador;
            //var veiculo = new Veiculo();
            veiculo.Proprietario = proprietario;
            veiculo.Tipo = TipoVeiculo.Automovel;
            veiculo.Cor = cor;
            veiculo.Modelo = modelo;
            veiculo.Placa = placa;
            estacionamento.RegistrarEntradaVeiculo(veiculo);
            estacionamento.RegistrarSaidaVeiculo(placa);


            //Act
            double faturamento = estacionamento.TotalFaturado();

            //Assert
            Assert.Equal(2, faturamento);

        }
        [Theory]
        [InlineData("Matheus Calisto", "ABC-8596", "preto", "Palio")]

        public void LocalizaVeiculoNoPatioPeloId(string proprietario, string placa, string cor, string modelo)
        {
            //Arrange
            Patio estacionamento = new Patio();
            estacionamento.OperadorPatio = operador;
            //var veiculo = new Veiculo();
            veiculo.Proprietario = proprietario;
            veiculo.Cor = cor;
            veiculo.Modelo = modelo;
            veiculo.Placa = placa;
            estacionamento.RegistrarEntradaVeiculo(veiculo);

            //Act
            var consultar = estacionamento.PesquisaVeiculo(veiculo.IdTicket);

            //Assert
            Assert.Contains("### Ticket Estacionamento Alura ###", consultar.Ticket);
        }
        [Fact]
        public void AlterarDadosVeiculo()
        {
            //Arrange
            Patio estacionamento = new Patio();
            estacionamento.OperadorPatio = operador;
            //var veiculo = new Veiculo();
            veiculo.Proprietario = "Maria da Graça";
            veiculo.Cor = "verde";
            veiculo.Modelo = "C3";
            veiculo.Placa = "LMI-0099";
            estacionamento.RegistrarEntradaVeiculo(veiculo);

            var veiculoAlterado = new Veiculo();
            veiculoAlterado.Proprietario = "Maria da Graça";
            veiculoAlterado.Cor = "vermelho"; //dado alterado
            veiculoAlterado.Modelo = "C3";
            veiculoAlterado.Placa = "LMI-0099";

            //Act
            Veiculo alterado = estacionamento.AlterarDadosVeiculo(veiculoAlterado);

            //Assert
            Assert.Equal(alterado.Cor, veiculoAlterado.Cor);

        }

        public void Dispose()
        {
            SaidaConsoleTeste.WriteLine("Execução do Cleanup: Limpando os objetos.");
        }
    }
}
