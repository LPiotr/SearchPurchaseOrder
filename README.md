[![Codacy Badge](https://app.codacy.com/project/badge/Grade/9d62951e6c1140bd9b8f6e68b20d0a2f)](https://app.codacy.com/gh/LPiotr/SearchPurchaseOrder/dashboard?utm_source=gh&utm_medium=referral&utm_content=&utm_campaign=Badge_grade)

Stwórz REST API w NET 6 zawierające jedną metodę służącą do wyszukiwania zamówień zapisanych w pliku w formacie CSV na podstawie przekazanych danych filtrujących

1. Lokalizacja pliku powinna być zapisana w pliku konfiguracyjnym
1. Opis pliku CSV

   1. Struktura pliku:

      0. Pierwszą linią pliku CSV są nagłówki
      1. Separator kolumn: przecinek
      2. Separator części dziesiętnej liczb rzeczywistych: kropka
      3. Format daty: dd.MM.yyyy
      4. Zapis wartości logicznych true/false: 1/0
      5. Dane tekstowe w cudzysłowu
      6. Kodowanie UTF-8

   1. Kolumny

| Nagłówek     | Typ danych         | Wymagane |
| :----------- | :----------------- | :------- |
| Number       | Tekst              | Tak      |
| ClientCode   | Tekst              | Tak      |
| ClientName   | Tekst              | Tak      |
| OrderDate    | Data               | Tak      |
| ShipmentDate | Data               | Nie      |
| Quantity     | Liczba całkowita   | Tak      |
| Confirmed    | Wartość logiczna   | Tak      |
| Value        | Liczba rzeczywista | Tak      |

1. Możliwe warunki które ma obsłużyć API
   1. Numer zamówienia
   1. Data zamówienia w postaci zakresu od do
   1. Kod klienta w postaci listy
1. Ma być możliwe przekazanie dowolnej liczby warunków
1. API powinno być przygotowane z wykorzystaniem wzorców projektowych Dependency Injection i Mediator

1. Lista wyszukanych zamówień powinna być zwrócona w formacie json i zawierać wszystkie dane odfiltrowanych zamówień z pliku

1. Kod powinien być napisany w sposób umożliwiający pokrycie go testami
