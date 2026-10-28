# Central de Atendimento

Solução em C# Windows Forms baseada no exercício de filas (`Queue<T>`).

## Funcionalidades

- Gerar senhas numeradas a partir de 1.
- Cadastrar um ou vários guichês.
- Selecionar um guichê e chamar a próxima senha.
- Exibir as senhas que ainda aguardam atendimento.
- Exibir o histórico de atendimentos agrupado por guichê.
- Registrar data e hora de geração e de atendimento.

## Como executar

1. Abra `CentralAtendimento.sln` no Visual Studio em um ambiente Windows com suporte ao .NET Framework 4.7.2.
2. Compile a solução.
3. Execute o projeto `CentralAtendimento`.
4. Cadastre os guichês, gere algumas senhas e use o campo `Guichê` para realizar os chamados.

## Regras principais

- A fila central é uma `Queue<Senha>`.
- `Enqueue()` coloca uma senha no final da fila.
- `Dequeue()` retira sempre a senha mais antiga.
- Uma chamada bem-sucedida remove a senha da fila central, registra o atendimento e coloca a senha no histórico do guichê.
- Uma chamada sem senhas disponíveis retorna falha e não altera nenhum histórico.
