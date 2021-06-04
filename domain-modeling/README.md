https://demo.hedgedoc.org/Ajdu2r7tQfqkKDinewx24w?both#

# Book club : Domain Modeling Made Functional Domain Driven
https://www.amazon.fr/Domain-Modeling-Made-Functional-Domain-Driven/dp/1680502549

### 2021-05-03
Premiers objectifs :
- lire la préface pour mercredi

### 2021-05-05
Sur la préface, pas grand chose à dire sauf que ça donne envie de lire la suite.
Bastien a suivi la formation de Scott Wlaschinn correspondant au livre. Lien vers le gist correspondant à sa formation : https://gist.github.com/swlaschin/01b03f737348e7dc34f16afc752b2937
- lire le premier chapitre pour vendredi

### 2021-05-07
*Objectif : Lire le chapitre 1*
Introduction efficace à DDD et Event Storming mais quelques raccourcis ou simplifications semblent masquer la complexité de ces pratiques.

Pierrick aussi a fait la formation de Scott !

### 2021-05-10

*Objectif : Lire le chapitre 2 - Understanding the Domain*

- Toujours aussi clair, explore des chemins "techniques" (BDD, OOP) en montrant les problèmes potentiels
    - assez bref mais pédagogique
- learn by mistake -> "caricatural", assez rigolo, peu être un peu frustrant mais très bien expliqué
- pseudo-langage utilisé pour capturer les "requirements" => très peu d'impedance mismatch avec le code
    - du mal à lire? un peu lourd? plus simple avec un diagramme box and arrows
    - un mi-chemin entre la simplification box/arrow et les détails du code OO ou ER
- schémas input/output -> proche représentation d'une fonction, assez limpide, visualise les dépendances "cachées" et les "effets de bord"
- citation "des semaines des dev peuvent éviter des heures de planification"
- primitive obsession -> "c'est un float !"
- dialogues convaincants, bien écrits, évite des lourdeurs sur la forme 
- très didactique -> montre ce que donnerait telle ou telle approche, plutôt que de dire "ne faites pas"
- est-ce que l'approche est simplifiée ?
- y-a-t'il encore des organisations qui utilisent du papier? 
    - oui! 
    - plutôt rare dans les grosses orgas, dans le monde des artisans, ils ont des notes et un carnet (même pas Excel), besoin d'automatisation (?!)
- gérer la complexité du domaine
    - remettre à plus tard certains détails -> '?' dans le code

### 2021-05-12

> lire ch.3

- le retour du C4 "si tu parles pas de C4 en 2021 t'as raté ta vie"
    - ce serait cool de se faire un atelier
    - on peut utiliser plantUML pour faire du C4: https://github.com/plantuml-stdlib/C4-PlantUML
- il insiste sur le contexte, et notamment sur les contrats entre BCs

- C'est bien de montrer les différents types de contrats qui peuvent exister mais il n'explique pas comment il fait ses choix.
    - --> https://github.com/ddd-crew/context-mapping
- "Parse don't validate" -> https://lexi-lambda.github.io/blog/2019/11/05/parse-don-t-validate/
- discussion sur "qu'est ce qu'un shared kernel ?"
    - technos compatibles?
- structure en oignons, repousser les IOs aux limites
    - ça semble difficile à faire en pratique
    - "workflow" c'est un truc plus petit que ce qu'on en pense -> c'est une fonction avec une responsabilité unique
    - voir ch. suivant sur le railway programming
    - très dépendant de la manière dont on définit les agrégats
- Question sur les événements liés à chaque BC (Avoid Domain Events Within a Bounded Context): Est-ce vraiment une bonne idée qu'un workflow *(bounded context?)* (ex:PlaceOrder) produise des événements spécifiques (ex:OrderAcknowledgmentSent, OrderPlaced, BillableOrderPlaced) **à destination** des autres workflows *(bounded contexts)* (ex:Shipping, Billing, etc.)?
- re-discussion sur le "Shared kernel"
    - design vs. techno (code concret)
    - ex. du Price
    - le DTO c'est un contrat de communication, pas nécessairement un format technique/binaire/textuel
    - le shared kernel est-il sur le domaine ou sur la communication entre BCs ? -> **sur le domaine**, cf. http://ddd.fed.wiki.org/view/shared-kernel 


### 2021-05-17

> lire ch.4

- Arnaud n'a pas appris grand chose :smile:, c'est un chapitre d'introduction sur le langage.
- Il y a une opposition FP valeur VS OO objet que Seb ne comprend pas très bien, mais Arnaud explique qu'en FP statiquement typé, le type n'existe qu'à la compilation et disparait au runtime et que cela représente une différence fondamentale.
- En F#, le unit est une indication qu'il y a des effets de bord mais ça peut être caché contrairement au type (monade) IO d'Haskell qui contraint et contamine les fonctions utilisatrices.

Exercices correspondants :
- 01 et 02 - https://github.com/swlaschin/DDDEU_DMMF/tree/master/src/B-PrinciplesOfFp
- Série des exercices 03 - https://github.com/swlaschin/DDDEU_DMMF/tree/master/src/D-DomainModelingWithTypes


### 2021-05-19

> Lire Chapitre 5

- F# est assez léger à prendre en main.
- L'auteur cache un peu sous le tapis un sujet qui nous semble tout de même important : Comment gère-t-on les problématiques de génération d'identifiants pour les entités?
- Idée de NoEquality intéressante (en Haskell, même pas besoin d'un attribut, c'est le cas par défaut)
- On est surpris par le fait qu'un OrderLine (dans le code final) contienne un OrderId. Pourquoi ça ?

Exercices associés:
- Un peu de ceux du Workflow (valable pour les chapitres suivants) : https://github.com/swlaschin/DDDEU_DMMF/tree/master/src/F-ImplementingWorkflows


### 2021-05-21

> Lire Chapitre 6

Arnaud nous fait une démo du pouvoir des types avec les types fantomes :ghost:.


"Making impossible states irrepresentable" - références:
- Conf de Scott : https://fsharpforfunandprofit.com/ddd/
- Conf de Richard Feldman (en Elm) : https://www.youtube.com/watch?v=x1FU3e0sT1I


### 2021-05-26

> Lire Chapitre 7

- chapitre assez long, pas toujours compris les choix faits mais probablement justifiés par l'objectif didactique
- modèle mental POO très ancré, problème avec le pattern-matching : ça ressemble à un switch-case, en objet on aurait utilisé l'héritage et le polymorphisme pour _encapsuler_ le traitement dans l'objet
    - pattern-matching = switch-case "survitaminé"
    - on a tendance à faire des fonctions totales en FP
    - en TS on a des _discriminated unions_ qui peuvent être automatiquement transformées en _interface_ par l'IDE
- https://wiki.c2.com/?ExpressionProblem
- exemple des _Lens_ en FP : si on veut s'abstraire de la structure concrète des données qu'on manipule, il faut passer par des fonctions (cf. _All patterns are functions_)
- choix d'explicitation des dépendances injectées, pas tout à fait d'accord sur le fait d'encapsuler les dépendances?
    - trop catégorique?
    - en fait, on va exposer uniquement les dépendances signifiantes pour le métier
- c'est un peu YAGNI de rendre la _Command_ générique tout de suite, ça serait plus pertinent de l'amener plus tard quand on introduit une deuxième commande 

### 2021-05-28

> Lire Chapitre 8

- Un chapitre globalement de bonne qualité sur les basiques mais qui n'apportera pas grand chose lorsqu'on a un minimum de connaissance de F#.

Recommandation pour la suite : Prendre le temps de lire le GitHub

Repo BenderLabs (exemple) : https://github.com/bender-labs/wrap-signer
F# and typescript : http://tpetricek.github.io/Talks/2020/typescript-fsharp-zealots/#/

### 2021-05-31

> Lire Chapitre 9 jusqu'à "Composing the Pipeline Steps Together" exclu
> dernière phrase "For example, in the next chapter we'll use it to deal with mismatch between different kinds of Result types" (p177 dans le livre)

- contenu pas très difficile, toujours aussi clair
- pourquoi écrire le type avant le code?
    - comme une documentation, ou un "test" en mode TDD
- patterns de refactoring?
    - pas vraiment, tout est fonction
    - utiliser les interfaces de la lib standard

La vidéo où l'on voit du refacto https://www.youtube.com/watch?v=FITJMJjASUs

### 2021-06-02

> Finir le chapitre 9

- on est que deux (et demi), est-ce le bon créneau horaire ?
- ce serait bien de trouver du temps pour coder le truc parce qu'on décroche, il y a trop de code et juste lire du code c'est pas top
    - => créer un repo partagé
- un peu gêné par les simplifications à répétitions
    - éviter les monades, les free monades, les async
    - un seul exemple de test U qui arrive comme un cheveu sur la soupe
- trop de code... ?
    - il faut suivre avec le repo sous la main
- => **une seule séance par semaine** pour avoir le temps de coder
    - une séance plus technique/codage
    - une séance papote/lecture/retro/planning/sprint demo
- discussion sur l'injection de dépendances en FP

### 2021-06-04

> Finir le chapitre 9 (encore) 
:wink: 

Les requirements deduit du chapitre 2 - https://discord.com/channels/737596349435871264/765961307139735582/850269382747357184




