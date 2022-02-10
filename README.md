### Installation and running this solution
Pre-requisite: Docker must be installed.

Option 1: Docker hub
1. Pull image from public repo
```
    docker pull amac1986/nflstatsclient:latest to get the image
```
2. Run the image
```
    docker run -p 5000:80 --name nflstatsclient -d amac1986/nflstatsclient
```
        
Option 2: Github  
1. Clone the repo and build the image:
```
    git clone https://github.com/Amac1986/NFLStatsClient.git
```
2. Build the Docker image
```
    docker build -t amac1986/nflstatsclient:latest -f .\NFLStatsClient\Dockerfile .
```
3. Run the image
```
    docker run -p 5000:80 --name nflstatsclient -d amac1986/nflstatsclient
```



