# DesafioModalGR

## O que é
Um projeto feito para o processo seletivo da empresa ModalGR,
composto de 3 partes: um cofre que criptografa senhas, um notificador de aniversariantes
e um programa de emprestimo para quem ja tem mais de 5 anos de casa.

## Utilizacao
```bash
git clone
abrir a pasta que foi descarregada
cd DesafioModalGR
dotnet run
```
ou ainda, git clone no projeto, abrir a solucao pelo visual studio e dar CTRL+F5 para rodar.

## Funcionamento
O cofre (1) tem um funcionamento bem simples, ele possui 3 senhas hardcoded e gera 3 senhas criptografadas,
usando as criptografias DES, 3DES e Rijndael em conjunto com a chave #modalGR#GPTW#top#maiorEmpresaTecnologia#baixadaSantista.

O notificador de aniversariantes (2) funciona a partir de um numero de 1 a 12, representando os
meses do ano, ele além de mostrar os aniversariantes do mês escolhido no terminal, cria um arquivo 
aniversariantes.txt na área de trabalho do computador com as informações dos mesmos.
OBS: ele pega as informações do arquivo MOCK_DATA.csv, que servem de dummy data e estão separadas por |.

O programa de Empréstimo(3) pergunta alguns dados a respeito do usuário, se o empréstimo não ultrapassar
duas vezes o valor do salário, e tiver um valor par, ele será aprovado - contanto que o usuário tenha 
mais de 5 anos de casa.
