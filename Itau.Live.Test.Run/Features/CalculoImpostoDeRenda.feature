#language: pt
Funcionalidade: Calculo do Imposto de Renda
	Eu como pessoa física
	Desejo declarar os meus bens
	Para que eu possa saber qual o valor do imposto que eu tenho a restituir ou a pagar

Cenario: Verificar se o imposto é calculado corretamente pela API
	Dado que tenho os seguintes bens <TabelaFipe> , <TipoResidencia> , <ValorResidencia>, <ValorInvestimento>, <ValorPoupanca>
	Quando submeto os meus bens para cálculo do imposto
	Então devo obter o valor de imposto equivalente a R$ <ResultadoEsperado>

	Exemplos:
		| TabelaFipe | TipoResidencia | ValorResidencia | ValorInvestimento | ValorPoupanca | ResultadoEsperado |
		| 55500,0    | C              | 300000,0        | 9000,0            | 27000,0       | 5775,0            |
		| 55500,0    | A              | 300000,0        | 9000,0            | 27000,0       | 4275,0            |

Cenario: Verificar se o imposto é calculado corretamente pela API para Residencia tipo A
	Dado que tenho os seguintes bens
		| TabelaFipe | TipoResidencia | ValorResidencia | ValorInvestimento | ValorPoupanca |
		| 55500      | A              | 300000          | 9000              | 27000         |
	Quando submeto os meus bens para cálculo do imposto
	Então devo obter o valor de imposto equivalente a R$ 4275,00

Cenario: Verificar se o imposto é calculado corretamente pela API para Residencia tipo C
	Dado que tenho os seguintes bens
		| TabelaFipe | TipoResidencia | ValorResidencia | ValorInvestimento | ValorPoupanca |
		| 55500      | C              | 300000          | 9000              | 27000         |
	Quando submeto os meus bens para cálculo do imposto
	Então devo obter o valor de imposto equivalente a R$ 5775,00