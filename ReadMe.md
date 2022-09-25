Overview 
Estore is a simple demo market store , 
which leverages the the uses the fellowing  technology and achitecture 
1. domain driven design 
2. solid principles 
3. clean architecture 
4. docker and containerization 
5. dotnet 6, csharp , mssql database
6. angular 14 


#Build and run with docker compose 
step 1 
docker-compose -f docker-compose-build.yaml build --parallel

step 2 
docker-compose up

once success build of step 1 and project running with step 2 , 
use this url to access both project 

frontend : http://localhost:4200/ 
backend : http://localhost:7010/swagger/index.html 
 
#stop and clean running process 
docker-compose down 
docker image prune --all

Public url 
frontend : https://632f980f0749cc7c21b5b6fd--relaxed-choux-738f05.netlify.app/

backend : https://simple-estore.herokuapp.com/swagger/index.html

