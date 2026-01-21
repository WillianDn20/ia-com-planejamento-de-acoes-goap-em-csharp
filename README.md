Sistema de Inteligência Artificial com Planejamento de Ações (GOAP) em C#

Este projeto implementa um sistema de Inteligência Artificial baseado em **GOAP (Goal-Oriented Action Planning)**,
onde agentes constroem dinamicamente planos de ações para atingir objetivos, considerando estados do mundo,
pré-condições, efeitos e custo das ações.

O foco está na arquitetura, lógica de decisão e planejamento simbólico.

---

Conceitos Principais

- Planejamento orientado a metas (GOAP)
- Busca em grafo para construção de planos
- Estados do mundo e estados do agente
- Pré-condições e efeitos de ações
- Seleção de plano por menor custo
- Agentes autônomos

---

Como o sistema funciona

1. O agente possui um conjunto de ações possíveis.
2. Cada ação define:
   - Pré-condições
   - Efeitos
   - Custo
3. O planejador (GoapPlanner) constrói um grafo de possibilidades.
4. O plano mais barato que satisfaz a meta é selecionado.
5. As ações são executadas em sequência pelo agente.

---

Mundo Global

O sistema mantém um estado global do ambiente:

- Recursos disponíveis (ex: cubículos)
- Entidades (ex: pacientes)
- Estados compartilhados entre agentes

Implementado via singleton para acesso centralizado.

---

Estrutura dos Scripts

- `GoapPlanner.cs` — algoritmo de planejamento e busca
- `GoapAgent.cs` — controle do agente e execução do plano
- `GoapAction.cs` — definição abstrata de ações
- `GoapWorld.cs` — estados globais do mundo
- `GoapInventory.cs` — inventário do agente

---

Tecnologias e Conceitos

- C#
- Programação Orientada a Objetos
- Inteligência Artificial simbólica
- Planejamento automático (GOAP)
- Estruturas de dados (dicionários, filas, grafos)
- Unity (apenas como ambiente de execução)

---

Objetivo do Projeto

Projeto acadêmico desenvolvido para estudar:

- Sistemas de tomada de decisão
- Planejamento automático
- Arquitetura de IA baseada em metas
- Organização e legibilidade de código

> Observação: este repositório contém apenas os scripts principais, com foco em análise técnica e arquitetural.
