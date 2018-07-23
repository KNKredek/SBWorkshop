- title : Service Bus Workshop
- description : Service Bus Workshop
- author : Krystian Kolad
- theme : night
- transition : default

***

## Service Bus Workshop

***

## Komunikacja między różnymi serwisami

---

## Problemy komunikacji:
* niezależność komponentów
* podczas wywoływania metod z innych serwisów:
    * przy zmianie w jednym serwisie, należy zmienić coś w innym
    * brak niezależności
    * przy większej ilości - problemy z SLA(Netflix)

---

## Rozwiązanie?

---

## Komunikacja 
* Events
* Messages
* Commands
* ...

***

## Service bus

---

## O co chodzi?
* Miejsce, w którym wysyłamy wiadomości
* Każdy może te wiadomości zdjąć
* Możliwość wykorzystania wiadomości przez więcej niż jeden komponent

---

## Schemat działania v1

<img src="images/queue.png" style="background: transparent; border-style: none;"  />

---

## Schemat działania v2

<img src="images/queue2.png" style="background: transparent; border-style: none;"  />

***

## Pros & Cons

---

## Pros
* asynchroniczność - jeden event przetwarzany na raz przez kilka serwisów
* brak problemów z SLA
* użytkownik nie musi siedzieć i czekać, aż post się wykona

---

## Cons
* brak pewności wykonania działania
* event może nie zostać obsłużony od razu
* jak obsługiwać błędy?

***

## Demo

***

##Czy wiecie, że...
Każdy z was korzystał z eventów?

---

##Co to?

<img src="images/button.png" style="background: transparent; border-style: none;"  />

---

##A to?

<img src="images/click.jpg" style="background: transparent; border-style: none;"  />

***

## Pytania

***

## Dziękuję za uwagę

***