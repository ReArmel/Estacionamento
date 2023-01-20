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
        [Fact(Skip = "Teste ainda n�o implementado. Ignorar")] // possibilidade para ignorar algo que ainda n�o terminou ou foi implementado
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
            Assert.Contains("Ficha do Ve�culo:", dados);
            // Contains � utilizado para verificar se cont�m determinado valor, nesse caso numa String.
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
            Assert.Equal("O 4� caractere deve ser um h�fen", mensagem.Message);
        }



        public void Dispose()
        {
            SaidaConsoleTeste.WriteLine("Execu��o do Cleanup: Limpando os objetos.");
        }
    }
}
//M�todo AAA
// Arrange, Act and Assert
//Arrange -> Prepara��o do cen�rio que eu preciso para evocar o m�todo que eu quero testar.
//Ex: Para testar o acelerar eu preciso ter um ve�culo. Preciso instanciar um objeto do tipo ve�culo, inicializar algumas vari�veis. Ent�o essa prapara��o fica no Arrange
//Act -> M�todo que eu quero testar: Acelerar, frear etc.
//Assert -> verifica��o do resultado obtido da execu��o do m�todo que foi testado/executado.
//S�o boas pr�ticas que nos ajudam futuramente na manuten��o do nosso c�digo
