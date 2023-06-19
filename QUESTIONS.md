# Questões:

## 1 - Como você implementou a função que retorna a representação por extenso do número no desafio 1? Quais foram os principais desafios encontrados?

Eu comecei a implementação identificando os números que possuem nomes únicos (0 até 19). Usando uma estrutura de dados de acesso rápido que pudesse ser indexada com o valor do número em que a representação por extenso representa (Dictionary), ficou fácil retornar o número buscando apenas pela chave.

Os negativos vieram na sequência com uma chamada recursiva para a mesma função concatenando a palavra "menos" e passando o mesmo número como parâmetro, porém usando a função de número absoluto para que o sinal fosse desprezado.

Após isso, os números de 20 até 99 tem nomes únicos para as dezenas e reutilizam os valores já presentes no Dictionary para as unidades. Nessa etapa o código era basicamente apenas o que hoje é a função privada "GetTensAndOnesWords".

O próximo passo era aumentar o algoritmo para suportar números até 999. Aqui foi a parte que deu mais trabalho de implementar, pois a escrita na primeira centena muda. Ex: 100 = "cem", 101 = "cento e um". O algoritmo precisava identificar quando usar "cem" ou "cento". Até aqui, basicamente o algoritmo era a função "GetTensAndOnesWords" e a "GetHundredsWords".

O último passo foi implementar milhares, milhões e bilhões. É possível obter a centena de qualquer milhar através de uma operação de resto de divisão por 1000. Dessa forma, foi possível processar a centena e controlar a potência de 10 sendo utilizada no momento através de um loop "for" que incrementa uma flag toda vez que a operação de resto de divisão por 1000 acontece. Dentro desse loop, o número vai sendo dividido por 1000, fazendo com que ele vá diminuindo. 
Ex: 1.500.500 % 1000 = 500. 
Esse 500 é processado e o texto é armazenado. 
Então 1.500.500 é divido por 1000 e armazenado de volta na sua varíavel int, o que despreza o componente após a vírgula do número e o torna 1.500.
Como o loop está na segunda iteração, ao processar o próximo 500, o algoritmo entende que são 500 mil e não 500.

Esse problema foi bem divertido de resolver, mas também foi bem desafiador. Implementações que retornam "cem e um mil" ao invés de "cento e um mil" para o número 101.000, ou "mil duzentos" ao invés de "mil e duzentos" para o número 1200, são comuns. Algumas flags foram inseridas no loop justamente para identificar esses erros e evitar a escrita incorreta.

Por fim, eu decidi tornar a class estática. Uma vez que a classe não precisa se comportar de forma diferente de acordo com dependências ou parâmetros, a implementação se torna muito semelhante aos métodos estáticos de "Math", como "Pow" ou "Abs", ou mesmo à implementação estática da serialização de "JsonSerializer".

## Como você lidou com a performance na implementação do desafio 2, considerando que o array pode ter até 1 milhão de números?

O algoritmo implementado usa processamento paralelo para otimizar o máximo possível o tempo de execução. Além do problema de performance, overflows podem acontecer quando a soma ultrapassa os limites dos tipos inteiros do .Net. Para isso, foi utilizado um mecanismo de soma parcial usando "long" e soma final usando "BigInteger", cuja a única limitação possível é a quantidade de memória utilizada na alocação. Para evitar OutOfMemoryExceptions, o algoritmo protege a soma com uma estrutura try e retorna um erro caso não haja memória suficiente para a alocação do "BigInteger". 

Com relação à soma parcial e ao processamento paralelo, threads diferentes poderiam acessar a variável de soma parcial (long) ao mesmo tempo e comprometer o resultado. Para evitar isso, um mecanismo de locking foi utilizado. Outro problema é que somas maiores que um long.MaxValue não geram erro por padrão. Elas apenas sujam a alocação de memória da variável. Para evitar isso, um mecanismo de "checking" foi utilizado. Ele força uma OverflowException quando houver.

## Como você implementou a função que remove objetos repetidos na implementação do desafio 4? Quais foram os principais desafios encontrados?

A função foi implementada como um método de extensão para qualquer implementação genérica de IList. Na implementação um hashset é utilizado. O Hashset é uma estrtura de dados de alta performance que não permite itens duplicados. Após o hashset ser instanciado, ele é convertido novamente numa lista genérica e retornado.

A princípio eu havia considerado percorrer a lista e adicionar a uma segunda caso o item não estivesse nesta segunda. Dessa forma, o algoritmo não adicionaria os duplicados pois a verificação da segunda lista não permitiria. 
Sabendo da existência do Hashset, fica mais fácil utilizar uma coleção de alta performance pré-existente no framework.