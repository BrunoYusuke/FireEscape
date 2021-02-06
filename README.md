# FireEscape 
Simulação baseada em jogos de escape room para treinamento de controle ou fuga de incêndio em realidade virtual.
Desenvolvido usando Unity Ver. 2019.3.10f1 .
Builds Para versões Windows e mobile Android disponíveis.
## Projeto Final de Programação

## Documentação

Ficha de Avaliação: [LINK](https://github.com/BrunoYusuke/FireEscape/blob/main/Ficha%20de%20avalia%C3%A7%C3%A3o%20-%20Bruno.pdf)

Relatório: [LINK](https://github.com/BrunoYusuke/FireEscape/blob/main/Projeto%20Final%20de%20Programa%C3%A7%C3%A3o%20-%20Documenta%C3%A7%C3%A3o.pdf)

Documentação gerada por Doxygen: [LINK](https://github.com/BrunoYusuke/FireEscape/tree/main/Docs/html)
- **Abrir arquivo 'index.html' após baixar o projeto.**

Código Fonte: [LINK](https://github.com/BrunoYusuke/FireEscape/tree/main/Assets/Scripts)
- **Procure por arquivos com extensão '.cs' para leitura.**

Executável Windows: [LINK](https://github.com/BrunoYusuke/FireEscape/tree/main/FireEscape_Windows_Build)

Instalador Android: [LINK](https://github.com/BrunoYusuke/FireEscape/tree/main/FireEscape_Android_Build)

# Manual do Usuário

Escrito para sanar dúvidas pertinentes ao projeto.

## Requisitos de Sistema

Para Windows:
- Windows 10, 64 bits.
- CPU: arquitetura x86, x64 e suporte para instruções SSE2. Intel ou AMD.
- API Gráfica: versões DX10, DX11, DX12.

Para Android:
- Sistemas Android 5.0+
- CPU: ARMv7 with Neon Support (32-bit) or ARM64.
- API Gráfica: OpenGL ES 2.0+, OpenGL ES 3.0+, Vulkan.
- Memória RAM: Recomendado acima de 1GB.

## Como executar o simulador em ambiente **Windows**

1. Baixar o projeto.
2. Acessar o diretório 'FireEscape_Windows_Build'.
3. Executar 'ProjectVR.exe'.

## Como executar o simulador em mobile **Android**
OBS: **Caso seja imprático de executar o simulador em dispositivo móvel. Opte pela versão em ambiente Windows.**

1. Baixar o projeto.
2. Acessar o diretório 'FireEscape_Android_Build'.
3. Extrair arquivo 'Fireescape_android.apk'.
4. Conectar smartphone Android no computador via USB.
5. Copiar arquivo 'Fireescape_android.apk' em alguma pasta de fácil acesso no dispositívo.
6. No dispositivo, utilizar algum 'explorador de arquivos' ou 'gerenciador de arquivos' e localizar o arquivo 'Fireescape_android.apk' dentro do dispositivo móvel.
7. Instalar ou Abrir arquivo via 'gerenciador de arquivos'.
8. Um aviso será notificado, avisando que o pacote a ser executado é de fonte desconhecida. Dependendo do dispositivo, poderá ser necessário realizar os passos a seguir:
  - Caso haja uma opção para executar o pacote apesar do aviso. Execute o pacote.
    - Um icone do simulador chamado 'ProjectVR' deve aparecer na tela home do dispositivo. Abra-o e o simulador executará.

  - Caso o sistema bloqueie a instalação de pacotes por fontes desconhecidas. Vá até as configurações do dispositivo e busque por alguma opção que bloqueie instalação de 'apk' por fontes externas ou desconhecidas. Tente procurar pela palavra chave 'apk' na barra de pesquisa em configurações.
    - Habilite a instalação de 'apk' de fontes desconhecidas ou externas.
    - Repita o passo 6 e 7. Permita da instalação do pacote.
    - Um icone do simulador chamado 'ProjectVR' deve aparecer na tela home do dispositivo. Abra-o e o simulador executará.

## Considerações Importantes

1. Optou-se por gerar duas builds do projeto, pelo fato da instalação do simulador em ambiente Android podendo não ser trivial. No entanto, não existem diferenças significativas entre ambas aplicações de ambientes diferentes. Uma diferença a ser notada seria a movimentação da visão na versão Windows, que ao invés de utilizar um smartphone, utiliza-se o Mouse.

2. Como mencionado no relatório, não é obrigatório o uso de um óculos de realidade aumentada caso a versão executada seja Android.

3. Esta versão do simulador conta apenas com um cenário doméstico.

## Controles 

1. Como Navegar:
  - A navegação pela cena é realizada pelas setas flutuantes espalhadas pelo cenário. Basta focar a câmera na seta e em instantes ocorrerá a locomoção para aquele espaço.

2. Pegar um objeto:
  - Para ter posse de algum objeto, basta focar a câmera no objeto. Um som indicará que o objeto está visualmente em suas mãos. Para soltar o objeto, basta um toque na tela do smartphone ou um clique.
  
3. Interação entre objetos em chama:
  - Ao ter posse de algum objeto, caso exista alguma interação do objeto em mãos com algum objeto que represente perigo, basta soltar o utensílio próximo ao objeto de risco.
