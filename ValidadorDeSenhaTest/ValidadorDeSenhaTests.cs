using ValidadorDeSenha;
using Xunit.Abstractions;
namespace ValidadorDeSenhaTest;

public class ValidadorDeSenhaTests(ITestOutputHelper output)
{
    protected readonly ITestOutputHelper _output = output;

    [Theory]
    [InlineData("1Ab")]
    [InlineData("Ba33BAb")]
    public void VerificaSeSenhaForMenorQue8CaracteresEDeveRetornarErro(string senhaCurta)
    {
        //Arange
        var validaSenha = new Validador();
        string erroEsperado = "A deve ter no mínimo 8 caracteres";
        //Act
        var resultado = validaSenha.Valida(senhaCurta);
        //Assert
        Assert.Contains(erroEsperado, resultado);
        string errosFormatados = string.Join(Environment.NewLine, resultado);
        _output.WriteLine($"mensagens de erro: \n{errosFormatados}");
        Assert.Single(resultado);
    }
    
    [Theory]
    [InlineData("12345678c")]
    [InlineData("cadhgvk5")]
    public void VerificaSeSenhaNaoContemLetraMaiusculaEDeveRetornarErro(string senhaTest)
    {
        //Arange
        var validaSenha = new Validador();
        string erroEsperado = "A senha deve conter pelo menos uma letra maiúscula";
        //Act
        var resultado = validaSenha.Valida(senhaTest);
        //Assert
        Assert.Contains(erroEsperado, resultado);
        string errosFormatados = string.Join(Environment.NewLine, resultado);
        _output.WriteLine($"mensagens de erro: \n{errosFormatados}");
        Assert.Single(resultado);
    }

    [Theory]
    [InlineData("12345678C")]
    [InlineData("SCAJODB1")]
    public void VerificaSeSenhaNaoContemLetraMinusculaEDeveRetornarErro(string senhaTest)
    {
        //Arange
        var validaSenha = new Validador();
        string erroEsperado = "A senha deve conter pelo menos uma letra minúscula";
        //Act
        var resultado = validaSenha.Valida(senhaTest);
        //Assert
        Assert.Contains(erroEsperado, resultado);
        string errosFormatados = string.Join(Environment.NewLine, resultado);
        _output.WriteLine($"mensagens de erro: \n{errosFormatados}");
        Assert.Single(resultado);

    }

    [Theory]
    [InlineData("AVDSGSNXIc")]
    [InlineData("cksfnjscH")]
    public void VerificaSeSenhaNaoContemNumeroEDeveRetornarErro(string senhaTest)
    {
        //Arange
        var validaSenha = new Validador();
        string erroEsperado = "A senha deve conter pelo menos um número";
        //Act
        var resultado = validaSenha.Valida(senhaTest);
        //Assert
        Assert.Contains(erroEsperado, resultado);
        string errosFormatados = string.Join(Environment.NewLine, resultado);
        _output.WriteLine($"mensagens de erro: \n{errosFormatados}");
        Assert.Single(resultado);
        
    }

    [Theory]
    [InlineData("@@@@@")]
    [InlineData("!")]
    public void VerificaSeSenhaNaoContemNumeroLetraEMenosDe8CaracteresEDeveRetornarErro(string senhaTest)
    {
        //Arange
        var validaSenha = new Validador();
        string erroEsperado = "A senha deve conter pelo menos um número";
        //Act
        var resultado = validaSenha.Valida(senhaTest);
        //Assert
        Assert.Contains(erroEsperado, resultado);
        Assert.Equal(4, resultado.Count);
        string errosFormatados = string.Join(Environment.NewLine, resultado);
        _output.WriteLine($"mensagens de erro: \n{errosFormatados}");
    }
    [Theory]
    [InlineData("ABCabc123")]
    [InlineData("123abcAB")]
    public void VerificaSeSenhaConterNumeroLetraEMaisDe8CaracteresEDeveRetornarVazio(string senhaForte)
    {
        var validaSenha = new Validador();


        var resultado = validaSenha.Valida(senhaForte);

        Assert.Empty(resultado);
        
    }



}
