
using Alura.Estacionamento.Alura.Estacionamento.Modelos;
using Alura.Estacionamento.Modelos;

namespace Estacionamento.Testes
{
    public class TipoVeiculoTestes
    {
            [Fact]
            public void TestaTipoVeiculo()
        {
            //Arrange
            var veiculo = new Veiculo();
            //Act            
            //Assert
            Assert.Equal(TipoVeiculo.Automovel, veiculo.Tipo);
        }
    }



}