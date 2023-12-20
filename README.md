[![Codacy Badge](https://app.codacy.com/project/badge/Grade/9d62951e6c1140bd9b8f6e68b20d0a2f)](https://app.codacy.com/gh/LPiotr/SearchPurchaseOrder/dashboard?utm_source=gh&utm_medium=referral&utm_content=&utm_campaign=Badge_grade)



Create a REST API in NET 6 that includes a single method for searching orders saved in a CSV file based on provided filtering data.

1. The file location should be saved in a configuration file.
2. Description of the CSV file:
	
	a. File Structure:
    - The first line of the CSV file is headers.
	- Column separator: comma.
   	- Decimal separator for real numbers: dot.
	- Date format: dd.MM.yyyy.
	- True/false logical values representation: 1/0.
	- Text data in quotes.
	- UTF-8 encoding.
   
   b. Columns:

|Header | Data Type	| Required |
| :----------- | :----------------- | :------- |
|Number	| Text|	Yes |
|ClientCode	|Text|	Yes |
|ClientName	|Text	|Yes |
|OrderDate |	Date	| Yes |
|ShipmentDate |	Date	| No |
|Quantity |	Integer	 | Yes |
|Confirmed |	Boolean	|Yes |
|Value |	Real Number|	Yes |


3. Possible conditions to be handled by the API:

   1. Order number.
   2. Order date in the form of a range from-to.
   3. Client code in the form of a list.
   4. It should be possible to pass any number of conditions.

4. The API should be prepared using the Dependency Injection and Mediator design patterns.
5. The list of found orders should be returned in json format and include all the data of the filtered orders from the file.
6. The code should be written in a way that allows it to be covered with tests.