using Alura.Estacionamento.Modelos;
using Alura.Estacionamento.Alura.Estacionamento.Modelos;
using Xunit.Abstractions;

namespace Estacionamento.Testes
{
    public class VeiculoTestes: IDisposable
    {
        private Veiculo veiculo;
        public ITestOutputHelper SaidaConsoleTeste;
        public VeiculoTestes(ITestOutputHelper _saidaConsoleTeste)
        {
            SaidaConsoleTeste = _saidaConsoleTeste;
            SaidaConsoleTeste.WriteLine("Chamando o Construtor.");
            veiculo = new Veiculo();
        }

        [Fact]
        public void TestaVeiculoAcelerarComParametro10()
        {
            //Arrange
            //var veiculo = new Veiculo();
            //Act
            veiculo.Acelerar(10);
            //Assert
            Assert.Equal(100, veiculo.VelocidadeAtual);
        }

        [Fact]

        public void TestaVeiculoFrearComParametro10()
        {
            //Arrange
            //var veiculo = new Veiculo();
            //Act
            veiculo.Frear(10);
            //Assert
            Assert.Equal(-150, veiculo.VelocidadeAtual);
        }
        [Fact(Skip = "Teste ainda não implementado. Ignorar")] // possibilidade para ignorar algo que ainda não terminou ou foi implementado
        public void ValidaNomeProprietarioDoVeiculo()
        {

        }

        [Fact]
        public void FichaDoVeiculo()
        {
            //Arrange
            //var veiculo = new Veiculo();
            veiculo.Proprietario = "Carlos Alberto";
            veiculo.Tipo = TipoVeiculo.Automovel;
            veiculo.Placa = "Zap-7845";
            veiculo.Cor = "Cinza";
            veiculo.Modelo = "Honda Fit";

            //Act
            string dados = veiculo.ToString();

            //Assert
            Assert.Contains("Ficha do Veículo:", dados);
            // Contains é utilizado para verificar se contém determinado valor, nesse caso numa String.
        }

        [Fact]
        public void TestarNomeDoProprietarioDoVeiculoComMenosDeTresCaracteres()
        {
            //Arrange
            string nomeProprietario = "Re";

            //Assert
            Assert.Throws<System.FormatException>(
            //Act
                () => new Veiculo(nomeProprietario)
                );
        }

        [Fact]

        public void TestarExcecaoDoQuartoCaracterDaPlaca()
        {
            //Arrange
            string placa = "ASDF6518";

            //Act
            var mensagem = Assert.Throws<System.FormatException>(
                () => new Veiculo().Placa = placa
                );

            //Assert
            Assert.Equal("O 4° caractere deve ser um hífen", mensagem.Message);
        }



        public void Dispose()
        {
            SaidaConsoleTeste.WriteLine("Execução do Cleanup: Limpando os objetos.");
        }
    }
}
//Método AAA
// Arrange, Act and Assert
//Arrange -> Preparação do cenário que eu preciso para evocar o método que eu quero testar.
//Ex: Para testar o acelerar eu preciso ter um veículo. Preciso instanciar um objeto do tipo veículo, inicializar algumas variáveis. Então essa praparação fica no Arrange
//Act -> Método que eu quero testar: Acelerar, frear etc.
//Assert -> verificação do resultado obtido da execução do método que foi testado/executado.
//São boas práticas que nos ajudam futuramente na manutenção do nosso código
