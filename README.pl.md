[![Codacy Badge](https://app.codacy.com/project/badge/Grade/9d62951e6c1140bd9b8f6e68b20d0a2f)](https://app.codacy.com/gh/LPiotr/SearchPurchaseOrder/dashboard?utm_source=gh&utm_medium=referral&utm_content=&utm_campaign=Badge_grade)


	Stwórz REST API w NET 6 zawierające jedną metodę służącą do wyszukiwania zamówień zapisanych w pliku w formacie CSV na podstawie przekazanych danych filtrujących.

1.  Lokalizacja pliku powinna być zapisana w pliku konfiguracyjnym
2.  Opis pliku CSV
	1. Struktura pliku:
      	- Pierwszą linią pliku CSV są nagłówki
     	- Separator kolumn: przecinek
      	- Separator części dziesiętnej liczb rzeczywistych: kropka
      	- Format daty: dd.MM.yyyy
      	- Zapis wartości logicznych true/false: 1/0
      	- Dane tekstowe w cudzysłowu
      	- Kodowanie UTF-8
	2. Kolumny

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
 
3. Możliwe warunki które ma obsłużyć API
   1. Numer zamówienia
   1. Data zamówienia w postaci zakresu od do
   1. Kod klienta w postaci listy
1. Ma być możliwe przekazanie dowolnej liczby warunków
1. API powinno być przygotowane z wykorzystaniem wzorców projektowych Dependency Injection i Mediator

1. Lista wyszukanych zamówień powinna być zwrócona w formacie json i zawierać wszystkie dane odfiltrowanych zamówień z pliku

1. Kod powinien być napisany w sposób umożliwiający pokrycie go testami
