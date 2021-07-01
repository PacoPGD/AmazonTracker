# Getting started
  You will need to have .net 5.0 installed and execute BuildAndRun.bat in CollectReview.API/ExposeReview.API
  
# Technical decisions
- Web scraping vs External API\
  I preferred to use an external API to maintain (backwards and forward) compatibility with Amazon reviews contract.
  The web scraping is a not a technique adapted in this scenario as it can makes the code more fragile and could introduce breaking change.
  
- Relational vs Nosql database\
  I used CosmosDB as a non-relational database because it is an application that will work with a large volume of data.
  Moreover, it is supported by Microsoft and compatible with C# /.NET.
 
- Pattern repository\
  I have used the pattern repository to abstract database layer and easier to work with data models.
  Also, it is a good practice for testing as tests rely on abstraction.
  
# Potential improvements
- Use a key store such as Microsoft KeyVault so that database connection keys, APIs, etc. are not visible to potential attackers.
- Change to Premiun version for Amazon API and CosmosDB because right now it's the basic version with a limitation of 50 calls and cosmosDB free also have limitations.
- Create a user interface to start and manage the service
- Increase the code coverage (as it is a POC, minimal tests have been created)
- Create Nonfunctional Requirements (NFRs) for performance improvements
- Add some paging for APIs

# Testing
- I created the project structure to cover implementation with unit test (for example, to cover the logic by ensuring the containers methods are called inside the repository methods) and integration tests to ensure the persistence is working. However, this part is not completed by lack of time and also because it was not a requirement.
- An improvement would be to rollback in teardown so that it is not needed to manually delete the item in the test, however it would require an important amount of work to implement with Azure Cosmos DB
- Another improvement could be to create a builder instead of reading a json file (test.json) as it relies on file system layer

# Overview
- Example query -> B01FXC7JWQ
![CollectReview](https://i.ibb.co/bP1Pk2V/trackreview.png)


- Example query -> select * from table t where t.asin.original='B01FXC7JWQ'
![ExposeReview](https://i.ibb.co/vkw8ysC/exposereview.png)
