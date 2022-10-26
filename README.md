# SistemaUniversidad
Fullstack project


There is a Postmant file with the structure of every controller with its respective calls inside the UniversidadSophosApi folder

To initialize the project do the following

## Database

1. Create a MySql database.

2. Populate it with the script supplied in the root folder of the project.




## Backend


1. Open Visual Studio Community and open the file with the name UniversidadSophosApi.sln under the path ../SistemaUniversidad/UniversidadSophosApi/UniversidadSophosApi.sln

Change the connection string, in order to change it do this

2. Go to the file appsettings.json  under the path  ../SistemaUniversidad/UniversidadSophosApi/UniversidadSophosApi/appsettings.json
 change the Data Source with your database server name. 
![image](https://user-images.githubusercontent.com/47578270/198074298-137fce2d-dfd8-4388-b557-5907a498636a.png)


3. Execute it, wait a couple of seconds and the API should be up an running

## Frontend
To start the Frontend

1. Open visual Studio code 

2. Open the project folder,
Make sure you are in the main folder ../SistemaUniversidad

Then do the following in the terminal-

3. cd frontuniversidadsophos/

![image](https://user-images.githubusercontent.com/47578270/198081017-84fe6f13-5475-4fc5-8958-e87310d4da4c.png)


Now install the node modules with THIS command

4. npm install --legacy-peer-deps

![image](https://user-images.githubusercontent.com/47578270/198081129-3284d9dd-13eb-441c-8f36-48e2396af9b9.png)


After it is done installing

5. npm start

It will automatically open the localhost.


