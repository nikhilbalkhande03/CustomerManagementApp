2. REST server
A small REST server with good performance for simple customer management has two functions:
•	POST customers
Request:
[
	  {
		 firstName: 'Aaaa',
		 lastName: 'Bbbb',
		 age: 20,
		 id: 5
	  },
	  {
		 firstName: 'Bbbb',
		 lastName: 'Cccc',
		 age: 24,
		 id: 6
	  }
]
Multiple customers can be sent in one request.
The server validates every customer of the request:
•	checks that every field is supplied
•	validates that the age is above 18
•	validates that the ID has not been used before
The server then adds each customer as an object to an internal array – the customers will not be appended to the array but instead it will be inserted at a position so that the customers are sorted by last name and then first name WITHOUT using any available sorting functionality (an example for the inserting is in the Appendix).
The server also persists the array so it will be still available after a restart of the server.
•	GET customers
Returns the array of customers with all fields
Write the server and a small simulator which can send several requests for POST customers and GET customers in parallel to the server.
For that program it is not allowed to use any sorting mechanism like array.sort().
The simulated POST customers requests have following requirements:
•	Each request should contain at least 2 different customers
•	Age should be randomized between 10 and 90
•	ID should be increasing sequentially.
•	The first names and last names of the Appendix should be used in random combinations



Appendix:
Data:
First names:					Last names:
Leia						Liberty
Sadie						Ray
Jose						Harrison
Sara						Ronan
Frank						Drew
Dewey						Powell
Tomas						Larsen
Joel						Chan
Lukas						Anderson
Carlos						Lane
Example for the inserting mechanism:
Array in server:
[
{ lastName: 'Aaaa', firstName: 'Aaaa', age: 20, id: 3 },
{ lastName: 'Aaaa', firstName: 'Bbbb', age: 56, id: 2 },
{ lastName: 'Cccc', firstName: 'Aaaa', age: 32, id: 5 },
{ lastName: 'Cccc', firstName: 'Bbbb', age: 50, id: 1 },
{ lastName: 'Dddd', firstName: 'Aaaa', age: 70, id: 4 },
]
Request POST customers:
[{ lastName: 'Bbbb', firstName: 'Bbbb', age: 26, id: 6 }]
Array after insert:
[
{ lastName: 'Aaaa', firstName: 'Aaaa', age: 20, id: 3 },
{ lastName: 'Aaaa', firstName: 'Bbbb', age: 56, id: 2 },
{ lastName: 'Bbbb', firstName: 'Bbbb', age: 26, id: 6 },
{ lastName: 'Cccc', firstName: 'Aaaa', age: 32, id: 5 },
{ lastName: 'Cccc', firstName: 'Bbbb', age: 50, id: 1 },
{ lastName: 'Dddd', firstName: 'Aaaa', age: 70, id: 4 },
]
Request POST customers:
[{ lastName: 'Bbbb', firstName: 'Aaaa', age: 28, id: 7 }]
Array after insert:
[
{ lastName: 'Aaaa', firstName: 'Aaaa', age: 20, id: 3 },
{ lastName: 'Aaaa', firstName: 'Bbbb', age: 56, id: 2 },
{ lastName: 'Bbbb', firstName: 'Aaaa', age: 28, id: 7 },
{ lastName: 'Bbbb', firstName: 'Bbbb', age: 26, id: 6 },
{ lastName: 'Cccc', firstName: 'Aaaa', age: 32, id: 5 },
{ lastName: 'Cccc', firstName: 'Bbbb', age: 50, id: 1 },
{ lastName: 'Dddd', firstName: 'Aaaa', age: 70, id: 4 },
]
